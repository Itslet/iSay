using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eloquera.Client;

namespace iSay
{
    public class Story
    {
        public string StoryHeader { get; set; }
        public string StoryText { get; set; }
        public DateTime PostDate { get; set; }
        public List<Comment> Comments { get; set; }
    }
}