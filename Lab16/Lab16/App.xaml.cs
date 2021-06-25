using System;
using Lab16.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lab16
{
    public partial class App : Application
    {
        public static SchoolManager SchoolManager { get; set; }
        public App()
        {
            InitializeComponent();

            SchoolManager = new SchoolManager(new RestService());
            
            MainPage = new NavigationPage(new View.SchoolsPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
