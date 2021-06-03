using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AW.Services.Interfaces
{
    public interface INotificationSender
    {
        void SendMessage(string email, string message);
    }
}
