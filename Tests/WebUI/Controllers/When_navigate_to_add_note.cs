using System;
using System.Web.Mvc;
using Domain.Commands.Notes;
using Domain.Design.Commands;
using NUnit.Framework;
using Primitives.Notes;
using Should.Fluent;
using Tests.Stubs;
using WebUI.Controllers;

namespace Tests.WebUI.Controllers
{
    [TestFixture]
    public class When_navigate_to_add_note
    {
        private ActionResult _result;

        [TestFixtureSetUp]
        public void SetUp()
        {
            ICommandSender commands = new CommandServiceStub();
            var controller = new NoteController(commands);

            _result = controller.Add();
        }

        [Test]
        public void Result_should_be_of_type_view_result()
        {
            _result.Should().Be.OfType<ViewResult>();
        }

        [Test]
        public void Result_model_should_be_of_type_create_note()
        {
            (((ViewResult) _result).Model).Should().Be.OfType<CreateNote>();
                
            var model = ((ViewResult) _result).Model;
            Assert.AreNotEqual(Guid.Empty, ((CreateNote)model).Id);
        }

        [Test]
        public void Result_model_should_be_initialized()
        {
            var model = ((CreateNote) ((ViewResult) _result).Model);
            model.Id.Should().Not.Equal(Guid.NewGuid());
            model.Color.Should().Equal(NoteColor.Yellow);
        }
    }
}