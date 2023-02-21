using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace Project3.Web.Entry.Pages.admin
{
    public class PermissionModel : PageModel
    {
        public List<DataModel> Value { get; set; }

        [BindProperty]
        public DataModel InputValue { get; set; }
        public void OnGet()
        {
            Value = new List<DataModel>()
            {
                new DataModel()
                {
                    Name = "wilber"
                }
            };

        }


        public IActionResult OnPost()
        {
            try
            {
                if (ModelState.IsValid)
                {

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            throw new NotImplementedException();
        }
    }

    public class DataModel
    {
        [Required]
        [StringLength(10)]
        [Display(Name = "©m¦W")]
        public string Name { get; set; }
    }
}
