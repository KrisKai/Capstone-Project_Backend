using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.Entities;
using JourneySick.Data.Models.VO;
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
        public Task<int> CreateTrip(Tbltrip tbltrip);
        public Task<int> GetLastOneId();
        public Task<Tbltrip> GetTripById(int tripId);
        public Task<int> UpdateTrip(Tbltrip tbltrip);
        public Task<int> DeleteTrip(int tripId);
    }
}
