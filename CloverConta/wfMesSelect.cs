using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloverConta
{
    public partial class wfMesSelect : Form
    {
        public string _sMes;
        public string _sAxo;
        public wfMesSelect()
        {
            InitializeComponent();
        }

        private void btMes1_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "01";
            Close();
        }

        private void btMes2_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "02";
            Close();
        }

        private void btMes3_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "03";
            Close();
        }

        private void btMes4_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "04";
            Close();
        }

        private void wfMesSelect_Load(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
        }

        private void btMes5_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "05";
            Close();
        }

        private void btMes6_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "06";
            Close();
        }

        private void btMes7_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "07";
            Close();
        }

        private void btMes8_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "08";
            Close();
        }

        private void btMes9_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "09";
            Close();
        }

        private void btMes10_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "10";
            Close();
        }

        private void btMes11_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "11";
            Close();
        }

        private void btMes12_Click(object sender, EventArgs e)
        {
            _sAxo = txtYear.Text.ToString();
            _sMes = "12";
            Close();
        }

        private void btDown_Click(object sender, EventArgs e)
        {
            int iYear = 0;
            if(int.TryParse(txtYear.Text,out iYear))
            {
                iYear--;
                txtYear.Text = iYear.ToString();
            }
        }

        private void btUp_Click(object sender, EventArgs e)
        {
            int iYear = 0;
            if (int.TryParse(txtYear.Text, out iYear))
            {
                iYear++;
                txtYear.Text = iYear.ToString();
            }
        }
    }
}
