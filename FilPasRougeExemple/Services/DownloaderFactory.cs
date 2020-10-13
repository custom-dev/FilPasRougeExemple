using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	public class DownloaderFactory : IDownloaderFactory
	{
		public IDownloader Create()
		{
			return new DownloaderService();
		}
	}
}
