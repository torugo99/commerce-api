using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable warnings
namespace Commerce.Models
{
    public class Product
    {  

        [Column("product_id")]
        [Key]
        [JsonIgnore]
        public int ProductId { get; set; }

        [Column("product_name")]
        public string Name { get; set; }

        [Column("product_description")]
        public string Description{ get; set; }

        [Column("product_value")]
        public decimal Value { get; set; }
    }
}