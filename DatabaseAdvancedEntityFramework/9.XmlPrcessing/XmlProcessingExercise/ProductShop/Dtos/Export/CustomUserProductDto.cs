namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class CustomUserProductDto
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public UserAndProductDto[] UserAndProductDto { get; set; }
    }
}
