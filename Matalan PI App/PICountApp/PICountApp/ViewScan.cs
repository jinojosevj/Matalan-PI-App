using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PICountApp
{
    public partial class ViewScan : Form
    {
        public ViewScan(DataTable dt)
        {
            InitializeComponent();
            dgvData.DataSource = dt;
        }
    }
}