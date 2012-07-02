using Domain.Design.Commands;

namespace Tests.Stubs
{
    public class CommandServiceStub : ICommandSender
    {
        #region Implementation of ICommandSender

        public void Send<T>(T command) where T : Command
        {
            
        }

        #endregion
    }
}