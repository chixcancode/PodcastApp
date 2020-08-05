using System;
using System.Collections.Generic;
using System.Text;

namespace dtc.models
{
    public class SocialMedia
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

        public string LinkUrl { get; set; }

        public SocialMediaLinkTypes LinkType { get; set; }

    }
}
