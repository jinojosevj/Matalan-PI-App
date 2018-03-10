#region NameSpace
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
//using PICountApp.BAL;
//using FileHelpers;
//using FileHelpers;

#endregion NameSpace


namespace PICountApp
{
    public partial class OfferCheck : Form
    {
        DataTable dtOffer = new DataTable();
        DataTable dtData = new DataTable();

        int i = 0;
        int k = 0;
        bool flag = true;

        string fileName = "", fileNameBackup = "";


        #region Events

        public OfferCheck(string UserFile)
        {
            InitializeComponent();
            fileName = ".\\My Documents\\Offer_data_" + UserFile + ".csv";
            fileNameBackup = ".\\Windows\\Offer_dataBackup.csv";

            if (File.Exists(fileName))
                File.Delete(fileName);

            txtQty.Text = "1";
            dtOffer.Columns.Add("Barcode");
            dtOffer.Columns.Add("Quantity", typeof(Int32));

            lblTotalQty.Text = "0";
            UpdateData();
            
        }

        #region txtBarcode_TextChanged
        /// <summary>
        /// txtBarcode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            Offer();
        }
        #endregion txtBarcode_TextChanged

        #region btnSave_Click
        /// <summary>
        /// btnSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            
        }
        #endregion btnSave_Click

        #region menuSave_Click
        /// <summary>
        /// menuSave_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        #endregion menuSave_Click

        #region menuExit_Click
        /// <summary>
        /// menuExit_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuExit_Click(object sender, EventArgs e)
        {
            var Result = MessageBox.Show("Are You Want to Save?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

            if (Result == System.Windows.Forms.DialogResult.Yes)
            {
                Save();
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
        #endregion menuExit_Click

        #endregion Events

        #region Methods

        #region Offer
        /// <summary>
        /// Offer
        /// </summary>
        private void Offer()
        {
           
                string str = GetLast(txtBarcode.Text.ToString(), 1);

                if (str == "\n" && txtBarcode.Text.Trim().ToString().Length == 13)
                {
                    //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());

                    if (CheckBarcode(txtBarcode.Text.Trim().ToString()))
                    {
                        dtOffer.Rows.Add();
                        dtOffer.Rows[i]["Quantity"] = Convert.ToInt32(txtQty.Text.Trim());
                        dtOffer.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        i++;
                       
                        txtBarcode.Text = "";
                        lblQty.Text = dtOffer.Rows.Count.ToString();

                        int sum = Convert.ToInt32(lblTotalQty.Text);
                        //foreach (DataRow dr in dtOffer.Rows)
                        //{
                           sum += Convert.ToInt32(txtQty.Text.Trim()); 
                            //foreach (DataColumn dc in dt.Columns)
                            //{

                            //}
                        //} 

                        //DataRow[] dr = dtOffer.Select("SUM(Quantity)");
                        lblTotalQty.Text = sum.ToString();
                        lbMessage.Text = "";
                    }
                    else
                    {
                        //MessageBox.Show("Barcode doesn't Exist");
                        var Result = System.Windows.Forms.DialogResult.No;

                        while (Result != System.Windows.Forms.DialogResult.Yes)
                        {
                            Result = MessageBox.Show("Barcode Not In Offer,Press Yes To Continue ", "Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                            //lbMessage.Text = "No BCD";
                            // lbMessage.BackColor = System.Drawing.Color.Red;
                            lbMessage.ForeColor = System.Drawing.Color.Red;
                            txtBarcode.Text = "";

                            this.BackColor = Color.Red;
                        }
                        this.BackColor = Color.White;
                    }

                }
                else if (!Regex.IsMatch(txtBarcode.Text.Trim().ToString(), @"^\d+$"))
                {
                    txtBarcode.Text = "";
                }

                else if (str == "\n" && txtBarcode.Text.Trim().ToString().Length < 13)
                {
                    txtBarcode.Text = "";
                    //MessageBox.Show("Wrong Barcode!");
                    var Result = System.Windows.Forms.DialogResult.No;

                    while (Result != System.Windows.Forms.DialogResult.Yes)
                    {
                        Result = MessageBox.Show("Wrong Barcode!,Press Yes To Continue ", "Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                        
                        this.BackColor = Color.Red;
                    }
                    this.BackColor = Color.White;
                }
                else if (str == "\n" && txtBarcode.Text.Trim().ToString().Length > 13)
                {
                    txtBarcode.Text = "";
                    var Result = System.Windows.Forms.DialogResult.No;

                    while (Result != System.Windows.Forms.DialogResult.Yes)
                    {
                        Result = MessageBox.Show("Wrong Barcode!,Press Yes To Continue ", "Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                        this.BackColor = Color.Red;
                    }
                    this.BackColor = Color.White;
                }
        }
           
        #endregion Offer

        #region CheckBarcode
        /// <summary>
        /// Check Barcode
        /// </summary>
        private bool CheckBarcode(String Barcode)
        {
            bool Result = false;

            //if (!Directory.Exists(@".\\My Documents\\Offer\\"))
            //{
            //    Directory.CreateDirectory(@".\\My Documents\\Offer\\");
            //}
            
            //string[] filePaths = Directory.GetFiles(@".\\My Documents\\Offer\\");

            //if (filePaths.Length>0)
            //{
            //    StreamReader sr = new StreamReader(filePaths[0].ToString());
            //    string line;
            //    string[] row = new string[5];
            //    while ((line = sr.ReadLine()) != null)
            //    {
            //        row = line.Split(',');

                    //Barcode,ItemNo,Description,OfferPrice,RetailPrice
            //DataRow[] filteredRows  = dtData.Select("Barcode like '" + Barcode+"'");
            
            string expression;
            expression = "Barcode = '" + Barcode+"'";
            DataRow[] foundRows;

            // Use the Select method to find all rows matching the filter.
            foundRows = dtData.Select(expression);

            if (foundRows.Length > 0)
            {
                //string str = foundRows[0]["Barcode"].ToString();
                Result = true;

                lblLastBarcode.Text = foundRows[0]["Barcode"].ToString();
                lblLastBarcode.ForeColor = System.Drawing.Color.Blue;
                lblItemNo.Text = foundRows[0]["ItemNo"].ToString();
                lblItemNo.ForeColor = System.Drawing.Color.Blue;

                lblDescription.Text = foundRows[0]["Description"].ToString();
                lblDescription.ForeColor = System.Drawing.Color.Blue;
                lblOfferPrice.Text = foundRows[0]["OfferPrice"].ToString();
                lblOfferPrice.ForeColor = System.Drawing.Color.Blue;

                lblRetailPrice.Text = foundRows[0]["RetailPrice"].ToString();
                lblRetailPrice.ForeColor = System.Drawing.Color.Blue;

                //break;
                //MessageBox.Show(str.ToString());
            }
            else
            {
                //MessageBox.Show("Not Found");
                Result = false;

                lblLastBarcode.Text = "";
                lblItemNo.Text = "";
                lblDescription.Text = "";
                lblOfferPrice.Text = "";

                lblRetailPrice.Text = "";

                lbMessage.Text = "Not Found";
                lbMessage.ForeColor = Color.Red;
            }

            //for (int i = 0; i < dtData.Rows.Count; i++)
            //{

            //    if (Barcode == dtData.Rows[i]["Barcode"].ToString())
            //    {
            //        Result = true;

            //        lblLastBarcode.Text = dtData.Rows[i]["Barcode"].ToString();
            //        lblLastBarcode.ForeColor = System.Drawing.Color.Blue;
            //        lblItemNo.Text = dtData.Rows[i]["ItemNo"].ToString();
            //        lblItemNo.ForeColor = System.Drawing.Color.Blue;

            //        lblDescription.Text = dtData.Rows[i]["Description"].ToString();
            //        lblDescription.ForeColor = System.Drawing.Color.Blue;
            //        lblOfferPrice.Text = dtData.Rows[i]["OfferPrice"].ToString();
            //        lblOfferPrice.ForeColor = System.Drawing.Color.Blue;

            //        lblRetailPrice.Text = dtData.Rows[i]["RetailPrice"].ToString();
            //        lblRetailPrice.ForeColor = System.Drawing.Color.Blue;

            //        break;
            //    }
            //    else
            //    {
            //        Result = false;

            //        lblLastBarcode.Text = "";
            //        lblItemNo.Text = "";
            //        lblDescription.Text = "";
            //        lblOfferPrice.Text = "";

            //        lblRetailPrice.Text = "";

            //        lbMessage.Text = "Not Found" ;
            //        lbMessage.ForeColor = Color.Red;
            //    }
            //}
                    
            return Result;

        }
        #endregion CheckBarcode

        #region GetLast
        /// <summary>
        /// GetLast
        /// </summary>
        /// <param name="source"></param>
        /// <param name="tail_length"></param>
        /// <returns></returns>
        public static string GetLast(string source, int tail_length)
        {
            if (tail_length >= source.Length)
                return source;
            return source.Substring(source.Length - tail_length);
        }
        #endregion GetLast

        #region Export To Csv
        /// <summary>
        /// Export To Csv
        /// </summary>
        /// <param name="dt"></param>
        private void ExportToCsv(DataTable dt, StreamWriter swText)
        {
            int iColCount = dt.Columns.Count;

            if (flag)
            {
                for (int j = 0; j < iColCount; j++)
                {
                    swText.Write(dt.Columns[j]);
                    if (j < iColCount - 1)
                    {
                        swText.Write(",");
                    }
                }
                swText.Write(swText.NewLine);

            }

            foreach (DataRow dr in dt.Rows)
            {
                for (int j = 0; j < iColCount; j++)
                {
                    if (!Convert.IsDBNull(dr[j]))
                        swText.Write(dr[j].ToString());
                    if (j < iColCount - 1)
                        swText.Write(",");
                }
                swText.Write(swText.NewLine);
            }
            swText.Close();
        }

        #endregion Export To Csv

        #region Base64Encode
        /// <summary>
        /// Base64Encode
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        #endregion Base64Encode


        #region Save
        /// <summary>
        /// Save
        /// </summary>
        private void Save()
        {

            StreamWriter sw = File.AppendText(fileName);
            StreamWriter sw1 = File.AppendText(fileNameBackup);


            DataTable dtEncode = new DataTable();
            dtEncode.Columns.Add("Quantity");
            dtEncode.Columns.Add("Barcode");

            for (int j = 0; k < dtOffer.Rows.Count; j++)
            {
                dtEncode.Rows.Add();
                dtEncode.Rows[j]["Quantity"] = Base64Encode(dtOffer.Rows[k]["Quantity"].ToString());
                dtEncode.Rows[j]["Barcode"] = Base64Encode(dtOffer.Rows[k]["Barcode"].ToString());
                k++;
            }

            ExportToCsv(dtEncode, sw);
            ExportToCsv(dtEncode, sw1);
            flag = false;

            lbMessage.Text = lblQty.Text.Trim().ToString() + " Lines Saved";
            lbMessage.ForeColor = System.Drawing.Color.Green;


        }
        #endregion Save


        #region UpdateData
        /// <summary>
        /// UpdateData
        /// </summary>
        private void UpdateData()
        { 
            if (!Directory.Exists(@".\\My Documents\\Offer\\"))
            {
                Directory.CreateDirectory(@".\\My Documents\\Offer\\");
            }
            
            string[] filePaths = Directory.GetFiles(@".\\My Documents\\Offer\\");
            //Barcode,ItemNo,Description,OfferPrice,RetailPrice
            dtData.Columns.Add("Barcode");
            dtData.Columns.Add("ItemNo");
            dtData.Columns.Add("Description");
            dtData.Columns.Add("OfferPrice");
            dtData.Columns.Add("RetailPrice");

            if (filePaths.Length > 0)
            {
                StreamReader sr = new StreamReader(filePaths[0].ToString());
                string line;
                string[] row = new string[5];
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    row = line.Split(',');
                    dtData.Rows.Add();
                    dtData.Rows[i]["Barcode"] = row[0];
                    dtData.Rows[i]["ItemNo"] = row[1];
                    dtData.Rows[i]["Description"] = row[2];
                    dtData.Rows[i]["OfferPrice"] = row[3];
                    dtData.Rows[i]["RetailPrice"] = row[4];
                    
                    lbMessage.Text = "Data Uploading " + (i + 1);
                    lbMessage.ForeColor = Color.Green;
                    i++;

                }
            }

        }
        #endregion UpdateData

        #endregion Methods


    }
}