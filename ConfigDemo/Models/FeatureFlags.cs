using Newtonsoft.Json;

namespace ConfigDemo.Models
{
    public class FeatureFlags
    {
        [JsonProperty(PropertyName = "mobile_wa")]
        public bool? MobileWA { get; set; } = null;

        [JsonProperty(PropertyName = "promotions")]
        public bool? Promotions { get; set; } = null;

        [JsonProperty(PropertyName = "covid19_banner")]
        public bool? Covid19Banner { get; set; } = null;

        [JsonProperty(PropertyName = "racial_sensitivity_banner")]
        public bool? RacialSensitivityBanner { get; set; } = null;

        [JsonProperty(PropertyName = "websockets")]
        public bool? Websockets { get; set; } = null;
    }
}