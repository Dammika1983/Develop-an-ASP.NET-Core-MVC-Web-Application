using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MvcMoto.Models
{
    public class Moto
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string? Name { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public string? Circuit { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Required]

        public String? Team { get; set; }
        [Required]
        [Display(Name = "World Rank")]
        public int WorldRank { get; set; }
        [Required]
        [Display(Name = "Driver Number")]
        public int DriverNumber { get; set; }

    }
}
