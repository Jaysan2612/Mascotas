using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MascotaFeliz.App.Dominio;
using MascotaFeliz.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MascotaFeliz.App.Frontend.Pages
{
    public class DetallesDuenosModel : PageModel
    {
        private readonly IRepositorioDueno _repoDueno;

        public Dueno dueno { get; set; }

        public DetallesDuenosModel()
        {
            this._repoDueno =
                new RepositorioDueno(new Persistencia.AppContext());
        }

        public IActionResult OnGet(int duenoId)
        {
            dueno = _repoDueno.GetDueno(duenoId);
            if (dueno == null)
            {
                return RedirectToPage("./NotFount");
            }
            else
            {
                return Page();
            }
        }
    }
}
