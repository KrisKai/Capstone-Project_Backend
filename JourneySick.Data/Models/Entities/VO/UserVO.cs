using System;
namespace JourneySick.Data.Models.Entities.VO
{
	public class UserVO: UserDetail
	{
        public String? Username { get; set; }
        public String? Password { get; set; }
        public string? Confirmation { get; set; }
        public DateTime SendDate { get; set; }

        public List<UserInterest>? userInterestList;
    }
}

