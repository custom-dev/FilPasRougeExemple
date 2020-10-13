using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	public interface IDownloaderFactory
	{
		IDownloader Create();
	}
}
