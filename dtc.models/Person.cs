using System;
using System.Collections.Generic;
using System.Text;

namespace dtc.models
{
    public enum SocialMediaLinkTypes
    {
        Twitter,
        Facebook,
        Instagram,
        YouTube,
        Website,
        LinkedIn
    }
    public class Person : Entity

    {

        public string FirstName { get; set; }
        public string LastName { get; set; }


        public string Bio { get; set; }

        public string Email { get; set; }

        public string PhotoUrl { get; set; }

        public List<SocialMedia> SocialMediaLinks { get; set; }
    }
}
