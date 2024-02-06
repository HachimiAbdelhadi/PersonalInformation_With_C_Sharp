namespace PersonInformatiomProject
{
    partial class ControlInformation
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPersonsInfo = new System.Windows.Forms.DataGridView();
            this.clmIDperson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPersonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblAllInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonsInfo)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPersonsInfo
            // 
            this.dgvPersonsInfo.AllowUserToAddRows = false;
            this.dgvPersonsInfo.AllowUserToDeleteRows = false;
            this.dgvPersonsInfo.AllowUserToOrderColumns = true;
            this.dgvPersonsInfo.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPersonsInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPersonsInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonsInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmIDperson,
            this.clmPersonName,
            this.clmAddress,
            this.clmImage});
            this.dgvPersonsInfo.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvPersonsInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPersonsInfo.Location = new System.Drawing.Point(0, 54);
            this.dgvPersonsInfo.Name = "dgvPersonsInfo";
            this.dgvPersonsInfo.Size = new System.Drawing.Size(815, 384);
            this.dgvPersonsInfo.TabIndex = 0;
            this.dgvPersonsInfo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            // 
            // clmIDperson
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Showcard Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clmIDperson.DefaultCellStyle = dataGridViewCellStyle1;
            this.clmIDperson.HeaderText = "ID";
            this.clmIDperson.MaxInputLength = 4;
            this.clmIDperson.Name = "clmIDperson";
            this.clmIDperson.Width = 193;
            // 
            // clmPersonName
            // 
            this.clmPersonName.HeaderText = "Name";
            this.clmPersonName.MinimumWidth = 20;
            this.clmPersonName.Name = "clmPersonName";
            this.clmPersonName.Width = 193;
            // 
            // clmAddress
            // 
            this.clmAddress.HeaderText = "Address";
            this.clmAddress.Name = "clmAddress";
            this.clmAddress.Width = 193;
            // 
            // clmImage
            // 
            this.clmImage.HeaderText = "Image";
            this.clmImage.Name = "clmImage";
            this.clmImage.Width = 193;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addImageToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(133, 26);
            // 
            // addImageToolStripMenuItem
            // 
            this.addImageToolStripMenuItem.Name = "addImageToolStripMenuItem";
            this.addImageToolStripMenuItem.Size = new System.Drawing.Size(132, 22);
            this.addImageToolStripMenuItem.Text = "Add image";
            this.addImageToolStripMenuItem.Click += new System.EventHandler(this.addImageToolStripMenuItem_Click);
            // 
            // lblAllInfo
            // 
            this.lblAllInfo.AutoSize = true;
            this.lblAllInfo.Font = new System.Drawing.Font("Showcard Gothic", 18F, System.Drawing.FontStyle.Bold);
            this.lblAllInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblAllInfo.Location = new System.Drawing.Point(173, 21);
            this.lblAllInfo.Name = "lblAllInfo";
            this.lblAllInfo.Size = new System.Drawing.Size(432, 30);
            this.lblAllInfo.TabIndex = 4;
            this.lblAllInfo.Text = "Show ALL Persons INformation";
            // 
            // ControlInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 438);
            this.Controls.Add(this.lblAllInfo);
            this.Controls.Add(this.dgvPersonsInfo);
            this.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "ControlInformation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Control Information";
            this.Load += new System.EventHandler(this.ControlInformation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonsInfo)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPersonsInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmIDperson;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPersonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmAddress;
        private System.Windows.Forms.DataGridViewImageColumn clmImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addImageToolStripMenuItem;
        private System.Windows.Forms.Label lblAllInfo;
    }
}