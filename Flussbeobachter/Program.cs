using System;

namespace Flussbeobachter
{
	class Program
	{
		static void Main(string[] args)
		{
			River rhine = new River("Rhein", 100, 10000);
			River danube = new River("Donau", 100, 10000);

			City cologne = new City("Cologne");
			City dusseldorf = new City("Dusseldorf");
			City ulm = new City("Ulm");

			Ship rhinegold = new Ship("Rheingold");
			Ship lorelei = new Ship("Lorelei");
			Ship xaver = new Ship("Xaver");
			Ship franz = new Ship("Unser Franz");

			// Klärwerk
			SewageTreatmentPlant stp = new SewageTreatmentPlant("Söder 1");

			// Rhein
			rhine.OnWaterLevelChange += cologne.WaterLevelChangeHandler;
			rhine.OnWaterLevelChange += dusseldorf.WaterLevelChangeHandler;
			rhine.OnWaterLevelChange += rhinegold.WaterLevelChangeHandler;
			rhine.OnWaterLevelChange += lorelei.WaterLevelChangeHandler;

			// Donau
			danube.OnWaterLevelChange += ulm.WaterLevelChangeHandler;
			danube.OnWaterLevelChange += xaver.WaterLevelChangeHandler;
			danube.OnWaterLevelChange += franz.WaterLevelChangeHandler;
			danube.OnWaterLevelChange += stp.WaterLevelChangeHandler;

			while (true)
			{
				Console.Clear();
				Console.WriteLine("Press ESC to exit.");
				
				if (Console.KeyAvailable && Console.ReadKey().Key == ConsoleKey.Escape)
				{
					break;
				}

				Console.WriteLine("".PadRight(Console.WindowWidth - 1, '='));

				Console.WriteLine("Rhine Status (if no text -> everything normal):");
				rhine.Simulate();

				Console.WriteLine();
				Console.WriteLine("Danube Status (if no text -> everything normal):");
				danube.Simulate();

				Console.WriteLine("".PadRight(Console.WindowWidth - 1, '='));
				System.Threading.Thread.Sleep(2000);
			}
		}
	}
}
