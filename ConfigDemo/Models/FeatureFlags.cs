using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class FeatureFlags
    {
        [JsonProperty(PropertyName = "mobile_wa")]
        public bool MobileWA { get; set; }

        [JsonProperty(PropertyName = "promotions")]
        public bool Promotions { get; set; }

        [JsonProperty(PropertyName = "covid19_banner")]
        public bool Covid19Banner { get; set; }

        [JsonProperty(PropertyName = "racial_sensitivity_banner")]
        public bool RacialSensitivityBanner { get; set; }

        [JsonProperty(PropertyName = "websockets")]
        public bool Websockets { get; set; }
    }
}