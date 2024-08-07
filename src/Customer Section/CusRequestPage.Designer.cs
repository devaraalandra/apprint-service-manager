namespace OOP_G18_Final_Assignment_APPrint
{
    partial class CusRequestPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblServiceType = new System.Windows.Forms.Label();
            this.rbBnW = new System.Windows.Forms.RadioButton();
            this.rbColor = new System.Windows.Forms.RadioButton();
            this.rbPosterA0 = new System.Windows.Forms.RadioButton();
            this.rbPosterA2 = new System.Windows.Forms.RadioButton();
            this.rbBindThick = new System.Windows.Forms.RadioButton();
            this.rbBindComb = new System.Windows.Forms.RadioButton();
            this.lblUrgency = new System.Windows.Forms.Label();
            this.cbUrgency = new System.Windows.Forms.ComboBox();
            this.lblQty = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.rbPosterA3 = new System.Windows.Forms.RadioButton();
            this.rbPosterA1 = new System.Windows.Forms.RadioButton();
            this.btnCheck = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Location = new System.Drawing.Point(-5, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 100);
            this.panel1.TabIndex = 1;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.Control;
            this.lblHeader.Location = new System.Drawing.Point(210, 33);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(601, 46);
            this.lblHeader.TabIndex = 1;
            this.lblHeader.Text = "APPrint: APU Printing Services";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(310, 151);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTitle.Size = new System.Drawing.Size(349, 55);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "Service Request";
            // 
            // lblServiceType
            // 
            this.lblServiceType.AutoSize = true;
            this.lblServiceType.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblServiceType.Location = new System.Drawing.Point(66, 271);
            this.lblServiceType.Name = "lblServiceType";
            this.lblServiceType.Size = new System.Drawing.Size(163, 33);
            this.lblServiceType.TabIndex = 6;
            this.lblServiceType.Text = "Service Type:";
            // 
            // rbBnW
            // 
            this.rbBnW.AutoSize = true;
            this.rbBnW.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBnW.Location = new System.Drawing.Point(246, 279);
            this.rbBnW.Name = "rbBnW";
            this.rbBnW.Size = new System.Drawing.Size(302, 29);
            this.rbBnW.TabIndex = 7;
            this.rbBnW.TabStop = true;
            this.rbBnW.Text = "A4 Printing - Black and White";
            this.rbBnW.UseVisualStyleBackColor = true;
            // 
            // rbColor
            // 
            this.rbColor.AutoSize = true;
            this.rbColor.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbColor.Location = new System.Drawing.Point(246, 317);
            this.rbColor.Name = "rbColor";
            this.rbColor.Size = new System.Drawing.Size(206, 29);
            this.rbColor.TabIndex = 8;
            this.rbColor.TabStop = true;
            this.rbColor.Text = "A4 Printing - Color";
            this.rbColor.UseVisualStyleBackColor = true;
            // 
            // rbPosterA0
            // 
            this.rbPosterA0.AutoSize = true;
            this.rbPosterA0.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPosterA0.Location = new System.Drawing.Point(245, 354);
            this.rbPosterA0.Name = "rbPosterA0";
            this.rbPosterA0.Size = new System.Drawing.Size(225, 29);
            this.rbPosterA0.TabIndex = 9;
            this.rbPosterA0.TabStop = true;
            this.rbPosterA0.Text = "Printing - Poster (A0)";
            this.rbPosterA0.UseVisualStyleBackColor = true;
            // 
            // rbPosterA2
            // 
            this.rbPosterA2.AutoSize = true;
            this.rbPosterA2.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPosterA2.Location = new System.Drawing.Point(573, 357);
            this.rbPosterA2.Name = "rbPosterA2";
            this.rbPosterA2.Size = new System.Drawing.Size(225, 29);
            this.rbPosterA2.TabIndex = 12;
            this.rbPosterA2.TabStop = true;
            this.rbPosterA2.Text = "Printing - Poster (A2)";
            this.rbPosterA2.UseVisualStyleBackColor = true;
            // 
            // rbBindThick
            // 
            this.rbBindThick.AutoSize = true;
            this.rbBindThick.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBindThick.Location = new System.Drawing.Point(573, 321);
            this.rbBindThick.Name = "rbBindThick";
            this.rbBindThick.Size = new System.Drawing.Size(234, 29);
            this.rbBindThick.TabIndex = 11;
            this.rbBindThick.TabStop = true;
            this.rbBindThick.Text = "Binding - Thick Cover";
            this.rbBindThick.UseVisualStyleBackColor = true;
            // 
            // rbBindComb
            // 
            this.rbBindComb.AutoSize = true;
            this.rbBindComb.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbBindComb.Location = new System.Drawing.Point(573, 283);
            this.rbBindComb.Name = "rbBindComb";
            this.rbBindComb.Size = new System.Drawing.Size(249, 29);
            this.rbBindComb.TabIndex = 10;
            this.rbBindComb.TabStop = true;
            this.rbBindComb.Text = "Binding - Comb Binding";
            this.rbBindComb.UseVisualStyleBackColor = true;
            // 
            // lblUrgency
            // 
            this.lblUrgency.AutoSize = true;
            this.lblUrgency.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUrgency.Location = new System.Drawing.Point(87, 445);
            this.lblUrgency.Name = "lblUrgency";
            this.lblUrgency.Size = new System.Drawing.Size(114, 33);
            this.lblUrgency.TabIndex = 13;
            this.lblUrgency.Text = "Urgency:";
            // 
            // cbUrgency
            // 
            this.cbUrgency.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUrgency.FormattingEnabled = true;
            this.cbUrgency.Items.AddRange(new object[] {
            "Normal",
            "Urgent"});
            this.cbUrgency.Location = new System.Drawing.Point(205, 446);
            this.cbUrgency.Name = "cbUrgency";
            this.cbUrgency.Size = new System.Drawing.Size(183, 37);
            this.cbUrgency.TabIndex = 14;
            // 
            // lblQty
            // 
            this.lblQty.AutoSize = true;
            this.lblQty.Font = new System.Drawing.Font("Times New Roman", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQty.Location = new System.Drawing.Point(450, 446);
            this.lblQty.Name = "lblQty";
            this.lblQty.Size = new System.Drawing.Size(120, 33);
            this.lblQty.TabIndex = 17;
            this.lblQty.Text = "Quantity:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuantity.Location = new System.Drawing.Point(573, 447);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(100, 35);
            this.txtQuantity.TabIndex = 18;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnBack.Location = new System.Drawing.Point(738, 155);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 52);
            this.btnBack.TabIndex = 19;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConfirm.Location = new System.Drawing.Point(698, 532);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(197, 58);
            this.btnConfirm.TabIndex = 20;
            this.btnConfirm.Text = "Confirm Order";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // rbPosterA3
            // 
            this.rbPosterA3.AutoSize = true;
            this.rbPosterA3.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPosterA3.Location = new System.Drawing.Point(573, 396);
            this.rbPosterA3.Name = "rbPosterA3";
            this.rbPosterA3.Size = new System.Drawing.Size(225, 29);
            this.rbPosterA3.TabIndex = 22;
            this.rbPosterA3.TabStop = true;
            this.rbPosterA3.Text = "Printing - Poster (A3)";
            this.rbPosterA3.UseVisualStyleBackColor = true;
            // 
            // rbPosterA1
            // 
            this.rbPosterA1.AutoSize = true;
            this.rbPosterA1.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbPosterA1.Location = new System.Drawing.Point(246, 392);
            this.rbPosterA1.Name = "rbPosterA1";
            this.rbPosterA1.Size = new System.Drawing.Size(225, 29);
            this.rbPosterA1.TabIndex = 21;
            this.rbPosterA1.TabStop = true;
            this.rbPosterA1.Text = "Printing - Poster (A1)";
            this.rbPosterA1.UseVisualStyleBackColor = true;
            // 
            // btnCheck
            // 
            this.btnCheck.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheck.Location = new System.Drawing.Point(495, 532);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(178, 58);
            this.btnCheck.TabIndex = 23;
            this.btnCheck.Text = "Check Pricing";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 498);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(469, 23);
            this.label1.TabIndex = 24;
            this.label1.Text = "Note: Urgent Requests are charged 30% surcharge fee.";
            // 
            // CusRequestPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.rbPosterA3);
            this.Controls.Add(this.rbPosterA1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQty);
            this.Controls.Add(this.cbUrgency);
            this.Controls.Add(this.lblUrgency);
            this.Controls.Add(this.rbPosterA2);
            this.Controls.Add(this.rbBindThick);
            this.Controls.Add(this.rbBindComb);
            this.Controls.Add(this.rbPosterA0);
            this.Controls.Add(this.rbColor);
            this.Controls.Add(this.rbBnW);
            this.Controls.Add(this.lblServiceType);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.panel1);
            this.Name = "CusRequestPage";
            this.Text = "Request Service";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private System.Windows.Forms.Label lblServiceType;
        private System.Windows.Forms.RadioButton rbBnW;
        private System.Windows.Forms.RadioButton rbColor;
        private System.Windows.Forms.RadioButton rbPosterA0;
        private System.Windows.Forms.RadioButton rbPosterA2;
        private System.Windows.Forms.RadioButton rbBindThick;
        private System.Windows.Forms.RadioButton rbBindComb;
        private System.Windows.Forms.Label lblUrgency;
        private System.Windows.Forms.ComboBox cbUrgency;
        private System.Windows.Forms.Label lblQty;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.RadioButton rbPosterA3;
        private System.Windows.Forms.RadioButton rbPosterA1;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Label label1;
    }
}