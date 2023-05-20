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
        public Task<int> CreateTripDetail(TripDetail tripdetail);
        //UPDATE
        public Task<int> UpdateTripDetail(TripDetail tripdetail);
        //DELETE
        public Task<int> DeleteTripDetail(string tripDetailId);

    }
}
