using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace FilPasRougeExemple.Utils
{
    /// <summary>
    /// Gestion de la cryptographie
    /// </summary>
    /// <remarks>
    /// Le contenu chiffré va contenir plusieurs informations
    /// <list type="bullet">
    /// <item>[clair] 1 octet : numéro de version</item>
    /// <item>[clair] 16 octets : le vecteur d'initialisation</item>
    /// <item>[chiffré] 32 octets : la signature (un hash du contenu original)</item>
    /// <item>[chiffré] le reste : le contenu</item>
    /// </list>
    /// 
    /// Le numéro de version sera utilisée en cas d'évolution de l'algorithme. 
    /// Par exemple, si une faille est découverte, on pourra changer de versio nde donc 
    /// d'algorithme de chiffrement
    /// 
    /// Le vecteur d'initialisation est le "sel" utilisé lors du chiffrement.
    /// 
    /// La signature permettra de s'assurer que les données n'ont pas été corrompues.
    /// 
    /// Le chiffrement va donc consister à réaliser les étapes suivantes :
    /// <list type="bullet">
    /// <item>écrire 1</item>
    /// <item>écrire les 16 octets du vecteur d'initialisation</item>
    /// <item>commencer le chiffrement</item>
    /// <item>écrire les 32 octets du hash</item>
    /// <item>écrire les octets du contenu à chiffrer</item>
    /// <item>terminer le chiffrement</item>
    /// </list>
    /// 
    /// Le déchiffrement va suivre les étades presques dans le même ordre :
    /// <list type="bullet">
    /// <item>lire le numéro de version. Si c'est à 1, on continue</item>
    /// <item>lire les 16 octets du numéro de version</item>
    /// <item>commencer le déchiffrement, en utilisant le vecteur d'initialisation récupéré
    ///     à l'étape précédente</item>
    /// <item>lire les 32 octets du hash</item>
    /// <item>lire le reste du message</item>
    /// <item>calculer le hash du message lu à l'étape précédente</item>
    /// <item>vérifier que les hashs correspondent.</item>
    /// </list>
    /// 
    /// La méthode retenue pour le calcul du hash est le SHA256.
    /// </remarks>
    public class AesCryptography
    {   
        /// <summary>
        /// Génère une nouvelle clé de chiffrement pour 
        /// être utilisée avec l'algorithme Aes.
        /// </summary>
        /// <returns>Nouvelle clé de chiffrement</returns>
        public static byte[] GenerateKey()
		{
            using (Aes aes = Aes.Create())
			{
                aes.GenerateKey();
                return aes.Key;
			}
        }

        /// <summary>
        /// Chiffre un contenu avec la clé passée en paramètre.
        /// 
        /// L'algorithme utilisée est AES en mode CBC
        /// </summary>
        /// <param name="plainContent">Contenu à chiffrer</param>
        /// <param name="key">Clé de chiffrement</param>
        /// <returns>Contenu chiffré</returns>       
        public static byte[] EncryptWithAes(byte[] plainContent, byte[] key)
        {
            if (plainContent == null || plainContent.Length == 0) { throw new ArgumentNullException("plainText"); }
            if (key == null || key.Length == 0) { throw new ArgumentNullException("key"); }

            byte[] encrypted;
            using (Aes aes = Aes.Create())
            using (SHA256 sha256 = SHA256.Create())
            {
                ICryptoTransform encryptor;
                byte[] signature = sha256.ComputeHash(plainContent);

                aes.GenerateIV();
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                if (aes.IV == null || aes.IV.Length != 16)
                {
                    throw new Exception("Invalid initialization vector");
                }

                encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    memoryStream.Write(aes.IV, 0, aes.IV.Length);
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        cryptoStream.WriteByte(1);
                        cryptoStream.Write(signature, 0, signature.Length);
                        cryptoStream.Write(plainContent, 0, plainContent.Length);
                    }

                    encrypted = memoryStream.ToArray();
                }
            }

            return encrypted;
        }

        /// <summary>
        /// Déchiffre un contenu avec la clé passée en paramètre.
        /// 
        /// L'algorithme utilisée est AES en mode CBC
        /// </summary>
        /// <param name="plainContent">Contenu à déchiffrer</param>
        /// <param name="key">Clé de chiffrement</param>
        /// <returns>Contenu en clair</returns>
        public static byte[] DecryptWithAes(byte[] cipherText, byte[] key)
        {
            if (cipherText == null || cipherText.Length == 0) { throw new ArgumentNullException("cipherText"); }
            if (key == null || key.Length == 0) { throw new ArgumentNullException("Key"); }

            byte[] plainContent = null;

            using (SHA256 sha256 = SHA256.Create())
            using (Aes aes = Aes.Create())
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                byte[] initializationVector = new byte[16];
                ICryptoTransform decryptor;

                msDecrypt.Read(initializationVector, 0, initializationVector.Length);
                aes.Mode = CipherMode.CBC;
                aes.Key = key;
                aes.IV = initializationVector;

                decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream outputDecrypt = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        int hashAlgorithm = cryptoStream.ReadByte();

                        if (hashAlgorithm == 1)
                        {
                            byte[] signature = new byte[32];
                            byte[] computedSignature;

                            cryptoStream.Read(signature, 0, 32);
                            cryptoStream.CopyTo(outputDecrypt);
                            plainContent = outputDecrypt.ToArray();
                            computedSignature = sha256.ComputeHash(plainContent);

                            if (!CompareByteArray(computedSignature, signature))
                            {
                                throw new Exception("Corrupted data");
                            }
                        }
                    }
                }

            }

            return plainContent;
        }

        /// <summary>
        /// Compare deux tableaux de bytes.
        /// </summary>
        /// <param name="array1">Premier tableau</param>
        /// <param name="array2">Second tableau</param>
        /// <returns>true si les tableaux contiennent des données identiques, false sinon</returns>
        private static bool CompareByteArray(byte[] array1, byte[] array2)
        {
            if (array1 == array2) { return true; }
            if (array1 == null && array2 != null) { return false; }
            if (array1 != null && array2 == null) { return false; }
            if (array1.Length != array2.Length) { return false; }

            for (int i = 0; i < array1.Length; ++i)
            {
                if (array1[i] != array2[i]) { return false; }
            }

            return true;
        }
    }
}
