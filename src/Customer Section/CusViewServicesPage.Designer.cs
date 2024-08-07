namespace OOP_G18_Final_Assignment_APPrint
{
    partial class CusViewServicesPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private APPrint_DatabaseDataSet aPPrint_DatabaseDataSet;
        private APPrint_DatabaseDataSetTableAdapters.ServicesTableAdapter servicesTableAdapter1;

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
            this.components = new System.ComponentModel.Container();
            this.lblHeader = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.servicesBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.aPPrint_DatabaseDataSet1 = new OOP_G18_Final_Assignment_APPrint.APPrint_DatabaseDataSet();
            this.servicesTableAdapter = new OOP_G18_Final_Assignment_APPrint.APPrint_DatabaseDataSetTableAdapters.ServicesTableAdapter();
            this.servicesBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oOPFINALASSIGNMENTDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serviceFeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discountPercentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityThresholdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPrint_DatabaseDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oOPFINALASSIGNMENTDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
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
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Location = new System.Drawing.Point(-5, -2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(990, 99);
            this.panel1.TabIndex = 2;
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Times New Roman", 12F);
            this.btnBack.Location = new System.Drawing.Point(738, 147);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(160, 52);
            this.btnBack.TabIndex = 6;
            this.btnBack.Text = "Go Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(352, 146);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblWelcome.Size = new System.Drawing.Size(286, 55);
            this.lblWelcome.TabIndex = 7;
            this.lblWelcome.Text = "Our Services";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.serviceFeeDataGridViewTextBoxColumn,
            this.discountPercentDataGridViewTextBoxColumn,
            this.quantityThresholdDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.servicesBindingSource2;
            this.dataGridView1.Location = new System.Drawing.Point(56, 236);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(858, 360);
            this.dataGridView1.TabIndex = 8;
            // 
            // servicesBindingSource2
            // 
            this.servicesBindingSource2.DataMember = "Services";
            this.servicesBindingSource2.DataSource = this.aPPrint_DatabaseDataSet1;
            // 
            // aPPrint_DatabaseDataSet1
            // 
            this.aPPrint_DatabaseDataSet1.DataSetName = "APPrint_DatabaseDataSet";
            this.aPPrint_DatabaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "ServiceType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Type of Service";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Size";
            this.dataGridViewTextBoxColumn2.HeaderText = "Size(s) Available";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 80;
            // 
            // serviceFeeDataGridViewTextBoxColumn
            // 
            this.serviceFeeDataGridViewTextBoxColumn.DataPropertyName = "ServiceFee";
            this.serviceFeeDataGridViewTextBoxColumn.HeaderText = "Service Fee";
            this.serviceFeeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.serviceFeeDataGridViewTextBoxColumn.Name = "serviceFeeDataGridViewTextBoxColumn";
            this.serviceFeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.serviceFeeDataGridViewTextBoxColumn.Width = 60;
            // 
            // discountPercentDataGridViewTextBoxColumn
            // 
            this.discountPercentDataGridViewTextBoxColumn.DataPropertyName = "DiscountPercent";
            this.discountPercentDataGridViewTextBoxColumn.HeaderText = "Discount (%)";
            this.discountPercentDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.discountPercentDataGridViewTextBoxColumn.Name = "discountPercentDataGridViewTextBoxColumn";
            this.discountPercentDataGridViewTextBoxColumn.ReadOnly = true;
            this.discountPercentDataGridViewTextBoxColumn.Width = 60;
            // 
            // quantityThresholdDataGridViewTextBoxColumn
            // 
            this.quantityThresholdDataGridViewTextBoxColumn.DataPropertyName = "QuantityThreshold";
            this.quantityThresholdDataGridViewTextBoxColumn.HeaderText = "/Page";
            this.quantityThresholdDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.quantityThresholdDataGridViewTextBoxColumn.Name = "quantityThresholdDataGridViewTextBoxColumn";
            this.quantityThresholdDataGridViewTextBoxColumn.ReadOnly = true;
            this.quantityThresholdDataGridViewTextBoxColumn.Width = 60;
            // 
            // CusViewServicesPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(978, 644);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.panel1);
            this.Name = "CusViewServicesPage";
            this.Text = "View Services";
            this.Load += new System.EventHandler(this.CusViewServicesPage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aPPrint_DatabaseDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oOPFINALASSIGNMENTDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource oOPFINALASSIGNMENTDataSetBindingSource;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private System.Windows.Forms.BindingSource servicesBindingSource1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceFee;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiscountPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuantityThreshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn sizeDataGridViewTextBoxColumn;
        private APPrint_DatabaseDataSet aPPrint_DatabaseDataSet1;
        private System.Windows.Forms.BindingSource servicesBindingSource2;
        private APPrint_DatabaseDataSetTableAdapters.ServicesTableAdapter servicesTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn serviceFeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn discountPercentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityThresholdDataGridViewTextBoxColumn;
    }
}