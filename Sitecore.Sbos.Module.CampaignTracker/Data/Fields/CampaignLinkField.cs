using Sitecore.Data.Fields;

namespace Sitecore.Sbos.Module.CampaignTracker.Data.Fields
{
    public class CampaignLinkField : LinkField
    {
        public CampaignLinkField(Field innerField)
            : base(innerField)
        {
        }

        public CampaignLinkField(Field innerField, string runtimeValue)
            : base(innerField, runtimeValue)
        {
        }

        public string Campaign
        {
            get
            {
                return GetAttribute("campaign");
            }
            set
            {
                this.SetAttribute("campaign", value);
            }
        }

        public string TriggerCampaign
        {
            get
            {
                return GetAttribute("triggercampaign");
            }
            set
            {
                this.SetAttribute("triggercampaign", value);
            }
        }
    }
}