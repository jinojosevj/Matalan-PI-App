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

#endregion NameSpace

namespace PICountApp
{
    public partial class LabelPrinting : Form
    {
        DataTable dtData = new DataTable();
        int i = 0;
        int k = 0;
        bool flag = true;

        string fileName = "", fileNameBackup = "";

        int PIType = 0;

        #region LabelPrinting
        /// <summary>
        /// LabelPrinting
        /// </summary>
        /// <param name="UserFile"></param>
        public LabelPrinting(string UserFile)
        {
            InitializeComponent();

            txtBarcode.Focus();
            //PIType = Type;
           
            fileName = ".\\My Documents\\Label_data_" + UserFile + ".csv";
            fileNameBackup = ".\\Windows\\Label_dataBackup.csv";

            txtQty.Text = "1";

            if (File.Exists(fileName))
                File.Delete(fileName);
          
            // sw = new StreamWriter(fileName, false);
            // sw1 = new StreamWriter(fileNameBackup, false);

            //File.Delete(fileName);
            //File.Delete(fileNameBackup);


            //string[] filePaths = Directory.GetFiles(@".\\My Documents\\");
            //foreach (string filePath in filePaths)
            //    File.Delete(filePath);
            


            // File.Delete(".\\My Documents\\*.csv");
            dtData.Columns.Add("Barcode");
            dtData.Columns.Add("Qty");
        }

        #endregion LabelPrinting

       
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

        #region txtBarcode_TextChanged
        /// <summary>
        /// txtBarcode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

            if (txtQty.Text.Trim().Length > 0)
            {

                    string str = GetLast(txtBarcode.Text.ToString(), 1);

                    if (str == "\n" && txtBarcode.Text.Trim().ToString().Length >= 12 && txtBarcode.Text.Trim().ToString().Length <= 13)
                    {
                        //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());


                        lblLastItem.Text = txtQty.Text + "," + txtBarcode.Text;
                        lblLastItem.ForeColor = System.Drawing.Color.Blue;

                        dtData.Rows.Add();

                        dtData.Rows[i]["Qty"] = txtQty.Text.Trim().ToString();

                        if (txtBarcode.Text.Trim().ToString().Length == 12)
                        {
                            dtData.Rows[i]["Barcode"] ="0"+ txtBarcode.Text.Trim().ToString();
                        }
                        else
                        {
                            dtData.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        }
                        
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
                MessageBox.Show("Please Enter Quantity");
            }
        }

        #endregion txtBarcode_TextChanged


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

        #region Methods


        #region Save
        /// <summary>
        /// Save
        /// </summary>
        private void Save()
        {
            StreamWriter sw = File.AppendText(fileName);
            StreamWriter sw1 = File.AppendText(fileNameBackup);


            DataTable dtEncode = new DataTable();
            dtEncode.Columns.Add("SlNo");
            dtEncode.Columns.Add("Barcode");
            dtEncode.Columns.Add("Quantity");


            for (int j = 0; k < dtData.Rows.Count; j++)
            {
                dtEncode.Rows.Add();
                dtEncode.Rows[j]["SlNo"] = k + 1;
                dtEncode.Rows[j]["Barcode"] = Base64Encode(dtData.Rows[k]["Barcode"].ToString());
                dtEncode.Rows[j]["Quantity"] = Base64Encode(dtData.Rows[k]["Qty"].ToString());
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
            // System.Windows.Forms.Application.Exit();


        }
        #endregion Save


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

        #region Negative
        /// <summary>
        /// Negative
        /// </summary>
        private void Negative()
        {
            if (txtQty.Text.Trim().Length > 0)
            {
                string str = GetLast(txtBarcode.Text.ToString(), 1);

                if (str == "\n" && txtBarcode.Text.Trim().ToString().Length == 13)
                {
                    //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());

                    if (!CheckBarcode(txtBarcode.Text.Trim().ToString()))
                    {
                        lblLastItem.Text = txtQty.Text + "," + txtBarcode.Text;
                        lblLastItem.ForeColor = System.Drawing.Color.Blue;

                        dtData.Rows.Add();
                        dtData.Rows[i]["Location"] = txtQty.Text.Trim().ToString();
                        dtData.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        i++;
                       // dgvData.DataSource = dtData;
                        txtBarcode.Text = "";
                        lblQty.Text = dtData.Rows.Count.ToString();
                    }
                    else
                    {
                        MessageBox.Show("Barcode doesn't Exist");
                    }

                }
                else if (!Regex.IsMatch(txtBarcode.Text.Trim().ToString(), @"^\d+$"))
                {
                    txtBarcode.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Please Enter Location");
            }

        }
        #endregion Negative

        #region CheckBarcode
        /// <summary>
        /// Check Barcode
        /// </summary>
        private bool CheckBarcode(String Barcode)
        {

            //var engine = new FileHelperEngine<Barcodes>();
            //// To Read Use:
            //var DtImport = engine.ReadFile(".\\My Documents\\NA_data.csv");

            //bool Result = false;

            //foreach (Barcodes Bar in DtImport)
            //{
            //    if (Barcode == Base64Decode(Bar.Barcode))
            //    {
            //        Result = true;
            //        break;
            //    }
            //    else
            //    {
            //        Result = false;
            //    }

            //}

          
           return false;

        }
        #endregion CheckBarcode

        #endregion Methods
    }
}