using FilPasRougeExemple.Actions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FilPasRougeExempleTests.Actions
{
	[TestClass]
	public class ActionHelloTest2
	{
		private TextWriter _writer;
		private List<string> _output;

		[TestInitialize]
		public void Init()
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

		[TestMethod]
		public void MustShowHelloWorld()
		{
			// arrange			
			ActionHello action = new ActionHello(this.Writer);

			// act
			action.Action(null);

			// assert
			Assert.AreEqual("Hello World", this.Lines[0]);
		}
	}
}
