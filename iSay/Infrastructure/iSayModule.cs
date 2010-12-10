using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;

namespace iSay.Infrastructure
{
    public class iSayModule : NinjectModule
    {
       public override void Load()
        {
            this.Bind<IStoryRepository>().To<StoryRepository>();
            //this.Bind<ISession>().ToMethod(x => MvcApplication.SessionFactory.GetCurrentSession());
        }
    }
 }
