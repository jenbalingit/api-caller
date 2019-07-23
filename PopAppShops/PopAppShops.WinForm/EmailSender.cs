using MailChimp;
using MailChimp.Helper;
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
    public partial class EmailSender : Form
    {
        public EmailSender()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMailChimpManager mailChimpManager = new MailChimpManager("aca9d814b6f3969bc062f2449777f529-us3");

            EmailParameter results = mailChimpManager.Subscribe("ef20891974", new EmailParameter { Email = "jeneson.balingit@basecamptech.ph" });
            
        }
    }
}
