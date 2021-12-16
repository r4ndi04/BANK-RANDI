using NASABAH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NASABAH.Controllers
{
    public class NasabahController : ApiController
    {
        public IHttpActionResult AddNewNasabah(NasabahModel nasabah)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid data.");
            }

            using (var x = new DBNASABAHEntities())
            {
                x.tblNasabahs.Add(new tblNasabah()
                {
                    NO_KTP = nasabah.NO_KTP,
                    NAMA_LGKP = nasabah.NAMA_LGKP,
                    ALAMAT = nasabah.ALAMAT,
                    TMPT_LAHIR = nasabah.TMPT_LAHIR,
                    TGL_LAHIR = nasabah.TGL_LAHIR,
                    NO_HP = nasabah.NO_HP
                });

                x.SaveChanges();
            }

            return Ok(nasabah);
        }

        public IHttpActionResult GetNasabahById(string id)
        {
            List<tblNasabah> y = new List<tblNasabah>();
            using (var db = new DBNASABAHEntities())
            {
                y = db.tblNasabahs.Where(x => x.NO_KTP == id).ToList();
                if (y==null || y.Count == 0)
                {
                    return NotFound();
                }
            }
            return Ok(y);
        }

        public IHttpActionResult Put(NasabahModel nasabah)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Model Invalid.");
            }

            using (var db = new DBNASABAHEntities())
            {
                var existNasabah = db.tblNasabahs.Where(x => x.NO_KTP == nasabah.NO_KTP).FirstOrDefault<tblNasabah>();

                if (existNasabah != null)
                {
                    existNasabah.NAMA_LGKP = nasabah.NAMA_LGKP;
                    existNasabah.ALAMAT = nasabah.ALAMAT;
                    existNasabah.TMPT_LAHIR = nasabah.TMPT_LAHIR;
                    existNasabah.TGL_LAHIR = nasabah.TGL_LAHIR;
                    existNasabah.NO_HP = nasabah.NO_HP;

                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok(nasabah);
        }

        public IHttpActionResult Delete(string id)
        {
            using (var db = new DBNASABAHEntities())
            {
                var nasabah = db.tblNasabahs.Where(x => x.NO_KTP == id).FirstOrDefault();

                db.Entry(nasabah).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
