using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Commands.Membership;
using Domain.Design.Commands;
using Domain.Model.Users.Services;
using DotNetOpenAuth.OAuth;
using DotNetOpenAuth.OpenId;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using DotNetOpenAuth.OpenId.RelyingParty;
using DotNetOpenAuth.Messaging;
using Infrastructure.Web;
using MvcContrib;
namespace WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IFormsAuthentication _formsAuthentication;
        private readonly IUserRepository _users;
        private readonly ICommandSender _cmds;
        static private readonly OpenIdRelyingParty _openid = new OpenIdRelyingParty();

        public AccountController(IFormsAuthentication formsAuthentication, 
            IUserRepository users, ICommandSender cmds)
        {
            _formsAuthentication = formsAuthentication;
            _users = users;
            _cmds = cmds;
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult SignOut()
        {
            _formsAuthentication.SignOut();
            
            return this.RedirectToAction<HomeController>(x => x.Index());
        }

        public ActionResult OpenId(string openIdUrl)
        {
            var response = _openid.GetResponse();
            if (response == null)
            {
                // Stage 2: user submitting Identifier
                Identifier id;
                if (Identifier.TryParse(openIdUrl, out id))
                {
                    try
                    {
                        var request = _openid.CreateRequest(openIdUrl);
                        var fetch = new FetchRequest();
                        fetch.Attributes.AddRequired(WellKnownAttributes.Contact.Email);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.First);
                        fetch.Attributes.AddRequired(WellKnownAttributes.Name.Last);
                        request.AddExtension(fetch);
                        return request.RedirectingResponse.AsActionResult();
                    }
                    catch (ProtocolException)
                    {
                        //_logger.Error("OpenID Exception...", ex);
                        return this.RedirectToAction(x => x.SignIn());
                    }
                }
                //_logger.Info("OpenID Error...invalid url. url='" + openIdUrl + "'");
                return this.RedirectToAction(x => x.SignIn());
            }

            // Stage 3: OpenID Provider sending assertion response
            switch (response.Status)
            {
                case AuthenticationStatus.Authenticated:
                    var fetch = response.GetExtension<FetchResponse>();
                    var firstName = "";
                    var lastName = "";
                    var email = "";
                    if (fetch != null)
                    {
                        firstName = fetch.GetAttributeValue(WellKnownAttributes.Name.First);
                        lastName = fetch.GetAttributeValue(WellKnownAttributes.Name.Last);
                        email = fetch.GetAttributeValue(WellKnownAttributes.Contact.Email);
                    }
                    return CreateUser(new CreateUser
                                          {
                                              UserName = response.ClaimedIdentifier, 
                                              FirstName = firstName, 
                                              LastName = lastName, 
                                              Email = email
                                          });
                case AuthenticationStatus.Canceled:
                    //_logger.Info("OpenID: Cancelled at provider.");
                    return this.RedirectToAction(x => x.SignIn());
                case AuthenticationStatus.Failed:
                    //_logger.Error("OpenID Exception...", response.Exception);
                    return this.RedirectToAction(x => x.SignIn());
            }
            return this.RedirectToAction(x => x.SignIn());
        }

        //public ActionResult OAuth(string returnUrl)
        //{
        //    var twitter = new WebConsumer(TwitterConsumer.ServiceDescription, _tokenManager);
        //    var url = Request.Url.ToString().Replace("OAuth", "OAuthCallback");
        //    var callBackUrl = new Uri(url);
        //    twitter.Channel.Send(twitter.PrepareRequestUserAuthorization(callBackUrl, null, null));

        //    return this.RedirectToAction(x => x.SignIn());
        //}

        //public ActionResult OAuthCallback()
        //{
        //    var twitter = new WebConsumer(new ServiceProviderDescription
        //                                      {
                                                  
        //                                      }, _tokenManager);
        //    var accessTokenResponse = twitter.ProcessUserAuthorization();
        //    if (accessTokenResponse != null)
        //    {
        //        string userName = accessTokenResponse.ExtraData["screen_name"];
        //        return CreateUser(userName, null, null, null);
        //    }
        //    _logger.Error("OAuth: No access token response!");
        //    return RedirectToAction("Login");
        //}

        private ActionResult CreateUser(CreateUser cmd)
        {
            var user = _users.FindBy(x => x.UserName == cmd.UserName);
            
            if (user == null)
            {
                return View("Create", cmd);
            }

            _formsAuthentication.SignIn(cmd.UserName, false);
            return this.RedirectToAction<HomeController>(x => x.Index());
        }

        [HttpPost]
        public ActionResult Create(CreateUser cmd)
        {
            _cmds.Send(cmd);
            
            return CreateUser(cmd);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}
