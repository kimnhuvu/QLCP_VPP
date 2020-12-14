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

namespace QLCP_VPP
{
     public partial class Dangnhap : Form
     {
          string chuoikn = System.Configuration.ConfigurationSettings.AppSettings["Main.ConnectionString"];
          SqlCommand thuchien;
          SqlConnection ketnoi;
          SqlDataReader docdulieu;
          string sql;
          int i = 0;
          public Dangnhap()
          {
               InitializeComponent();
          }

          private void btn_Exit_Click(object sender, EventArgs e)
          {
               this.Dispose();
          }

          private void btn_Dangnhap_MouseLeave(object sender, EventArgs e)
          {
               btn_Dangnhap.BackColor = Color.LightSeaGreen;
               btn_Dangnhap.Font = new Font(btn_Dangnhap.Font.FontFamily, 10);

          }

          private void btn_Dangnhap_MouseMove(object sender, MouseEventArgs e)
          {
               btn_Dangnhap.BackColor = Color.DodgerBlue;
               btn_Dangnhap.Font = new Font(btn_Dangnhap.Font.FontFamily, 14);
          }

          private void btn_Dangnhap_Click(object sender, EventArgs e)
          {
               using (ketnoi = new SqlConnection(chuoikn))
               {
                    sql = "select * from nhanvien where SDT like '" + txt_SDT_dangnhap.Text + "'";
                    ketnoi.Open();
                    thuchien = new SqlCommand(sql, ketnoi);
                    docdulieu = thuchien.ExecuteReader();
                    if (docdulieu.Read())
                    {
                         if (txt_Pass_dangnhap.Text == "123456")
                         {
                              Trang_chu ct = new Trang_chu();
                              this.Hide();
                              ct.TB_TenNV = docdulieu[1].ToString();
                              ct.maNV = docdulieu[0].ToString();
                              ct.Visible = true;
                              ketnoi.Close();
                         }
                         else
                         {
                              lb_tbao.Visible = true;
                         }

                    }
                    else
                    {
                         lb_tbao.Visible = true;
                    }
               }

          }

          private void txt_SDT_dangnhap_Click(object sender, EventArgs e)
          {
               lb_tbao.Visible = false;
          }


          private void txt_Pass_dangnhap_Click(object sender, EventArgs e)
          {
               lb_tbao.Visible = false;
          }
     }
}
