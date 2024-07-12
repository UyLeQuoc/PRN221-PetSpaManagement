using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Interfaces;

namespace PetSpaManagementWeb.Pages.Services
{
    public class EditModel : PageModel
    {
        private readonly IServiceService _service;

        public EditModel(IServiceService service)
        {
            _service = service;
        }

        [BindProperty]
        public Service Service{ get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null || await _service.GetService() == null)
            {
                return NotFound();
            }

            var service = await _service.GetServiceByID(id);
            if (service == null)
            {
                return NotFound();
            }
            Service = service;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(SeaArea).State = EntityState.Modified;

            try
            {
                await _service.UpdateService(id, Service);
            }
            catch (DbUpdateConcurrencyException)
            {

            }

            return RedirectToPage("./Index");
        }
    }
}
