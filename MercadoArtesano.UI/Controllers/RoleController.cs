using MercadoArtesano.BL;
using MercadoArtesano.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoArtesano.UI.Controllers
{
    public class RoleController : Controller
    {
        RoleBL roleBL = new RoleBL();
        // GET: RoleController
        public async Task<IActionResult> Index(Role role = null)
        {
            if (role == null)
                role = new Role();
            if (role.Top_Aux == 0)
                role.Top_Aux = 10; // setear el número de registros a mostrar
            else if (role.Top_Aux == -1)
                role.Top_Aux = 0;

            var roles = await roleBL.SearchAsync(role);
            ViewBag.Top = role.Top_Aux;

            return View(roles);
        }

        // acción que muestra los detalles de un registro
        public async Task<IActionResult> Details(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            return View(role);
        }

        // acción que muestra el formulario para agregar una nueva categoría
        public IActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // acción que recibe los datos del formulario y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Role role)
        {
            try
            {
                int result = await roleBL.CreateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }

        // // acción que muestra el formulario con los datos cargados para modificar
        public async Task<IActionResult> Edit(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            ViewBag.Error = "";
            return View(role);
        }

        // acción que recibe los datos modificados y los envía a la bd
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Role role)
        {
            try
            {
                int result = await roleBL.UpdateAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }

        // acción que muestra los datos para confirmar la eliminación
        public async Task<IActionResult> Delete(int id)
        {
            var role = await roleBL.GetByIdAsync(new Role { Id = id });
            ViewBag.Error = "";
            return View(role);
        }

        // acción que recibe la confirmación de eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, Role role)
        {
            try
            {
                int result = await roleBL.DeleteAsync(role);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(role);
            }
        }
    }
}
