using System;
using System.Collections.Specialized;
using System.Xml;
using Sitecore.Diagnostics;
using Sitecore.Shell.Applications.Dialogs;
using Sitecore.Shell.Applications.Dialogs.ExternalLink;
using Sitecore.Web.UI.HtmlControls;
using Sitecore.Web.UI.Sheer;
using Sitecore.Xml;

namespace Sitecore.Sbos.Module.CampaignTracker.sitecore.shell.Applications.Dialogs.ExternalLink
{
    public class CampaignExternalLink : ExternalLinkForm
    {
        private const string CampaignAttributeName = "campaign";

        private const string CampaignTriggerAttName = "triggercampaign";

        protected Combobox Campaign;

        protected Checkbox TriggerCampaign;

        private NameValueCollection campaignLinkAttributes;
        protected NameValueCollection CampaignLinkAttributes
        {
            get
            {
                if (campaignLinkAttributes == null)
                {
                    campaignLinkAttributes = new NameValueCollection();
                    ParseLinkAttributes(GetLink());
                }

                return campaignLinkAttributes;
            }
        }

        protected override void ParseLink(string link)
        {
            base.ParseLink(link);
            ParseLinkAttributes(link);
        }

        protected virtual void ParseLinkAttributes(string link)
        {
            Assert.ArgumentNotNull(link, "link");
            XmlDocument xmlDocument = XmlUtil.LoadXml(link);
            if (xmlDocument == null)
            {
                return;
            }

            XmlNode node = xmlDocument.SelectSingleNode("/link");
            if (node == null)
            {
                return;
            }

            CampaignLinkAttributes[CampaignAttributeName] = XmlUtil.GetAttribute(CampaignAttributeName, node);
            CampaignLinkAttributes[CampaignTriggerAttName] = XmlUtil.GetAttribute(CampaignTriggerAttName, node);
        }

        protected override void OnLoad(EventArgs e)
        {
            Assert.ArgumentNotNull(e, "e");
            base.OnLoad(e);
            if (Context.ClientPage.IsEvent)
            {
                return;
            }

            LoadControls();
        }

        protected virtual void LoadControls()
        {
            string campaignValue = CampaignLinkAttributes[CampaignAttributeName];
            string triggerCampaignValue = CampaignLinkAttributes[CampaignTriggerAttName];

            if (!string.IsNullOrWhiteSpace(campaignValue))
            {
                Campaign.Value = campaignValue;
                TriggerCampaign.Value = triggerCampaignValue;
            }
        }

        protected override void OnOK(object sender, EventArgs args)
        {
            Assert.ArgumentNotNull(sender, "sender");
            Assert.ArgumentNotNull(args, "args");
            string path = GetPath();
            string attributeFromValue = LinkForm.GetLinkTargetAttributeFromValue(Target.Value, CustomTarget.Value);
            Packet packet = new Packet("link", new string[0]);
            LinkForm.SetAttribute(packet, "text", (Control)Text);
            LinkForm.SetAttribute(packet, "linktype", "external");
            LinkForm.SetAttribute(packet, "url", path);
            LinkForm.SetAttribute(packet, "anchor", string.Empty);
            LinkForm.SetAttribute(packet, "title", (Control)Title);
            LinkForm.SetAttribute(packet, "class", (Control)Class);
            LinkForm.SetAttribute(packet, "target", attributeFromValue);

            TrimComboboxControl(Campaign);
            LinkForm.SetAttribute(packet, CampaignTriggerAttName, (Control)TriggerCampaign);
            LinkForm.SetAttribute(packet, CampaignAttributeName, (Control)Campaign);

            SheerResponse.SetDialogValue(packet.OuterXml);
            SheerResponse.CloseWindow();
        }

        private string GetPath()
        {
            string url = this.Url.Value;
            if (url.Length > 0 && url.IndexOf("://", StringComparison.InvariantCulture) < 0 && !url.StartsWith("/", StringComparison.InvariantCulture))
            {
                url = string.Concat("http://", url);
            }

            return url;
        }

        protected virtual void TrimComboboxControl(Combobox control)
        {
            if (control == null || string.IsNullOrEmpty(control.Value))
            {
                return;
            }

            control.Value = control.Value.Trim();
        }
    }
}