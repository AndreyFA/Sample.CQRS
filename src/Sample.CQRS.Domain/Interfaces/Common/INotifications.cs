using System.Collections.Generic;

namespace Sample.CQRS.Domain.Interfaces.Common
{
    public interface INotifications
    {
        bool IsSuccessfully { get; }
        IEnumerable<string> Errors { get; }

        void AddError(string error);
        void AddError(IEnumerable<string> errors);
    }
}