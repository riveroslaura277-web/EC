using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class Nosotros : Controller
    {
        // GET: Nosotros
        public ActionResult Index()
        {
            return View();
        }

        // GET: Nosotros/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Nosotros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nosotros/Create
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

        // GET: Nosotros/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Nosotros/Edit/5
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

        // GET: Nosotros/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Nosotros/Delete/5
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
