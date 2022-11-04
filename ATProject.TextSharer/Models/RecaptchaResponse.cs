using Newtonsoft.Json;
using System.Collections.Generic;
using System;

namespace ATProject.TextSharer.API.Models
{
    public class RecaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("error-codes")]
        public IEnumerable<string> ErrorCodes { get; set; }
        [JsonProperty("challenge_ts")]
        public DateTime ChallengeTs { get; set; }
        [JsonProperty("hostname")]
        public string Hostname { get; set; }
        [JsonProperty("score")]
        public decimal Score { get; set; }
    }
}
