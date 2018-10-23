using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NNV.Models
{
    [Table(name: "Prisustvo")]

    public class Prisustvo
    {
        [Key, Column(Order = 0)]
        [DisplayName("ID Седница")]
        public int SednicaID { get; set; }

        [Key, Column(Order = 1)]
        [DisplayName("Члан")]
        public int ClanID { get; set; }
        [DisplayName("Присутан")]
     
        public bool Prisutan { get; set; }
        [DisplayName("Оправдано")]
        public bool Opravdano { get; set; }
        public virtual Sednice Sednice { get; set; }
        public virtual Clanovi Clanovi { get; set; }



    }     
}
