namespace DLMS_Presentation_Layer
{
    partial class frmPeople
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFilter = new System.Windows.Forms.ComboBox();
            this.txtFilterText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRowsNum = new System.Windows.Forms.Label();
            this.dgvPeople = new System.Windows.Forms.DataGridView();
            this.ctxtMdgv = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAddUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ShowDetialsStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddNewPersontoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeletetoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).BeginInit();
            this.ctxtMdgv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(590, 197);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(294, 42);
            this.label1.TabIndex = 0;
            this.label1.Text = "Manage People";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 258);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Filter By:";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.cbFilter.FormattingEnabled = true;
            this.cbFilter.Items.AddRange(new object[] {
            "None",
            "Person ID",
            "National No",
            "First Name",
            "Second Name ",
            "Third Name",
            "Last Name",
            "Gender",
            "Address",
            "Phone ",
            "Email ",
            "Country"});
            this.cbFilter.Location = new System.Drawing.Point(107, 256);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(165, 24);
            this.cbFilter.TabIndex = 3;
            this.cbFilter.SelectedIndexChanged += new System.EventHandler(this.cbFilter_SelectedIndexChanged);
            // 
            // txtFilterText
            // 
            this.txtFilterText.Location = new System.Drawing.Point(278, 258);
            this.txtFilterText.Name = "txtFilterText";
            this.txtFilterText.Size = new System.Drawing.Size(199, 22);
            this.txtFilterText.TabIndex = 4;
            this.txtFilterText.TextChanged += new System.EventHandler(this.txtFilterText_TextChanged);
            this.txtFilterText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilterText_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(13, 797);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "# Records :";
            // 
            // lblRowsNum
            // 
            this.lblRowsNum.AutoSize = true;
            this.lblRowsNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRowsNum.Location = new System.Drawing.Point(126, 797);
            this.lblRowsNum.Name = "lblRowsNum";
            this.lblRowsNum.Size = new System.Drawing.Size(19, 20);
            this.lblRowsNum.TabIndex = 7;
            this.lblRowsNum.Text = "0";
            // 
            // dgvPeople
            // 
            this.dgvPeople.AllowUserToAddRows = false;
            this.dgvPeople.AllowUserToDeleteRows = false;
            this.dgvPeople.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dgvPeople.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvPeople.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgvPeople.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPeople.ContextMenuStrip = this.ctxtMdgv;
            this.dgvPeople.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dgvPeople.Location = new System.Drawing.Point(17, 296);
            this.dgvPeople.Name = "dgvPeople";
            this.dgvPeople.ReadOnly = true;
            this.dgvPeople.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders;
            this.dgvPeople.RowTemplate.Height = 24;
            this.dgvPeople.Size = new System.Drawing.Size(1496, 484);
            this.dgvPeople.TabIndex = 8;
            // 
            // ctxtMdgv
            // 
            this.ctxtMdgv.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxtMdgv.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowDetialsStripMenuItem,
            this.toolStripSeparator1,
            this.AddNewPersontoolStripMenuItem,
            this.EdittoolStripMenuItem,
            this.DeletetoolStripMenuItem,
            this.toolStripMenuItem6});
            this.ctxtMdgv.Name = "ctxtMdgv";
            this.ctxtMdgv.Size = new System.Drawing.Size(192, 140);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(191, 26);
            this.toolStripMenuItem6.Text = " ";
            // 
            // btnAddUpdate
            // 
            this.btnAddUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnAddUpdate.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnAddUpdate.FlatAppearance.BorderSize = 2;
            this.btnAddUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUpdate.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAddUpdate.Image = global::DLMS_Presentation_Layer.Properties.Resources.Add_Person_40;
            this.btnAddUpdate.Location = new System.Drawing.Point(1438, 224);
            this.btnAddUpdate.Name = "btnAddUpdate";
            this.btnAddUpdate.Size = new System.Drawing.Size(75, 66);
            this.btnAddUpdate.TabIndex = 10;
            this.btnAddUpdate.UseVisualStyleBackColor = true;
            this.btnAddUpdate.Click += new System.EventHandler(this.btnAddUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Image = global::DLMS_Presentation_Layer.Properties.Resources.Close_32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.Location = new System.Drawing.Point(1407, 786);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(106, 42);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ShowDetialsStripMenuItem
            // 
            this.ShowDetialsStripMenuItem.Image = global::DLMS_Presentation_Layer.Properties.Resources.PersonDetails_32;
            this.ShowDetialsStripMenuItem.Name = "ShowDetialsStripMenuItem";
            this.ShowDetialsStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.ShowDetialsStripMenuItem.Text = "Show Details";
            this.ShowDetialsStripMenuItem.Click += new System.EventHandler(this.ShowDetailsStripMenuItem_Click);
            // 
            // AddNewPersontoolStripMenuItem
            // 
            this.AddNewPersontoolStripMenuItem.Image = global::DLMS_Presentation_Layer.Properties.Resources.Add_Person_40;
            this.AddNewPersontoolStripMenuItem.Name = "AddNewPersontoolStripMenuItem";
            this.AddNewPersontoolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.AddNewPersontoolStripMenuItem.Text = "Add New Person";
            this.AddNewPersontoolStripMenuItem.Click += new System.EventHandler(this.AddNewPersontoolStripMenuItem_Click);
            // 
            // EdittoolStripMenuItem
            // 
            this.EdittoolStripMenuItem.Image = global::DLMS_Presentation_Layer.Properties.Resources.edit_32;
            this.EdittoolStripMenuItem.Name = "EdittoolStripMenuItem";
            this.EdittoolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.EdittoolStripMenuItem.Text = "Edit";
            this.EdittoolStripMenuItem.Click += new System.EventHandler(this.EdittoolStripMenuItem_Click);
            // 
            // DeletetoolStripMenuItem
            // 
            this.DeletetoolStripMenuItem.Image = global::DLMS_Presentation_Layer.Properties.Resources.Delete_32;
            this.DeletetoolStripMenuItem.Name = "DeletetoolStripMenuItem";
            this.DeletetoolStripMenuItem.Size = new System.Drawing.Size(191, 26);
            this.DeletetoolStripMenuItem.Text = "Delete";
            this.DeletetoolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DLMS_Presentation_Layer.Properties.Resources.People_400;
            this.pictureBox1.Location = new System.Drawing.Point(640, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(192, 201);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // frmPeople
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1525, 939);
            this.Controls.Add(this.btnAddUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvPeople);
            this.Controls.Add(this.lblRowsNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilterText);
            this.Controls.Add(this.cbFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(1543, 986);
            this.Name = "frmPeople";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "People";
            this.Load += new System.EventHandler(this.frmPeople_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPeople)).EndInit();
            this.ctxtMdgv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFilter;
        private System.Windows.Forms.TextBox txtFilterText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRowsNum;
        private System.Windows.Forms.DataGridView dgvPeople;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip ctxtMdgv;
        private System.Windows.Forms.ToolStripMenuItem ShowDetialsStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AddNewPersontoolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem EdittoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeletetoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.Button btnAddUpdate;
    }
}