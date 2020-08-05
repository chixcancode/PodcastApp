using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dtc.models
{
    public enum EpisodeStatus
    {
        Created,
        InProgress,
        Publishing,
        Published
    }
    public class Episode : Entity
    {
        [JsonProperty("code", NullValueHandling = NullValueHandling.Include)]
        public string Code { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Include)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [JsonProperty("number", NullValueHandling = NullValueHandling.Include)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Episode Nubmer is required")]
        public string Number { get; set; }

        [JsonProperty("publishDate", NullValueHandling = NullValueHandling.Include)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Publish Date is required")]
        public DateTime PublishDate { get; set; }

        [JsonProperty("showNotes", NullValueHandling = NullValueHandling.Include)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Show Notes are required")]
        public string ShowNotes { get; set; }
        [JsonProperty("tags", NullValueHandling = NullValueHandling.Include)]
        public List<string> Tags { get; set; }
        [JsonProperty("publishUrl", NullValueHandling = NullValueHandling.Include)]
        public string PublishUrl { get; set; }
        [JsonProperty("status", NullValueHandling = NullValueHandling.Include)]
        public EpisodeStatus Status { get; set; } = EpisodeStatus.Created;
    }
}
