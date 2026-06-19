
using Microsoft.AspNetCore.Mvc;

namespace EC.Controladores
{
    public class Contactanos : Controller
    {
        // GET: Contactanos
        public ActionResult Index()
        {
            return View();
        }

        // GET: Contactanos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Contactanos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contactanos/Create
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

        // GET: Contactanos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Contactanos/Edit/5
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

        // GET: Contactanos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contactanos/Delete/5
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
