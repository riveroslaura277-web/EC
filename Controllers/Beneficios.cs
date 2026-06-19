
using Microsoft.AspNetCore.Mvc;

namespace EC.Controladores
{
    public class Beneficios : Controller
    {
        // GET: Beneficios
        public ActionResult Index()
        {
            return View();
        }

        // GET: Beneficios/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Beneficios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Beneficios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Beneficios/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Beneficios/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Beneficios/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Beneficios/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
