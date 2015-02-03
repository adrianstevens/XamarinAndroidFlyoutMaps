using Android.Gms.Maps;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Android.OS;

namespace ToolBarTabsMap
{
	public class MyMapFragment : Fragment
	{
		private static View view;

		public override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);
		}

		public override Android.Views.View OnCreateView (Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			if (container == null)
				return null;

			if(view == null)
				view = inflater.Inflate (Resource.Layout.frag_map, null);

			return view;
		}
	
	}
		
}

