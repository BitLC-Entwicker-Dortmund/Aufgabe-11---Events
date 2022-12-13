using System;

namespace Flussbeobachter
{
	class Ship
	{
		bool IsInNormalMode = true;
		public string Name { get; private set; }

		const int MinWaterLevel = 250;
		const int MaxWaterLevel = 8000;

		public Ship(string name)
		{
			Name = name;
		}

		public void WaterLevelChangeHandler(object sender, WaterLevelChangeEventArgs arg)
		{
			if (arg.WaterLevel >= MaxWaterLevel)
			{
				Console.WriteLine(
					"Ship \"{0:s}\" stopped -> Water level above maximum <= {1}.",
					Name,
					MinWaterLevel
				);

				IsInNormalMode = false;
			}
			else if (arg.WaterLevel <= MinWaterLevel)
			{
				Console.WriteLine(
					"Ship \"{0:s}\" stopped -> Water level below minimum <= {1}.",
					Name,
					MaxWaterLevel
				);
				
				IsInNormalMode = false;
			}
			else
			{
				if (!IsInNormalMode)
				{
					Console.WriteLine(
						"Ship \"{0:s}\" started -> Water level normal <= {1}.",
						Name,
						MaxWaterLevel
					);

					IsInNormalMode = true;
				}
			}
		}
	}
}
