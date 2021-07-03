using System;
using System.Collections.Generic;
using System.ComponentModel;
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
     [Description("Imagen")]
      Image = 1,
      /// <summary>
      /// 
      /// </summary>
     [Description("Video")]
      Video = 2,
      /// <summary>
      /// 
      /// </summary>
     [Description("Audio")]
      Audio= 3,
      /// <summary>
      /// 
      /// </summary>
      [Description("YouTube Link")]
      YouTubeLink= 4,
     
      /// <summary>
      /// Link externo
      /// </summary>
     [Description("Link externo")]
     ExternalLink= 5
    }

    public enum MultimediaRelevance
    {
        [Description("Logo")]
        Logo = 1,
        /// <summary>
        /// 
        /// </summary>
        [Description("Principal")]
        Primary = 2,
        /// <summary>
        /// 
        /// </summary>
        [Description("Secundaria")]
        secondary =3,
        /// <summary>
        /// 
        /// </summary>
        [Description("Footer")]
        Footer = 4
    }

}
