using System.Collections.Generic;
using System.Linq;
using Sample.CQRS.Domain.Interfaces.Common;

namespace Sample.CQRS.Domain.Common
{
    public class Notifications : INotifications
    {
        private readonly ISet<string> _errors;

        public Notifications()
        {
            _errors = new HashSet<string>();
        }

        public bool IsSuccessfully => !_errors.Any();

        public IEnumerable<string> Errors => new List<string>(_errors);

        public string CurrentUser { get; set; }

        public void AddError(string error)
        {
            if (!string.IsNullOrWhiteSpace(error))
            {
                _errors.Add(error);
            }
        }

        public void AddError(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }
    }
}