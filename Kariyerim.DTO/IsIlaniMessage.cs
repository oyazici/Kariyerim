﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kariyerim.DTO
{
    public class IsIlaniMessage
    {
        public int IlanNumarasi { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public DateTime IlanTarihi { get; set; }
        public string SirketAdi { get; set; }
        public DateTime? IlanBitisTarihi { get; set; }
    }
}
