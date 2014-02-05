using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace SaveLoadPreferencies
{
	[Activity (Label = "SaveLoadPreferencies", MainLauncher = true)]
	public class Activity1 : Activity
	{
	var prefs = Application.Context.GetSharedPreferences("MyApp", FileCreationMode.Private);  
	var somePref = prefs.GetString("PrefName", null);

	 prefEditor = prefs.Edit();
	prefEditor.PutString("PrefName", "Some value");
	prefEditor.Commit();
	}
}


