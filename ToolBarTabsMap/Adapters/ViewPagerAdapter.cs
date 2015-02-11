using System;
using System.Collections.Generic;
using Android.Gms.Maps;
using JavaString = Java.Lang.String;
using Android.Support.V4.App;

namespace ToolBarTabsMap
{
	public class ViewPagerAdapter : FragmentPagerAdapter
	{
		List<Fragment> fragments;

		public static JavaString[] Titles = new[]
		{
			new JavaString("Support MapFrag"),
			new JavaString("Tab2"),
			new JavaString("My MapFrag"),
			new JavaString("Tab4"),
			new JavaString("Tab5"),
		};

		public override int Count 
		{
			get { return fragments.Count; }
		}

		public ViewPagerAdapter (FragmentManager fm) : base(fm)
		{
			this.fragments = new List<Fragment>();

			fragments.Add (new SupportMapFragment ());
			fragments.Add (new Fragment1());
			fragments.Add (new MyMapFragment ());
			fragments.Add (new Fragment2());
			fragments.Add (new Fragment3());

		}

		public override Java.Lang.ICharSequence GetPageTitleFormatted (int position)
		{
			return Titles [position];
		}


		public override Fragment GetItem (int position)
		{
			return fragments[position];
		}


	}
}

