namespace PICountApp
{
    partial class PO
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLastQty = new System.Windows.Forms.Label();
            this.lbMessage = new System.Windows.Forms.Label();
            this.lblQty = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBarcode = new System.Windows.Forms.TextBox();
            this.Qty = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.lblLastBarcode = new System.Windows.Forms.Label();
            this.btnView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(154, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 20);
            this.label2.Text = "Ct";
            // 
            // lblLastQty
            // 
            this.lblLastQty.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLastQty.ForeColor = System.Drawing.Color.Magenta;
            this.lblLastQty.Location = new System.Drawing.Point(65, 208);
            this.lblLastQty.Name = "lblLastQty";
            this.lblLastQty.Size = new System.Drawing.Size(144, 20);
            this.lblLastQty.Text = ".";
            // 
            // lbMessage
            // 
            this.lbMessage.Location = new System.Drawing.Point(9, 9);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(100, 20);
            this.lbMessage.Text = ".";
            // 
            // lblQty
            // 
            this.lblQty.Font = new System.Drawing.Font("Tahoma", 14F, System.Drawing.FontStyle.Regular);
            this.lblQty.ForeColor = System.Drawing.Color.Magenta;
            this.lblQty.Location = new System.Drawing.Point(185, 34);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(80, 20);
            this.lblQty.Text = ".";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.Text = "Location:";
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(89, 35);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(60, 21);
            this.txtLocation.TabIndex = 7;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(19, 142);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 24);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtBarcode
            // 
            this.txtBarcode.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txtBarcode.Location = new System.Drawing.Point(6, 97);
            this.txtBarcode.Multiline = true;
            this.txtBarcode.Name = "txtBarcode";
            this.txtBarcode.Size = new System.Drawing.Size(215, 28);
            this.txtBarcode.TabIndex = 8;
            this.txtBarcode.TextChanged += new System.EventHandler(this.txtBarcode_TextChanged);
            // 
            // Qty
            // 
            this.Qty.Location = new System.Drawing.Point(9, 59);
            this.Qty.Name = "Qty";
            this.Qty.Size = new System.Drawing.Size(59, 20);
            this.Qty.Text = "Qty:";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(89, 58);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(60, 21);
            this.txtQty.TabIndex = 18;
            // 
            // lblLastBarcode
            // 
            this.lblLastBarcode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.lblLastBarcode.ForeColor = System.Drawing.Color.Magenta;
            this.lblLastBarcode.Location = new System.Drawing.Point(65, 185);
            this.lblLastBarcode.Name = "lblLastBarcode";
            this.lblLastBarcode.Size = new System.Drawing.Size(144, 20);
            this.lblLastBarcode.Text = ".";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(131, 142);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(90, 24);
            this.btnView.TabIndex = 21;
            this.btnView.Text = "View Scan";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 20);
            this.label3.Text = "Lst Bd:";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(0, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.Text = "Lst Qty:";
            // 
            // PO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.lblLastBarcode);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.Qty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblLastQty);
            this.Controls.Add(this.lbMessage);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtBarcode);
            this.Menu = this.mainMenu1;
            this.Name = "PO";
            this.Text = "PO";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLastQty;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtBarcode;
        private System.Windows.Forms.Label Qty;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label lblLastBarcode;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}