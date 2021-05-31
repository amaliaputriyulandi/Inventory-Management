using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InventoryMgmt.Models;
using System.Data.Sql;
using purchasemvc.Models;

namespace InventoryMgmt.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: Inventory
        public ActionResult Index()
        {
            //return View(db.Inventories.ToList());
            return View(db.Func_GetInventory());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nama,Jumlah,Harga")] Inventory inventory)
        {
            var names = inventory.Nama;
            var name = (from x in db.Inventories where x.Nama == names select x).ToList();

            if (ModelState.IsValid)
            {
                if (name.Count > 0)
                {
                    ViewBag.Duplicate = "Inventory dengan nama " + names + " sudah exist pada database.";
                }
                else
                {
                    db.Inventories.Add(inventory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            return View(inventory);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nama,Jumlah,Harga")] Inventory inventory)
        {
            var names = inventory.Nama;
            var name = (from x in db.Inventories where x.Nama == names select x).ToList();

            if (ModelState.IsValid)
            {
                if (name.Count > 0)
                {
                    ViewBag.Duplicate = "Inventory dengan nama " + names + " sudah exist pada database.";
                }
                else
                {
                    db.Entry(inventory).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(inventory);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            OrderEntities dc = new OrderEntities();

            var fk = (from x in dc.Orders where x.InventoryId == inventory.Id select x).ToList();

            if (fk.Count > 0)
            {
                ViewBag.Duplicate = "Inventory tersebut terdapat referensi pada transaski Purchase / Orders.";
                return View(inventory);
            }
            else { 
            db.Inventories.Remove(inventory);
            db.SaveChanges();
            return RedirectToAction("Index");
            }

        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
