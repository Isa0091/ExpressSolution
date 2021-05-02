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
    public enum MultimediaType
    { 
      /// <summary>
      /// 
      /// </summary>
      Image = 1,
      /// <summary>
      /// 
      /// </summary>
      Video = 2,
      /// <summary>
      /// 
      /// </summary>
      Audio= 3,
      /// <summary>
      /// 
      /// </summary>
      YouTubeLink= 4,
     
      /// <summary>
      /// Link externo
      /// </summary>
     ExternalLink= 5
    }

    public enum MultimediaRelevance
    {
        Logo = 1,
        /// <summary>
        /// 
        /// </summary>
        Primary = 2,
        /// <summary>
        /// 
        /// </summary>
        secondary =3,
        /// <summary>
        /// 
        /// </summary>
        Footer= 4
    }

}
