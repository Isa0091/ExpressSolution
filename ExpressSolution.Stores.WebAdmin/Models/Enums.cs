using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models
{
    /// <summary>
    /// Define activos o inactivos
    /// </summary>
    public enum State
    {
        [Description("Inactivos")]
        Inactive = 0,

        [Description("Activos")]
        Active = 1,
    }
}
