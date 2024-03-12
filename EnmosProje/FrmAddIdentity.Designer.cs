
namespace EnmosProje
{
    partial class FrmAddIdentity
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAddIdentity));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbNames = new System.Windows.Forms.ComboBox();
            this.GetId = new DevExpress.XtraEditors.SimpleButton();
            this.BtnPickPic = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(113, 81);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(283, 405);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(52, 56);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(70, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name";
            // 
            // CmbNames
            // 
            this.CmbNames.FormattingEnabled = true;
            this.CmbNames.Location = new System.Drawing.Point(125, 206);
            this.CmbNames.Name = "CmbNames";
            this.CmbNames.Size = new System.Drawing.Size(121, 21);
            this.CmbNames.TabIndex = 3;
            // 
            // GetId
            // 
            this.GetId.Location = new System.Drawing.Point(73, 281);
            this.GetId.Name = "GetId";
            this.GetId.Size = new System.Drawing.Size(173, 29);
            this.GetId.TabIndex = 4;
            this.GetId.Text = "Save";
            this.GetId.Click += new System.EventHandler(this.GetId_Click);
            // 
            // BtnPickPic
            // 
            this.BtnPickPic.Location = new System.Drawing.Point(73, 246);
            this.BtnPickPic.Name = "BtnPickPic";
            this.BtnPickPic.Size = new System.Drawing.Size(173, 29);
            this.BtnPickPic.TabIndex = 6;
            this.BtnPickPic.Text = "Select Picture from Folders";
            this.BtnPickPic.Click += new System.EventHandler(this.BtnPickPic_Click);
            // 
            // FrmAddIdentity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(334, 461);
            this.Controls.Add(this.BtnPickPic);
            this.Controls.Add(this.GetId);
            this.Controls.Add(this.CmbNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrmAddIdentity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAddIdentity";
            this.Load += new System.EventHandler(this.FrmAddIdentity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CmbNames;
        private DevExpress.XtraEditors.SimpleButton GetId;
        private DevExpress.XtraEditors.SimpleButton BtnPickPic;
    }
}