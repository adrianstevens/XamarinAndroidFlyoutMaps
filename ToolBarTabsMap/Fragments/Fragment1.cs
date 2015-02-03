using System;
using Android.Support.V4.App;
using Android.Views;

namespace ToolBarTabsMap
{
	public class Fragment1 : Fragment
	{
		public Fragment1 ()
		{
		}

		public override View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			View view = inflater.Inflate(Resource.Layout.frag_blue, container, false);
			return view;
		}
	}
}

