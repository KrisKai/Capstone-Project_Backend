using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.IRepositories
{
    public interface ITripDetailRepository
    {
        //CREATE
        public Task<int> CreateTripDetail(Tbltripdetail tbltripdetail);
        //UPDATE
        public Task<int> UpdateTripDetail(Tbltripdetail tbltripdetail);
        //DELETE
        public Task<int> DeleteTripDetail(string tripDetailId);

    }
}
