using Newtonsoft.Json;
using System.Collections.Generic;

namespace CarDealer.DTO
{
    public class ExportCarPartsDto
    {
        [JsonProperty("car")]
        public ExportCarDto Car { get; set; }

        [JsonProperty("parts")]
        public ICollection<ExportPartDto> Parts { get; set; }
    }
}
