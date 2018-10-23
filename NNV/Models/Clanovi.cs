using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NNV.Models
{
    [Table(name:"Clanovi")]
    public class Clanovi
    {
        [Key]
        [DisplayName("ID Чланови")]
        public int ClanID { get; set; }
        [DisplayName("Име и презиме")]
        [Required(ErrorMessage ="Неопходно је унети име и презиме")]
        public string ImePrezime { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Е-маил")]
        public string Email {get; set;}
        [DisplayName("Статус")]
        public bool Status { get; set; }
        [DisplayName("Корисничко име")]
        [Required(ErrorMessage ="Обавезно поље за унос.")]
        public string KorisnickoIme { get; set; }
        [DisplayName("Лозинка")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Обавезно поље за унос.")]
        public string Lozinka { get; set; }
        public bool admin { get; set; }
        //public string LoginErrorMessage { get; set; }
        public virtual ICollection<Prisustvo> Prisustvo { get; set; }

    }
}