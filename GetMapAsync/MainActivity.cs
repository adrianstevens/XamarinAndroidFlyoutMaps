using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;
using System.Threading.Tasks;
using Android.Support.V4.App;
using Android.Gms.Maps.Model;

namespace GetMapAsync
{
	[Activity (Label = "GetMapAsync", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity: FragmentActivity, IOnMapReadyCallback
	{
		GoogleMap _map;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				if(bAdded == false)
				{
					AddMap ();
					bAdded = true;

					button.Text = "";
				}
				else
				{}
			}; 
		}

		bool bAdded = false;
		async Task AddMap ()
		{
			var fragment = new SupportMapFragment ();

			// Insert the fragment by replacing any existing fragment
			SupportFragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragment)
				.Commit ();

			await GetMap (fragment);

			_map.UiSettings.CompassEnabled = true;
		}

		TaskCompletionSource<GoogleMap> tcs;
		async Task<GoogleMap> GetMap (SupportMapFragment frag)
		{
			if (_map != null)
				return _map;

			if (tcs != null && tcs.Task.Status == TaskStatus.Running) {
				return tcs.Task.Result;
			}

			tcs = new TaskCompletionSource<GoogleMap> ();

			frag.GetMapAsync (this);
			await tcs.Task;

			return _map;
		}

		void IOnMapReadyCallback.OnMapReady (GoogleMap googleMap)
		{
			_map = googleMap;

			tcs.TrySetResult (_map);
		}
	}
}


