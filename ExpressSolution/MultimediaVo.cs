using Isa0091.Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressSolution
{
    public record MultimediaVo : IValidatedValueObject
    {
        public MultimediaVo(string name,string mimeType,string urlMultimedia, MultimediaType multimediaType)
        {
            Name = name;
            MimeType = mimeType;
            UrlMultimedia = urlMultimedia;
            MultimediaType = multimediaType;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string MimeType { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public string UrlMultimedia { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public MultimediaType MultimediaType { get; init; }
        /// <summary>
        /// 
        /// </summary>
        public void IsValid()
        {
            throw new NotImplementedException();
        }
    }
}
