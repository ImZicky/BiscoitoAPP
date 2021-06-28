using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Biscoito.Service
{

    public interface IPasswordService
    {
        ObservableCollection<PasswordDTO> GetPasswordList();
    }

    public class PasswordService : IPasswordService
    {
        public ObservableCollection<PasswordDTO> GetPasswordList()
        {
            // TODO: REALIZA O GET NO SITE DA LISTA, DEPOIS TRANSFORMA EM OBSERVABLEcOLEECTION E DEVOLVE
            throw new NotImplementedException();
        }







    }
}
