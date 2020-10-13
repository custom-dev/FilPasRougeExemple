using FilPasRougeExemple.BusinessLayer.VDM;
using FilPasRougeExemple.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Services
{
	[TestClass]
	public class VieDeMerdeQueryTest
	{
		[TestMethod]
		[DeploymentItem("../../../Datas/BusinessLayer/VDM/viedemerde.html")]
		public void GetVDM()
		{
			// Arrange
			IDownloaderFactory downloaderFactory = Mock.Of<IDownloaderFactory>();
			IDownloader downloader = Mock.Of<IDownloader>();

			Mock.Get(downloaderFactory)
				.Setup(x => x.Create())
				.Returns(() => downloader);

			Mock.Get(downloader)
				.Setup(x => x.DownloadString("https://www.viedemerde.fr"))
				.Returns(() => File.ReadAllText("viedemerde.html"));

			// Act
			VieDeMerdeQuery query = new VieDeMerdeQuery(downloaderFactory);
			IReadOnlyList<VieDeMerde> vdms = query.GetLastVieDeMerdes();

			// Assert
			Assert.AreEqual(30, vdms.Count);
			Assert.AreEqual("Le trottoir c'est pas pour les chiens", vdms[0].Titre);
			Assert.AreEqual("lau", vdms[0].Auteur);

			Assert.AreEqual("Dernier recours", vdms[1].Titre);
			Assert.AreEqual("Anonyme", vdms[1].Auteur);
			
			Assert.AreEqual("Dictature", vdms[2].Titre);
			Assert.AreEqual("Plante verte", vdms[2].Auteur);
		}
	}
}
