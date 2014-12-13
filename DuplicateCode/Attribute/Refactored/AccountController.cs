using DuplicateCode.Attribute.Support;

namespace DuplicateCode.Attribute.Refactored {
   [DenyInternational]
   public class AccountController:Controller {
      [DenyInternational]
      public ActionResult Index() {
         return View();
      }

      [DenyInternational]
      public ActionResult Login() {
         return View();
      }
   }
}