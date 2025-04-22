using GameController;

[Register ("AppDelegate")]
public class AppDelegate : UIApplicationDelegate {
	public override UIWindow? Window {
		get;
		set;
	}

	public override bool FinishedLaunching (UIApplication application, NSDictionary? launchOptions)
	{
		// create a new window instance based on the screen size
		Window = new UIWindow (UIScreen.MainScreen.Bounds);

		// create a UIViewController with a single UILabel
		var vc = new UIViewController ();
		vc.View!.AddSubview (new UILabel (Window!.Frame) {
			BackgroundColor = UIColor.SystemBackground,
			TextAlignment = UITextAlignment.Center,
			Text = "Hello, iOS!",
			AutoresizingMask = UIViewAutoresizing.All,
		});
		Window.RootViewController = vc;

		// make the window visible
		Window.MakeKeyAndVisible ();

		PrintGameControllerInfo ();

		return true;
	}

	static int ticker = 0;
	static void PrintGameControllerInfo ()
	{
		NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (1), (timer) =>
		{
	        ticker++;
	        Console.WriteLine ("Tick #{0}", ticker);
	        var controllers = GCController.Controllers;
	        Console.WriteLine ("    Got {0} controllers", controllers.Length);
	        for (int i = 0; i < controllers.Length; i++) {
	            var controller = controllers [i];
	            Console.WriteLine ("        #{0}: {1}", i, controller);
	            Console.WriteLine ("            ExtendedGamepad: {0} = {1}", controller.ExtendedGamepad?.Handle, controller.ExtendedGamepad);
	            Console.WriteLine ("                ButtonHome: {0} = {1}", controller.ExtendedGamepad?.ButtonHome?.Handle, controller.ExtendedGamepad?.ButtonHome);
	            Console.WriteLine ("                LeftThumbstickButton: {0} = {1}", controller.ExtendedGamepad?.LeftThumbstickButton?.Handle, controller.ExtendedGamepad?.LeftThumbstickButton);
	        }
		});
	}
}
