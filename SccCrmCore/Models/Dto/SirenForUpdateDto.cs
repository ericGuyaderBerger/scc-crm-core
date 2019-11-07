using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Models.Dto
{
    public class SirenForUpdateDto : SirenForInsertDto
    {
        [Required(ErrorMessage = "Obligatoire")]
        public int? Id { get; set; }
    }
}
