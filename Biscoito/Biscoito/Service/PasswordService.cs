using Biscoito.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Biscoito.Service
{

    public interface IPasswordService
    {
        ObservableCollection<Password> GetPasswordList();
    }

    public class PasswordService : IPasswordService
    {
        public ObservableCollection<Password> GetPasswordList()
        {
            // TODO: REALIZA O GET NO SITE DA LISTA, DEPOIS TRANSFORMA EM OBSERVABLEcOLEECTION E DEVOLVE
            throw new NotImplementedException();
        }







    }
}
