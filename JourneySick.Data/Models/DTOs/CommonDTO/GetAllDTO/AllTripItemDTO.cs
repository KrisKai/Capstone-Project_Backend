namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllTripItemDTO
    {
        public int NumOfItem { get; set; }
        public List<TripItemDTO>? ListOfItem { get; set; }
    }
}
