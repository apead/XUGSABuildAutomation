using CrossPlatformDemo.Core.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Xamarin.Forms;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace CrossPlatformDemo.Uwp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage 
    {
        public MainPage()
        {
            SQLitePCL.Batteries.Init();
//            Microsoft.WindowsAzure.MobileServices.Curr.Init();

            this.InitializeComponent();

            var app = new Core.App();
            app.MainPage = new NavigationPage(new DotNetDevicesView())
            {
             //   BarTextColor = Color.White,
//BarBackgroundColor = Color.FromHex("#0094f2")
            };
            LoadApplication(app);
        }
    }
}
