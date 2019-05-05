using BDS.OBJE;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_View : System.Web.UI.Page
{
    private bus_Danhmuc dm = new bus_Danhmuc();
    private bus_Admin admin = new bus_Admin();
    private DataTable dtanh = new DataTable();
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
                if (Request.QueryString["ID"] == null)
                {
                    return;
                }
                else
                {
                    laydsBDS();                    
                }

            }
        }
    }
    private void loadDM()
    {
        DropDownList khuvuc = (DropDownList)Viewedit.FindControl("drlKhuvuc");
        dm = new bus_Danhmuc();
        khuvuc.DataSource = dm.BUS_loadDM().Tables[0];
        //khuvuc.DataSource = Enum.GetNames(typeof(TestimonialStatus.CurrentTestimonialStatus));
        khuvuc.DataTextField = "tenKV";
        khuvuc.DataValueField = "maKV";
        khuvuc.DataBind();

        DropDownList loaibds = (DropDownList)Viewedit.FindControl("drlLoaiBDS");
        loaibds.DataSource = dm.BUS_loadDM().Tables[1];
        loaibds.DataTextField = "tenLoaiBDS";
        loaibds.DataValueField = "maLoaiBDS";
        loaibds.DataBind();

    }
    void laydsBDS()
    {
        try
        {
            DataTable dt = new DataTable();
            dt = admin.BUS_view_batdongsan("", -1, -1, Convert.ToInt16(Request.QueryString["ID"]), -1).Tables[0];
            Viewedit.DataSource = dt;
            Viewedit.DataBind();

            DropDownList khuvuc = (DropDownList)Viewedit.FindControl("drlKhuvuc");
            khuvuc.DataSource = dm.BUS_loadDM().Tables[0];
            khuvuc.DataTextField = "tenKV";
            khuvuc.DataValueField = "maKV";
            khuvuc.DataBind();

            ListItem selectedKV = khuvuc.Items.FindByValue(dt.Rows[0]["maKV"].ToString());

            if (selectedKV != null)
            {
                selectedKV.Selected = true;
            }

            DropDownList loaibds = (DropDownList)Viewedit.FindControl("drlLoaiBDS");
            loaibds.DataSource = dm.BUS_loadDM().Tables[1];
            loaibds.DataTextField = "tenLoaiBDS";
            loaibds.DataValueField = "maLoaiBDS";
            loaibds.DataBind();

            ListItem selectedLoaibds = loaibds.Items.FindByValue(dt.Rows[0]["maLoaiBDS"].ToString());

            if (selectedLoaibds != null)
            {
                selectedLoaibds.Selected = true;
            }


            CheckBox chknoibat = (CheckBox)Viewedit.FindControl("chkNoiBat");
            chknoibat.Checked = Convert.ToBoolean(dt.Rows[0]["NoiBat"].ToString());

            CheckBox chkdaban = (CheckBox)Viewedit.FindControl("chkDaBan");
            chkdaban.Checked = Convert.ToBoolean(dt.Rows[0]["DaBan"].ToString());

            //DataTable dt1 = new DataTable();
            //dt1.Columns.Add("hinhanh", typeof(string));
            //DataRow rows;
            //if (dt != null && dt.Rows.Count > 0) foreach (DataRow row in dt.Rows)
            //    {
            //        if (row["hinhanh"].ToString() != null && row["hinhanh"].ToString() != "")
            //        {
            //            //string linkfile = link.Uploadfile_congviec(Session["Auto_idcongviec"].ToString());
            //            FileInfo file = new FileInfo( row["hinhanh"].ToString());
            //            string Mb = (file.Length / 1024).ToString();
            //            string stenfile = string.Format("{0} ({1}KB)", row["hinhanh"].ToString(), Mb);
            //            rows = dt1.NewRow();
            //            rows["hinhanh"] = stenfile;
            //            dt1.Rows.Add(rows);
            //        }
            //    }
            //string file = dt.Rows[0]["hinhanh"].ToString();
            //FileUpload txtanhdaidien = (FileUpload)Viewedit.FindControl("txtanhdaidien");
            //txtanhdaidien.FileName = file;
            GridView gvanhdaidien = (GridView)Viewedit.FindControl("gv_anhdaidien");
            gvanhdaidien.DataSource = dt;
            gvanhdaidien.DataBind();

            GridView gv = (GridView)Viewedit.FindControl("gv_tenfile");
            dtanh = admin.BUS_view_batdongsan("", -1, -1, Convert.ToInt16(Request.QueryString["ID"]), -1).Tables[1];
            Session.Remove("anhct");
            Session["anhct"] = dtanh;
            gv.DataSource = dtanh;
            gv.DataBind();
        }
        catch { }
        
    }
    
    protected void Viewedit_ItemCommand(object sender, FormViewCommandEventArgs e)
    {
        try
        {
            string command = e.CommandArgument.ToString();
            if (e.CommandName == "Capnhat")
            {
                obj_BDS obj = new obj_BDS();
                obj.maBDS = int.Parse(command);
                TextBox tenbds = (TextBox)Viewedit.FindControl("txtTenBDS");
                obj.tenBDS = tenbds.Text.ToString();
                TextBox diachi = (TextBox)Viewedit.FindControl("txtDiachi");
                obj.diachi = diachi.Text.ToString();
                TextBox gia = (TextBox)Viewedit.FindControl("txtGia");
                obj.gia = gia.Text.ToString();
                FredCK.FCKeditorV2.FCKeditor noidung = (FredCK.FCKeditorV2.FCKeditor)Viewedit.FindControl("fckNoidung");
                obj.noidung = noidung.Value;
                obj.ghichu = "";
                CheckBox daban = (CheckBox)Viewedit.FindControl("chkDaBan");
                obj.daban = daban.Checked;
                DropDownList khuvuc = (DropDownList)Viewedit.FindControl("drlKhuvuc");
                obj.maKV = Convert.ToInt32(khuvuc.SelectedItem.Value.ToString());
                DropDownList loaibds = (DropDownList)Viewedit.FindControl("drlLoaiBDS");
                obj.maLoaiBDS = Convert.ToInt32(loaibds.SelectedItem.Value.ToString());
                CheckBox noibat = (CheckBox)Viewedit.FindControl("chkNoiBat");
                obj.noibat = noibat.Checked;
                TextBox youtube = (TextBox)Viewedit.FindControl("txtyoutube");
                obj.youtube = youtube.Text.ToString();

                string anhdaidien, anhct = "", stranhct = "";
                FileUpload txtanhdaidien = (FileUpload)Viewedit.FindControl("txtanhdaidien");
                Label lblanhdaidien = (Label)Viewedit.FindControl("lblanhdaidien");
                if (txtanhdaidien.FileName == "" && lblanhdaidien.Text != "")
                    anhdaidien = lblanhdaidien.Text.ToString().Replace("Images/nhadat/", "");
                else if (txtanhdaidien.FileName != "")
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
                FileUpload txtanhct = (FileUpload)Viewedit.FindControl("txtanhct");
                Label lblanhct = (Label)Viewedit.FindControl("lblanhct");
                GridView gv = (GridView)Viewedit.FindControl("gv_tenfile");
                
                if (txtanhct.FileName == "")
                {
                    DataTable dt = new DataTable();
                    dt = (DataTable)Session["anhct"];
                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            stranhct += dt.Rows[i]["anhct"].ToString().Replace("Images/nhadat/", "") + ",";
                        }
                    }
                }
                else if (txtanhct.HasFiles)
                {
                    foreach (HttpPostedFile uploadedFile in txtanhct.PostedFiles)
                    {
                        uploadedFile.SaveAs(System.IO.Path.Combine(Server.MapPath("~/Images/nhadat/"), uploadedFile.FileName));
                        stranhct += uploadedFile.FileName + ",";
                    }
                }
                int tt = admin.BUS_ql_batdongsan(obj, 2, stranhct);
                
                Label thongbao = (Label)Viewedit.FindControl("lblthongbao");
                if (tt != 0)
                {
                    
                    laydsBDS();
                    //thongbao.Text = "Cập nhật thành công!";
                    lblthongbao.Text = "Cập nhật thành công!";
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "An_hien_tbao()", true);
                }
                else
                {
                    lblthongbao.Text = "Thêm thất bại.Vui lòng kiểm tra lại!";
                    //ScriptManager.RegisterStartupScript(this.Page, GetType(), "Message", "An_hien_tbao()", true);
                }

            }
        }
        catch { }
    }
    protected void gv_tenfile_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
}