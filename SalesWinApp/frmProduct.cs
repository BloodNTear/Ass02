using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.BusinessObject;
using DataAccess.Repository;
namespace SalesWinApp
{
    public partial class frmProduct : Form
    {
        TblMember loginMember = null;
        string function = null;
        private ProductRepository productDao = new ProductRepository();
        public frmProduct(TblMember member)
        {
            InitializeComponent();
            loginMember = member;
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tài khoản :" + loginMember.Email;
            var list = productDao.GetList();
            loadProduct(list);
            tool(false);
            btnEdit.Enabled = false;

            btnSave.Enabled = false;
            btnDelete.Enabled = false;
        }

        private void loadProduct(List<TblProduct> list)
        {
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = list;
        }

        private void tool(Boolean check)
        {
            txtCategoryID.Enabled = check;
            txtProductID.Enabled = check;
            txtProductName.Enabled = check;
            txtWeight.Enabled = check;
            txtPrice.Enabled = check;
            txtStock.Enabled = check;
        }

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tool(true);
            function = "Add";
            btnSave.Enabled = true;
            txtProductID.ReadOnly = true;
            txtProductID.Text = "Auto generated";
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tool(true);
            function = "Edit";
            btnSave.Enabled = true;
            txtProductID.Enabled = false;
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex < 0 || rowindex >= dgvProduct.Rows.Count)
                {
                    throw new Exception("Chưa chọn đúng thông tin");
                }

                txtProductID.Text = dgvProduct.Rows[rowindex].Cells["ProductId"].Value.ToString();
                txtCategoryID.Text = dgvProduct.Rows[rowindex].Cells["CategoryId"].Value.ToString();
                txtProductName.Text = dgvProduct.Rows[rowindex].Cells["ProductName"].Value.ToString();
                txtWeight.Text = dgvProduct.Rows[rowindex].Cells["Weight"].Value.ToString();
                txtPrice.Text = dgvProduct.Rows[rowindex].Cells["UnitPrice"].Value.ToString();
                txtStock.Text = dgvProduct.Rows[rowindex].Cells["UnitslnStock"].Value.ToString();

                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TblProduct product = new TblProduct();

                if (txtProductName.Text.Length < 1) throw new Exception("Product name cannot be empty");
                if (txtCategoryID.Text.Length < 1) throw new Exception("Category cannot be empty");
                if (txtPrice.Text.Length < 1) throw new Exception("Price cannot be empty");
                if (txtStock.Text.Length < 1) throw new Exception("Stock cannot be empty");

                if (decimal.Parse(txtPrice.Text.Trim()) < 1) throw new Exception("Price must be greater than 0");
                if (int.Parse(txtStock.Text.Trim()) < 1) throw new Exception("Stock must be greater than 0");

                try
                {
                    product.ProductId = int.Parse(txtProductID.Text);
                } catch(Exception ex)
                {
                    product.ProductId = 0;
                }
                product.CategoryId = int.Parse(txtCategoryID.Text.Trim());
                product.ProductName = txtProductName.Text.Trim();
                product.Weight = txtWeight.Text.Trim();
                product.UnitPrice = decimal.Parse(txtPrice.Text.Trim());
                product.UnitslnStock = int.Parse(txtStock.Text.Trim());

                switch (function)
                {
                    case "Add":
                        {
                            productDao.Insert(product);
                            var list = productDao.GetList();
                            loadProduct(list);
                            MessageBox.Show("Thêm thành công.", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            productDao.Update(product);
                            var list = productDao.GetList();
                            loadProduct(list);
                            MessageBox.Show("Sửa thành công.", "Thông báo");
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productId = int.Parse(txtProductID.Text.Trim());
            TblProduct product = productDao.getRow(productId);
            productDao.Delete(product);
            MessageBox.Show("Xóa thành công.", "Thông báo");
            dgvProduct.DataSource = productDao.GetList();
        }


        //private void loadSearch(int productId)
        //{
        //    dgvProduct.DataSource = productDao.getListSearch(productId);
        //}


        private void btnUnitPriceSearch_Click(object sender, EventArgs e)
        {
            var target = new List<TblProduct>();
            try
            {
                if (txtSearchByPrice.Text.Trim().Length < 1) throw new Exception("Please input something to search");
                decimal price = decimal.Parse(txtSearchByPrice.Text.Trim());
                target = productDao.SearchbyPrice(price);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadProduct(target);
        }


        private void btnSearchByID_Click(object sender, EventArgs e)
        {
            var target = new List<TblProduct>();
            try
            {
                if (txtSearchID.Text.Trim().Length < 1) throw new Exception("Please input something to search");
                int id = int.Parse(txtSearchID.Text.Trim());
                target = productDao.getListSearch(id);
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadProduct(target);
        }

        private void BtnLoadAll_Click(object sender, EventArgs e)
        {
            var list = productDao.GetList();
            loadProduct(list);
        }

        private void btnSearchByName_Click(object sender, EventArgs e)
        {
            var target = new List<TblProduct>();
            try
            {
                if (txtSearchName.Text.Trim().Length < 1) throw new Exception("Please input something to search");
                string name = txtSearchName.Text.Trim();
                target = productDao.SearchByName(name);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadProduct(target);
        }

        private void btnUnitInStockSearch_Click(object sender, EventArgs e)
        {
            var target = new List<TblProduct>();
            try
            {
                if (txtUnitInStockSearch.Text.Trim().Length < 1) throw new Exception("Please input something to search");
                int stock = int.Parse(txtUnitInStockSearch.Text.Trim());
                target = productDao.SearchbyStock(stock);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadProduct(target);
        }
    }
}
