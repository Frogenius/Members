using System;
using Xamarin.Forms;
using System.IO;
using Members.Data;

namespace Members
{
    public partial class App : Application
    {
        static DataDB dataDB;

        public static DataDB DataDB
        {
            get
            {
                if (dataDB == null)
                {
                    dataDB = new DataDB(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "DataDB.db3"));
                }
                return dataDB;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
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
