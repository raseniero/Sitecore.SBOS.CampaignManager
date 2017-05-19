function activateSelectedCampaign(campaignId, isTriggerCampaign)
{
    $.ajax({
                url: "/Campaign/Handler/CampaignTrackerHandler.ashx",
                type: "GET",
                data: { gid: campaignId, triggerCampaign: isTriggerCampaign },
                context: this,
                success: function (data) {
                    
                    if(isTriggerCampaign == "true")
                    {
                        alert("Campaign has been triggered", data);
                    }
                    else
                    {
                        alert("Campaign is not been triggered", data);
                    }
                },
                error: function (data) {
                    alert("Campaign is not been triggered", data);
                }
          });
}
