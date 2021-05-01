using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ClientException : Isa0091.Domain.Core.Exceptions.DomainClientException<ClientExceptionType>
    {
        protected ClientException(ClientExceptionType exceptionType, string relatedField, Type relatedObject, string message) : base(exceptionType, relatedField, relatedObject, message)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <param name="message">Opcional, si no se esopecifica se pone un mensaje generico indicando el campo y clase base </param>
        /// <returns></returns>
        public static ClientException CreateException(ClientExceptionType type, string relatedField,
            Type relatedObject, string message = null)
        {
            return new ClientException(type, relatedField, relatedObject, message ?? GetMessage(type, relatedField, relatedObject));
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ClientExceptionType
    {
        /// <summary>
        /// 
        /// </summary>
        RequiredField = 0,
        /// <summary>
        /// 
        /// </summary>
        InvalidOperation = 1,
        /// <summary>
        /// Se especifico unvalor no valido para un campo
        /// </summary>
        InvalidFieldValue = 2,

        /// <summary>
        /// Error en el envio de email
        /// </summary>
        SendingEmailFailed=3
    }
}
