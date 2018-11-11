using System;
using System.Collections.Generic;
using Vehicles.Cqrs.CommandModel.CommandHandlers;
using Vehicles.Cqrs.CommandModel.Commands;
using Vehicles.Cqrs.Domain;
using Vehicles.Data;

namespace Vehicles.Cqrs.CommandModel
{
    public class CommandRouter : ICommandRouter
    {
        private readonly IServiceProvider _serviceProvider;
        private static readonly Dictionary<Type, Type> Handlers = new Dictionary<Type, Type>();

        public CommandRouter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        internal static void RegisterHandlers()
        {
            Handlers.Add(typeof(UpdateMileageCommand), typeof(UpdateMileageCommandHandler));
            Handlers.Add(typeof(RegisterVehicleCommand), typeof(RegisterVehicleCommandHandler));
        }

        public void Handle<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handlerType = Handlers[typeof(TCommand)];
            var storage = _serviceProvider.GetService(typeof(IStorage));
            var handler = Activator.CreateInstance(handlerType, storage);

            handler.GetType().GetMethod(nameof(CommandHandler<AggregateRoot, ICommand>.Handle)).Invoke(handler, new object[] {command});
        }
    }
}
