using Cinema.Data.Models.Enums;
using Newtonsoft.Json;

namespace Cinema.DataProcessor.ExportDto
{
    public class ExportMovieDto
    {
        [JsonProperty("Title")]
        public string Title { get; set; }

        [JsonProperty("Genre")]
        public string Genre { get; set; }

        [JsonProperty("Duration")]
        public string Duration { get; set; }

        [JsonProperty("Rating")]
        public double Rating { get; set; }

        [JsonProperty("Director")]
        public string Director { get; set; }
    }
}
