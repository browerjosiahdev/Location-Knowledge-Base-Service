using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace LocationKnowledgeBase.Models
{
    public class KnowledgeModel
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "body")]
        public string Body { get; set; }
        [JsonProperty(PropertyName = "macAddress")]
        public string MacAddress { get; set; }
        [JsonProperty(PropertyName = "rssi")]
        public int RSSI { get; set; }
        [JsonProperty(PropertyName = "url")]
        public string URL { get; set; }
    }

    public class KnowledgeItemRequestDataModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "rssi")]
        public int RSSI { get; set; }
    }
}