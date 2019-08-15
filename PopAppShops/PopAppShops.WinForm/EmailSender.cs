using MailChimp.Net;
using MailChimp.Net.Core;
using MailChimp.Net.Interfaces;
using MailChimp.Net.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PopAppShops.WinForm
{
    public partial class EmailSender : Form
    {

        private readonly MailChimpManager _mailChimpManager;

        public EmailSender()
        {
            InitializeComponent();
            _mailChimpManager = new MailChimpManager("aca9d814b6f3969bc062f2449777f529-us3");
        }

        private Setting _campaignSettings = new Setting
        {
            ReplyTo = "jeneson.balingit@basecamptech.ph",
            FromName = "Jeneson Balingit",
            Title = "Sample test with custom Template",
            SubjectLine = "Sample Subject",
        };

        private const string ListId = "ef20891974";
        private const int TemplateId = 3206307; // (your template id)

        public async Task CreateAndSendCampaign(string html)
        {
            var campaign = await _mailChimpManager.Campaigns.AddOrUpdateAsync(new Campaign
            {
                Settings = _campaignSettings,
                Recipients = new Recipient { ListId = ListId },
                Type = CampaignType.Regular


            });

            //var campaign = await _mailChimpManager.Campaigns.AddAsync(new Campaign
            //{
            //    Settings = _campaignSettings,
            //    Recipients = new Recipient { ListId = ListId },
            //    Type = CampaignType.Regular
            //});

            
            var timeStr = DateTime.Now.ToString();
            var content = _mailChimpManager.Content.AddOrUpdateAsync(campaign.Id, new ContentRequest()
            {
                Template = new ContentTemplate
                {
                    Id = TemplateId,
                    
                    Sections = new Dictionary<string, object>()
                                {
                                   { "body_content", html },
                                   { "preheader_leftcol_content", $"<p>{timeStr}</p>" }
                                }
                }
            }).Result;

            

            await _mailChimpManager.Campaigns.SendAsync(campaign.Id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //IMailChimpManager mailChimpManager = new MailChimpManager("");

            ////EmailParameter results = mailChimpManager.Subscribe("ef20891974", new EmailParameter { Email = "jeneson.balingit@basecamptech.ph" });
            //var camContent = mailChimpManager.GetCampaignContent("0505a42d35");
            //camContent.Html = "Hello world!";
            //var send = mailChimpManager.SendCampaignTest("0505a42d35", new List<string> { "jeneson.balingit@basecamptech.ph" }, "");

            CreateAndSendCampaign($"<h3>Hello World!  { DateTime.UtcNow }</h3>");

        }
    }
}
