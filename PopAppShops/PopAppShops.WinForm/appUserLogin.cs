using PopAppShops.API;
using PopAppShops.API.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTOs = PopAppShop.Backend.DTOs;
namespace PopAppShops.WinForm
{
    public partial class appUserLogin : Form
    {
        Customer customerAPI;
        public appUserLogin(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            customerAPI = new Customer((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }, Logger);
            txtemail.Text = "the.bikers.qc@basecamptech.ph";
            txtpassword.Text = "Qwerty1-8";
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            var result = await customerAPI.Login(new DTOs.User.UserCredentials
            {
                EmailAddress = txtemail.Text,
                ApplicationID = "MOTOLITE",
                Password = txtpassword.Text,
                BranchId = 607
            });

            if (result.IsSuccess)
            {
                MessageBox.Show("Login Success", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new TextFileManager<string>(@"c:\popappsdata\authticket.txt").SaveChanges(result.Token.Replace("\"",""));
                this.Hide();
            }
            else
                MessageBox.Show(result.Message, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var result = await customerAPI.ForgotPassword(txtemail.Text);
            if(result)
                MessageBox.Show("Forgot password link is sent on your email", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
