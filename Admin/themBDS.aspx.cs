using BDS.OBJE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_themBDS : System.Web.UI.Page
{
    private bus_Danhmuc dm = new bus_Danhmuc();
    private bus_Admin admin = new bus_Admin();
    protected void Page_Load(object sender, EventArgs e)
    {
        string session;
        try
        {
             session = Session["user"].ToString();
        }
        catch {
            session = null;
        }
        if (session == null || session != "admin")
        {
            Response.Redirect("~/Default.aspx");
        }
        else
        {   
            if (!IsPostBack)
            {
                Clear();
                loadDM();
            }
        }
    }
    private void loadDM()
    {
        drlKhuvuc.DataSource = dm.BUS_loadDM().Tables[0];
        drlKhuvuc.DataTextField = "tenKV";
        drlKhuvuc.DataValueField = "maKV";
        drlKhuvuc.DataBind();

        drlLoaiBDS.DataSource = dm.BUS_loadDM().Tables[1];
        drlLoaiBDS.DataTextField = "tenLoaiBDS";
        drlLoaiBDS.DataValueField = "maLoaiBDS";
        drlLoaiBDS.DataBind();
        
    }
    private void Clear()
    {
        txtTenBDS.Text = "";
        txtDiachi.Text = "";
        txtGia.Text = "";
        fckNoidung.Value = "";
    }
    protected void btnluu_Click(object sender, EventArgs e)
    {
        try
        {
            obj_BDS obj = new obj_BDS();
            obj.maBDS = 0;
            obj.tenBDS = txtTenBDS.Text.ToString();
            obj.diachi = txtDiachi.Text.ToString();
            obj.gia = txtGia.Text.ToString();
            obj.noidung = fckNoidung.Value;
            obj.ghichu = "";
            obj.daban = chkDaBan.Checked;
            obj.maKV = Convert.ToInt32(drlKhuvuc.SelectedItem.Value.ToString());
            obj.maLoaiBDS = Convert.ToInt32(drlLoaiBDS.SelectedItem.Value.ToString());
            obj.noibat = chkNoiBat.Checked;
            
            string anhdaidien,anhct="",stranhct="";
            if (txtanhdaidien.FileName != "")
            {
                //anhdaidien = Server.MapPath("..\\Images\\nhadat\\" + txtanhdaidien.FileName);
                anhdaidien = Server.MapPath("~/Images/nhadat/" + txtanhdaidien.FileName);
                txtanhdaidien.PostedFile.SaveAs(anhdaidien);
                anhdaidien = txtanhdaidien.FileName;
            }

            else
            {
                anhdaidien = "Empty.jpg";
            }           
            obj.hinhanh = anhdaidien;

            if (txtanhct.HasFiles)
            {
                foreach (HttpPostedFile uploadedFile in txtanhct.PostedFiles)
                {
                    uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/nhadat/"), uploadedFile.FileName));
                    stranhct += uploadedFile.FileName + ",";
                }
            }
            else
            {
                stranhct = "Empty.jpg";
            }
            int tt = admin.BUS_ql_batdongsan(obj, 1, stranhct);
            if (tt != 0)
            {
                lblthongbao.Text = "Thêm mới thành công!";
                Clear();
            }
            else
            {
                lblthongbao.Text = "Thêm thất bại.Vui lòng kiểm tra lại!";
            }
        }
        catch { }
    }
    protected void btnlamlai_Click(object sender, EventArgs e)
    {
        Clear();
        lblthongbao.Text = "";
    }
    
}