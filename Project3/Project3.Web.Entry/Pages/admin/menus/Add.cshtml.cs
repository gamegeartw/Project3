using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Application;
using Project3.Application.Dtos;
using System.ComponentModel.DataAnnotations;

namespace Project3.Web.Entry.Pages.admin.menus
{
    public class Add : PageModel
    {
        private readonly IAdminService _service;

        public Add(IAdminService service)
        {
            _service = service;
        }
        [BindProperty]
        public ValueModel Item { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var menu = Item.Adapt<InputMenuItemDto>();
                    var roles = Item.RolesStr.Split(',');
                    var result = new List<long>();
                    foreach (var role in roles)
                    {
                        result.Add(Convert.ToInt64(role));
                    }

                    menu.Roles = result.ToArray();
                    await _service.AddSysMenuAsync(menu);
                    return new JsonResult(new { Code = 200, message = "新增成功" });
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new JsonResult(new { Code = 500, message = e.Message });
            }

            return BadRequest();
        }

        [BindProperties]
        public class ValueModel
        {
            [Required]
            public string Title { get; set; }
            public string Description { get; set; }
            public string Icon { get; set; }
            [Required]
            public string Url { get; set; }

            public int? ParentId { get; set; }
            public string RolesStr { get; set; }
        }
    }
}