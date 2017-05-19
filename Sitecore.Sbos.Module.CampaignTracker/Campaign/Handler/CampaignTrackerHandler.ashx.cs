using System.Web;
using Sitecore.Analytics;
using Sitecore.Analytics.Data.Items;
using Sitecore.Analytics.Model;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web;
using System;
using System.Web.Mvc;
using System.Web.SessionState;

namespace Sitecore.Sbos.Module.CampaignTracker.Campaign.Handler
{
    /// <summary>
    /// Summary description for CampaignTrackerHandler1
    /// </summary>
    public class CampaignTrackerHandler1 : IHttpHandler, IRequiresSessionState
    {
        [HttpGet]
        public void ProcessRequest(HttpContext context)
        {                                                                                                                                                                                                   
            var gid = context.Request.QueryString["gid"];
            var triggerCampaign = context.Request.QueryString["triggerCampaign"];

            bool isTriggerCampaign = false;
            bool.TryParse(triggerCampaign.ToString(), out isTriggerCampaign);

            if (!string.IsNullOrEmpty(gid.ToString()) && isTriggerCampaign)
            {
                if (!Tracker.IsActive)
                {
                    Tracker.StartTracking();
                }

                if (Tracker.IsActive)
                {
                    if (Tracker.Current.CurrentPage != null)
                    {
                        var id = new Sitecore.Data.ID(gid.ToString());
                        Item campaignItem = Context.Database.GetItem(id);
                        CampaignItem campaignToTrigger = new CampaignItem(campaignItem);

                        if (campaignToTrigger != null)
                        {
                            Tracker.Current.CurrentPage.TriggerCampaign(campaignToTrigger);
                            Console.WriteLine("Campaign is successfully triggered.");
                        }
                        else
                        {
                            Log.Error("Campaign with ID " + gid + " does not exist", this);
                        }
                    }
                    else
                    {
                        Log.Error("Tracker.Current.CurrentPage is null", this);
                    }
                }
                else
                {
                    Log.Warn("The tracker is not active. Unable to register the campaign.", this);
                }
            }
            else
            {
                Log.Warn("There is no campaign selected.", this);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}