
namespace ProgrammBaseData
{
    partial class Report
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
            this.MainTable = new System.Windows.Forms.DataGridView();
            this.labelWarehous1 = new System.Windows.Forms.Label();
            this.buttonnextorback = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTable
            // 
            this.MainTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainTable.Location = new System.Drawing.Point(12, 12);
            this.MainTable.Name = "MainTable";
            this.MainTable.ReadOnly = true;
            this.MainTable.RowHeadersWidth = 51;
            this.MainTable.RowTemplate.Height = 24;
            this.MainTable.Size = new System.Drawing.Size(592, 426);
            this.MainTable.TabIndex = 0;
            this.MainTable.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.MainTable_CellMouseUp);
            // 
            // labelWarehous1
            // 
            this.labelWarehous1.AutoSize = true;
            this.labelWarehous1.Location = new System.Drawing.Point(610, 109);
            this.labelWarehous1.Name = "labelWarehous1";
            this.labelWarehous1.Size = new System.Drawing.Size(46, 17);
            this.labelWarehous1.TabIndex = 1;
            this.labelWarehous1.Text = "label1";
            this.labelWarehous1.Visible = false;
            // 
            // buttonnextorback
            // 
            this.buttonnextorback.Location = new System.Drawing.Point(610, 12);
            this.buttonnextorback.Name = "buttonnextorback";
            this.buttonnextorback.Size = new System.Drawing.Size(178, 71);
            this.buttonnextorback.TabIndex = 2;
            this.buttonnextorback.Text = "button1";
            this.buttonnextorback.UseVisualStyleBackColor = true;
            this.buttonnextorback.Visible = false;
            this.buttonnextorback.Click += new System.EventHandler(this.button1_Click);
            // 
            // Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonnextorback);
            this.Controls.Add(this.labelWarehous1);
            this.Controls.Add(this.MainTable);
            this.Name = "Report";
            this.Text = "OrderReport";
            ((System.ComponentModel.ISupportInitialize)(this.MainTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MainTable;
        private System.Windows.Forms.Label labelWarehous1;
        private System.Windows.Forms.Button buttonnextorback;
    }
}