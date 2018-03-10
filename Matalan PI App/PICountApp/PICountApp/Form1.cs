
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
    public partial class frmScan : Form
    {

        DataTable dtData = new DataTable();
         int i = 0;
         int k = 0;
         bool flag = true;

        string fileName = "", fileNameBackup = "",dataFile="";

        int PIType = 0;
        //public  StreamReader sr = null;
            
            
        //StreamWriter sw = null;
        //StreamWriter sw1 = null;
        
        #region Events

        #region frmScan
        /// <summary>
        /// frmScan
        /// </summary>
        public frmScan()
        {
            InitializeComponent();
            //txtLocation.Text = "0";
            txtBarcode.Focus();

            dtData.Columns.Add("Location");
            dtData.Columns.Add("Barcode");
        }
        #endregion frmScan


        #region frmScan
        /// <summary>
        /// frmScan
        /// </summary>
        public frmScan(int Type,string UserFile)
        {
            InitializeComponent();
            //txtLocation.Text = "0";
            txtBarcode.Focus();
            PIType = Type;

            switch (Type)
            {
                case  1: this.Text = "PI";
                    fileName = ".\\My Documents\\PI_data_" + UserFile + ".csv";
                          fileNameBackup = ".\\Windows\\PI_dataBackup.csv";
                         break;
                case  2: this.Text = "Write Off";
                         fileName = ".\\My Documents\\WO_data_" + UserFile + ".csv";
                         fileNameBackup = ".\\Windows\\WO_dataBackup.csv";
                         break;
                case  3: this.Text = "Negative";
                         fileName = ".\\My Documents\\Negative_data_" + UserFile + ".csv";
                         fileNameBackup = ".\\Windows\\Negative_dataBackup.csv";
                         
                         if (File.Exists(".\\My Documents\\NA_Data.csv"))
                         {
                             //sr = new StreamReader(".\\My Documents\\NA_Data.csv");
                             dataFile = ".\\My Documents\\NA_Data.csv";
                         }
                         else
                         {
                             lbMessage.Text = "Data File Not Found";
                             lbMessage.ForeColor = Color.Red;
                             txtBarcode.Enabled = false;
                         }
                         break;
                case 4: this.Text = "Receive";
                         fileName = ".\\My Documents\\Receive_data_" + UserFile + ".csv";
                         fileNameBackup = ".\\Windows\\Receive_dataBackup.csv";
                         
                         if(File.Exists(".\\My Documents\\TO_Data.csv"))
                         {
                           // sr = new StreamReader(".\\My Documents\\TO_Data.txt");
                             dataFile=".\\My Documents\\TO_Data.csv";
                             
                         }
                         else
                         {
                             lbMessage.Text = "Data File Not Found";
                             lbMessage.ForeColor = Color.Red;
                             txtBarcode.Enabled = false;
                         }
                         break;
            
            }

            // sw = new StreamWriter(fileName, false);
            // sw1 = new StreamWriter(fileNameBackup, false);
            
            //File.Delete(fileName);
            File.Delete(fileNameBackup);

            if (File.Exists(fileName))
                File.Delete(fileName);

            //string[] filePaths = Directory.GetFiles(@".\\My Documents\\");
            //foreach (string filePath in filePaths)
            //    File.Delete(filePath);


           // File.Delete(".\\My Documents\\*.csv");

            dtData.Columns.Add("Location");
            dtData.Columns.Add("Barcode");
        }
        #endregion frmScan


     

        #region txtBarcode_TextChanged
        /// <summary>
        /// txtBarcode_TextChanged
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {

            if (txtLocation.Text.Trim().Length > 0)
            {

                if (PIType == 3 || PIType == 4)
                {
                    Negative();
                }
                else
                {
                    string str = GetLast(txtBarcode.Text.ToString(), 1);

                    if (str == "\n" && txtBarcode.Text.Trim().ToString().Length == 13)
                    {
                        //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());

                        lblLastItem.Text = txtLocation.Text + "," + txtBarcode.Text;
                        lblLastItem.ForeColor = System.Drawing.Color.Blue;

                        dtData.Rows.Add();
                        dtData.Rows[i]["Location"] = txtLocation.Text.Trim().ToString();
                        dtData.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        i++;
                        //dgvData.DataSource = dtData;
                        txtBarcode.Text = "";
                        lblQty.Text = dtData.Rows.Count.ToString();
                        this.BackColor = System.Drawing.Color.White;
                        lbMessage.Text = "";

                    }
                    else if (!Regex.IsMatch(txtBarcode.Text.Trim().ToString(), @"^\d+$"))
                    {
                        txtBarcode.Text = "";
                        this.BackColor = System.Drawing.Color.White;
                    }
                    else if (str == "\n" && txtBarcode.Text.Trim().ToString().Length < 13)
                    {
                        txtBarcode.Text = "";
                        //MessageBox.Show("Wrong Barcode!");
                        lbMessage.Text = "Wrong Barcode!";
                        lbMessage.ForeColor = System.Drawing.Color.Red;
                        this.BackColor = System.Drawing.Color.Yellow;

                        if (File.Exists(".\\My Documents\\Sound.wav"))
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(".\\My Documents\\Sound.wav");
                            player.Play();
                        }

                        var Result = System.Windows.Forms.DialogResult.No;

                        while (Result != System.Windows.Forms.DialogResult.Yes)
                        {
                            Result = MessageBox.Show("Wrong Barcode!,Press Yes To Continue ", "Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                            this.BackColor = Color.Red;
                        }
                        this.BackColor = Color.White;
                        lbMessage.Text = "";
                    }
                    else if (str == "\n" && txtBarcode.Text.Trim().ToString().Length > 13)
                    {
                        txtBarcode.Text = "";
                        //MessageBox.Show("Wrong Barcode!");
                        lbMessage.Text = "Wrong Barcode!";
                        lbMessage.ForeColor = System.Drawing.Color.Red;
                        this.BackColor = System.Drawing.Color.Yellow;
                        if (File.Exists(".\\My Documents\\Sound.wav"))
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(".\\My Documents\\Sound.wav");
                            player.Play();
                        }

                        var Result = System.Windows.Forms.DialogResult.No;

                        while (Result != System.Windows.Forms.DialogResult.Yes)
                        {
                            Result = MessageBox.Show("Wrong Barcode!,Press Yes To Continue ", "Barcode", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                            this.BackColor = Color.Red;
                        }
                        this.BackColor = Color.White;
                        lbMessage.Text = "";
                    }
                }
            }
            else
            {
                lbMessage.Text = "Please Enter Location";
                lbMessage.ForeColor = Color.Red;
                //MessageBox.Show("Please Enter Location");
            }
        }
        #endregion txtBarcode_TextChanged

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


        #region Save
        /// <summary>
        /// Save
        /// </summary>
        private void Save()
        {
            StreamWriter sw = File.AppendText(fileName);
            StreamWriter sw1 = File.AppendText(fileNameBackup);


            DataTable dtEncode = new DataTable();
            dtEncode.Columns.Add("Location");
            dtEncode.Columns.Add("Barcode");

            for (int j = 0; k < dtData.Rows.Count; j++)
            {
                dtEncode.Rows.Add();
                dtEncode.Rows[j]["Location"] = Base64Encode(dtData.Rows[k]["Location"].ToString());
                dtEncode.Rows[j]["Barcode"] = Base64Encode(dtData.Rows[k]["Barcode"].ToString());
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
        public static string GetLast( string source, int tail_length)
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
            if (txtLocation.Text.Trim().Length > 0)
            {
                string str = GetLast(txtBarcode.Text.ToString(), 1);

                if (str == "\n" && txtBarcode.Text.Trim().ToString().Length == 13)
                {
                    //txtData.Text = txtData.Text.Trim()+(txtLocation.Text.Trim().ToString() + "," + txtBarcode.Text.Trim().ToString());

                    if (CheckBarcode(txtBarcode.Text.Trim().ToString()))
                    {
                        lblLastItem.Text = txtLocation.Text + "," + txtBarcode.Text;
                        lblLastItem.ForeColor = System.Drawing.Color.Blue;

                        dtData.Rows.Add();
                        dtData.Rows[i]["Location"] = txtLocation.Text.Trim().ToString();
                        dtData.Rows[i]["Barcode"] = txtBarcode.Text.Trim().ToString();
                        i++;
                        //dgvData.DataSource = dtData;
                        txtBarcode.Text = "";
                        lblQty.Text = dtData.Rows.Count.ToString();
                        lbMessage.Text = "";
                        this.BackColor = System.Drawing.Color.White;
                    }
                    else
                    {
                        //MessageBox.Show("Barcode doesn't Exist");
                        lbMessage.Text = "Barcode Not Found!";
                        lbMessage.ForeColor = System.Drawing.Color.Red;
                        this.BackColor = System.Drawing.Color.Yellow;
                        
                        if (File.Exists(".\\My Documents\\Sound.wav"))
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(".\\My Documents\\Sound.wav");
                            player.Play();
                        }
                        txtBarcode.Text = "";
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
                    lbMessage.Text = "Wrong Barcode!";
                    lbMessage.ForeColor = System.Drawing.Color.Red;
                    this.BackColor = System.Drawing.Color.Yellow;

                    if (File.Exists(".\\My Documents\\Sound.wav"))
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(".\\My Documents\\Sound.wav");
                        player.Play();
                    }
                }
                else if (str == "\n" && txtBarcode.Text.Trim().ToString().Length > 13)
                {
                    txtBarcode.Text = "";
                    //MessageBox.Show("Wrong Barcode!");
                    lbMessage.Text = "Wrong Barcode!";
                    lbMessage.ForeColor = System.Drawing.Color.Red;
                    this.BackColor = System.Drawing.Color.Yellow;
                    if (File.Exists(".\\My Documents\\Sound.wav"))
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(".\\My Documents\\Sound.wav");
                        player.Play();
                    }
                }

            }
            else
            {
               // MessageBox.Show("Please Enter Location");
                lbMessage.Text = "Enter Location";
            }

        }
        #endregion Negative
        
        #region CheckBarcode
        /// <summary>
        /// Check Barcode
        /// </summary>
        private bool CheckBarcode(String Barcode)
        {

           // var engine = new FileHelperEngine<Barcodes>();
            // To Read Use:
            //var DtImport = engine.ReadFile(".\\My Documents\\NA_Data.csv");

            bool Result = false;

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

            StreamReader sr = new StreamReader(dataFile);
            

            string line;
            string[] row = new string[5];
            while ((line = sr.ReadLine()) != null)
            {
                row = line.Split(',');

                    if (Barcode == row[0])
                    {
                        Result = true;
                        break;
                    }
                    else
                    {
                        Result = false;
                    }
                
                //importingData.Add(new Transaction
                //{
                //    Date = DateTime.Parse(row[0]),
                //    Reference = row[1],
                //    Description = row[2],
                //    Amount = decimal.Parse(row[3]),
                //    Category = (Category)Enum.Parse(typeof(Category), row[4])
                //});


            }
           
            

            return Result;

        }
        #endregion CheckBarcode

        
        
        #endregion Methods
    }
}