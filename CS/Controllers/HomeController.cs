using System;
using System.IO;
using System.Web;
using System.Web.Mvc;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrintingLinks;
using DevExpress.Web.Mvc;
using CS.Model;

namespace CS.Controllers {
    public class HomeController : Controller {
        public ActionResult Index() {
            return View(new MyViewModel { Categories = MyModel.GetCategories(), Products = MyModel.GetProducts(0) });
        }
        public ActionResult GridViewPartialCategories() {
            return PartialView(MyModel.GetCategories());
        }
        public ActionResult GridViewPartialProducts() {
            return PartialView(MyModel.GetProducts(Request.Params["MasterRowKey"]));
        }

        public ActionResult ExportTo(int MasterRowKey) {
            var ps = new PrintingSystemBase();

            var link1 = new PrintableComponentLinkBase(ps);
            GridViewSettings categoriesGridSettings = new GridViewSettings();
            categoriesGridSettings.Name = "gvCategories";
            categoriesGridSettings.KeyFieldName = "CategoryID";
            categoriesGridSettings.Columns.Add("CategoryID");
            categoriesGridSettings.Columns.Add("CategoryName");
            categoriesGridSettings.Columns.Add("Description");
            link1.Component = GridViewExtension.CreatePrintableObject(categoriesGridSettings, MyModel.GetCategories());

            var link2 = new PrintableComponentLinkBase(ps);
            GridViewSettings productsGridSettings = new GridViewSettings();
            productsGridSettings.Name = "gvProducts";
            productsGridSettings.KeyFieldName = "ProductID";
            productsGridSettings.Columns.Add("ProductID");
            productsGridSettings.Columns.Add("ProductName");
            productsGridSettings.Columns.Add("CategoryID");
            productsGridSettings.Columns.Add("UnitPrice");
            link2.Component = GridViewExtension.CreatePrintableObject(productsGridSettings, MyModel.GetProducts(MasterRowKey));

            var compositeLink = new CompositeLinkBase(ps);
            compositeLink.Links.AddRange(new object[] { link1, link2 });
            compositeLink.CreateDocument();

            FileStreamResult result = CreateExcelExportResult(compositeLink);
            ps.Dispose();

            return result;
        }

        FileStreamResult CreateExcelExportResult(CompositeLinkBase link) {
            MemoryStream stream = new MemoryStream();
            link.PrintingSystemBase.ExportToXls(stream);
            stream.Position = 0;
            FileStreamResult result = new FileStreamResult(stream, "application/xls");
            result.FileDownloadName = "MyData.xls";
            return result;
        }
    }
}
