using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Entities.Entities
{
    public class ResultData
    {
        [Key]
        public int IdResult { get; set; }
        [Required]
        public DateTime ResultDate { get; set; }
        [Required]
        public string MachineName { get; set; }
        [Required]
        public int AngleResult { get; set; }
        [Required]
        public int AngleUpperTol { get; set; }
        [Required]
        public int AngleLowerTol { get; set; }
        [Required]
        public int DiameterResult { get; set; }
        [Required]
        public int DiameterUpperTol { get; set; }
        [Required]
        public int DiameterLowerTol { get; set; }
    }
}
