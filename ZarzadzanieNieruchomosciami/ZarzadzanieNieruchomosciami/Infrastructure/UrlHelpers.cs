using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZarzadzanieNieruchomosciami.Infrastructure
{
    public static class UrlHelpers
    {

        public static string dokumentySciezka(this UrlHelper helper, string nazwaDokumentu)
        {
            var dokumentyFolder = AppConfig.dokumentyFolderWzgledny;
            var sciezka = Path.Combine(dokumentyFolder, nazwaDokumentu);
            var sciezkaBezwzglendna = helper.Content(sciezka);

            return sciezkaBezwzglendna;
        }

        public static string DokWlasneSciezka(this UrlHelper helper, string nazwaDokWlasnego)
        {
            var DokWlasneFolder = AppConfig.dokWlasneFolderrWzgledny;
            var sciezka = Path.Combine(DokWlasneFolder, nazwaDokWlasnego);
            var sciezkaBezwzglendna = helper.Content(sciezka);

            return sciezkaBezwzglendna;
        }
    }
}