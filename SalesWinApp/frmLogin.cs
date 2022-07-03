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
namespace SalesWinApp
{
    public partial class frmLogin : Form
    { 
        private MemberManagementContext context = new MemberManagementContext();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbtenDangNhap.TextLength < 6)
                {
                    throw new Exception("tên đăng nhập ít nhất 6 kí tự");
                }
                if (tbMatKhau.TextLength <6)
                {
                    throw new Exception("Mật Khẩu ít nhất 6 kí tự");
                }
                String tenDangNhap = tbtenDangNhap.Text.Trim();
                String matKhau = tbMatKhau.Text.Trim();
                TblMember member = context.TblMembers.Where(m=> m.Email == tenDangNhap).FirstOrDefault();
                if (member == null)
                {
                    throw new Exception("Tên đăng nhập không tồn tại");
                }
                if (member.Password != matKhau)
                {
                    throw new Exception("Mật khẩu không chính xác");
                }
                Form frmmain = new frmMainNotMDI(member);
                frmmain.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Thông Báo");
            }
        }
    }
}
