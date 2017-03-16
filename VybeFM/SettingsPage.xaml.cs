using System;
using System.Collections.Generic;
using System.Diagnostics;

using Xamarin.Forms;

namespace VybeFM
{
	public partial class SettingsPage : ContentPage
	{
		VybeFMPage MainPage;

		public SettingsPage(VybeFMPage _mainPage)
		{
			MainPage = _mainPage;
			InitializeComponent();
			UpdateSettingsFields();
		}

		void CloseModal(object sender, EventArgs args)
		{
			Navigation.PopModalAsync();
		}

		void ChangedEnabledHQ(object sender, EventArgs args)
		{
			if (Settings.EnabledHQ != EnabledHQ.On)
			{
				Settings.EnabledHQ = EnabledHQ.On;
				MainPage.RestartStream();
			}
		}

		void UpdateSettingsFields()
		{
			EnabledHQ.On = Settings.EnabledHQ;
		}
	}
}
