﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class Awaria
    {
        [Key]
        public int AwariaID { get; set; }
        public int BlokMieszkalnyId { get; set; }
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Opis { get; set; }
        public DateTime DataDodania { get; set; }

        public Status Status { get; set; }
        public Typ Typ { get; set; }


        public virtual BlokMieszkalny BlokMieszkalny { get; set; }
        // public virtual ICollection<StanLicznikow> StanLicznikow { get; set; }

    }

    public enum Status
    {
        Nowe,
        Trwa_usuwanie,
        Usunieto_awarie,
        Odrzucono,
        Uwaga
    }

    public enum Typ
    {
        awarie_elekryczne,
        awarie_wod_kan_gaz,
        awarie_ogrzewania_co,
        uszkodzenia_elewacji_dachu,
        uszkodzenia_drzwi_demofonu,
        inne_awarie_uszkodzenia,
        uwagi_opinie

    }
}