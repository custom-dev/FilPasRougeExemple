using System;
using System.Collections.Generic;
using System.Text;

namespace FilPasRougeExemple.Services
{
	public interface IDownloader : IDisposable
	{
		string DownloadString(string url);
	}
}
