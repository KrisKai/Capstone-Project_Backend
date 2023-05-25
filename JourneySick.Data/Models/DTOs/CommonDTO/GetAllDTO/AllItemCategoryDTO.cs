namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllItemCategoryDTO
    {
        public int NumOfCategory { get; set; }
        public List<ItemCategoryDTO>? ListOfCategory { get; set; }
    }
}
