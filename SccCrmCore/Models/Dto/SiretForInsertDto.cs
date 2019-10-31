using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Dto
{
    public class SiretForInsertDto
    {
        [Required]
        [RegularExpression("^\\d{14}$", ErrorMessage ="Doit être composé de 14 chiffres")]
        public string Numero { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Au moins deux caractères")]
        [MaxLength(100, ErrorMessage = "Au plus 100 caractères")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "Obligatoire")]
        public Nullable<int> SirenId { get; set; }
    }
}
