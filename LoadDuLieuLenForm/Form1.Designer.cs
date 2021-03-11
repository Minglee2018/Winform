namespace LoadDuLieuLenForm
{
    partial class Form1
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
            this.Grdhienthi = new System.Windows.Forms.DataGridView();
            this.label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtmnv = new System.Windows.Forms.TextBox();
            this.txttnv = new System.Windows.Forms.TextBox();
            this.txttienluong = new System.Windows.Forms.TextBox();
            this.txtchucvu = new System.Windows.Forms.TextBox();
            this.cbgioitinh = new System.Windows.Forms.ComboBox();
            this.dtngaysinh = new System.Windows.Forms.DateTimePicker();
            this.bntThem = new System.Windows.Forms.Button();
            this.bntsua = new System.Windows.Forms.Button();
            this.bntxoa = new System.Windows.Forms.Button();
            this.bntkhoitao = new System.Windows.Forms.Button();
            this.bntthoat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Grdhienthi)).BeginInit();
            this.SuspendLayout();
            // 
            // Grdhienthi
            // 
            this.Grdhienthi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grdhienthi.Location = new System.Drawing.Point(40, 13);
            this.Grdhienthi.Name = "Grdhienthi";
            this.Grdhienthi.Size = new System.Drawing.Size(916, 275);
            this.Grdhienthi.TabIndex = 11;
            this.Grdhienthi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grdhienthi_CellContentClick);
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Location = new System.Drawing.Point(58, 333);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(75, 13);
            this.label.TabIndex = 1;
            this.label.Text = "Mã Nhân Viên";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 384);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên Nhân Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 428);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Giới Tính";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(445, 333);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Ngày Sinh";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(445, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Chức Vụ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(445, 428);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Tiền Lương";
            // 
            // txtmnv
            // 
            this.txtmnv.Location = new System.Drawing.Point(169, 333);
            this.txtmnv.Name = "txtmnv";
            this.txtmnv.Size = new System.Drawing.Size(121, 20);
            this.txtmnv.TabIndex = 0;
            // 
            // txttnv
            // 
            this.txttnv.Location = new System.Drawing.Point(169, 377);
            this.txttnv.Name = "txttnv";
            this.txttnv.Size = new System.Drawing.Size(121, 20);
            this.txttnv.TabIndex = 1;
            // 
            // txttienluong
            // 
            this.txttienluong.Location = new System.Drawing.Point(532, 428);
            this.txttienluong.Name = "txttienluong";
            this.txttienluong.Size = new System.Drawing.Size(116, 20);
            this.txttienluong.TabIndex = 5;
            // 
            // txtchucvu
            // 
            this.txtchucvu.Location = new System.Drawing.Point(532, 381);
            this.txtchucvu.Name = "txtchucvu";
            this.txtchucvu.Size = new System.Drawing.Size(116, 20);
            this.txtchucvu.TabIndex = 4;
            // 
            // cbgioitinh
            // 
            this.cbgioitinh.FormattingEnabled = true;
            this.cbgioitinh.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbgioitinh.Location = new System.Drawing.Point(169, 419);
            this.cbgioitinh.Name = "cbgioitinh";
            this.cbgioitinh.Size = new System.Drawing.Size(121, 21);
            this.cbgioitinh.TabIndex = 2;
            // 
            // dtngaysinh
            // 
            this.dtngaysinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtngaysinh.Location = new System.Drawing.Point(532, 325);
            this.dtngaysinh.Name = "dtngaysinh";
            this.dtngaysinh.Size = new System.Drawing.Size(116, 20);
            this.dtngaysinh.TabIndex = 3;
            // 
            // bntThem
            // 
            this.bntThem.Location = new System.Drawing.Point(733, 325);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(75, 23);
            this.bntThem.TabIndex = 6;
            this.bntThem.Text = "Thêm ";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.BntThem_Click);
            // 
            // bntsua
            // 
            this.bntsua.Location = new System.Drawing.Point(733, 379);
            this.bntsua.Name = "bntsua";
            this.bntsua.Size = new System.Drawing.Size(75, 23);
            this.bntsua.TabIndex = 7;
            this.bntsua.Text = "Sửa";
            this.bntsua.UseVisualStyleBackColor = true;
            this.bntsua.Click += new System.EventHandler(this.Bntsua_Click);
            // 
            // bntxoa
            // 
            this.bntxoa.Location = new System.Drawing.Point(733, 425);
            this.bntxoa.Name = "bntxoa";
            this.bntxoa.Size = new System.Drawing.Size(75, 23);
            this.bntxoa.TabIndex = 8;
            this.bntxoa.Text = "Xóa";
            this.bntxoa.UseVisualStyleBackColor = true;
            this.bntxoa.Click += new System.EventHandler(this.Bntxoa_Click);
            // 
            // bntkhoitao
            // 
            this.bntkhoitao.Location = new System.Drawing.Point(733, 480);
            this.bntkhoitao.Name = "bntkhoitao";
            this.bntkhoitao.Size = new System.Drawing.Size(75, 23);
            this.bntkhoitao.TabIndex = 9;
            this.bntkhoitao.Text = "Khởi Tạo";
            this.bntkhoitao.UseVisualStyleBackColor = true;
            this.bntkhoitao.Click += new System.EventHandler(this.Bntkhoitao_Click);
            // 
            // bntthoat
            // 
            this.bntthoat.Location = new System.Drawing.Point(360, 496);
            this.bntthoat.Name = "bntthoat";
            this.bntthoat.Size = new System.Drawing.Size(75, 23);
            this.bntthoat.TabIndex = 10;
            this.bntthoat.Text = "Thoát";
            this.bntthoat.UseVisualStyleBackColor = true;
            this.bntthoat.Click += new System.EventHandler(this.Bntthoat_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 551);
            this.Controls.Add(this.bntthoat);
            this.Controls.Add(this.bntkhoitao);
            this.Controls.Add(this.bntxoa);
            this.Controls.Add(this.bntsua);
            this.Controls.Add(this.bntThem);
            this.Controls.Add(this.dtngaysinh);
            this.Controls.Add(this.cbgioitinh);
            this.Controls.Add(this.txtchucvu);
            this.Controls.Add(this.txttienluong);
            this.Controls.Add(this.txttnv);
            this.Controls.Add(this.txtmnv);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.Grdhienthi);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grdhienthi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Grdhienthi;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtmnv;
        private System.Windows.Forms.TextBox txttnv;
        private System.Windows.Forms.TextBox txttienluong;
        private System.Windows.Forms.TextBox txtchucvu;
        private System.Windows.Forms.ComboBox cbgioitinh;
        private System.Windows.Forms.DateTimePicker dtngaysinh;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.Button bntsua;
        private System.Windows.Forms.Button bntxoa;
        private System.Windows.Forms.Button bntkhoitao;
        private System.Windows.Forms.Button bntthoat;
    }
}

