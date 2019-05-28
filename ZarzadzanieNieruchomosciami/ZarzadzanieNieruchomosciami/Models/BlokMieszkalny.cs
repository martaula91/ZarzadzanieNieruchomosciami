using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Models
{
    public class BlokMieszkalny
    {

        public int BlokMieszkalnyId { get; set; }


        public string Ulica { get; set; }
        public int NumerBlokuMieszkalnego { get; set; }
        public string Adres { get; set; }
        public double PowierzchniaUzytkowa { get; set; }
        public int LiczbaLokali { get; set; }
        public double PowDzialki { get; set; }
        public int NrEwidDzialki { get; set; }
        public bool Ukryty { get; set; }

        //NOWE
        public string PrzeznaczenieDzialki { get; set; }
        public double PowTerenuZielonego { get; set; }
        public int IloscPieter { get; set; }
        public string TechnologiaWykonania { get; set; }

        public int IloscKlatek { get; set; }
        public int RokBudowy { get; set; }
        public double Kubatura { get; set; }
        public double PowPodpiwniczenia { get; set; }
        public int IloscLawek { get; set; }
        public string ObMalejArchitektury { get; set; }
        public string Smietnik { get; set; }


        public string ProtokolOdbioruObiektu { get; set; }
        public string PozwolenieNaUzytkowanieObiektu { get; set; }
        public string ProtokolPrzejeciaObiektu { get; set; }
        public DateTime DataZalozeniaKsiegiOB { get; set; }

        public string DokumentyPrzekazaneZarządcy { get; set; }
        public string SwiadectwoCharakterystykiEnergetycznej { get; set; }
        public DateTime DataOstProtokołuKontroli { get; set; }
        public string OcenaStanuPoKontroli { get; set; }
        public DateTime DataKontroliSysOgrzewania { get; set; }

        public virtual ICollection<LokalMieszkalny> Lokal { get; set; }
        public virtual ICollection<Awaria> Awaria { get; set; }
        public virtual ICollection<Dokument> Dokument { get; set; }
        public virtual ICollection<Glosowanie> Glosowanie { get; set; }


    }
}