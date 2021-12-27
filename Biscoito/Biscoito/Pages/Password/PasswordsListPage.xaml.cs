using Biscoito.ViewModel;
using Biscoito.Service;
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

        //TODO: ESCONDER MELHOR A SENHA e pensar numa maneira melhor de realizar isso
        private async void GetDecryptedPassword(object sender, ItemTappedEventArgs e)
        {
            var pass = e.Item as Biscoito.ViewModel.Password;
            var senhaDescriptografada = DigitalFortressService.Decrypt(pass.Valor, "TODO: TIRAR ISSO AQUI");
            await Clipboard.SetTextAsync(senhaDescriptografada);
        }

        private async void CallCreateNewPasswordModal(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync((Page)Activator.CreateInstance(typeof(CreatePasswordPage)), true);
        }







    }
}