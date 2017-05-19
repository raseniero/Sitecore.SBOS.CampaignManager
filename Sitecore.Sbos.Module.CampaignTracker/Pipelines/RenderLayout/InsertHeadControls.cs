using Sitecore.Mvc.Pipelines.Response.GetPageRendering;
using Sitecore.Mvc.Pipelines.Response.RenderRendering;
using Sitecore.Mvc.Presentation;
using Sitecore.Pipelines.InsertRenderings;
using Sitecore.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Xml;

namespace Sitecore.Sbos.Module.CampaignTracker.Pipelines.RenderLayout
{
    public class InsertHeadControls : RenderRenderingProcessor
    {
        public override void Process(RenderRenderingArgs args)
        {
            if (Sitecore.Context.Site.Name == "shell")
            {
                return;
            }
            
            if (!args.Writer.ToString().Contains(Data.Constants.CampaignTrackerConstants.CampaignTrackerMgdJSPath))
            {
                if (args.Writer.ToString().Contains("<title>"))
                {
                    args.Writer.WriteLine(Data.Constants.CampaignTrackerConstants.JQueryScript);
                    args.Writer.WriteLine(Data.Constants.CampaignTrackerConstants.CampaignTrackerMgrScript);
                }             
            }
            
        }
    }
}