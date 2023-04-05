﻿using JourneySick.Data.Models.Entities;

namespace JourneySick.Data.IRepositories
{
    public interface ITripRepository
    {
        
        //CREATE
        public Task<List<Tbltrip>> GetAllTripsWithPaging(int pageIndex, int pageSize, String? tripName);
        public Task<int> CountAllTrips();
        public Task<string> GetLastOneId();
        public Task<Tbltrip> GetTripById(string tripId);
        //CREATE
        public Task<int> CreateTrip(Tbltrip tbltrip);
        public Task<int> UpdateTrip(Tbltrip tbltrip);
        public Task<int> DeleteTrip(string tripId);
    }
}
