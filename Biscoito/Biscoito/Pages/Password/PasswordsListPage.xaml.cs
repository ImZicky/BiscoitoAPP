using Biscoito.Service;
using DTO;
using Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using IPasswordService = Biscoito.Service.IPasswordService;

namespace Biscoito.Pages.Password
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordsListPage : ContentPage
    {

        private readonly IPasswordService _serv;

        public PasswordsListPage()
        {
            InitializeComponent();
            _serv = DependencyService.Resolve<IPasswordService>();

            lstSenhas.ItemsSource = _serv.GetPasswordList();
        }


        private async void GetDecryptedPassword(object sender, ItemTappedEventArgs e)
        {
            var pass = e.Item as PasswordDTO;
            var senhaDescriptografada = DigitalFortressService.Decrypt(pass.Valor, "BEJLLMMT#22");
            await Clipboard.SetTextAsync(senhaDescriptografada);
        }

        private async void CallCreateNewPasswordModal(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync((Page)Activator.CreateInstance(typeof(CreatePasswordPage)), true);
        }







    }
}