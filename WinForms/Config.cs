﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	public class CheckerFormat
	{
		public bool Enabled { get; set; }
		public string Name { get; set; }
		public string Facebook { get; set; }
		public string YouTube { get; set; }
		public string Twitch { get; set; }
	}

	public class SoundFormat
	{
		public bool OnVideo { get; set; }
		public bool OnLivestream { get; set; }
		public bool OnFacebook { get; set; }
	}

	public class ConfigFormat
	{
		public bool CheckVideo { get; set; }
		public bool CheckLivestream { get; set; }
		public bool CheckSocial { get; set; }
		public bool MergeSocialVideo { get; set; }
		public bool AutoUpdate { get; set; }
		public SoundFormat Sounds { get; set; }
		public string CurrentSound { get; set; }
		public int NotifyDelay { get; set; }
		public int NotifyColor { get; set; }
		public List<CheckerFormat> Checkers { get; set; }
		public bool AutoStart { get; set; }
	}

	public class Config
	{
		public static ConfigFormat Settings;

		public static void Load()
		{
			try
			{
				if (!File.Exists("config.json")) File.WriteAllText("config.json", JsonConvert.SerializeObject(new ConfigFormat() { NotifyColor = 0, AutoStart = false, CurrentSound = "Sounds/pew.wav", CheckSocial = true, MergeSocialVideo = true, NotifyDelay = 100, CheckLivestream = true, CheckVideo = true, AutoUpdate = false, Sounds = new SoundFormat() { OnFacebook = false, OnLivestream = true, OnVideo = false }, Checkers = new List<CheckerFormat>() { new CheckerFormat() { Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol", Name = "TheLockNLol" } } }, Formatting.Indented));
				Settings = JsonConvert.DeserializeObject<ConfigFormat>(File.ReadAllText("config.json"));
			}
			catch
			{
				Settings = new ConfigFormat()
				{
					NotifyColor = 0,
					CurrentSound = "Sounds/pew.wav",
					CheckSocial = true,
					MergeSocialVideo = true,
					NotifyDelay = 100,
					CheckLivestream = true,
					CheckVideo = true,
					AutoUpdate = false,
					AutoStart = false,
					Sounds = new SoundFormat()
					{
						OnFacebook = false,
						OnLivestream = true,
						OnVideo = false
					},
					Checkers = new List<CheckerFormat>()
					{
						new CheckerFormat()
						{
							Enabled = true,
							Facebook = "TheLockNLol",
							Twitch = "TheLockNLol",
							YouTube = "TheLockNLol",
							Name = "TheLockNLol",
						}
					}
				};
			}
		}

		public static void Save()
		{
			try
			{
				File.WriteAllText("config.json", JsonConvert.SerializeObject(Settings, Formatting.Indented));
			}
			catch
			{
				MessageBox.Show("Failed to Save config.json", "Error");
			}
		}
	}
}
