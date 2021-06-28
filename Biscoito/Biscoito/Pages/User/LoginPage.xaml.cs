using Biscoito.Pages.Password;
using Biscoito.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Biscoito.Pages.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        private readonly IUserService _serv;
        private IResourceService _resServ;
        private IMessageService _msgServ;

        public LoginPage()
        {
            InitializeComponent();
            _serv = DependencyService.Get<IUserService>();
            _resServ = DependencyService.Get<IResourceService>();
            _msgServ = DependencyService.Get<IMessageService>();
        }

        private async void Login(object sender, EventArgs e)
        {
            ShowLoginLoadIcon(true);
            if (string.IsNullOrEmpty(EmailEntry.Text) || string.IsNullOrEmpty(PasswordEntry.Text))
            {
                _msgServ.ShortAlert(_resServ.GetText("PleaseCompleteAllFields"));
            }
            else
            {
                var isLogged = await _serv.Login(EmailEntry.Text, PasswordEntry.Text);

                if (isLogged)
                {
                    ShowLoginLoadIcon(false);
                    await Navigation.PushAsync(new PasswordsListPage());
                }
                else
                {
                    _msgServ.ShortAlert(_resServ.GetText("WrongLogin"));
                }
            }
            ShowLoginLoadIcon(false);
        }

        private void EntryFocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = Color.FromHex("#4F281F");
            entry.TextColor = Color.FromHex("#FFFFFF");
            entry.PlaceholderColor = Color.FromHex("#FFFFFF");

            if (string.IsNullOrEmpty(entry.Text))
            {
                entry.Text = entry.Placeholder;
            }
        }

        private void EntryUnfocused(object sender, FocusEventArgs e)
        {
            var entry = sender as Entry;
            entry.BackgroundColor = Color.FromHex("#FFFFFF");
            entry.PlaceholderColor = Color.FromHex("#4F281F");
            entry.TextColor = Color.FromHex("#4F281F");
        }

        private void EntryTextChanged(object sender, TextChangedEventArgs e)
        {
            var entry = sender as Entry;
            entry.Text = entry.Text.Replace(entry.Placeholder, "");
        }

        private void ShowPassword(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;

            ExtClickToShowPassword.Text = PasswordEntry.IsPassword
                ? _resServ.GetText("ClickHereToShowPasswordExtendedLabel")
                : _resServ.GetText("ClickHereToHidePasswordExtendedLabel");
        }

        private void ShowLoginLoadIcon(bool value)
        {
            LoadingIcon.IsVisible = value;
        }
    }
}