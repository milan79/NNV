using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace NNV.Models
{
    [Table(name: "Prilozi")]
    public class Prilozi
    {
        [Key, Column(Order = 0)]
        [DisplayName("ID Седница")]
        public int SednicaID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("ID Прилог")]
        public int PrilogID { get; set; }
        [DisplayName("ID Документ")]
        public int DokumentID { get; set; }
        [DisplayName("Назив прилога")]
        public string NazivPriloga { get; set; }
        [DisplayName("Путања")]
        public string Putanja { get; set; }
        [DisplayName("Послато")]
        public bool Poslato { get; set; }
        [DisplayName("Датум слања")]
        public DateTime DatumSlanja { get; set; }
        public virtual Sednice Sednice { get; set; }
        public virtual VrsteDokumenata VrsteDokumenata { get; set; }
    }
}