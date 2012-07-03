using System;
using System.ServiceModel;
using System.Web.Mvc;
using Domain.Commands.Notes;
using Ncqrs.CommandService;
using Ncqrs.CommandService.Contracts;
using MvcContrib;

namespace WebUI.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private static ChannelFactory<ICommandWebServiceClient> _channelFactory;

        static NoteController()
        {
            _channelFactory = new ChannelFactory<ICommandWebServiceClient>("CommandWebServiceClient");
        }

        public ActionResult Add()
        {
            return View(new CreateNote
                            {
                                NoteId = Guid.NewGuid()
                            });
        }

        [HttpPost]
        public ActionResult Add(CreateNote cmd)
        {
            ChannelHelper.Use(_channelFactory.CreateChannel(), client => client.Execute(new ExecuteRequest(cmd)));

            return this.RedirectToAction<HomeController>(x => x.Index());
        }

        public ActionResult Delete(DeleteNote cmd)
        {
            ChannelHelper.Use(_channelFactory.CreateChannel(), client => client.Execute(new ExecuteRequest(cmd)));

            return this.RedirectToAction<HomeController>(x => x.Index());
        } 

    }
}
