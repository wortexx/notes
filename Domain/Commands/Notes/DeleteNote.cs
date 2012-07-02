using System;
using Ncqrs.Commanding;
using Ncqrs.Commanding.CommandExecution.Mapping.Attributes;
using Domain.Model.Notes;

namespace Domain.Commands.Notes
{
    [MapsToAggregateRootMethod(typeof(Note), "Delete")]
    public class DeleteNote : CommandBase
    {
        public Guid Id { get; set; }
    }
}