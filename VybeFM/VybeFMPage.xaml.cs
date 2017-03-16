﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

using Xamarin.Forms;
using Plugin.MediaManager;

namespace VybeFM
{
	public partial class VybeFMPage : ContentPage
	{
		string radioStreamURL_HQ = "http://cast1.vybe.se:8433/192.mp3";
		string radioStreamURL_LQ = "http://cast1.vybe.se:8433/64.mp3";

		bool highQualityStream = false;

		bool isPlaying = false;
		HttpClient client;

		public VybeFMPage()
		{
			InitializeComponent();
			GetStats();
			Xamarin.Forms.Device.StartTimer(TimeSpan.FromSeconds(10), RefreshStatsCallback);
		}

		void ToggleOnOff(object sender, EventArgs args)
		{
			if (isPlaying == false)
			{
				StartMusicPlayer();
			}
			else
			{
				StopMusicPlayer();
			}
		}

		string GetStreamURL()
		{
			if (highQualityStream)
			{
				return this.radioStreamURL_HQ;
			}
			else
			{
				return this.radioStreamURL_LQ;
			}
		}

		async void StartMusicPlayer()
		{
			await CrossMediaManager.Current.Play(GetStreamURL());

			StartStopButtonImage.Source = "stop.png";
			isPlaying = true;
			streamStatus.Text = "NOW PLAYING";
		}

		async void StopMusicPlayer()
		{
			await CrossMediaManager.Current.Stop();
			StartStopButtonImage.Source = "play.png";
			isPlaying = false;
			streamStatus.Text = "PAUSED";
		}

		bool RefreshStatsCallback()
		{
			GetStats();
			return true;
		}

		async void GetStats()
		{
			this.IsBusy = true;
		
			client = new HttpClient();
			client.MaxResponseContentBufferSize = 256000;

			var uri = new Uri("http://cast1.vybe.se:8433/stats?sid=1&json=1");
			var request = await client.GetAsync(uri);
			if (request.IsSuccessStatusCode)
			{
				string response = await request.Content.ReadAsStringAsync();
				HandleStatsCallback(JsonConvert.DeserializeObject<StatsResponse>(response));
			}		
		}

		void HandleStatsCallback(StatsResponse response)
		{
			currentSong.Text = response.songtitle;
			this.IsBusy = false;
		}

	}
}
