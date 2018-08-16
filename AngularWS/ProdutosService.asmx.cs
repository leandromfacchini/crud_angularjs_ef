using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Script.Serialization;

namespace AngularWS
{
    /// <summary>
    /// Summary description for ProdutosService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ProdutosService : System.Web.Services.WebService
    {

        [WebMethod]
        public void getProdutos()
        {
            List<Products> products = new List<Products>();
            string connectionString = ConfigurationManager.ConnectionStrings["connection"].ToString();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Products", con);
                con.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Products product = new Products();
                    product.ProductID = Convert.ToInt32(reader["ProductID"]);
                    product.ProductName = reader["ProductName"].ToString();
                    product.SupplierID = Convert.ToInt32(reader["SupplierID"]);
                    product.CategoryID = Convert.ToInt32(reader["CategoryID"]);
                    product.QuantityPerUnit = reader["QuantityPerUnit"].ToString();
                    product.UnitPrice = Convert.ToDecimal(reader["UnitPrice"]);
                    product.UnitsInStock = Convert.ToInt32(reader["UnitsInStock"]);
                    product.UnitsOnOrder = Convert.ToInt32(reader["UnitsOnOrder"]);
                    product.ReorderLevel = Convert.ToInt32(reader["ReorderLevel"]);
                    product.Discontinued = Convert.ToBoolean(reader["Discontinued"]);

                    products.Add(product);
                }
            }

            JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
            Context.Response.Write(javaScriptSerializer.Serialize(products));

        }
    }
}
