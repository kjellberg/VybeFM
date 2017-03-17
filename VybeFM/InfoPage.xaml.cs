using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Version.Plugin;

namespace VybeFM
{
	public partial class InfoPage : ContentPage
	{
		public InfoPage()
		{
			InitializeComponent();
			VersionLabel.Text = "Version " + Device.OS.ToString() + " " + CrossVersion.Current.Version.ToString();
		}

		void CloseModal(object sender, EventArgs args)
		{
			Navigation.PopModalAsync();
		}
	}
}
