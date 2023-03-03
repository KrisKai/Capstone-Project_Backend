using JourneySick.Data.Models.DTOs;
using JourneySick.Data.Models.VO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<string> SelectAllTripWithPaging();
        //Select User
        public Task<UserVO> SelectTrip();
        //insert
        public Task<String> CreateTrip(TripDTO tripDTO);
        //update
        public Task<String> UpdateTrip(TripDTO tripDTO);
    }
}
