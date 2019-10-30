using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Entities
{
    public class Siren
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(9)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }
        
        public bool Actif { get; set; } = false;

        [Required]
        public DateTime DateMaj { get; set; } = DateTime.Now;
    }
}
