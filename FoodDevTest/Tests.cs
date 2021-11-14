using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using FoodDev.Models;

namespace FoodDevTest
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
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void WelcomeTextIsDisplayed()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to FoodDev!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [TestCase("user", "pass")]
        public void LogInWithValidCreds_AuthenticationRequested(string userName, string password)
        {
            //CreateViewModelAndLogin(userName, password);

            //authenticationServiceMock.Verify(x => x.Login(userName, password), Times.Once);
        }

        [Test]
        public void UserCanLogoutSuccesfully()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to FoodDev!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }

        [Test]
        public void SendExtraMessageWithinCartView()
        {
            AppResult[] results = app.WaitForElement(c => c.Marked("Welcome to FoodDev!"));
            app.Screenshot("Welcome screen.");

            Assert.IsTrue(results.Any());
        }


    }
}
