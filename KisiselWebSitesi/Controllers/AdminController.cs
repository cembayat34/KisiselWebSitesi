using KisiselWebSitesi.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KisiselWebSitesi.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var deger = c.AnaSayfas.ToList();
            return View(deger);
        }
        [Authorize]
        public ActionResult AnaSayfaGetir(int id)
        {
            //ag=AnaSayfa Getir
            var ag = c.AnaSayfas.Find(id);
            return View("AnaSayfaGetir", ag);
        }
        [Authorize]
        public ActionResult AnaSayfaGuncelle(AnaSayfa anaSayfa)
        {

            var anasyf = c.AnaSayfas.Find(anaSayfa.id);
            anasyf.isim = anaSayfa.isim;
            anasyf.profil = anaSayfa.profil;
            anasyf.unvan = anaSayfa.unvan;
            anasyf.aciklama = anaSayfa.aciklama;
            anasyf.iletisim = anaSayfa.iletisim;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult IkonListesi()
        {
            var deger = c.Ikonlars.ToList();
            return View(deger);
        }

        [Authorize]
        [HttpGet]

        public ActionResult YeniIkon()
        {

            return View();
        }

        [HttpPost]
        public ActionResult YeniIkon(Ikonlar p)
        {

            c.Ikonlars.Add(p);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
        [Authorize]
        public ActionResult IkonGetir(int id)
        {
            //ig= ikon getir
            var ig = c.Ikonlars.Find(id);
            return View("IkonGetir", ig);
        }
        [Authorize]
        public ActionResult IkonGuncelle(Ikonlar x)
        {
            //ig= ikon getir
            var ig = c.Ikonlars.Find(x.id);
            ig.ikon = x.ikon;
            ig.link = x.link;
            c.SaveChanges();
            return RedirectToAction("IkonListesi");
        }
        [Authorize]
        public ActionResult IkonSil(int id)
        {
            //sl = sil
            var sl = c.Ikonlars.Find(id);
            c.Ikonlars.Remove(sl);
            c.SaveChanges();
            return RedirectToAction("IkonListesi");

        }

    }
}