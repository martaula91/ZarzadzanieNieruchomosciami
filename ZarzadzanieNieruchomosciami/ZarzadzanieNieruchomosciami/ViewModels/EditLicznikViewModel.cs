﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZarzadzanieNieruchomosciami.Models;

namespace ZarzadzanieNieruchomosciami.ViewModels
{
    public class EditLicznikViewModel
    {
        public StanLicznikow StanLicznikow { get; set; }
        public IEnumerable<LokalMieszkalny> Lokal { get; set; }
        public bool? Potwierdzenie { get; set; }
    }
}