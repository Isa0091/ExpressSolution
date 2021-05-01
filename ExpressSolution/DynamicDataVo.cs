using ExpressSolution.Exceptions;
using Isa0091.Domain.Core.ValueObjects;

namespace ExpressSolution
{
    /// <summary>
    /// Value object para alamacenardatod dinamicos alas entidades
    /// </summary>
    public record DynamicDataVo : IValidatedValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataName"></param>
        /// <param name="dataValue"></param>
        public DynamicDataVo(string dataName, string dataValue)
        {
            DataName = dataName;
            DataValue = dataValue;
        }

        /// <summary>
        /// Nombre del dato
        /// </summary>
        public string DataName { get; init; }

        /// <summary>
        /// El Valor del dato
        /// </summary>
        public string DataValue { get; init; }

        /// <summary>
        /// 
        /// </summary>
        public void IsValid()
        {
            if(string.IsNullOrEmpty(DataName))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, nameof(DataName), this.GetType());

            if (string.IsNullOrEmpty(DataValue))
                throw ClientException.CreateException(ClientExceptionType.RequiredField, nameof(DataValue), this.GetType());
        }
    }
}
