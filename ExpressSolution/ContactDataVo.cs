using ExpressSolution.Exceptions;
using Isa0091.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution
{
    /// <summary>
    /// Datos de contacto
    /// </summary>
    public record ContactDataVo : IValidatedValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="landLineNumber"></param>
        /// <param name="email"></param>
        /// <param name="mobileNumber"></param>
        public ContactDataVo(string landLineNumber, string email, string mobileNumber, string name)
        {
            LandLineNumber = landLineNumber;
            Email = email;
            MobileNumber = mobileNumber;
            Name = name;
        }

        /// <summary>
        /// Nombre del contacto
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Numero fijo
        /// </summary>
        public string LandLineNumber { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string MobileNumber { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public void IsValid()
        {
            if(string.IsNullOrEmpty(Name))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, Name, this.GetType(), "Debe de ingresar el nombre del contacto");

            if (string.IsNullOrEmpty(LandLineNumber) && string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(MobileNumber))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, "LandLineNumber-MobileNumber-Email", this.GetType(), "Debe de ingresar al menos un contacto");
        }
    }
}
