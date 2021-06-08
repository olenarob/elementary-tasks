using System;
using System.IO;
using System.Numerics;
using System.Text;
using Xunit;

namespace NumberToString.Test
{
    public class NumberToStringViewTests
    {
		private static StringBuilder SetupAndGetConsoleTextBuffer()
		{
			var textBuffer = new StringBuilder();
			Console.SetOut(new StringWriter(textBuffer));
			return textBuffer;
		}

		[Fact]
		public void View_DisplayMessage_Test()
		{
			StringBuilder consoleBuffer = SetupAndGetConsoleTextBuffer();
			string testMessage = "Test message 1";
			var view = new View();

			view.DisplayMessage(testMessage);

			Console.Out.Flush();
			Assert.Equal(testMessage, consoleBuffer.ToString(), "Incorrect message!");
		}

		[Fact]
		public void View_DisplayBigNumber_Test()
		{
			StringBuilder consoleBuffer = SetupAndGetConsoleTextBuffer();
			BigInteger number = 211515151515515151548348438;
			string testMessage = "1,211,515,151,515,515,151,548,348,438";

			var view = new View();

			view.DisplayBigNumber(number);

			Console.Out.Flush();
			Assert.Equal(testMessage, consoleBuffer.ToString(), "Incorrect format of big number!");
		}

		[Fact]
		public void View_DisplayHelp_Test()
		{
			StringBuilder consoleBuffer = SetupAndGetConsoleTextBuffer();

			var view = new View();

			view.DisplayHelp(number);

			Console.Out.Flush();

			string consoleText = consoleBuffer.ToString();
			Assert.IsTrue(consoleText.Contains("Help"), "Missing 'Help' label!");
			Assert.IsTrue(consoleText.Contains("Usage: "), "Missing usage message!");
			Assert.IsTrue(consoleText.Contains("integer more than zero"), "Incorrect usage message!");
		}

		[Fact]
		public void View_DisplayTask_Test()
		{
			StringBuilder consoleBuffer = SetupAndGetConsoleTextBuffer();

			var view = new View();

			view.DisplayHelp();

			Console.Out.Flush();

			string consoleText = consoleBuffer.ToString();
			Assert.Equal(consoleText.Contains("Task 5"), "Missing 'Task 5' label!");
		}
	}
}
