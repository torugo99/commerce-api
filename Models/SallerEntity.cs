using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

#nullable disable warnings
namespace Commerce.Models
{
    public class Saller
    {
        [Column("saller_id")]
        [Key]
        [JsonIgnore]
        public int SallerId { get; set; }

        [Column("saller_name_saller")]
        public string NameSaller { get; set; }

        [Column("saller_cpf")]
        public string Cpf { get; set; }

        [Column("saller_email")]
        public string Email { get; set; }

        [Column("saller_active")]
        public bool Active { get; set; }

        [Column("saller_telephone")]
        public string Telephone { get; set; }

        [Column("saller_created_at")]
        public DateTime CreatedAt { get; set; }

        [Column("saller_updated_at")]
        public DateTime UpdatedAt { get; set; }
    }
}