using FilPasRougeExemple.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Services
{
	/// <summary>
	/// Fichier de test d'une interface.
	/// Ecrire un test unitaire pour une interface peut sembler étonnant, dans la mesure
	/// où une interface n'est qu'un contrat et n'a pas de code.
	/// 
	/// Pourtant, c'est justement très utile ! En effet, en testant une interface,
	/// on s'abstrait complètement des implémentations, et on s'assure ainsi que les différentes
	/// implémentations auront un comportement testé identique.
	/// 
	/// De plus, dans le cas où on teste plusieurs implémentations, le code de test
	/// n'est écrit qu'une seule fois !
	/// 
	/// Notez bien que la classe IFileSystemTest est ici défini comme abstract, et définie
	/// une propriété FileSystem de type IFileSystem. C'est l'objet contenu dans cette propriété
	/// qui va être testé.
	/// 
	/// Il faudra donc dériver la classe IFileSystemTest autant de fois qu'il y a d'implémentations
	/// différentes. Dans chacune des implémentations, il n'y aura qu'à implémenter la propriétés FileSystem.
	/// </summary>
	public abstract class IFileSystemTest
	{
		/// <summary>
		/// C'est cette propriété qui va être utilisée pour récupérer 
		/// l'objet (et donc l'implémentation) à tester
		/// </summary>
		public abstract IFileSystem FileSystem { get; }

		[TestMethod]
		public void CheckIfExists()
		{
			// arrange
			string tempFileName = Path.GetTempFileName();

			// act
			bool fileExist = this.FileSystem.Exists(tempFileName);
			File.Delete(tempFileName);

			// assert
			Assert.IsTrue(fileExist);
		}

		[TestMethod]
		public void CheckIfNotExists()
		{
			// arrange
			// act
			bool fileExist = this.FileSystem.Exists(@"C:\nom_dun_fichier_qui_nexiste_pas_enfin_jespere.xyz");

			// assert
			Assert.IsFalse(fileExist);
		}

		[TestMethod]
		public void CheckCreateDirectory()
		{
			// arrange
			string path = Path.GetTempFileName();
			File.Delete(path);
			bool exists;

			// act
			exists = Directory.Exists(path);
			if (exists)
			{
				Assert.Inconclusive("Impossible de créer le répertoire car il existe déjà");
			}
			this.FileSystem.CreateDirectory(path);
			exists = Directory.Exists(path);
			Directory.Delete(path);

			// assert
			Assert.IsTrue(exists);
		}
	}
}
