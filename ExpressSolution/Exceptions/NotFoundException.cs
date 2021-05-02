using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution
{
    /// <summary>
    /// 
    /// </summary>
    public class NotFoundException : Isa0091.Domain.Core.Exceptions.DomainNotFoundException<NotFoundExceptionType>
    {


        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="relatedField"></param>
        /// <param name="relatedObject"></param>
        /// <returns></returns>
        public static NotFoundException CreateException(NotFoundExceptionType type, string relatedField,
            Type relatedObject)
        {
            return new NotFoundException(type, relatedField, relatedObject, GetMessage(type, relatedField, relatedObject));
        }

        protected NotFoundException(NotFoundExceptionType exceptionType, string relatedField, Type relatedObject, string message) : base(exceptionType, relatedField, relatedObject, message)
        {
        }
    }
    /// <summary>
    /// 
    /// </summary>
    public enum NotFoundExceptionType
    {
        /// <summary>
        /// 
        /// </summary>
        Account = 0,
        /// <summary>
        /// 
        /// </summary>
        Group = 1,
        /// <summary>
        /// 
        /// </summary>
        Client = 2,
        /// <summary>
        /// 
        /// </summary>
        AccountGroup = 3,
        /// <summary>
        /// 
        /// </summary>
        Movement = 4,
        /// <summary>
        /// Un dato dinamico de una cuenta no se encontro
        /// </summary>
        AccountDynamicData = 6,
        /// <summary>
        /// 
        /// </summary>
        ClientContact = 7,
        /// <summary>
        /// Un dato dinamico del cliente
        /// </summary>
        ClientDynamicData = 8,
        /// <summary>
        /// 
        /// </summary>
        MovementType = 9,

        /// <summary>
        /// 
        /// </summary>
        PaymenMethod=10
    }
}
