using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace registerweb2.Controllers
{
    public class DaftarController : Controller
    {
        // GET: Daftar
        pendaftaranEntities _context = new pendaftaranEntities();
        public ActionResult Index()
        {
            var ListofData = _context.Daftars.ToList();
            return View(ListofData);
        }

        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create(Daftar model)
        {
            _context.Daftars.Add(model);
            _context.SaveChanges();
            ViewBag.Massage = "Data Berhasil Dimasukan";
            return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var data = _context.Daftars.Where(x => x.Id == id).FirstOrDefault();
            return View();
        }
        [HttpPost]
        public ActionResult Edit(Daftar Model)
        {
            var data = _context.Daftars.Where(x => x.Id == Model.Id).FirstOrDefault();
            if (data != null)
            {
                data.nama = Model.nama;
                data.instansi = Model.instansi;
                data.ttl = Model.ttl;
                data.nik = Model.nik;
                data.email = Model.email;
                data.no_hp = Model.no_hp;
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }
        
        public ActionResult Detail(int id)
        {
            var data = _context.Daftars.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }

        public ActionResult Delete(int id)
        {
            var data = _context.Daftars.Where(x => x.Id == id).FirstOrDefault();
            _context.Daftars.Remove(data);
            _context.SaveChanges();
            ViewBag.Message = "Data Berhasil Dihapus";
            return RedirectToAction("index");
        }
    
    }
}