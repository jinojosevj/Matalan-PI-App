#region NameSpace
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
#endregion NameSpace
namespace PICountApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        #region btnPI_Click
        /// <summary>
        /// btnPI_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPI_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {
                var Result = MessageBox.Show("Are You Want to Create New PI ?", "PI", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    frmScan objPI = new frmScan(1,fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        #endregion btnPI_Click


        #region btnNegative_Click
        /// <summary>
        /// btnNegative_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNegative_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New Negative ?", "Negative", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    frmScan objPI = new frmScan(3,fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion btnNegative_Click

        #region btnWriteOff_Click
        /// <summary>
        /// btnWriteOff_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWriteOff_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New WriteOff ?", "WriteOff", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    frmScan objPI = new frmScan(2,fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion btnWriteOff_Click

        #region btnLabel_Click
        /// <summary>
        /// btnLabel_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLabel_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New Label Print ?", "Label", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    LabelPrinting objPI = new LabelPrinting(fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        #endregion btnLabel_Click

        #region btnPO_Click
        /// <summary>
        /// btnPO_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPO_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New PO?", "PO", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    PO objPI = new PO(fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion btnPO_Click

        #region btnOffer_Click
        /// <summary>
        /// btnOffer_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOffer_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New Offer?", "Offer", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    OfferCheck objPI = new OfferCheck(fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion btnOffer_Click


        #region btnReceive_Click
        /// <summary>
        /// btnReceive_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReceive_Click(object sender, EventArgs e)
        {
            if (txtFileName.Text.Length > 0)
            {

                var Result = MessageBox.Show("Are You Want to Create New Receive ?", "Receive", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                if (Result == System.Windows.Forms.DialogResult.Yes)
                {
                    string fileName = txtFileName.Text.Trim();
                    frmScan objPI = new frmScan(4, fileName);
                    objPI.Show();
                }
                lblMessage.Text = "";
            }
            else
            {
                lblMessage.Text = "Enter File Name!";
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
        #endregion btnReceive_Click


    }
}