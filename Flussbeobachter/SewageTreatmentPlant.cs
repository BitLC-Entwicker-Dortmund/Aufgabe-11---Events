using System;

namespace Flussbeobachter
{
	class SewageTreatmentPlant
	{
		bool InNormalMode = true;
		public string Name { get; private set; }

		const int MaxWaterLevel = 8000;
		const int MinWaterLevel = 3000;

		public SewageTreatmentPlant(string name)
		{
			Name = name;
		}

		public void WaterLevelChangeHandler(object sender, WaterLevelChangeEventArgs arg)
		{
			if (arg.WaterLevel >= MaxWaterLevel)
			{
				Console.WriteLine(
					"Sewage Treatment Plant \"{0:s}\" output stopped -> Water level above {1}.",
					Name,
					MaxWaterLevel
				);
			}
			else if (arg.WaterLevel <= MinWaterLevel)
			{
				Console.WriteLine(
					"Sewage Treatment Plant \"{0:s}\" output increased -> Water level below {1}.",
					Name,
					MinWaterLevel
				);
			}
			else
			{
				if (!InNormalMode)
				{
					Console.WriteLine(
						"Sewage Treatment Plant \"{0:s}\" output normal -> Water level normal {1}.",
						Name,
						MinWaterLevel
					);
					InNormalMode = true;
				}
			}
		}
	}
}
