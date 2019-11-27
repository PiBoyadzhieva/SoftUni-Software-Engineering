using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Items
{
    public class CreateItemInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.01", "5000.00")]
        public decimal Price { get; set; }

        public string CategoryName { get; set; }
    }
}
