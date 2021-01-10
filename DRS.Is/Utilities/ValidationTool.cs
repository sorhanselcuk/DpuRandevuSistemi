using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Utilities
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator,object veri)
        {
            var result = validator.Validate(veri);
            if (result.Errors.Count > 0)
                throw new ValidationException(result.Errors);
        }
    }
}
