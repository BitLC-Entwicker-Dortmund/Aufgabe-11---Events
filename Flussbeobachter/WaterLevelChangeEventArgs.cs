using System;

namespace Flussbeobachter
{
	class WaterLevelChangeEventArgs : EventArgs
	{
		public int WaterLevel { get; private set; }

		public WaterLevelChangeEventArgs()
			: base()
		{
		}

		public WaterLevelChangeEventArgs(int CurrentWaterLevel)
			: this()
		{
			WaterLevel = CurrentWaterLevel;
		}
	}
}
