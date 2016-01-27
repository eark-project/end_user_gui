using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace end_user_gui_aspnet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            //# Search
            //POST        /search                          @controllers.SearchController.Search()
            routes.MapRoute(
                name: "search",
                url: "search",
                defaults: new { controller = "Search", action = "Search" },
                constraints: new { httpMethod = new HttpMethodConstraint("POST") }
                );
            //GET         /search/autocomplete/:q          @controllers.SearchController.AutoComplete(q: String)


            //# Cart (Order)
            //GET         /cart/add/:key//                 @controllers.OrderController.Add(key: String, disKey = null, commnets = null)
            routes.MapRoute(
                name: "cart add",
                url: "cart/add/{key}/",
                defaults: new { controller = "Order", action = "Add", comments = null as string }
                );
            //GET         /cart/add/:key/:disKey/          @controllers.OrderController.Add(key: String, disKey: String, commnets = null)
            routes.MapRoute(
                name: "cart add with display",
                url: "cart/add/{key}/{disKey}/",
                defaults: new { controller = "Order", action = "Add", comments = null as string }
             );
            //GET         /cart/remove/:key/               @controllers.OrderController.Remove(key:String)
            routes.MapRoute(
                name: "cart remove",
                url: "cart/remove/{key}/",
                defaults: new { controller = "Order", action = "Remove", }
             );
            //GET         /cart/view/                      @controllers.OrderController.View()
            routes.MapRoute(
                name: "cart view",
                url: "cart/view/",
                defaults: new { controller = "Order", action = "View", }
             );
            //GET         /cart/count/                     @controllers.OrderController.Count()
            routes.MapRoute(
                name: "cart count",
                url: "cart/count/",
                defaults: new { controller = "Order", action = "Count", }
             );
            //GET         /cart/empty/                     @controllers.OrderController.Empty()
            routes.MapRoute(
                name: "cart empty",
                url: "cart/empty/",
                defaults: new { controller = "Order", action = "Empty", }
             );
            //GET         /cart/submit/                    @controllers.OrderController.Submit()
            routes.MapRoute(
                name: "cart submit",
                url: "cart/submit/",
                defaults: new { controller = "Order", action = "Submit", }
             );


            //GET         /profile/                        @controllers.UserController.ProfileSummary()
            routes.MapRoute(
                name: "profile",
                url: "profile/",
                defaults: new { controller = "User", action = "ProfileSummary", }
             );
            //GET         /profile                         @controllers.UserController.ProfileSummary()
            routes.MapRoute(
                name: "profile2",
                url: "profile",
                defaults: new { controller = "User", action = "ProfileSummary", }
             );

            // Default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
