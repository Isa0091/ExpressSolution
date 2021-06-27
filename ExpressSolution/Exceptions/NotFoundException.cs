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
       DynamicData = 1,
       /// <summary>
       /// 
       /// </summary>
       Contact = 2,
       /// <summary>
       /// 
       /// </summary>
       Store = 3,
       /// <summary>
       /// 
       /// </summary>
       Category= 4,

       /// <summary>
       /// 
       /// </summary>
       Multimedia = 5

    }
}
