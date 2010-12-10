using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eloquera.Client;

namespace iSay
{
    public class Comment
    {
        public string CommentText { get; set; }
        public DateTime PostDate { get; set; }
        public Story Story { get; set; }
        public string PostedBy { get; set; }
    }
}