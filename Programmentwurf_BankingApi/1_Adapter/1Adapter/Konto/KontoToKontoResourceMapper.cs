﻿using Programmentwurf_BankingApi.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi.Adapter.Konto
{
    public class KontoToKontoResourceMapper
    {
        private static KontoToKontoResourceMapper instance;
        public static KontoToKontoResourceMapper getInstance()
        {
            if(instance == null)
            {
                instance = new KontoToKontoResourceMapper();
            }
            return instance;
        }
        public KontoResource apply(KontoEntity konto)
        {
            return map(konto);
        }

        private KontoResource map(KontoEntity konto)
        {
            return new KontoResource(
                konto.Id,
                konto.UserId,
                konto.BIC
                );
        }
    }
}