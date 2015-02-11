using Android.Gms.Maps;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.OS;
using Android.Gms.Maps.Model;

namespace ToolBarTabsMap
{
	public class MyMapFragment : Fragment //support fragment from V4
	{
		private static readonly LatLng LatLong_Van = new LatLng(49.25, -123.1);

		SupportMapFragment _myMapFrag;
		GoogleMap _map;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			if (container == null)
				return null;

			var view =  inflater.Inflate (Resource.Layout.frag_map, null);

			_myMapFrag = SupportMapFragment.NewInstance ();
			FragmentTransaction fragTrans = ChildFragmentManager.BeginTransaction ();
			fragTrans.Add (Resource.Id.map, _myMapFrag);
			fragTrans.Commit ();

			return view;

		}

		public override void OnResume ()
		{
			base.OnResume ();

			_map = _myMapFrag.Map;//see GetMapAsync for a non-blocking solution

			_map.MapType = GoogleMap.MapTypeSatellite;

			MarkerOptions markerOp = new MarkerOptions()
				.SetPosition(LatLong_Van)
				.SetTitle("Vancouver")
				.SetSnippet("BC, Canada")
				.InvokeIcon(BitmapDescriptorFactory.DefaultMarker(BitmapDescriptorFactory.HueGreen));
			_map.AddMarker(markerOp);
		}

		/*public override void OnDestroyView ()
		{
			base.OnDestroyView ();

			if (_myMapFrag != null) 
			{
				FragmentManager.BeginTransaction ().Remove (_myMapFrag).Commit ();
				_myMapFrag = null;
			}
		}*/
	
	}
		
}

