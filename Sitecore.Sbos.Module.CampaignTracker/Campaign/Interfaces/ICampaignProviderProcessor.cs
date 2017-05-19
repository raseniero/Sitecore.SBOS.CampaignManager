using Sitecore.Pipelines;

namespace Sitecore.Sbos.Module.CampaignTracker.Campaign.Interfaces
{
    public interface ICampaignProviderProcessor
    {
        void Process(PipelineArgs args);
    }
}
