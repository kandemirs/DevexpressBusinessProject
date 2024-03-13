
namespace EnmosProje
{
    partial class FrmRequests
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.LblName = new System.Windows.Forms.Label();
            this.LblDescription = new System.Windows.Forms.Label();
            this.LblLabel = new System.Windows.Forms.Label();
            this.LblAssignee2 = new System.Windows.Forms.Label();
            this.LblAssignee = new System.Windows.Forms.Label();
            this.LblRequester = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnReject = new System.Windows.Forms.Button();
            this.BtnOnayla = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gridControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 511);
            this.splitContainer1.SplitterDistance = 791;
            this.splitContainer1.TabIndex = 2;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(791, 511);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged_1);
            // 
            // groupControl1
            // 
            this.groupControl1.Appearance.BackColor = System.Drawing.Color.DimGray;
            this.groupControl1.Appearance.Options.UseBackColor = true;
            this.groupControl1.Controls.Add(this.LblName);
            this.groupControl1.Controls.Add(this.LblDescription);
            this.groupControl1.Controls.Add(this.LblLabel);
            this.groupControl1.Controls.Add(this.LblAssignee2);
            this.groupControl1.Controls.Add(this.LblAssignee);
            this.groupControl1.Controls.Add(this.LblRequester);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label5);
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.BtnReject);
            this.groupControl1.Controls.Add(this.BtnOnayla);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(289, 511);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "groupControl1";
            // 
            // LblName
            // 
            this.LblName.AutoSize = true;
            this.LblName.BackColor = System.Drawing.Color.Transparent;
            this.LblName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblName.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblName.Location = new System.Drawing.Point(22, 316);
            this.LblName.Name = "LblName";
            this.LblName.Size = new System.Drawing.Size(101, 19);
            this.LblName.TabIndex = 13;
            this.LblName.Text = "Description";
            // 
            // LblDescription
            // 
            this.LblDescription.AutoSize = true;
            this.LblDescription.BackColor = System.Drawing.Color.Transparent;
            this.LblDescription.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDescription.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblDescription.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblDescription.Location = new System.Drawing.Point(22, 262);
            this.LblDescription.Name = "LblDescription";
            this.LblDescription.Size = new System.Drawing.Size(101, 19);
            this.LblDescription.TabIndex = 12;
            this.LblDescription.Text = "Description";
            // 
            // LblLabel
            // 
            this.LblLabel.AutoSize = true;
            this.LblLabel.BackColor = System.Drawing.Color.Transparent;
            this.LblLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblLabel.Location = new System.Drawing.Point(22, 207);
            this.LblLabel.Name = "LblLabel";
            this.LblLabel.Size = new System.Drawing.Size(101, 19);
            this.LblLabel.TabIndex = 11;
            this.LblLabel.Text = "Description";
            // 
            // LblAssignee2
            // 
            this.LblAssignee2.AutoSize = true;
            this.LblAssignee2.BackColor = System.Drawing.Color.Transparent;
            this.LblAssignee2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAssignee2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblAssignee2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblAssignee2.Location = new System.Drawing.Point(22, 149);
            this.LblAssignee2.Name = "LblAssignee2";
            this.LblAssignee2.Size = new System.Drawing.Size(101, 19);
            this.LblAssignee2.TabIndex = 10;
            this.LblAssignee2.Text = "Description";
            // 
            // LblAssignee
            // 
            this.LblAssignee.AutoSize = true;
            this.LblAssignee.BackColor = System.Drawing.Color.Transparent;
            this.LblAssignee.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblAssignee.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblAssignee.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblAssignee.Location = new System.Drawing.Point(22, 86);
            this.LblAssignee.Name = "LblAssignee";
            this.LblAssignee.Size = new System.Drawing.Size(101, 19);
            this.LblAssignee.TabIndex = 9;
            this.LblAssignee.Text = "Description";
            // 
            // LblRequester
            // 
            this.LblRequester.AutoSize = true;
            this.LblRequester.BackColor = System.Drawing.Color.Transparent;
            this.LblRequester.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRequester.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LblRequester.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.LblRequester.Location = new System.Drawing.Point(22, 30);
            this.LblRequester.Name = "LblRequester";
            this.LblRequester.Size = new System.Drawing.Size(101, 19);
            this.LblRequester.TabIndex = 8;
            this.LblRequester.Text = "Description";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Gray;
            this.label6.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label6.Location = new System.Drawing.Point(152, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 23);
            this.label6.TabIndex = 7;
            this.label6.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(152, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 23);
            this.label5.TabIndex = 6;
            this.label5.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Gray;
            this.label4.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(152, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 23);
            this.label4.TabIndex = 5;
            this.label4.Text = "Assignee";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Gray;
            this.label3.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(152, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Assignee2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(152, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Label";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Gray;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(152, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Requester";
            // 
            // BtnReject
            // 
            this.BtnReject.BackColor = System.Drawing.Color.Red;
            this.BtnReject.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnReject.ForeColor = System.Drawing.Color.White;
            this.BtnReject.Location = new System.Drawing.Point(129, 416);
            this.BtnReject.Name = "BtnReject";
            this.BtnReject.Size = new System.Drawing.Size(116, 91);
            this.BtnReject.TabIndex = 1;
            this.BtnReject.Text = "Reject";
            this.BtnReject.UseVisualStyleBackColor = false;
            this.BtnReject.Click += new System.EventHandler(this.BtnReject_Click_1);
            // 
            // BtnOnayla
            // 
            this.BtnOnayla.BackColor = System.Drawing.Color.YellowGreen;
            this.BtnOnayla.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnOnayla.ForeColor = System.Drawing.Color.White;
            this.BtnOnayla.Location = new System.Drawing.Point(7, 416);
            this.BtnOnayla.Name = "BtnOnayla";
            this.BtnOnayla.Size = new System.Drawing.Size(116, 91);
            this.BtnOnayla.TabIndex = 0;
            this.BtnOnayla.Text = "Approve";
            this.BtnOnayla.UseVisualStyleBackColor = false;
            this.BtnOnayla.Click += new System.EventHandler(this.BtnOnayla_Click_1);
            // 
            // FrmRequests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 511);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FrmRequests";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmRequests";
            this.Load += new System.EventHandler(this.FrmRequests_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label LblName;
        private System.Windows.Forms.Label LblDescription;
        private System.Windows.Forms.Label LblLabel;
        private System.Windows.Forms.Label LblAssignee2;
        private System.Windows.Forms.Label LblAssignee;
        private System.Windows.Forms.Label LblRequester;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnReject;
        private System.Windows.Forms.Button BtnOnayla;
    }
}