using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Collections.Generic;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Android.Support.V4.App;
using Android.Content.Res;
using ICS;
using Android.Gms.Maps;

namespace GooglePlusSignIn
{
	[Activity (Label = "ActionBarCompat", Icon = "@drawable/ic_launcher", Theme = "@style/Theme.AppCompat.Light", MainLauncher = true)]
	//[MetaData ("android.support.UI_OPTIONS", Value = "splitActionBarWhenNarrow")]//If you wanted to slit it!
	public class MainActivity : ActionBarActivity
	{
		static readonly string Tag = "Flyout";
		DrawerLayout drawerLayout;
		ActionBarDrawerToggle drawerToggle;
		ListView drawerList;
		static string[] sections = new[] { "Map Fragment Direct", "Frag in Frag (code)", "Frag in Frag (inflate)" };

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			drawerLayout = FindViewById<DrawerLayout> (Resource.Id.drawer_layout);
			drawerLayout.SetDrawerShadow (Resource.Drawable.drawer_shadow, (int)GravityFlags.Start);
			drawerList = FindViewById<ListView> (Resource.Id.flyout);
			drawerList.Adapter = new ArrayAdapter<string> (this, Resource.Layout.drawer_list_item, sections);

			drawerToggle = new ActionBarDrawerToggle (this, drawerLayout, Resource.Drawable.ic_drawer, Resource.String.drawer_open, Resource.String.drawer_close);
			drawerLayout.SetDrawerListener (drawerToggle);

			drawerList.ItemClick += (object sender, AdapterView.ItemClickEventArgs e) => ListItemClicked (e.Position);
			ListItemClicked (0);

			ActionBar.SetDisplayHomeAsUpEnabled (true);
			ActionBar.SetHomeButtonEnabled (true);
		}

		void ListItemClicked (int position)
		{
			SupportFragmentManager.PopBackStack (null, (int)PopBackStackFlags.Inclusive);

			Android.Support.V4.App.Fragment fragment = null;

			fragment = new MyMapFragment ();

			switch (position) 
			{
			case 0:
				fragment = new SupportMapFragment ();
				break;
			case 1:
				fragment = new MyMapFragment ();
				break;
			case 2:
				fragment = new MyMapFragment2 ();
				break;
			
			default:


				break;
			}

			// Insert the fragment by replacing any existing fragment
			SupportFragmentManager.BeginTransaction ()
				.Replace (Resource.Id.content_frame, fragment)
				.Commit ();

			// Highlight the selected item, update the title, and close the drawer
			drawerList.SetItemChecked (position, true);
			SupportActionBar.Title = sections [position];
			drawerLayout.CloseDrawer (drawerList);
		}

		protected override void OnPostCreate (Bundle savedInstanceState)
		{
			base.OnPostCreate (savedInstanceState);
			drawerToggle.SyncState ();
		}
		public override void OnConfigurationChanged (Configuration newConfig)
		{
			base.OnConfigurationChanged (newConfig);
			drawerToggle.OnConfigurationChanged (newConfig);
		}
		// Pass the event to ActionBarDrawerToggle, if it returns
		// true, then it has handled the app icon touch event
		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			if (drawerToggle.OnOptionsItemSelected (item))
				return true;

			return base.OnOptionsItemSelected (item);
		}
		public override bool OnPrepareOptionsMenu (IMenu menu)
		{
			var drawerOpen = drawerLayout.IsDrawerOpen (drawerList);
			//when open don't show anything
			for (int i = 0; i < menu.Size (); i++)
				menu.GetItem (i).SetVisible (!drawerOpen);

			return base.OnPrepareOptionsMenu (menu);
		}
	}
}


