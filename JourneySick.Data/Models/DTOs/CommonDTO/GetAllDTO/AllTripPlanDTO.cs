namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripPlanDTO
    {
        public int NumOfPlan { get; set; }
        public List<TripPlanDTO>? ListOfPlan { get; set; }
    }
}
