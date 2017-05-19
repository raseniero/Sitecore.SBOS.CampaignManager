using System.Xml;
using Sitecore.Pipelines.RenderField;
using Sitecore.Xml;

namespace Sitecore.Sbos.Module.CampaignTracker.Pipelines.RenderField
{
    public class SetCampaignAttributeOnLink
    {
        private string CampaignXmlAttributeName { get; set; }

        private string CampaignAttributeName { get; set; }

        private string BeginningHtml { get; set; }

        public void Process(RenderFieldArgs args)
        {
            if (!CanProcess(args))
            {
                return;
            }

            string isTriggerCampaign = string.Empty;

            if (!string.IsNullOrEmpty(GetXmlAttributeValue(args.FieldValue, "triggercampaign")))
            {
                if (GetXmlAttributeValue(args.FieldValue, "triggercampaign") == "1")
                {
                    isTriggerCampaign = "true";
                }
                else
                {
                    isTriggerCampaign = "false";
                }
            }
            else
            {
                isTriggerCampaign = "false";
            }

            args.Result.FirstPart = AddCampaignAttributeValue(args.Result.FirstPart, CampaignAttributeName, GetXmlAttributeValue(args.FieldValue, CampaignXmlAttributeName));
            args.Result.FirstPart = AddCampaignAttributeValue(args.Result.FirstPart, "triggercampaign", isTriggerCampaign);
            args.Result.FirstPart = AddCampaignAttributeValue(args.Result.FirstPart, "onclick", "activateSelectedCampaign('" + GetXmlAttributeValue(args.FieldValue, CampaignXmlAttributeName) + "', '" + isTriggerCampaign + "');");
        }

        protected virtual bool CanProcess(RenderFieldArgs args)
        {
            return !string.IsNullOrWhiteSpace(CampaignAttributeName)
                    && !string.IsNullOrWhiteSpace(BeginningHtml)
                    && !string.IsNullOrWhiteSpace(CampaignXmlAttributeName)
                    && args != null
                    && args.Result != null
                    && HasXmlAttributeValue(args.FieldValue, CampaignAttributeName)
                    && !string.IsNullOrWhiteSpace(args.Result.FirstPart)
                    && args.Result.FirstPart.ToLower().StartsWith(BeginningHtml.ToLower());
        }

        protected virtual bool HasXmlAttributeValue(string linkXml, string attributeName)
        {
            return !string.IsNullOrWhiteSpace(GetXmlAttributeValue(linkXml, attributeName));
        }

        protected virtual string GetXmlAttributeValue(string linkXml, string attributeName)
        {
            XmlDocument xmlDocument = XmlUtil.LoadXml(linkXml);
            if (xmlDocument == null)
            {
                return string.Empty;
            }

            XmlNode node = xmlDocument.SelectSingleNode("/link");
            if (node == null)
            {
                return string.Empty;
            }

            return XmlUtil.GetAttribute(attributeName, node);
        }

        protected virtual string AddCampaignAttributeValue(string html, string attributeName, string attributeValue)
        {
            if (string.IsNullOrWhiteSpace(html) || string.IsNullOrWhiteSpace(attributeName) || string.IsNullOrWhiteSpace(attributeValue))
            {
                return html;
            }

            int index = html.LastIndexOf(">");
            if (index < 0)
            {
                return html;
            }

            string firstPart = html.Substring(0, index);
            string attribute = string.Format(" {0}=\"{1}\"", attributeName, attributeValue);
            string lastPart = html.Substring(index);
            return string.Concat(firstPart, attribute, lastPart);
        }
    }
}