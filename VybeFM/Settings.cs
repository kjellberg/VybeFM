using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace VybeFM
{
	public static class Settings
	{
		private static ISettings AppSettings
		{
			get
			{
				return CrossSettings.Current;
			}
		}

		public static bool EnabledHQ
		{
			get { return AppSettings.GetValueOrDefault<bool>("high_quality_stream", true); }
			set { AppSettings.AddOrUpdateValue<bool>("high_quality_stream", value); }
		}
	}
}
