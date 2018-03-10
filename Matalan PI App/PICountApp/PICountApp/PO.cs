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
    public partial class PO : Form
    {

        DataTable dtData = new DataTable();
        int i = 0;
        int k = 0;
        bool flag = true;

        string fileName = "", fileNameBackup = "";

        #region PO
        public PO(string UserFile)
        {
            InitializeComponent();

            fileName = ".\\My Documents\\PO_data_" + UserFile + ".csv";
            fileNameBackup = ".\\Windows\\PO_dataBackup.csv";

            dtData.Columns.Add("Location");
            dtData.Columns.Add("Barcode");
            dtData.Columns.Add("Qty");
        }
        #endregion PO

        #region txtBarcode_TextChanged
        /// <summary>
        /// txtBarcode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

            if (txtLocation.Text.Trim().Length > 0 && txtQty.Text.Trim().Length > 0)
            {

               
                    string str = GetLast(txtBarcode.Text.ToString(), 1);

                    if (str == "\n" && txtBarcode.Text.Trim().ToString().Length == 13)
                    {
                        //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());

                        lblLastQty.Text = txtQty.Text;
                        lblLastQty.ForeColor = System.Drawing.Color.Blue;

                        lblLastBarcode.Text = txtBarcode.Text;
                        lblLastBarcode.ForeColor = System.Drawing.Color.Blue;

                        dtData.Rows.Add();
                        dtData.Rows[i]["Location"] = txtLocation.Text.Trim().ToString();
                        dtData.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        dtData.Rows[i]["Qty"] = txtQty.Text.Trim().ToString();
                        i++;
                        //dgvData.DataSource = dtData;
                        txtBarcode.Text = "";
                        lblQty.Text = dtData.Rows.Count.ToString();

                    }
                    else if (!Regex.IsMatch(txtBarcode.Text.Trim().ToString(), @"^\d+$"))
                    {
                        txtBarcode.Text = "";
                    }
                
            }
            else
            {
                MessageBox.Show("Please Enter Location & Qty!");
            }
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
            StreamWriter sw = File.AppendText(fileName);
            StreamWriter sw1 = File.AppendText(fileNameBackup);


            DataTable dtEncode = new DataTable();
            dtEncode.Columns.Add("Location");
            dtEncode.Columns.Add("Barcode");
            dtEncode.Columns.Add("Qty");

            for (int j = 0; k < dtData.Rows.Count; j++)
            {
                dtEncode.Rows.Add();
                dtEncode.Rows[j]["Location"] = dtData.Rows[k]["Location"].ToString();
                dtEncode.Rows[j]["Barcode"] = dtData.Rows[k]["Barcode"].ToString();
                dtEncode.Rows[j]["Qty"] = dtData.Rows[k]["Qty"].ToString();
                k++;
            }

            ExportToCsv(dtEncode, sw);
            ExportToCsv(dtEncode, sw1);
            flag = false;

            // dtData.Clear();
            //i = 0;
            // lblQty.Text = "0";
            lbMessage.Text = lblQty.Text.Trim().ToString() + " Items Saved";
            lbMessage.ForeColor = System.Drawing.Color.Green;

            //sw.Close();
            //sw1.Close();
            //System.Windows.Forms.Application.Exit();
        }
        #endregion btnSave_Click


        #region btnView_Click
        /// <summary>
        /// btnView_Click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnView_Click(object sender, EventArgs e)
        {
            ViewScan objView = new ViewScan(dtData);
            objView.Show();
        }
        #endregion btnView_Click



        #region Methods

        //#region Export To Csv
        ///// <summary>
        ///// Export To Csv
        ///// </summary>
        //private void ExportToCsv(StreamWriter swText)
        //{

        //    string columnHead = Base64Encode("Location,Barcode");
        //    swText.Write(columnHead);
        //    swText.Write(swText.NewLine);

        //    string encodedText = Base64Encode(txtBarcode.Text.ToString());
        //    swText.Write(encodedText);
        //    swText.Write(swText.NewLine);

        //    swText.Close();
        //}

        //#endregion Export To Csv

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

        #region Base64Decode
        // For Decoding

        public static string Base64Decode(string base64EncodedData)
        {
            object misValue = System.Reflection.Missing.Value;

            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes, 0, base64EncodedData.Length);
        }
        #endregion Base64Decode

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


       


        #endregion Methods

    }
}