using System;

namespace TuneBladeKey
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var generator = new Generator();
			var result = generator.Generate("dennis@umetzu.com");

			Console.WriteLine(result);
		}
	}
}
