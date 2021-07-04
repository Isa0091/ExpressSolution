using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Store.Inputs.CustomValidations
{
    public class ValidateContacAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            StoreContactInputVm contacto = (StoreContactInputVm)validationContext.ObjectInstance;

            if (string.IsNullOrEmpty(contacto.Email) && string.IsNullOrEmpty(contacto.MobileNumber) && string.IsNullOrEmpty(contacto.LandLineNumber))
            {
                return new ValidationResult("Debe de ingresar al menos un contacto: teléfono fijo, celular o email", new[] { nameof(contacto.LandLineNumber) });
            }

            return ValidationResult.Success;
        }
    }
}
