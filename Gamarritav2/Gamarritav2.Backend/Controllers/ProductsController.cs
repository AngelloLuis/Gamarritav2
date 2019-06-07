namespace Gamarritav2.Backend.Controllers
{
    using Backend.Models;
    using Common.Models;
    using Gamarritav2.Backend.Helpers;
    using System;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;


    public class ProductsController : Controller
    {
        private LocalDataContext db = new LocalDataContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await this.db.Products.OrderBy(p => p.description).ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await this.db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ProductView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Products";

                if (view.imageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.imageFile, folder);
                    pic = $"{folder}/{pic}";
                }
                var product = this.ToProduct(view, pic);

                this.db.Products.Add(product);
                await this.db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Product ToProduct(ProductView view, string pic)
        {
            return new Product
            {
                description = view.description,
                imagePath = pic,
                isAvailable = view.isAvailable,
                price = view.price,
                productId = view.productId,
                publishOn = view.publishOn,
                remarks = view.remarks
            };
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = await this.db.Products.FindAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            var view = this.ToView(product);

            return View(view);
        }

        private ProductView ToView(Product product)
        {
            return new ProductView
            {
                description = product.description,
                imagePath = product.imagePath,
                isAvailable = product.isAvailable,
                price = product.price,
                productId = product.productId,
                publishOn = product.publishOn,
                remarks = product.remarks
            };
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.imagePath;
                var folder = "~/Content/Products";

                if (view.imageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.imageFile, folder);
                    pic = $"{folder}/{pic}";
                }
                var product = this.ToProduct(view, pic);

                this.db.Entry(product).State = EntityState.Modified;
                await this.db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(view);
        }

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var  product = await this.db.Products.FindAsync(id);

            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await this.db.Products.FindAsync(id);
            this.db.Products.Remove(product);
            await this.db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
