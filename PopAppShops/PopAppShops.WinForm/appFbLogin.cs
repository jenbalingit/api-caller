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

namespace PopAppShops.WinForm
{
    public partial class appFbLogin : Form
    {
        Customer customerAPI;
        public appFbLogin(Action<string, string, HttpMethod, bool, string, string, string> Logger)
        {
            InitializeComponent();
            customerAPI = new Customer((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }, Logger);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            webbrowser.Url = new Uri(textBox1.Text);
            webbrowser.ScriptErrorsSuppressed = true;
            webbrowser.DocumentCompleted += Webbrowser_DocumentCompleted;
        }

        private void Webbrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            textBox1.Text = e.Url.AbsoluteUri;
            if (e.Url.AbsoluteUri.Contains("access_token"))
            {
                var data = e.Url.Fragment.Split(new char[] { '&' }, StringSplitOptions.RemoveEmptyEntries);
                if(data.Length > 1)
                {
                    string accessToken = data[0].Replace("#access_token=","");
                    txtaccesstoken.Text = accessToken;
                }
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            //lblstatus.Text = "Trying to register access token to the server. Please wait...";
            //var result = await customerAPI.RegisterFacebook(txtaccesstoken.Text);

            lblstatus.Text = "Trying to login access token to the server. Please wait...";
            var token = await customerAPI.LoginFacebook(txtaccesstoken.Text);
            if (token.IsSuccess)
            {
                new TextFileManager<string>(@"c:\popappsdata\authticket.txt").SaveChanges(token.Token.Replace("\"", ""));
                MessageBox.Show("Login Success", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblstatus.Text = "Done";
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void appFbLogin_Load(object sender, EventArgs e)
        {

        }
    }
}
