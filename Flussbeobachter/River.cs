using System;

namespace Flussbeobachter
{
	class River
	{
		static Random m_rand = new Random();
		private int m_water_level;

		public string Name { get; private set; }
		public int MinWaterLevel { get; private set; }
		public int MaxWaterLevel { get; private set; }

		#region Delegates
		public delegate void WaterLevelChange(object sender, WaterLevelChangeEventArgs arg);
		#endregion

		#region Events
		public event WaterLevelChange OnWaterLevelChange;
		#endregion

		public int WaterLevel
		{
			get { return m_water_level; }
			private set
			{
				if (m_water_level == value)
				{
					return;
				}
				
				m_water_level = value;

				if (OnWaterLevelChange != null)
				{
					OnWaterLevelChange(this, new WaterLevelChangeEventArgs(m_water_level));
				}
			}
		}

		public River(string name, int min_water_level, int max_water_level)
		{
			Name = name;
			MinWaterLevel = min_water_level;
			MaxWaterLevel = max_water_level;

			WaterLevel = m_rand.Next(MinWaterLevel, MaxWaterLevel + 1);
		}

		public void Simulate()
		{
			WaterLevel = m_rand.Next(MinWaterLevel, MaxWaterLevel + 1);
		}
	}
}
