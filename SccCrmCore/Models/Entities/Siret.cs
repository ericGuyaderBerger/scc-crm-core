using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Entities
{
    public class Siret
    {
        public int Id { get; set; }

        [Required]
        [MinLength(14)]
        [MaxLength(14)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nom { get; set; }

        [Required]
        public string Adresse { get; set; }

        [Required]
        public int SirenId { get; set; }
        public Siren Siren { get; set; }
    }
}
