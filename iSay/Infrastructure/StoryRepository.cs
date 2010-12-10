using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Eloquera.Client;

namespace iSay.Infrastructure
{
    public class StoryRepository : IStoryRepository
    {

        private DB db = MvcApplication.db;
        public IEnumerable<Story> getStories()
        {
           return db.ExecuteQuery("SELECT Story").OfType<Story>();
        }

        public void Add(Story s)
        {
            db.Store(s);
        }

        public int getNumberOfComments(Story s)
        {
            var comments = s.Comments.Count();
            return comments;
        }
    }
}