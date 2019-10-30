using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Dto
{
    public class SirenForInsertDto
    {
        [Required]
        [RegularExpression("^\\d{9}$", 
            ErrorMessage ="Doit être constitué de 9 chiffres")]
        public string Numero { get; set; }

        [Required]
        [MinLength(2,
            ErrorMessage ="Doit au moins mesurer 2 caractères")]
        [MaxLength(100, 
            ErrorMessage ="Ne doit pas dépasser 100 caractères")]
        public string Nom { get; set; }

        public bool Actif { get; set; } = true;

    }
}
