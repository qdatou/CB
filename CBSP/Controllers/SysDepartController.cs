using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CBSP.DAL;
using Newtonsoft.Json;
using CBSP.Models;

namespace CBSP.Controllers
{
    public class SysDepartController : Controller
    {
        private CBDBModel db = new CBDBModel();

        // GET: SysDepart
        public ActionResult Index()
        {
            /*
            List<Sys_Depart> lists = db.Sys_Depart.ToList();
            db.Sys_Depart.ToList();
            */


            return View();
        }



        [HttpGet]
        public string GetNodes()
        {
            List<NodeModel> departNodes = new List<NodeModel>();

            List<Sys_Depart> lists = db.Sys_Depart.ToList();
            for (int i=0; i<lists.Count;  i++)
            {
                Sys_Depart depart = (Sys_Depart)lists[i];
                
                NodeModel node = new NodeModel();
                node.id = depart.id;
                node.name = depart.name;
                node.pId = depart.parent_id;
                node.open = true;
                //node.isParent = true;
                departNodes.Add(node);
            }

            // 节点类集合
           

           
            string json = JsonConvert.SerializeObject(departNodes);

            return json;
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Depart sys_Depart = db.Sys_Depart.Find(id);
            if (sys_Depart == null)
            {
                return HttpNotFound();
            }
            return View(sys_Depart);
        }

        // GET: SysDepart/Create
        public ActionResult Create()
        {
            return View();
        }
        
        // GET: SysDepart/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Depart sys_Depart = db.Sys_Depart.Find(id);
            if (sys_Depart == null)
            {
                return HttpNotFound();
            }
            return View(sys_Depart);
        }

        /// <summary>
        /// 保存操作
        /// </summary>
        /// <param name="sys_Depart"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSysDepart([Bind(Include = "id,parent_id,name")] Sys_Depart sys_Depart)
        {

            int id = sys_Depart.id;
            if (id > 0)
            {
                db.Entry(sys_Depart).State = EntityState.Modified;
                db.SaveChanges();
            }
            else
            {
                db.Sys_Depart.Add(sys_Depart);
                db.SaveChanges();
            }
            return RedirectToAction("Index");

            //return View(sys_Depart);
        }

        // GET: SysDepart/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sys_Depart sys_Depart = db.Sys_Depart.Find(id);
            if (sys_Depart == null)
            {
                return HttpNotFound();
            }
            return View(sys_Depart);
        }

        // POST: SysDepart/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sys_Depart sys_Depart = db.Sys_Depart.Find(id);
            db.Sys_Depart.Remove(sys_Depart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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
