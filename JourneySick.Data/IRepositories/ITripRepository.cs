﻿using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    {
        //CREATE
        public Task<int> CreateTrip(Tbltrip Tbltrip);
        public Task<string> getLastOneId();
    }
}