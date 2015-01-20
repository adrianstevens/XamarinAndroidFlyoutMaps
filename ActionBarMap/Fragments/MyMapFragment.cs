
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using GooglePlusSignIn;

using Android.Gms.Maps;
using System.Threading.Tasks;

namespace ActionBarMap
{
	//interface only needed if you're getting a reference to the map object
	public class MyMapFragment : Fragment
	{
		SupportMapFragment _myMapFrag;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
		}

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var view = inflater.Inflate(Resource.Layout.map_frag, null);

			CreateMap ();

			return view;
		}

		void CreateMap ()
		{
			_myMapFrag = SupportMapFragment.NewInstance();
			//FragmentTransaction tx = FragmentManager.BeginTransaction();

			var tx = ChildFragmentManager.BeginTransaction ();
			tx.Add(Resource.Id.frameMap, _myMapFrag);
			tx.Commit();
		}
			
	/*	public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
		{
			inflater.Inflate(Resource.Menu.refresh, menu);
		}*/


	}
}

