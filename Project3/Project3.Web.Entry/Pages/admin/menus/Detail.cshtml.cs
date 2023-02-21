using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Application;
using Project3.Application.Dtos;

namespace Project3.Web.Entry.Pages.admin.menus
{
    public class Detail : PageModel
    {

        [FromQuery(Name = "id")]
        public long PageId { get; set; }

        public MenuItemDto MenuItem { get; set; }

        private readonly IAdminService _service;

        public Detail(IAdminService service)
        {
            _service = service;
        }

        public async Task OnGet()
        {
            MenuItem = await _service.GetSysMenuAsync(PageId);
        }
    }
}