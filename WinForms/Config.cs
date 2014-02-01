using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
	public class CheckerFormat
	{
		public bool Enabled { get; set; }
		public string Name { get; set; }
		public string Facebook { get; set; }
		public string YouTube { get; set; }
		public string Twitch { get; set; }
		public string Twitter { get; set; }
	}

	public class SoundFormat
	{
		public bool OnVideo { get; set; }
		public bool OnLivestream { get; set; }
		public bool OnFacebook { get; set; }
		public bool OnTwitter { get; set; }
	}

	public class ConfigFormat
	{
		public bool CheckVideo { get; set; }
		public bool CheckLivestream { get; set; }
		public bool CheckSocial { get; set; }
		public bool MergeSocialVideo { get; set; }
		public bool AutoUpdate { get; set; }
		public SoundFormat Sounds { get; set; }
		public string LastVideo { get; set; }
		public string CurrentSound { get; set; }
		public int NotifyDelay { get; set; }
		public string NotifyColor { get; set; }
		public CheckerFormat[] Checkers { get; set; }
		public string[] Filter { get; set; }
	}

	public class Config
	{
		public static bool LastTwitchOnline = false;
		public static ConfigFormat Settings;

		public static void Load()
		{
			if (!File.Exists("config.json")) File.WriteAllText("config.json", JsonConvert.SerializeObject(new ConfigFormat() { NotifyColor = "255, 255, 255", CurrentSound = "Sounds/pew.wav", CheckSocial = true, MergeSocialVideo = true, LastVideo = "", CheckLivestream = true, CheckVideo = true, AutoUpdate = false, Filter = new [] { "TheLockNLol" }, Sounds = new SoundFormat() { OnFacebook = false, OnLivestream = true, OnTwitter = false, OnVideo = false }, Checkers = new[] { new CheckerFormat() { Enabled = true, Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol", Name = "TheLockNLol", Twitter = "TheLockNLol" } } }, Formatting.Indented));
			Settings = JsonConvert.DeserializeObject<ConfigFormat>(File.ReadAllText("config.json"));
		}

		public static void Save()
		{
			File.WriteAllText("config.json", JsonConvert.SerializeObject(Settings, Formatting.Indented));
		}
	}
}
