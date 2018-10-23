using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NNV.Models
{
    [Table(name:"VrsteDokumenata")]
    public class VrsteDokumenata
    {
        [Key]
        [DisplayName("ID Документ")]
        public int DokumentID { get; set; }
        [DisplayName("Врста документа")]
        public string VrstaDokumenta { get; set; }
        public virtual ICollection<Prilozi> Prilozi { get; set; }
    }
}