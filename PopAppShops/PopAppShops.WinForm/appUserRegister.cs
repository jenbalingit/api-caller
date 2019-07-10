using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopAppShops.API.API;
using DTOs = PopAppShop.Backend.DTOs;
using Newtonsoft.Json;
using PopAppShops.API;
using System.Net.Http;

namespace PopAppShops.WinForm
{
    public partial class appUserRegister : Form
    {
        Customer customerAPI;
        public appUserRegister(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            customerAPI = new Customer((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }, Logger);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await customerAPI.Register(new API.DTO.UserInfo
            {
                EmailAddress = txtemail.Text,
                FirstName = txtfname.Text,
                LastName = txtlname.Text,
                MiddleName = txtmname.Text,
                Password = txtpassword.Text
            });

            MessageBox.Show(result.ToString(), "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
