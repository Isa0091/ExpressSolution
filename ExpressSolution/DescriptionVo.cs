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
    /// Una descripciond ealgu elemento del sistema
    /// </summary>
    public record DescriptionVo : IValidatedValueObject
    {
        public DescriptionVo(string description, string extendedDescription)
        {
            Description = description;
            ExtendedDescription = extendedDescription;
        }
        /// <summary>
        /// Descripcion corta
        /// </summary>
        public string Description { get; init; }

        /// <summary>
        /// Opcional: descripcion larga
        /// </summary>
        public string ExtendedDescription { get; init; }
        public void IsValid()
        {
            if (string.IsNullOrEmpty(Description))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, nameof(Description), this.GetType());
        }
    }
}
