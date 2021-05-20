﻿using Programmentwurf_BankingApi._3Domain.Entities;
using Programmentwurf_BankingApi._3Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Programmentwurf_BankingApi._3Domain.Aggregates
{
    public class BankAggregate
    {
        public int Id { get; set; }
        public BankEntity Bank { get; set; }
        public AdressVO Adresse { get; set; }
    }
}
