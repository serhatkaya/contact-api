using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [Key] public string Id { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string? CreatedUser { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? UpdatedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? UpdatedUser { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool Deleted { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? DeletedDate { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? DeletedUser { get; set; }
    }
}
