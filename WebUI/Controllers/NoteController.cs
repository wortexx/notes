using System;
using System.Web.Mvc;
using Domain.Commands.Notes;
using Domain.Design.Commands;

namespace WebUI.Controllers
{
    [Authorize]
    public class NoteController : Controller
    {
        private readonly ICommandSender _bus;

        public NoteController(ICommandSender bus)
        {
            _bus = bus;
        }

        public ActionResult Add()
        {
            return View(new CreateNote
                            {
                                Id = Guid.NewGuid()
                            });
        }

        [HttpPost]
        public void Add(CreateNote cmd)
        {
            _bus.Send(cmd);
        }

        public void Delete(DeleteNote cmd)
        {
             _bus.Send(cmd);
        } 

    }
}
