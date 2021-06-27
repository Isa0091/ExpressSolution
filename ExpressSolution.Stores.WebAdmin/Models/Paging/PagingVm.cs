using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.Models.Paging
{
    public class PagingVm
    {
        public string UrlPreviousPage { get; set; }

        public List<ButtonPagintationVm> Buttons { get; set; }

        public string UrlNexPage{ get; set; }

        public int ActivePage { get; set; }

        public string Customclass { get; set; }
    }
}
