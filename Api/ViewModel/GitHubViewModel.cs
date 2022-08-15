using System.Text.Json.Serialization;

namespace Api.ViewModel
{
    public class GitHubViewModel
    {

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("created_at")]
        public string CreatedAt { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }
    }
}
