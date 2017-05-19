using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Sitecore.Data.Items;
using Sitecore.Pipelines;
using Sitecore.Sbos.Module.CampaignTracker.Campaign.Interfaces;
using System;
using System.Reflection;
using System.Web;

namespace Sitecore.Sbos.Module.CampaignTracker.Campaign
{
    public class CampaignProvider : ICampaignProviderProcessor
    {
        public void Process(PipelineArgs args)
        {
            SetCampaignFieldValue();
        }
        public List<Item> GetCampaignItems(string path)
        {
            Sitecore.Data.Database context = Sitecore.Configuration.Factory.GetDatabase("master");           
            Item item = context.SelectSingleItem(path);
            List<Item> items = item.Axes.GetDescendants().Where(x => x.TemplateID.ToString() == "{94FD1606-139E-46EE-86FF-BC5BF3C79804}").ToList();
            return items;

        }

        public void SetCampaignFieldValue()
        {
            string webRooPath = GetWebRootPath("Sitecore.Sbos.Module.CampaignTracker");

            if (!string.IsNullOrEmpty(webRooPath))
            {
                var campaignitems = GetCampaignItems(Data.Constants.CampaignTrackerConstants.SitecoreCampaignPath + "Social/");
                var campaignitemshabitat = GetCampaignItems(Data.Constants.CampaignTrackerConstants.SitecoreCampaignPath + "Habitat/");

                if (campaignitems != null)
                {
                    XmlDocument xdoc = new XmlDocument();
                    xdoc.Load(webRooPath + Data.Constants.CampaignTrackerConstants.ExternalFormPath);
                    XmlNodeList nodeList = xdoc.GetElementsByTagName("Combobox");

                    if (nodeList.Count > 1)
                    {
                        XmlElement campaignElement = (XmlElement)nodeList[1];
                        campaignElement.IsEmpty = true;
                        XmlElement listItemEmpty = xdoc.CreateElement("ListItem");

                        listItemEmpty.SetAttribute("Value", string.Empty);
                        listItemEmpty.SetAttribute("Header", string.Empty);
                        listItemEmpty.RemoveAttribute("xmlns");

                        campaignElement.AppendChild(listItemEmpty);

                        foreach (var item in campaignitems)
                        {
                            var itemName = item.DisplayName;
                            var itemID = item.ID;
                            var itemSC = item.Fields[new Sitecore.Data.ID("{B0114342-587F-4753-87A2-308CC7AEE48D}")];

                             XmlElement listItem = xdoc.CreateElement("ListItem");

                             listItem.SetAttribute("Value", itemID.ToString());
                             listItem.SetAttribute("Header", itemName.ToString());
                             listItem.RemoveAttribute("xmlns");

                             campaignElement.AppendChild(listItem);
                        }

                        foreach (var item in campaignitemshabitat)
                        {
                            var itemName = item.DisplayName;
                            var itemID = item.ID;
                            var itemSC = item.Fields[new Sitecore.Data.ID("{B0114342-587F-4753-87A2-308CC7AEE48D}")];

                            XmlElement listItem = xdoc.CreateElement("ListItem");

                            listItem.SetAttribute("Value", itemID.ToString());
                            listItem.SetAttribute("Header", itemName.ToString());
                            listItem.RemoveAttribute("xmlns");

                            campaignElement.AppendChild(listItem);
                         }

                        xdoc.Save(webRooPath + Data.Constants.CampaignTrackerConstants.ExternalFormPath);
                    } 
                }
            }
        }

        public string GetWebRootPath(string assembly)
        {
            string assemblyLoc = Assembly.Load(assembly).CodeBase;

            if (!string.IsNullOrEmpty(assemblyLoc))
            {
                assemblyLoc = assemblyLoc.Replace("file:///", "");
                string webRootPath = assemblyLoc.Replace(Data.Constants.CampaignTrackerConstants.AssemblyCampaignTrackerPath, "");

                return webRootPath ?? string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }
    }
}