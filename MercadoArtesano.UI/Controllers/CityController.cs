using MercadoArtesano.BL;
using MercadoArtesano.EN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MercadoArtesano.UI.Controllers
{
    public class CityController : Controller
    {
        CityBL cityBL = new CityBL();
        // GET: CityController
        public async Task<IActionResult> Index(City city)
        {
            if (city == null)
                city = new City();
            if (city.Top_Aux == 0)
                city.Top_Aux = 10; // setear el número de registros a mostrar
            else if (city.Top_Aux == -1)
                city.Top_Aux = 0;

            var roles = await cityBL.SearchAsync(city);
            ViewBag.Top = city.Top_Aux;

            return View(roles);
        }

        // GET: CityController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var city = await cityBL.GetByIdAsync(new City { Id = id });
            return View(city);
        }

        // GET: CityController/Create
        public ActionResult Create()
        {
            ViewBag.Error = "";
            return View();
        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            try
            {
                int result = await cityBL.CreateAsync(city);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: CityController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var city = await cityBL.GetByIdAsync(new City { Id = id });
            ViewBag.Error = "";
            return View(city);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, City city)
        {
            try
            {
                int result = await cityBL.UpdateAsync(city);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(city);
            }
        }

        // GET: CityController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var city = await cityBL.GetByIdAsync(new City { Id = id });
            ViewBag.Error = "";
            return View(city);
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, City city)
        {
            try
            {
                int result = await cityBL.DeleteAsync(city);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View(city);
            }
        }
    }
}
