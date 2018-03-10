namespace PICountApp
{
    partial class Home
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
            this.btnPI = new System.Windows.Forms.Button();
            this.btnNegative = new System.Windows.Forms.Button();
            this.btnWriteOff = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.btnLabel = new System.Windows.Forms.Button();
            this.btnOffer = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReceive = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnPI
            // 
            this.btnPI.Location = new System.Drawing.Point(44, 73);
            this.btnPI.Name = "btnPI";
            this.btnPI.Size = new System.Drawing.Size(124, 20);
            this.btnPI.TabIndex = 0;
            this.btnPI.Text = "PI/PO";
            this.btnPI.Click += new System.EventHandler(this.btnPI_Click);
            // 
            // btnNegative
            // 
            this.btnNegative.Location = new System.Drawing.Point(44, 101);
            this.btnNegative.Name = "btnNegative";
            this.btnNegative.Size = new System.Drawing.Size(124, 20);
            this.btnNegative.TabIndex = 1;
            this.btnNegative.Text = "Negative";
            this.btnNegative.Click += new System.EventHandler(this.btnNegative_Click);
            // 
            // btnWriteOff
            // 
            this.btnWriteOff.Location = new System.Drawing.Point(44, 132);
            this.btnWriteOff.Name = "btnWriteOff";
            this.btnWriteOff.Size = new System.Drawing.Size(124, 20);
            this.btnWriteOff.TabIndex = 2;
            this.btnWriteOff.Text = "Write Off";
            this.btnWriteOff.Click += new System.EventHandler(this.btnWriteOff_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 20);
            this.label1.Text = "File:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(39, 42);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(175, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // lblMessage
            // 
            this.lblMessage.Location = new System.Drawing.Point(3, 10);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(175, 20);
            this.lblMessage.Text = ".";
            // 
            // btnLabel
            // 
            this.btnLabel.Location = new System.Drawing.Point(44, 164);
            this.btnLabel.Name = "btnLabel";
            this.btnLabel.Size = new System.Drawing.Size(124, 20);
            this.btnLabel.TabIndex = 6;
            this.btnLabel.Text = "Label Printing";
            this.btnLabel.Click += new System.EventHandler(this.btnLabel_Click);
            // 
            // btnOffer
            // 
            this.btnOffer.Location = new System.Drawing.Point(44, 192);
            this.btnOffer.Name = "btnOffer";
            this.btnOffer.Size = new System.Drawing.Size(124, 20);
            this.btnOffer.TabIndex = 9;
            this.btnOffer.Text = "Offer";
            this.btnOffer.Click += new System.EventHandler(this.btnOffer_Click);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(54, 242);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.Text = "Version:301217";
            // 
            // btnReceive
            // 
            this.btnReceive.Location = new System.Drawing.Point(44, 219);
            this.btnReceive.Name = "btnReceive";
            this.btnReceive.Size = new System.Drawing.Size(124, 20);
            this.btnReceive.TabIndex = 12;
            this.btnReceive.Text = "Receive";
            this.btnReceive.Click += new System.EventHandler(this.btnReceive_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.btnReceive);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOffer);
            this.Controls.Add(this.btnLabel);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnWriteOff);
            this.Controls.Add(this.btnNegative);
            this.Controls.Add(this.btnPI);
            this.Menu = this.mainMenu1;
            this.Name = "Home";
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPI;
        private System.Windows.Forms.Button btnNegative;
        private System.Windows.Forms.Button btnWriteOff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Button btnLabel;
        private System.Windows.Forms.Button btnOffer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReceive;
    }
}