using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CrossPlatformDemo.Core;
using CrossPlatformDemo.Core.Services;
using CrossPlatformDemo.Core.Views;

namespace CrossPlatformDemo.Droid
{
    [Activity(Label = "Where is .NET?", MainLauncher = false, Icon = "@drawable/icon")]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            FormsAppCompatActivity.ToolbarResource = Resource.Layout.toolbar;
           FormsAppCompatActivity.TabLayoutResource = Resource.Layout.tabs;
            base.OnCreate(bundle);

            Forms.Init(this, bundle);

            AzureDevicesService.Path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), AzureDevicesService.Path);

            // For Mobile Client 3+

            if (!File.Exists(AzureDevicesService.Path)) { File.Create(AzureDevicesService.Path).Dispose(); }

            SQLitePCL.Batteries.Init();
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

            var app = new App();
            app.MainPage = new NavigationPage(new DotNetDevicesView())
            {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.FromHex("#0094f2")
            };
            LoadApplication(app);
        }
    }
}

