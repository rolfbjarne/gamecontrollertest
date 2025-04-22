namespace dotnet;

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

		return true;
	}

	static int ticker = 0;
	static void PrintGameControllerInfo ()
	{

		NSTimer.CreateRepeatingScheduledTimer (TimeSpan.FromSeconds (1), (timer) =>
		{
	        ticker++;
	        Console.WriteLine ("Tick #%i", ticker);
	        var controllers = GCController.Controllers;
	        Console.WriteLine ("    Got {0} controllers", controllers.Length);
	        for (int i = 0; i < controllers.Length; i++) {
	            GCController* controller = [controllers objectAtIndex:i];
	            Console.WriteLine ("        #{0}: {1}", i, controller);
	            Console.WriteLine ("            ExtendedGamepad: 0x{0} = {1}", controller.ExtendedGamepad?.Handle.ToString ("x"), controller.ExtendedGamepad);
	            Console.WriteLine ("                ButtonHome: 0x{0} = {1}", controller.ExtendedGamepad?.ButtonHome?.Handle.ToString ("x"), controller.ExtendedGamepad?.ButtonHome);
	            Console.WriteLine ("                LeftThumbstickButton: 0x{0} = {1}", controller.ExtendedGamepad?.LeftThumbstickButton?.Handle.ToString ("x"), controller.ExtendedGamepad?.LeftThumbstickButton);
	        }
		});
	}
}
