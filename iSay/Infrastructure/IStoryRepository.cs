using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iSay.Infrastructure
{
    public interface IStoryRepository
    {
        IEnumerable<Story> getStories();
        void Add(Story s);
        int getNumberOfComments(Story s);
    }
}