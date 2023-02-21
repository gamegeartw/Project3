using Furion.FriendlyException;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Project3.Application;
using Project3.Web.Entry.Filters;

namespace Project3.Web.Entry.Pages.admin
{
    
    public class Menus : PageModel
    {
        private readonly ILogger<Menus> _logger;
        private readonly IAdminService _service;

        [FromQuery(Name = "id")]
        public string Id { get; set; }

        public string[] arr { get; set; }


        
        public Menus(
            ILogger<Menus> logger,
            IAdminService service)
        {
            _logger = logger;
            _service = service;
        }

        [MyRazorFilter(Order = Int32.MinValue)]
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostDeleteAsync(long id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.DeleteSysMenuAsync(id);
                    return new JsonResult(new { code = 200 });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new JsonResult(new { code = 500, message = e.Message });
            }

            return BadPageResult.Status500InternalServerError;
        }

        public async Task<IActionResult> OnPostMoveAsync(long id, string type)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _service.MoveSysMenuAsync(id, type);
                    return new JsonResult(new { code = 200 });
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return new JsonResult(new { code = 500, message = e.Message });
            }

            return BadPageResult.Status500InternalServerError;
        }
    }
}