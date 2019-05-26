using System;

namespace BreakFreeAudioKeyMaker
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var generatorTuneBlade = new TuneBlade();
			var resultTuneBlade = generatorTuneBlade.Generate("tuneblade@umetzu.com");

			Console.WriteLine("TuneBlade: " + resultTuneBlade);

			var generatorTuneAero = new TuneAero();
			var resultTuneAero = generatorTuneAero.Generate();

			Console.WriteLine("TuneAero: " + resultTuneAero);
		}
	}
}
