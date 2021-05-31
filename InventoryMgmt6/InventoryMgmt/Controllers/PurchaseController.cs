using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using purchasemvc.Models;

namespace purchasemvc.Controllers
{
    public class PurchaseController : Controller
    {
        string connectionString = ConfigurationManager.ConnectionStrings["InventoryConnectionString"].ConnectionString;
        [HttpGet]
        public ActionResult Index()
        {
            DataTable dtblPurchase = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("EXECUTE  [dbo].[GetPurchase] ", sqlCon);
                sqlDa.Fill(dtblPurchase);
            }
            return View(dtblPurchase);
        }

        //public static List<Supplier> GetSuppliers()
        //{
        //    List<Supplier> supplieridobj = new List<Supplier>();
        //    string connection = @"Data Source = LAPTOP - 0IHEI7B8\\SQLEXPRESS2; Initial Catalog = Inventory; Integrated Security = True";

        //    using (SqlConnection sqlconn = new SqlConnection(connection))
        //    {
        //        using (SqlCommand sqlcomm = new SqlCommand("select * from Supplier"))
        //        {
        //            using (SqlDataAdapter sda = new SqlDataAdapter())
        //            {
        //                sqlcomm.Connection = sqlconn;
        //                sqlconn.Open();
        //                sda.SelectCommand = sqlcomm;
        //                SqlDataReader sdr = sqlcomm.ExecuteReader();
        //                while (sdr.Read())
        //                {
        //                    Supplier supplierobj = new Supplier();
        //                    supplierobj.Nama = sdr["Nama"].ToString();
        //                    supplieridobj.Add(supplierobj);
        //                }
        //            }
        //            return supplieridobj;
        //        }
        //    }
        //}


        //[HttpGet]
        //// GET: Purchase/Create
        //public ActionResult Create()
        //{
        //    Supplier supplier = new Supplier();
        //    supplier.Nama = PopulateNama();
        //    return View(supplier,new PurchaseModel());
        //}

        [HttpGet]
        public ActionResult create()
        {
            SqlConnection sqlCon = new SqlConnection(connectionString);
            sqlCon.Open();
            SqlConnection _con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select * From Supplier", connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewBag.SupplierList = ToSelectList(dt, "Id", "Nama");

            SqlDataAdapter _da = new SqlDataAdapter("Select * From Inventory", connectionString);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.InventoryList = ToSelectList(_dt, "Id", "Nama");


            return View( new PurchaseModel());
        }



        //[HttpPost]
        //public ActionResult Create(Supplier supplier)
        //{
        //    supplier.Nama = PopulateNama();
        //    var selectedItem = supplier.Nama.Find(p => p.Value == supplier.Id.ToString());
        //    if (selectedItem != null)
        //    {
        //        selectedItem.Selected = true;
        //        ViewBag.Message = "supplier: " + selectedItem;

        //    }

        //    return View(supplier);

        //    private static List<SelectListItem> PopulateNama()
        //    {
        //        List<SelectListItem> items = new List<SelectListItem>();
        //        string connection = @"Data Source = LAPTOP - 0IHEI7B8\\SQLEXPRESS2; Initial Catalog = Inventory; Integrated Security = True";
        //        using (SqlConnection con = new SqlConnection(connection))
        //        {
        //            string query = " SELECT Nama, Id FROM Supplier";
        //            using (SqlCommand cmd = new SqlCommand(query))
        //            {
        //                cmd.Connection = con;
        //                con.Open();
        //                using (SqlDataReader sdr = cmd.ExecuteReader())
        //                {
        //                    while (sdr.Read())
        //                    {
        //                        items.Add(new SelectListItem
        //                        {
        //                            Text = sdr["Nama"].ToString(),
        //                            Value = sdr["Id"].ToString()
        //                        });
        //                    }
        //                }
        //                con.Close();
        //            }
        //        }

        //        return items;
        //    }

        ////public static List<Supplier> GetSuppliers()
        ////{
        ////    List<Supplier> supplieridobj = new List<Supplier>();
        ////    string connection = @"Data Source = LAPTOP - 0IHEI7B8\SQLEXPRESS2; Initial Catalog = Inventory; Integrated Security = True";

        ////    using (SqlConnection sqlconn = new SqlConnection(connection))
        ////    {
        ////        using (SqlCommand sqlcomm = new SqlCommand("select * from Supplier"))
        ////        {
        ////            using (SqlDataAdapter sda = new SqlDataAdapter())
        ////            {
        ////                sqlcomm.Connection = sqlconn;
        ////                sqlconn.Open();
        ////                sda.SelectCommand = sqlcomm;
        ////                SqlDataReader sdr = sqlcomm.ExecuteReader();
        ////                while (sdr.Read())
        ////                {
        ////                    Supplier supplierobj = new Supplier();
        ////                    supplierobj.Nama = sdr["Nama"].ToString();
        ////                    supplieridobj.Add(supplierobj);
        ////                }
        ////            }
        ////            return supplieridobj;
        ////        }
        ////    }

        //}

        //private ActionResult View(List<Supplier> lists, PurchaseModel purchaseModel)
        //{
        //    throw new NotImplementedException();
        //}

        // POST: Purchase/Create
        [HttpPost]
        public ActionResult Create(PurchaseModel purchaseModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "INSERT INTO Purchase VALUES(@SupplierId,@InventoryId,@TotalAmount)";
                //string query = "INSERT INTO Purchase VALUES(@TotalAmount,@TotalPrice)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@SupplierId", purchaseModel.SupplierId);
                sqlCmd.Parameters.AddWithValue("@InventoryId", purchaseModel.InventoryId);
                sqlCmd.Parameters.AddWithValue("@TotalAmount", purchaseModel.TotalAmount);
                _ = sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        [NonAction]
        public SelectList ToSelectList(DataTable table, string valueField, string textField)
        {
            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow row in table.Rows)
            {
                list.Add(new SelectListItem()
                {
                    Text = row[textField].ToString(),
                    Value = row[valueField].ToString()
                });
            }

            return new SelectList(list, "Value", "Text");
        }


        // GET: Purchase/Edit/5
        public ActionResult Edit(int id)
        {
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlConnection _con = new SqlConnection(connectionString);
            SqlDataAdapter da = new SqlDataAdapter("Select * From Supplier", connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ViewBag.SupplierList = ToSelectList(dt, "Id", "Nama");

            SqlDataAdapter _da = new SqlDataAdapter("Select * From Inventory", connectionString);
            DataTable _dt = new DataTable();
            _da.Fill(_dt);
            ViewBag.InventoryList = ToSelectList(_dt, "Id", "Nama");

            PurchaseModel purchaseModel = new PurchaseModel();
            DataTable dtblPurchase = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                String query = "SELECT * FROM Purchase Where Id = @Id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query,sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
                sqlDa.Fill(dtblPurchase);
            }
            if (dtblPurchase.Rows.Count == 1)
            {
                purchaseModel.Id = Convert.ToInt32(dtblPurchase.Rows[0][0].ToString());
                purchaseModel.SupplierId = Convert.ToInt32(dtblPurchase.Rows[0][1].ToString());
                purchaseModel.InventoryId = Convert.ToInt32(dtblPurchase.Rows[0][2].ToString());
                purchaseModel.TotalAmount = Convert.ToInt32(dtblPurchase.Rows[0][3].ToString());
                return View(purchaseModel);
            }
            else
                return RedirectToAction("Index");
        }

        // POST: Purchase/Edit/5
        [HttpPost]
        public ActionResult Edit(PurchaseModel purchaseModel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "UPDATE Purchase SET SupplierId = @SupplierId , InventoryId = @InventoryId, TotalAmount = @TotalAmount Where Id = @Id";
                //string query = "UPDATE Purchase SET TotalAmount = @TotalAmount, TotalPrice = @TotalPrice Where Id = @Id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", purchaseModel.Id);
                sqlCmd.Parameters.AddWithValue("@SupplierId", purchaseModel.SupplierId);
                sqlCmd.Parameters.AddWithValue("@InventoryId", purchaseModel.InventoryId);
                sqlCmd.Parameters.AddWithValue("@TotalAmount", purchaseModel.TotalAmount);
                _ = sqlCmd.ExecuteNonQuery();
            }

            return RedirectToAction("Index");

        }

        // GET: Purchase/Delete/5
        public ActionResult Delete(int id)
        {
            PurchaseModel purchaseModel = new PurchaseModel();
            DataTable dtblPurchase = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                String query = "SELECT * FROM Purchase Where Id = @Id";
                SqlDataAdapter sqlDa = new SqlDataAdapter(query, sqlCon);
                sqlDa.SelectCommand.Parameters.AddWithValue("@Id", id);
                sqlDa.Fill(dtblPurchase);
            }
            if (dtblPurchase.Rows.Count == 1)
            {
                purchaseModel.Id = Convert.ToInt32(dtblPurchase.Rows[0][0].ToString());
                purchaseModel.SupplierId = Convert.ToInt32(dtblPurchase.Rows[0][1].ToString());
                purchaseModel.InventoryId = Convert.ToInt32(dtblPurchase.Rows[0][2].ToString());
                purchaseModel.TotalAmount = Convert.ToInt32(dtblPurchase.Rows[0][3].ToString());
                return View(purchaseModel);
            }
            else
                return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(PurchaseModel purchaseModel,int id)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                string query = "DELETE FROM Purchase Where Id = @Id";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@Id", id);
                sqlCmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }
    }
}
