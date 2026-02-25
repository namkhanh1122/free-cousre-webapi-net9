using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace freecourse_api.Helper
{
    public class ApiBadRequestResponse : ApiResponse
    {
        public IEnumerable<string> Errors { get; }

        public ApiBadRequestResponse(ModelStateDictionary modelState) : base(400, "Validation errors occurred.")
        {
            if (modelState == null)
            {
                throw new ArgumentNullException(nameof(modelState));
            }

            Errors = modelState
                .Where(e => e.Value.Errors.Count > 0)
                .Select(e => e.Value.Errors.First().ErrorMessage)
                .ToList();
        }
        public ApiBadRequestResponse(string message ) : base(400, "Validation errors occurred.")
        {
            
        }
    }
}
        