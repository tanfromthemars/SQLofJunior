using HotelManager.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManager
{
    public partial class fManagement : Form
    {
        private string userName;
        public fManagement(string userName)
        {
            this.userName = userName;
            InitializeComponent();
            fLoad();
        }
        public bool IsAdmin()
        {
            return AccountTypeDAO.Instance.GetStaffTypeByUserName(userName).Id == 1;
        }
        void fLoad()
        {
            panelLeft.Width = 17;
        }
        private bool CheckAccess(string nameform)
        {
            return AccessDAO.Instance.CheckAccess(userName, nameform);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnNavigationPanel_Click(object sender, EventArgs e)
        {
            if (panelLeft.Width == 42)
            {
                panelLeft.Width = 177;
                panelRight.Width = 939;
                this.Width = 1116;
            }    
            else
            {
                panelLeft.Width = 42;
                panelRight.Width = 807;
                this.Width = 981;
            }    
        }

        private void titleBookRoom_Click(object sender, EventArgs e)
        {
            if (CheckAccess("fBookRoom"))
            {
                Hide();
                
            }    
        }
    }
}
