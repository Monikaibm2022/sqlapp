using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sqlapp.Model;
using sqlapp.service;

namespace sqlapp.Pages
{
    public class IndexModel : PageModel
    {
        public List<product> products;

        public void OnGet()
        {
            productservice service = new productservice();
            products = service.product();
        }
    }
}