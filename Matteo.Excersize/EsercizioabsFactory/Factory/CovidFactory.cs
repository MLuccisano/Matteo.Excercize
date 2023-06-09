﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EsercizioabsFactory.Products;

namespace EsercizioabsFactory.Factory
{
    public class CovidFactory : abstractFactory
    {
        Europe _europe;
        public CovidFactory(Europe europe)
        {
            _europe = europe;
        }
        public override void GetInfoSectionA()
        {
            ZoneInfoFactory zif = new ZoneInfoFactory(_europe);
            TravelDocumentFactory tdf = new TravelDocumentFactory (zif);        
        }
    }
}
