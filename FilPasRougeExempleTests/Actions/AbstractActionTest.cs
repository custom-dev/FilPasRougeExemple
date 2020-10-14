using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	public abstract class AbstractActionTest
	{
		private TextWriter _writer;
		private List<string> _output;

		[TestInitialize]
		public virtual void Init()
		{
			_writer = Mock.Of<TextWriter>();
			_output = new List<string>();

			Mock.Get(_writer)
				.Setup(x => x.WriteLine(It.IsAny<string>()))
				.Callback<string>(x => _output.Add(x));

			Mock.Get(_writer)
				.Setup(x => x.WriteLine(It.IsAny<float>()))
				.Callback<float>(x => _output.Add(x.ToString()));
		}

		public TextWriter Writer => _writer;

		public IReadOnlyList<string> Lines
		{
			get { return _output; }
		}

		public string[] GetParameters(string actionName, params object[] parameters)
		{
			List<string> list = new List<string>();

			list.Add(actionName);

			if (parameters != null)
			{
				foreach(object p in parameters)
				{
					if (p != null)
					{
						list.Add(p.ToString());
					}
				}
			}

			return list.ToArray();
		}
	}
}
