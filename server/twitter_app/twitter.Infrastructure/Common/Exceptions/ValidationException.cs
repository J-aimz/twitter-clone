using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using twitter.Infrastructure.Common.Extensions;

namespace twitter.Infrastructure.Common.Exceptions
{
    public class ValidationException : Exception
    {
		public ValidationException()
		  : base("One or more validation failures have occurred.")
		{
			Errors = new Dictionary<string, string[]>();
		}

		public ValidationException(IEnumerable<ValidationFailure> failures) : this()
		{
			var failureGroups = failures
				.GroupBy(e => e.PropertyName, e => e.ErrorMessage);

			foreach (var failureGroup in failureGroups)
			{
				var propertyName = failureGroup.Key;
				var propertyFailures = failureGroup.ToArray();

				Errors.TryAdd(propertyName, propertyFailures);
			}
		}

		public IDictionary<string, string[]> Errors { get; }

		public string GetErrors()
		{
			var errors = string.Empty;
			try
			{
				if (Errors?.Count > 0)
				{
					errors = Errors.Aggregate(errors,
						(current, error) => current + (error.Value.ToStringItems() + "; "));
				}

				return errors.TrimEnd(';');
			}
			catch (Exception ex)
			{
				Log.Logger.Error(ex, ex.Message);
				return $"{ex.Message}";
			}
		}
	}
}
