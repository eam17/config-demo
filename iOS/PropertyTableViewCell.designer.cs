// WARNING
//
// This file has been generated automatically by Visual Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace ConfigDemo.iOS
{
	[Register ("PropertyTableViewCell")]
	partial class PropertyTableViewCell
	{
		[Outlet]
		UIKit.UILabel KeyLabel { get; set; }

		[Outlet]
		UIKit.UILabel ValueLabel { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (KeyLabel != null) {
				KeyLabel.Dispose ();
				KeyLabel = null;
			}

			if (ValueLabel != null) {
				ValueLabel.Dispose ();
				ValueLabel = null;
			}
		}
	}
}
