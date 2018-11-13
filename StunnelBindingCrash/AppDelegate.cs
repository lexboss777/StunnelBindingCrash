using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Foundation;
using UIKit;

namespace StunnelBindingCrash
{
	public static class Stunnel
	{
		[DllImport("__Internal", CallingConvention = CallingConvention.Cdecl)]
		public static extern int stunnel_main(int argc, [In, Out] string[] argv);
	}

	[Register("AppDelegate")]
	public class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations

		public override UIWindow Window
		{
			get;
			set;
		}

		public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
		{
			// Override point for customization after application launch.
			// If not required for your application you can safely delete this method

			StartTesting();

			return true;
		}

		async Task StartTesting()
		{
			Task.Factory.StartNew(StunnelThread);

			await Task.Delay(1000);

			//now it will crash
			Console.WriteLine(new NSString("If you can read this from Application Output MtouchFastDev is disabled."));
		}

		public static void StunnelThread()
		{
			var configFileName = CreateStunnelConfig();
			Stunnel.stunnel_main(2, new string[] { "stunnel", configFileName });
		}

		static string CreateStunnelConfig()
		{
			var tmpDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "tmp/");

			var confPath = Path.Combine(tmpDir, "stunnel.conf");
			var pidFile = Path.Combine(tmpDir, "stunnel.pid");
			var logFile = Path.Combine(tmpDir, "stunnel.log");

			if (File.Exists(logFile))
				Console.WriteLine(File.ReadAllText(logFile));

			Directory.CreateDirectory(tmpDir);
			File.Delete(pidFile);

			using (var fs = File.Create(logFile));

			string content = $"pid = {pidFile}\noutput = {logFile}\nsocket = a:SO_REUSEADDR=1\nforeground = yes\ndebug = 7\nsocket = l:TCP_NODELAY=1\nsocket = r:TCP_NODELAY=1\n[test]\nclient = yes\naccept = 127.0.0.1:8888\nconnect = www.cryptopro.ru:5555";

			File.WriteAllText(confPath, content);

			return confPath;
		}
	}
}

