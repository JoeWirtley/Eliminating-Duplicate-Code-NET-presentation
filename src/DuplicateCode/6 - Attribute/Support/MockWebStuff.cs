using System;
using System.Web;

namespace DuplicateCode.Attribute.Support {
   public interface ISessionWrapper {
      bool IsInternational { get; }
   }

   public class DependencyResolver {
      public static IDependencyResolver Current { get; set; }
   }


   public interface IDependencyResolver {
      T GetService< T >();
   }

   public class ActionExecutingContext {
      public object ActionDescriptor { get; set; }
      public HttpContextBase HttpContext { get; set; }
   }

   public class ActionFilterAttribute: System.Attribute {
      public virtual void OnActionExecuting( ActionExecutingContext filterContext ) {
         throw new NotImplementedException();
      }
   }

   public class ActionResult {
   }
}