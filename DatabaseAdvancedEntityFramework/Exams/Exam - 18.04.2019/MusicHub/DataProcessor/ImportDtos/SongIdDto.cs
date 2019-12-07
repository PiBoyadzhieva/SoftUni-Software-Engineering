namespace MusicHub.DataProcessor.ImportDtos
{
    using System.Xml.Serialization;

    [XmlType("Song")]
    public class SongIdDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }
    }
}