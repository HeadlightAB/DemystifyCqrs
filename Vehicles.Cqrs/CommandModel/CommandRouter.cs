using System;
using System.Collections.Generic;
using Vehicles.Cqrs.CommandModel.CommandHandlers;
using Vehicles.Cqrs.CommandModel.Commands;

namespace Vehicles.Cqrs.CommandModel
{
    public class CommandRouter : ICommandRouter
    {
        private static readonly Dictionary<Type, Type> Handlers = new Dictionary<Type, Type>();

        internal static void RegisterHandlers()
        {
            Handlers.Add(typeof(UpdateMileageCommand), typeof(UpdateMileageCommandHandler));
        }

        public void Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handlerType = Handlers[typeof(TCommand)];
            var handler = (IHandleCommand<TCommand>) Activator.CreateInstance(handlerType);

            handler.Handle(command);
        }
    }
}
