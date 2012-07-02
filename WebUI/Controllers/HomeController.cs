using System.Web.Mvc;
using DotNetOpenAuth.OpenId.RelyingParty;

namespace WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //var openid = new OpenIdRelyingParty();
            //openid.GetResponse()
            

            return View();
        }

        public ActionResult About()
        {
            return View();
        }
    }
}
