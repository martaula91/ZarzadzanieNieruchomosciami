using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ZarzadzanieNieruchomosciami.Infrastructure
{
    public class AppConfig
    {
        private static string _dokumentyFolderWzgledny = ConfigurationManager.AppSettings["dokumentyFolder"];

        public static string dokumentyFolderWzgledny
        {
            get
            {
                return _dokumentyFolderWzgledny;
            }
        }

        private static string _dokWlasneFolderWzgledny = ConfigurationManager.AppSettings["dokWlasneFolder"];

        public static string dokWlasneFolderrWzgledny
        {
            get
            {
                return _dokWlasneFolderWzgledny;
            }
        }

        private static string _obrazkiFolderWzgledny = ConfigurationManager.AppSettings["ObrazkiFolder"];

        public static string ObrazkiFolderWzgledny
        {
            get
            {
                return _obrazkiFolderWzgledny;
            }
        }

    }
}