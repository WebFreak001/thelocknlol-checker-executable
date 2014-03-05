using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinForms
{
	static class Program
	{
		static Mutex mutex = new Mutex(true, "{8F6F0AC4-B9A1-45fd-A8CF-72F04E6BDE8F}");

		[STAThread]
		static void Main(string[] args)
		{
			if (args.Contains("-a"))
			{
				try
				{
					ProcessStartInfo s = new ProcessStartInfo();
					s.FileName = Application.ExecutablePath;
					s.Arguments = "-s";
					Process.Start(s);
				}
				catch (Exception e)
				{
					using (StreamWriter w = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "/error.txt"))
					{
						w.WriteLine("Error trying to start " + Application.ExecutablePath + " -s");
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						w.WriteLine(e.Message);
						w.WriteLine(e.StackTrace);
						w.WriteLine(e.Source);
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						if (e.Data.Count > 0)
						{
							w.WriteLine("  Extra details:");
							foreach (DictionaryEntry de in e.Data)
								w.WriteLine("    Key: {0,-20}      Value: {1}", "'" + de.Key.ToString() + "'", de.Value);
						}
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						w.WriteLine("Send message to naronco pls!");
						MessageBox.Show("Error Document written to " + Path.GetDirectoryName(Application.ExecutablePath) + "/error.txt");
					}
				}
			}
			else
			{
#if !DEBUG
				try
				{
#endif
				if (mutex.WaitOne(TimeSpan.Zero, true))
				{
					Application.EnableVisualStyles();
					Application.SetCompatibleTextRenderingDefault(false);
					MainForm f = new MainForm();
					if (args.Contains("-s"))
					{
						f.Hidden = true;
					}
					Environment.CurrentDirectory = AppDomain.CurrentDomain.BaseDirectory;
					Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
					Application.Run(f);
					mutex.ReleaseMutex();
				}
				else
				{
					NativeMethods.PostMessage(
						(IntPtr)NativeMethods.HWND_BROADCAST,
						NativeMethods.WM_SHOWME,
						IntPtr.Zero,
						IntPtr.Zero);
				}
#if !DEBUG
				}
				catch (Exception e)
				{
					using (StreamWriter w = new StreamWriter(Path.GetDirectoryName(Application.ExecutablePath) + "/error.txt"))
					{
						w.WriteLine("OMFG AN ERROR OCCURED!");
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						w.WriteLine(e.Message);
						w.WriteLine(e.StackTrace);
						w.WriteLine(e.Source);
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						if (e.Data.Count > 0)
						{
							w.WriteLine("  Extra details:");
							foreach (DictionaryEntry de in e.Data)
								w.WriteLine("    Key: {0,-20}      Value: {1}", "'" + de.Key.ToString() + "'", de.Value);
						}
						w.WriteLine();
						w.WriteLine("============");
						w.WriteLine();
						w.WriteLine("Send message to naronco pls!");
						MessageBox.Show("Error Document written to " + Path.GetDirectoryName(Application.ExecutablePath) + "/error.txt");
					}
				}
#endif
			}
		}
	}
}
