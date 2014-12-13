using System;
using System.Web;
using DuplicateCode.Attribute.Support;

namespace DuplicateCode.Attribute.Refactored {
   public class DenyInternationalAttribute: ActionFilterAttribute {
      public override void OnActionExecuting( ActionExecutingContext filterContext ) {
         bool isInternational = DependencyResolver.Current.GetService<ISessionWrapper>().IsInternational;

         if ( isInternational ) {
            HttpResponseBase response = filterContext.HttpContext.Response;
            UriBuilder ub = new UriBuilder( filterContext.HttpContext.Request.Url ) {
               Path = "/"
            };
            response.Redirect( ub.Uri.ToString(), true );
         }
         base.OnActionExecuting( filterContext );
      }
   }
}