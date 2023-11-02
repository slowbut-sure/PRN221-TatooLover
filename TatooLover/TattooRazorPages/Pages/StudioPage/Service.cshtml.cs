using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories;

namespace TattooRazorPages.Pages.StudioPage
{
    public class ServiceModel : PageModel
    {
        StudioRepository studioRepository = new StudioRepository();
        public List<Service> services = new List<Service>();
        public void OnGet()
        {
            var id = HttpContext.Session.GetInt32("id") != null ?
                    (int)HttpContext.Session.GetInt32("id")! : -1;

            if (id < 0)
            {
                NotFound(); return;
            }
            else
            {
                try
                {
                    services = studioRepository.GetServiceByStudioId(id);
                }
                catch (Exception ex)
                {
                    ViewData["Message"] = "Error getting data";
                }
            }
        }
    }
}