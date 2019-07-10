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
using Core.Cryptography;
using System.Net;
using System.Net.Http;

namespace PopAppShops.WinForm
{
    public partial class appInit : Form
    {
        Device deviceAPI;
        public appInit()
        {
            InitializeComponent();
            deviceAPI = new Device((data) =>
            {
                MessageBox.Show(data.ExceptionMessage, data.Message, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            });
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            System.IO.File.Delete("c:\\popappsdata\\device.txt");
            System.IO.File.Delete("c:\\popappsdata\\authticket.txt");
            lblstatus.Text = "Registering device please wait...";
            var clientTokenFile = new TextFileManager<DTOs.Device.ClientToken>(@"c:\popappsdata\device.txt");
            var savedToken = clientTokenFile.RetreiveFiles();
            if (savedToken == null)
            {
                var device = new DTOs.Device.DeviceLoginCredentials
                {
                    Code = "Decode12345",
                    Description = "The Descriptive5",
                    ApplicationID = "MOTOLITE",
                    UserID = 29

                };

                try
                {
                    bool result = await deviceAPI.DeviceRegister(device, (err) =>
                    {
                        lblstatus.Text = "Device Registration Complete Result: " + err.ExceptionMessage;
                    });

                    if (result)
                        lblstatus.Text = "Device Registration Complete Result: " + result.ToString();

                    
                }
                catch (Exception)
                {

                }



                lblstatus.Text = "Logging in Device Please wait...";
                var token = await deviceAPI.DeviceLogin(device);

                if (token != null)
                {
                    lblstatus.Text = "Device Successfullly logged in.";
                    clientTokenFile.SaveChanges(token);
                }


            }
            else
            {
                lblstatus.Text = "App is already registered and Logged In.";
            }
            btnProceed.Visible = true;
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            this.Hide();
            new appMain().Show();
        }
    }
    
}
