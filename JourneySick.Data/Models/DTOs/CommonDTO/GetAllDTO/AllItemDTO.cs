using JourneySick.Data.Models.DTOs.CommonDTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JourneySick.Data.Models.DTOs.CommonDTO.GetAllDTO
{
    public class AllItemDTO
    {
        public int NumOfItem { get; set; }
        public List<ItemRequest>? ListOfItem { get; set; }
    }
}
