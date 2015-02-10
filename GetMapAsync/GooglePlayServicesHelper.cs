using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Common;
using Android.Util;

namespace GetMapAsync
{
	public static class CheckGooglePlayServices
	{
		private static int PLAY_SERVICE_RESOLUTION_REQ = 9000;

		public static bool CheckPlayServices (Activity context)
		{
			int result = GooglePlayServicesUtil.IsGooglePlayServicesAvailable (context);

			if (result != ConnectionResult.Success) 
			{
				if (GooglePlayServicesUtil.IsUserRecoverableError (result)) 
				{
					GooglePlayServicesUtil.GetErrorDialog (result, context, PLAY_SERVICE_RESOLUTION_REQ).Show ();
				} 
				else 
				{
					Log.Debug ("GetMapAsync", "Google Play Services is not supported on this device");
					context.Finish ();
				}
				return false;
			}
			return true;//we're good 
		}
	}
}

