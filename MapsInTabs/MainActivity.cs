using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Gms.Maps;


namespace MapsInTabs
{
	[Activity (Label = "MapsInTabs", MainLauncher = true, Icon = "@drawable/icon", Theme="@style/ApplicationTheme")]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			this.ActionBar.Show ();
			this.ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

			AddTab("Blue", Resource.Drawable.Icon, new BlueFragment());
			AddTab("Red", Resource.Drawable.Icon, new RedFragment());
			AddTab("MapFrag", Resource.Drawable.Icon, new MapFragment());
			AddTab("MyMapFrag", Resource.Drawable.Icon, new MyMapFragment());

		}

		void AddTab(string tabText, int iconResourceId, Fragment fragment)
		{
			var tab = this.ActionBar.NewTab();
			tab.SetText(tabText);
			tab.SetIcon(iconResourceId);

			tab.TabSelected += (sender, e) => FragmentManager.BeginTransaction().Replace(Resource.Id.fragmentContainer, fragment).Commit();

			this.ActionBar.AddTab(tab);
		}

	}
}


