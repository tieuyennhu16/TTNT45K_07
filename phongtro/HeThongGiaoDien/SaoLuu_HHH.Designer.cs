namespace phongtro.HeThongGiaoDien
{
    partial class SaoLuu_HHH
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaoLuu_HHH));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_xac_nhan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ten_file = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_noi_luu = new System.Windows.Forms.TextBox();
            this.btn_mo_thu_muc = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::phongtro.Properties.Resources.InternetSlowdown_Day;
            this.pictureBox1.Location = new System.Drawing.Point(225, 1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 143);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btn_xac_nhan
            // 
            this.btn_xac_nhan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xac_nhan.Location = new System.Drawing.Point(122, 110);
            this.btn_xac_nhan.Margin = new System.Windows.Forms.Padding(4);
            this.btn_xac_nhan.Name = "btn_xac_nhan";
            this.btn_xac_nhan.Size = new System.Drawing.Size(164, 51);
            this.btn_xac_nhan.TabIndex = 6;
            this.btn_xac_nhan.Text = "Xác nhận";
            this.btn_xac_nhan.UseVisualStyleBackColor = true;
            this.btn_xac_nhan.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 67);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 19);
            this.label1.TabIndex = 7;
            this.label1.Text = "Đặt tên tập tin:";
            // 
            // txt_ten_file
            // 
            this.txt_ten_file.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_ten_file.Location = new System.Drawing.Point(122, 64);
            this.txt_ten_file.Margin = new System.Windows.Forms.Padding(4);
            this.txt_ten_file.Name = "txt_ten_file";
            this.txt_ten_file.Size = new System.Drawing.Size(426, 26);
            this.txt_ten_file.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 19);
            this.label2.TabIndex = 9;
            this.label2.Text = "Nơi lưu:";
            // 
            // txt_noi_luu
            // 
            this.txt_noi_luu.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_noi_luu.Location = new System.Drawing.Point(122, 18);
            this.txt_noi_luu.Margin = new System.Windows.Forms.Padding(4);
            this.txt_noi_luu.Name = "txt_noi_luu";
            this.txt_noi_luu.ReadOnly = true;
            this.txt_noi_luu.Size = new System.Drawing.Size(426, 26);
            this.txt_noi_luu.TabIndex = 10;
            this.txt_noi_luu.Text = "C:\\QLNHATRO\\FileBackup\\";
            // 
            // btn_mo_thu_muc
            // 
            this.btn_mo_thu_muc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_mo_thu_muc.Location = new System.Drawing.Point(339, 110);
            this.btn_mo_thu_muc.Margin = new System.Windows.Forms.Padding(4);
            this.btn_mo_thu_muc.Name = "btn_mo_thu_muc";
            this.btn_mo_thu_muc.Size = new System.Drawing.Size(209, 51);
            this.btn_mo_thu_muc.TabIndex = 11;
            this.btn_mo_thu_muc.Text = "Mở mục chứa file";
            this.btn_mo_thu_muc.UseVisualStyleBackColor = true;
            this.btn_mo_thu_muc.Click += new System.EventHandler(this.button2_Click);
            // 
            // SaoLuu_HHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(565, 177);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btn_mo_thu_muc);
            this.Controls.Add(this.txt_noi_luu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_ten_file);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_xac_nhan);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SaoLuu_HHH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sao lưu dữ liệu";
            this.Load += new System.EventHandler(this.Backup_HHH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_xac_nhan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ten_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_noi_luu;
        private System.Windows.Forms.Button btn_mo_thu_muc;
    }
}