using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
	public class CheckerFormat
	{
		public string Facebook { get; set; }
		public string YouTube { get; set; }
		public string Twitch { get; set; }
	}

	public class ConfigFormat
	{
		public bool Video { get; set; }
		public bool Livestream { get; set; }
		public bool Facebook { get; set; }
		public bool AutoUpdate { get; set; }
		public string LastVideo { get; set; }
		public CheckerFormat[] Checkers { get; set; }
	}

	public class Config
	{
		public static bool LastTwitchOnline = false;
		public static ConfigFormat Settings;

		public static void Load()
		{
			if (!File.Exists("config.json")) File.WriteAllText("config.json", JsonConvert.SerializeObject(new ConfigFormat() { Facebook = true, LastVideo = "", Livestream = true, Video = true, Checkers = new[] { new CheckerFormat() { Facebook = "TheLockNLol", Twitch = "TheLockNLol", YouTube = "TheLockNLol" } } }));
			Settings = JsonConvert.DeserializeObject<ConfigFormat>(File.ReadAllText("config.json"));
		}

		public static void Save()
		{

		}
	}
}
