using System.Collections.Generic;
using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class ClientObject
    {
        [JsonProperty(PropertyName = "analyticsTrackingCode")]
        public string AnalyticsTrackingCode { get; set; }

        [JsonProperty(PropertyName = "minimumVersion")]
        public string MinimumVersion { get; set; }

        [JsonProperty(PropertyName = "currentVersion")]
        public string CurrentVersion { get; set; }

        [JsonProperty(PropertyName = "clientActions")]
        public ClientActions ClientActions { get; set; }

        [JsonProperty(PropertyName = "featureFlags")]
        public FeatureFlags FeatureFlags { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<object> Messages { get; set; }
    }
}