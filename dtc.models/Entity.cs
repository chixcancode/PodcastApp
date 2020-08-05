using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace dtc.models
{
    public enum ItemCollectionTypes
    {
       Episode,
       Host,
       Guest
    }
    public class Entity
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; } = "";

        [JsonProperty(PropertyName = "upsertDate")]
        public DateTime UpsertDate { get; set; } = DateTime.Now;

        [JsonProperty(PropertyName = "collectionType")]
        public ItemCollectionTypes CollectionType { get; set; }
    }
}
