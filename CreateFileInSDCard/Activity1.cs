using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace CreateFileInSDCard
{
    [Activity(Label = "CreateFileInSDCard", MainLauncher = true, Icon = "@drawable/icon")]
    public class Activity1 : Activity
    {
        TextView textView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            textView = FindViewById<TextView>(Resource.Id.textView1);
            var button = FindViewById<Button>(Resource.Id.MyButton);
            button.Click += button_Click;

            //Write File
            WriteTextFile();
        }

        void button_Click(object sender, EventArgs e)
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
            var filePath = System.IO.Path.Combine(sdCardPath, "MyTextFile.txt");
            if (System.IO.File.Exists(filePath))
            {
                var text = System.IO.File.ReadAllText(filePath);
                textView.Text = text;
            }
        }

        private void WriteTextFile()
        {
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.Path;
            var filePath = System.IO.Path.Combine(sdCardPath, "MyTextFile.txt");

            if (!System.IO.File.Exists(filePath))
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, true))
                {
                    writer.Write("This is the content of my text file.");
                }
            }
        }
    }
}

