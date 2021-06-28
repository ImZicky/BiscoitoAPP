using Biscoito.Pages.Password;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Biscoito.Service;
using Biscoito.Pages.User;
using Biscoito.WebService;

namespace Biscoito.Pages
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<IWebClientOptionsService, WebClientOptionsService>();
            DependencyService.Register<IPasswordService, PasswordService>();
            DependencyService.Register<IUserService, UserService>();
            DependencyService.Register<IResourceService, ResourceService>();
            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
        }

        protected override async void OnSleep()
        {

            if (!MainPage.Title.Equals("Login"))
            {
                await MainPage.Navigation.PopToRootAsync();
            }
        }

        protected override void OnResume()
        {
        }
    }
}
