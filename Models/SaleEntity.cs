using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable warnings
namespace Commerce.Models
{
     public class Sale
    {
        [Column("sale_id")]
        [Key]
        [JsonIgnore]
        public int SaleId { get; set; }

        [Column("sale_name")]
        public string Name { get; set; }

        [Column("saller_id")]
        public int? SallerId { get; set; }
        
        [ForeignKey("SallerId")]
        [JsonIgnore]
        public Saller? Saller { get; set; }

        [Column("product_id")]
        public int? ProductId { get; set; }

        [ForeignKey("ProductId")]
        [JsonIgnore]
        public virtual Product? Product { get; set; }
        
        [Column("sale_product_value_total")]
        public decimal TotalValueProduct { get; set; }
        
        [Column("sale_status")]
        public StatusEnum? Status { get; set; }

        [Column("sale_created_at")]
        public DateTime CreatedAt { get; set; }
        
        [Column("sale_updated_at")]
        public DateTime UpdatedAt { get; set; }
        
    }
}