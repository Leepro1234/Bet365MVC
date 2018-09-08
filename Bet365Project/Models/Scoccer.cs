using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bet365Project.Models
{
    public class Scoccer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        public string SDATE { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string LEAGUE { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string HOME{ get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string AWAY { get; set; }

        [Required]
        public double  V1 { get; set; }

        [Required]
        public double V2 { get; set; }

        [Required]
        public double V3 { get; set; }

        public string STATUS { get; set; }

        public int HRS { get; set; }

        public int HFE { get; set; }

        public int HHT { get; set; }

        public int ARS { get; set; }
        
        public int AFE { get; set; }

        public int AHT { get; set; }
    }
}