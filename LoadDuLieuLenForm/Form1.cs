using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient; 

namespace LoadDuLieuLenForm
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = @"Data Source=ADMINISTRATOR\SQLEXPRESS;Initial Catalog=TH_KiemTra;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable(); 

        void hienthidl()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThongTinNV";
            command.ExecuteNonQuery();
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            Grdhienthi.DataSource = table;
            Grdhienthi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            hienthidl();

        }

        private void Bntthoat_Click(object sender, EventArgs e)
        {
            Close(); 
        }

        private void Grdhienthi_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtmnv.ReadOnly = true;
            int i = Grdhienthi.CurrentRow.Index;
            txtmnv.Text =       Grdhienthi.Rows[i].Cells[0].Value.ToString();
            txttnv.Text =       Grdhienthi.Rows[i].Cells[1].Value.ToString();
            dtngaysinh.Text =   Grdhienthi.Rows[i].Cells[2].Value.ToString();
            cbgioitinh.Text =   Grdhienthi.Rows[i].Cells[3].Value.ToString(); 
            txtchucvu.Text =    Grdhienthi.Rows[i].Cells[4].Value.ToString(); 
            txttienluong.Text = Grdhienthi.Rows[i].Cells[5].Value.ToString();
        }

        private void BntThem_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "insert into ThongTinNV values(N'"+txtmnv.Text+"',N'"+txttnv.Text+"','"+dtngaysinh.Text+"',N'"+cbgioitinh.Text+"',N'"+txtchucvu.Text+"',"+txttienluong.Text+")";
            command.ExecuteNonQuery();
            hienthidl();

        }

        private void Bntxoa_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "delete from ThongTinNV where ThongTinNV.MaNV = '"+txtmnv.Text+"'";
            command.ExecuteNonQuery();
            hienthidl(); 
        }

        private void Bntsua_Click(object sender, EventArgs e)
        {
            command = connection.CreateCommand();
            command.CommandText = "update ThongTinNV set TenNV = N'"+txttnv.Text+"',NgaySinh= N'"+dtngaysinh.Text+"',GioiTinh =N'"+cbgioitinh.Text+"',ChucVu=N'"+txtchucvu.Text+"',TienLuong = "+txttienluong.Text+" where MaNV = '"+txtmnv.Text+"'";
            command.ExecuteNonQuery();
            hienthidl(); 
        }

        private void Bntkhoitao_Click(object sender, EventArgs e)
        {
            txtmnv.Text = "";
            txtchucvu.Text = "";
            txttnv.Text = "";
            txttienluong.Text = "";
            dtngaysinh.Text = "1/1/1900";
            cbgioitinh.Text = "";

        }
    }
}
