using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IPSAlyzer_v1.Models;
using IPSAlyzer_v1.ViewModels;
using PagedList;

namespace IPSAlyzer_v1.Controllers
{
    public class ProductsController : Controller
    {
        private ipsalyzerContainer db = new ipsalyzerContainer();

        // GET: Products
        public ActionResult Index(int? fid, int? page, bool? mode, int? catid, string lang = "en")
        {
            if (mode == null)
            {
                mode = false;
            }




            string viewname;  
            

            int pageSize = 3;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            IPagedList<Product> prod = null;
            IQueryable<Product> products;
            var funcs =(from x in db.Product_Func select x ).OrderBy(x => x.Id);
            var cats= (from x in db.Product_Cat select x).OrderBy(x => x.Id);
            var rps = (from x in db.recipes select x).OrderBy(x => x.Id);
            if (fid != null)
            {
                products = db.Products.Include(p => p.Product_Func).Where(p => p.Product_Func.Id == fid).OrderBy(p=>p.Id);
            }
            else
            { 
                products = db.Products.Include(p => p.Product_Func).OrderBy(p => p.Id);
            }
            if (Session["recipe"] == null)
            {
                List<Product> recp = new List<Product>();

                Session["recipe"] = recp;
            }
            prod = products.ToPagedList(pageIndex, pageSize);
            List<int> skip=new List<int>();
            int first = 0;
            int cnt = 0;
            foreach (var cat in cats)
            {
                cnt = ((IEnumerable<Product>)Session["recipe"]).Where(x => x.Product_CatId == cat.Id).Count();
                skip.Add(cnt);
                if (first==0 && cnt>0) { first = cat.Id; }
                
            }




            ViewBag.lang = lang;
            ViewBag.selectid = fid;
            ViewBag.mode = mode;
            ViewBag.catid = catid;
            ViewBag.skip = skip;
            ViewBag.first = first;
            if (lang=="en")
            {
                viewname = "index";
            }
            else
            {
                viewname = "c_index";
            }
            return View(viewname,new IndexViewModel { P_rcp= rps.ToList(), P_Cat =cats.ToList(),  P_Func = funcs.ToList(), P_s = /*products.ToList()*/ prod, P_recipe = (IEnumerable<Product>)Session["recipe"] });
        }

      

        // GET: Products/Create
        public ActionResult Add(int? fid, int? catid, int? proc_fid, string lang)
        {
            if (fid == null || catid == null)
            {
                return RedirectToAction("Index", new { fid = proc_fid, mode =false, lang=lang });
            }
            var product= db.Products.Include(p => p.Product_Func).Where(p => p.Id == fid).SingleOrDefault();
            product.Product_CatId = catid;
            List<Product> recp = (List < Product > )Session["recipe"];
            if (recp.Find(x => x.Id == fid && x.Product_CatId==catid) == null)
            {
                recp.Add(product);
            }
            Session["recipe"] = recp;
            return RedirectToAction("Index", new { fid=proc_fid, mode = false, lang = lang });
            
        }

       
       

     

        // GET: Products/Delete/5
        public ActionResult Delete(int? fid, int? catid, string lang)
        {
            if (fid == null || catid==null)
            {
                return RedirectToAction("Index", new { mode = false, lang = lang });
            }
            List<Product> recp = (List<Product>)Session["recipe"];
            Product product = recp.Find(x=>x.Id==fid && x.Product_CatId == catid);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                recp.Remove(product);
                Session["recipe"] = recp;
            }
            return RedirectToAction("Index", new { mode = false, lang = lang });
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
