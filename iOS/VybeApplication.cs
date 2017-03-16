using System;
using Plugin.MediaManager;

using Foundation;
using UIKit;

namespace VybeFM.iOS
{
	[Register("VybeApplication")]
	public class VybeApplication: UIApplication
	{
		private MediaManagerImplementation MediaManager => (MediaManagerImplementation)CrossMediaManager.Current;

		public override void RemoteControlReceived(UIEvent theEvent)
		{
			MediaManager.MediaRemoteControl.RemoteControlReceived(theEvent);
		}
	}
}
