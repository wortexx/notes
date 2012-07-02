﻿namespace Domain.Design.Commands
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}