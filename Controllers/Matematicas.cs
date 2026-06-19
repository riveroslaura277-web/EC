using Microsoft.AspNetCore.Mvc;

namespace EC.Controllers
{
    public class Matematicas : Controller
    {
        // GET: Matematicas
        public ActionResult Index()
        {
            return View();
        }

        // GET: Matematicas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Matematicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Matematicas/Create
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

        // GET: Matematicas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Matematicas/Edit/5
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

        // GET: Matematicas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Matematicas/Delete/5
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
