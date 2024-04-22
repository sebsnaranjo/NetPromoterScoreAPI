﻿using System.ComponentModel.DataAnnotations;

namespace NetPromoterScoreAPI.DTOs
{
    public class UserDTO
    {
        [Key]
        public int IdUser { get; set; }

        [Required]
        public int CC { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

        [Required]
        public int Role { get; set; }
    }
}
