using System;
using System.Collections.Generic;
using System.Text;

namespace Biscoito.Service
{
    public interface IMessageService
    {
        void LongAlert(string message);
        void ShortAlert(string message);
    }
}
