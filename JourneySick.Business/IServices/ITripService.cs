﻿using JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO;
using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using JourneySick.Data.Models.DTOs.CommonDTO.Response;
using JourneySick.Data.Models.Entities.VO;

namespace JourneySick.Business.IServices
{
    public interface ITripService
    {
        //Select list w paging
        public Task<AllTripDTO> GetAllTripsWithPaging(int pageIndex, int pageSize, string? tripName);
        //Select User
        public Task<TripVO> GetTripById(string tripId, CurrentUserObject currentUser);
        //Insert
        public Task<int> CreateTrip(CreateTripRequest createTripRequest, CurrentUserObject currentUser);
        //Update
        public Task<string> UpdateTrip(UpdateTripRequest updateTripRequest, CurrentUserObject currentUser);
        //Delete
        public Task<int> DeleteTrip(string tripId, CurrentUserObject currentUser);
        //Count this month
        public Task<TripStatisticResponse> TripStatistic();
        public Task<List<TripVO>> GetTripHistory(string userId);
        //Create in user site
        public Task<string> CreateTripUser(CreateTripRequest tripRequest, CurrentUserObject currentUser);
        public Task<string> UpdateTripThumbnail(UpdateTripRequest tripVO, CurrentUserObject currentUser);
    }
}
