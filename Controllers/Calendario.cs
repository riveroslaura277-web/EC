
using Microsoft.AspNetCore.Mvc;

namespace EC.Controladores
{
    public class Calendario : Controller
    {
        // GET: Calendario
        public ActionResult Index()
        {
            return View();
        }

        // GET: Calendario/Details/54
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calendario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendario/Create
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

        // GET: Calendario/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Calendario/Edit/5
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

        // GET: Calendario/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Calendario/Delete/5
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
