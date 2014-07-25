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

namespace GooglePlusSignIn
{
	public class MyMapFragment2 : Fragment
	{
		SupportMapFragment _myMapFrag;

		public override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			// Create your fragment here
		}

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			//this.HasOptionsMenu = true;

			var view = inflater.Inflate(Resource.Layout.map_frag2, null);

			return view;
		}
	}
}

