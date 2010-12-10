using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using System.Reflection;
using Eloquera.Client;
using System.IO;

namespace iSay
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : NinjectHttpApplication
    {

        public static DB db = new DB("server=(local);password=;options=none;");

        private static void openSession()
        {
            if (File.Exists(@"c:\temp\db\iSay.eq")) {
                            db.OpenDatabase("iSay");
                            db.RegisterType(typeof(iSay.Story));
                            db.RegisterType(typeof(iSay.Comment)); 
                
            } else {

                db.CreateDatabase("iSay");
                db.OpenDatabase("iSay");

                db.RegisterType(typeof(iSay.Story)); 
                db.RegisterType(typeof(iSay.Comment)); 
                

                //add some dummy data
                Story s = new Story {
                    StoryHeader = "Just another iSay weblog!",
                    StoryText = "Today I am so awesome.",
                    PostDate = DateTime.Now
                };
                
                Comment c = new Comment {
                CommentText = "Oh really.",
                PostDate = DateTime.Now,
                PostedBy = "The Lousy Commenter",
                Story = s
                };

                Comment c1 = new Comment
                {
                    CommentText = "I totally agree",
                    PostDate = DateTime.Now,
                    PostedBy = "The Sweet Commenter",
                    Story = s
                };

                var comments = new List<Comment>();
                comments.Add(c);
                comments.Add(c1);
                s.Comments = comments;

                db.Store(s);
                db.Store(c);
                db.Store(c1);

                db.Close();
                openSession();
            }

        }

        public MvcApplication()
        {
            this.BeginRequest += new EventHandler(MvcApplication_BeginRequest);
            this.EndRequest += new EventHandler(MvcApplication_EndRequest);
        }

       
        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            openSession();

        }

        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            db.Close();
        }


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

       

        protected override Ninject.IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            return kernel;
        }

        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}