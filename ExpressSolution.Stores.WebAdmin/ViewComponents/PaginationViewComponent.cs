using ExpressSolution.Stores.WebAdmin.Models.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpressSolution.Stores.WebAdmin.ViewComponents
{
    public class PaginationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(PagingInfo pagingInfo, Func<int, string> pageUrl, string clasePersonalizada = null)
        {
            PagingVm model = new PagingVm()
            {
                ActivePage = pagingInfo.CurrentPage,
                Buttons = new List<ButtonPagintationVm>(),
                Customclass = clasePersonalizada
            };
            int totalP = 10;
            int ipage = 1;

            //Pagina anterior
            if (pagingInfo.CurrentPage > 1)
            {
                model.UrlPreviousPage = pageUrl(pagingInfo.CurrentPage - 1);
            }

            if (totalP > pagingInfo.TotalPages)
                totalP = pagingInfo.TotalPages;

            if (pagingInfo.CurrentPage > 6)
            {
                totalP = pagingInfo.CurrentPage + 4;
                ipage = pagingInfo.CurrentPage - 5;

                if (totalP > pagingInfo.TotalPages)
                {
                    totalP = pagingInfo.TotalPages;
                    ipage = pagingInfo.TotalPages - 9;
                    if (ipage < 1)
                    {
                        ipage = 1;
                    }

                }
            }

            if (totalP != 1)
            {
                for (int i = ipage; i <= totalP; i++)
                {
                    model.Buttons.Add(new ButtonPagintationVm()
                    {
                        Page = i,
                        UrlButton = pageUrl(i)
                    });
                }
            }


            //Pagina siguiente
            if (pagingInfo.CurrentPage < pagingInfo.TotalPages)
            {
                model.UrlNexPage = pageUrl(pagingInfo.CurrentPage + 1);
            }

            return View(model);
        }
    }
}
