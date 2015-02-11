using System;
using Android.Gms.Maps;
using Android.OS;
using Android.Views;
using Android.App;
using Android.Gms.Maps.Model;

namespace MapsInTabs
{
	public class MyMapFragment : Fragment
	{
		MapFragment _myMapFrag;
		GoogleMap _map;
		static View view;

		private static readonly LatLng LatLong_Van = new LatLng(49.25, -123.1);

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			if (view == null)
				view = inflater.Inflate(Resource.Layout.MapFrag, null);

			return view;
		}

		public override void OnResume ()
		{
			base.OnResume ();

			_myMapFrag = FragmentManager.FindFragmentById(Resource.Id.map) as MapFragment;
			_map = _myMapFrag.Map;//see GetMapAsync for a non-blocking solution

			_map.MapType = GoogleMap.MapTypeSatellite;

			MarkerOptions markerOp = new MarkerOptions()
				.SetPosition(LatLong_Van)
				.SetTitle("Vancouver")
				.SetSnippet("BC, Canada")
				.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));
			_map.AddMarker(markerOp);
		}

		public override void OnStop ()
		{
			base.OnStop ();

			view = null;
		}
	}
}

