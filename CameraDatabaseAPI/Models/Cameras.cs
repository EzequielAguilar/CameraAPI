using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CameraDatabaseAPI.Models
{
    [Table("cameras")]

    public class Cameras
    {
        [Key]
        public int cameraID { get; set; }

        [Required]
        public int companyID { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public int Megapixels { get; set; }

        [Required]
        [Display(Name = "Price")]
        public decimal cameraPrice { get; set; }
        
    }
}
