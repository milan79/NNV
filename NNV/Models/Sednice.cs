using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NNV.Models
{
    [Table(name:"Sednice")]
    public class Sednice
    {
        [Key]
        [DisplayName("ID")]
        public int SednicaID { get; set; }
        [DisplayName("Датум")]
        public DateTime Datum { get; set; }
        [DisplayName("Врста седнице")]
        public string VrstaSednice { get; set; }
        [DisplayName("Учионица")]
        public string Ucionica { get; set; }
        [DisplayName("Записник")]
        public string Zapisnik { get; set; }
        [DisplayName("Позив")]
        public string Poziv { get; set; }
        public virtual ICollection<Prilozi> Prilozi { get; set; }
        public virtual ICollection<VrsteDokumenata> VrsteDokumenata { get; set; }
    }
}