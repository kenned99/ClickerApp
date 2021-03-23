using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Database;


namespace ClickerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // var forfatterErRis = new MongoDB();
            //Database.MongoDB.MongoDBConnect();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
