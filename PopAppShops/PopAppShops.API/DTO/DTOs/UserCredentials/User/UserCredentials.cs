using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopAppShop.Backend.DTOs.User
{
    public class UserCredentials : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        string emailAddress;
        string password;

        public string EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                emailAddress = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("EmailAddress"));
                }
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this,
                        new PropertyChangedEventArgs("Password"));
                }
            }
        }

        public long MerchantID { get; set; }
        public string ApplicationID { get; set; }
    }
}
