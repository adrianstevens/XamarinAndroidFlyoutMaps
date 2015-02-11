# XamarinAndroidFlyoutMaps

This code started as a sample to show how to use a Google Maps fragment within a flyout.

It's grown overtime and now contains 4 projects:

<b>ActionBarMap</b> shows Flyout naviagition between SupportMapFragments within an ActionBarActivity.

<b>GetMapAsync</b> is a small project getting a reference to a GoogleMap object using the async GetMap method with a TaskCompletionSource. It also includes code for detecting if the Google Play Services runtime is installed.

<b>MapsInTabs</b> adds an ActionBar to a regular Activity and navigates with tabs using fragments and MapFragments.  Also includes code to save and restore the current tab index.

<b>ViewPagerTabsMap</b> uses a ActionBarActivity to impliment a ViewPager which switches between support fragments.  This also shows how to create a SupportMapFragment entirely in code and add it to a FrameLayout.

<img src="https://raw.githubusercontent.com/adrianstevens/XamarinAndroidFlyoutMaps/master/Screenshots/FlyoutMap.png" />

