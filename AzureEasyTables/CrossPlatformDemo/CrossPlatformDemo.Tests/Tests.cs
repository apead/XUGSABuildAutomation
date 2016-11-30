using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace CrossPlatformDemo.Tests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp.Android.ApkFile("C:\\work\\samples\\XUGSABuildAutomation\\AzureEasyTables\\CrossPlatformDemo\\Releases\\za.co.ctxug.CrossPlatformDemo.apk").StartApp();
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");
            app.WaitForElement(c => c.Marked("iOS"),"Time Out",new TimeSpan(0,0,5,0));
            app.Screenshot("Latte Panda Master.");
            app.Tap(c => c.Marked("Latte Panda"));
            app.Screenshot("Latte Panda Detail.");
        }

  //      [Test]
  //      public void ReplIt()
  //      {
  //          app.Repl();
  //      }

    }
}

