using System;

namespace BreakFreeAudioKeyMaker
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Console.Write("Email for TuneBlade:");

			string email = Console.ReadLine();
			var resultTuneBlade = TuneBlade.Generate(email);
			Console.WriteLine("TuneBlade Serial: " + resultTuneBlade);

            Console.Write("Patch TuneAero [Y/n]? (close it first)");

			if (Console.ReadLine().ToLower() == "y")
			{
                string path = @"C:\Program Files (x86)\Breakfree Audio\TuneAero\TuneAero.exe";
                Console.WriteLine("Patching {0}", path);

                bool result = TuneAero.Patch(path);
                Console.WriteLine("Patched: {0}", result);
            }

            Console.ReadLine();
        }
	}
}
