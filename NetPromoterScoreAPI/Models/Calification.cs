using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NetPromoterScoreAPI.Models
{
    public class Calification
    {
        [Key, ForeignKey("Conductor")]
        public int IdUser { get; set; }

        [Required]
        [Range(0, 10)]
        public decimal Score { get; set; }
    }
}