using Android.App;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.View;

namespace ToolBarTabsMap
{
	[Activity (Label = "ToolBarTabsMap", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/Theme.AppCompat.Light.NoActionBar")]
	public class MainActivity : ActionBarActivity, Toolbar.IOnMenuItemClickListener
	{
		bool Toolbar.IOnMenuItemClickListener.OnMenuItemClick (IMenuItem item)
		{
			return false;
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.Main);

			ViewPagerAdapter pageAdapter = new ViewPagerAdapter(SupportFragmentManager);
			var viewPager = FindViewById<ViewPager>(Resource.Id.pager);
			viewPager.Adapter = pageAdapter;

			viewPager.SetCurrentItem (0, true);
		}
	}
}


