using System;
using Newtonsoft.Json;

namespace ConfigDemo.Models
{
        public class ClientActions
        {
        [JsonProperty(PropertyName = "purgeLocal")]
        public DateTime? PurgeLocal { get; set; } = null;
        }
    }