using System;
using Android.Gms.Maps;
using Android.OS;
using Android.Views;
using Android.App;

namespace MapsInTabs
{
	public class MyMapFragment : Fragment
	{
		MapFragment _myMapFrag;
		GoogleMap _map;
		static View view;

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
	}
}

