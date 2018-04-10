using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CameraDatabaseAPI.Models
{
    [Table("companies")]
    public class Manufacturers
    {

        [Key]
        [Required]
        public int companyID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Phone { get; set; }

        [Required]
        public string CEO { get; set; }

        [Required]
        public int numEmployees { get; set; }

        [Required]
        public string stockName { get; set; }
    }
}
