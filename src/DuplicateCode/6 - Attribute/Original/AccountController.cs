using DuplicateCode.Attribute.Support;

namespace DuplicateCode.Attribute.Original {
   public class AccountController: Controller {
      public ActionResult Index() {
         if ( IsInternational ) {
            return Redirect( "/" );
         }
         return View();
      }

      public ActionResult Login() {
         if ( IsInternational ) {
            return Redirect( "/" );
         }
         return View();
      }
   }
}