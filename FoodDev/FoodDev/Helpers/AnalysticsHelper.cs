using Microsoft.AppCenter.Analytics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FoodDev.Helpers
{
    public class AnalysticsHelper
    {
        public async static Task TrackEventAsync(string eventName, Dictionary<string, string> properties = null)
        {
            if (await Analytics.IsEnabledAsync())
            {
                Analytics.TrackEvent(eventName, properties);
            }
        }
    }
}
