using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinForms
{
	public class SavingConfig
	{
		public static bool Video = true;
		public static bool Livestream = true;
		public static bool Facebook = true;
		public static string LastVideo = "";

		public static void Save()
		{

		}

		public static void Load()
		{

		}
	}

	public class Config
	{
		public static bool LastTwitchOnline = false;
	}
}
