using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.EntityLayer.Concrete
{
    public class GeneralInfo
    {
        public int GeneralInfoId { get; set; }
        public string Email { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string AboutUsContent { get; set; }
        public string SocialMedia { get; set; }
        public string FollowOrder { get; set; }

    }
}
