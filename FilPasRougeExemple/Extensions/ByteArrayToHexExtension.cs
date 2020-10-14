using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace FilPasRougeExemple.Extensions
{
	public static class ByteArrayToHexExtension
	{
		public static string ToHex(this byte[] data)
		{
			StringBuilder builder = new StringBuilder();

			if (data != null)
			{
				foreach(byte b in data )
				{
					builder.Append(b.ToString("x2"));
				}
			}

			return builder.ToString();
		}
	}
}
