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
    public partial class frmOrder : Form
    {
        TblMember loginMember = null;
        private MemberRepository memberDAO = new MemberRepository();
        private ProductRepository productDAO = new ProductRepository();

        private OrderRepository orderDao = new OrderRepository();
        private OrderDetailRepository orderDetailDAO = new OrderDetailRepository();
        string function = null;

        public frmOrder(TblMember member)
        {
            InitializeComponent();
            loginMember = member;
        }
        private void tool(Boolean check)
        {
            cboMemberID.Enabled = check;
            txtOrderID.Enabled = check;
            orderDate.Enabled = check;
            requireDate.Enabled = check;
            shippedDate.Enabled = check;
            txtFreight.Enabled = check;
            lbMemberID.Enabled = check;
            lborderID.Enabled = check;


            txtDiscount.Enabled = check;
            txtUnitPrice.Enabled = check;
            txtQuantity.Enabled = check;
            cboProductID.Enabled = check;
            lbQuantity.Enabled = check;

        }

        private void frmOrder_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Tài khoản : " + loginMember.Email;
            loadMember();
            loadProduct();
            loadOrder();
            tool(false);

            lbStatDate.Visible = false;
            lbRQDate.Visible = false;
            btSend.Enabled = false;
            btnEdit.Enabled = true;
            btnSave.Enabled = false;
            btnDelete.Enabled = true;
            btnReport.Enabled = true;
        }

        private void loadMember()
        {

            cboMemberID.DataSource = memberDAO.GetList();
            cboMemberID.DisplayMember = "CompanyName";
            cboMemberID.ValueMember = "MemberId";
        }

        private void loadProduct()
        {
            cboProductID.DataSource = productDAO.GetList();
            cboProductID.DisplayMember = "ProductName";
            cboProductID.ValueMember = "ProductId";
        }

        private void loadOrder()
        {
            dgvOrder.DataSource = orderDao.GetList();
        }

        private void loadOrderReport(DateTime startDate, DateTime endDate)
        {
            dgvOrder.DataSource = orderDao.GetListReport(startDate, endDate);
        }

        private void loadOrderDetail(int orderID)
        {
            dgvDetail.DataSource = orderDetailDAO.getListByID(orderID);
        }



        private void btnAdd_Click(object sender, EventArgs e)
        {
            tool(true);
            function = "Add";
            btnSave.Enabled = true;
            txtOrderID.Text = "Auto Generated";
            txtOrderID.ReadOnly = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            tool(true);
            function = "Edit";
            btnSave.Enabled = true;
            txtOrderID.Enabled = false;
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            
            btnSave.Enabled = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;
            btnDelete.Enabled = false;
            lborderDate.Enabled = false;
            lbRQDate.Enabled = false;
            lbStatDate.Enabled = true;
            lbEndDate.Enabled = true;
            btnReport.Enabled = true;
            btSend.Enabled = true; 
            orderDate.Enabled = true;
            requireDate.Enabled = true;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                loadOrder();
                loadOrderReport(DateTime.Parse(orderDate.Text.Trim()), DateTime.Parse(requireDate.Text.Trim()));
                lbStatDate.Enabled = false;
                lbEndDate.Enabled = false;
                btnSave.Enabled = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
                lborderDate.Enabled = true;
                lbRQDate.Enabled = true;
                lbStatDate.Enabled = true;
                lbEndDate.Enabled = true;
                btnReport.Enabled = true;
                btSend.Enabled = true;
                orderDate.Enabled = true;
                requireDate.Enabled = true;

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try            
            {
                TblOrder order = new TblOrder();
                TblOrderDetail orderDetail = new TblOrderDetail();
                    
                    try
                {
                    order.OrderId = int.Parse(txtOrderID.Text.Trim());
                } catch(Exception ex)
                {
                    order.OrderId = 0;
                }

                if (cboMemberID.Text.Length < 0) throw new Exception("No member");
                if (txtQuantity.Text.Length < 0) throw new Exception("Empty Quantity");
                if (txtUnitPrice.Text.Length < 0) throw new Exception("Empty Price");

                    order.MemberId = int.Parse(cboMemberID.SelectedValue.ToString());
                    try
                {
                    order.OrderDate = DateTime.Parse(orderDate.Text.Trim());
                    order.ShippedDate = DateTime.Parse(shippedDate.Text.Trim());
                    order.RequiredDate = DateTime.Parse(requireDate.Text.Trim());
                } catch(Exception ex)
                {

                }
                    
                try
                {
                    order.Freight = decimal.Parse(txtFreight.Text.Trim());
                } catch (Exception ex)
                {
                    order.Freight = 0;
                }

                    orderDetail.ProductId = int.Parse(cboProductID.SelectedValue.ToString());
                    orderDetail.OrderId = order.OrderId;
                    orderDetail.UnitPrice = decimal.Parse(txtUnitPrice.Text.Trim());
                    orderDetail.Quantity = int.Parse(txtQuantity.Text.Trim());
                    try
                {
                    orderDetail.Discount = double.Parse(txtDiscount.Text.Trim());
                } catch(Exception ex)
                {
                    orderDetail.Discount = 0;
                }    

                switch (function)
                {
                    case "Add":
                        {
                            orderDao.Insert(order);
                            orderDetailDAO.Insert(orderDetail);
                            loadOrder();
                            loadOrderDetail(order.OrderId);
                            MessageBox.Show("Thêm thành công.", "Thông báo");
                            break;
                        }
                    case "Edit":
                        {
                            orderDao.Update(order);
                            orderDetailDAO.Update(orderDetail);
                            loadOrder();
                            loadOrderDetail(order.OrderId);
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

        private void dgvOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void DgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int rowindex = e.RowIndex;
                if (rowindex < 0 || rowindex >= dgvOrder.Rows.Count)
                {
                    throw new Exception("Chưa chọn đúng thông tin");
                }
                txtOrderID.Text = dgvOrder.Rows[rowindex].Cells["OrderID"].Value.ToString();
                cboMemberID.Text = dgvOrder.Rows[rowindex].Cells["MemberID"].Value.ToString();
                orderDate.Text = dgvOrder.Rows[rowindex].Cells["OrderDate"].Value.ToString();
                requireDate.Text = dgvOrder.Rows[rowindex].Cells["RequiredDate"].Value.ToString();
                shippedDate.Text = dgvOrder.Rows[rowindex].Cells["ShippedDate"].Value.ToString();
                txtFreight.Text = dgvOrder.Rows[rowindex].Cells["Freight"].Value.ToString();

                int id = int.Parse(dgvOrder.Rows[rowindex].Cells["OrderID"].Value.ToString());
                loadOrderDetail(id);
                dgvDetail.Enabled = true;
                btnEdit.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void DgvDetail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                int rowindex = e.RowIndex;
                if (rowindex < 0 || rowindex >= dgvDetail.Rows.Count)
                {
                    throw new Exception("Chưa chọn đúng thông tin");
                }
                cboProductID.Text = dgvDetail.Rows[rowindex].Cells["ProductId"].Value.ToString();
                txtUnitPrice.Text = dgvDetail.Rows[rowindex].Cells["Unit Price"].Value.ToString();
                txtQuantity.Text = dgvDetail.Rows[rowindex].Cells["Quantity"].Value.ToString();
                txtDiscount.Text = dgvDetail.Rows[rowindex].Cells["Discount"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            try
            {
              int id = int.Parse(txtOrderID.Text);
              orderDao.Delete(id);
              orderDetailDAO.Delete(id);
            } catch (Exception ex)
            {
                MessageBox.Show("Error");
            }
            
        }
    }
}
