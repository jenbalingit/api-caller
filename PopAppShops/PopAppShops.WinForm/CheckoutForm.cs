using PopAppShops.API;
using PopAppShops.API.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAppShops.WinForm
{
    public partial class CheckoutForm : Form
    {
        public CheckoutForm()
        {
            InitializeComponent();
        }

        private async void btnCheckout_Click(object sender, EventArgs e)
        {
            try
            {
                var c = new Checkout();
                var login = await c.CheckoutLogin(txtpassword.Text);
                if (!string.IsNullOrEmpty(login))
                {
                    var dto = new API.DTO.DTOs.Checkout();
                    dto.AddressID = 0;
                    dto.SuccessUrl = ServiceConfig.SuccessUrl;
                    dto.FailUrl = ServiceConfig.FailUrl;
                    dto.CancelUrl = ServiceConfig.CancelUrl;
                    dto.IsCredicard = cmbpaymentmethod.Text.Equals("CreditCard") ? API.DTO.DTOs.PaymentMethod.CreditCard : 
                                                                                   API.DTO.DTOs.PaymentMethod.Cash;
                    dto.CheckoutSessionID = login;
                    dto.ShippingMethod = cmdshippingmethod.Text;
                    dto.MeetUpDate = DateTime.Now;
                    dto.MeetUpDetailID = 1;
                    var checkout = await c.CheckoutOrder(dto);
                    if (dto.IsCredicard == API.DTO.DTOs.PaymentMethod.CreditCard) System.Diagnostics.Process.Start(checkout.RedirectUrl);
                    else MessageBox.Show(checkout.TransactionID);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var c = new Checkout();
            var login = await c.SocialCheckoutLogin(txtpassword.Text);
        }
    }
}
