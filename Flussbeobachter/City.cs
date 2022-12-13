using System;

namespace Flussbeobachter
{
	class City
	{
		bool IsInNormalMode = true;
		public string Name { get; private set; }

		const int MaxWaterLevel = 8200;

		public City(string name)
		{
			Name = name;
		}

		public void WaterLevelChangeHandler(object sender, WaterLevelChangeEventArgs arg)
		{
			if (arg.WaterLevel >= MaxWaterLevel)
			{
				Console.WriteLine(
					"City \"{0:s}\" water protection wall raised -> Water level above >= {1}.",
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
						"City \"{0:s}\" water protection wall lowered -> Water level below <= {1}.",
						Name,
						MaxWaterLevel
					);

					IsInNormalMode = true;
				}
			}
		}
	}
}
