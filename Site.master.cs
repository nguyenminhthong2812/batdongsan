using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text.RegularExpressions;
using System.Text;


public partial class SiteMaster : MasterPage
{
    private bus_Danhmuc dm = new bus_Danhmuc();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        img_banner.Attributes["src"] = "./Images/nhadat.jpg";
        LoadKhuVuc();
        LoadLoaiBDS();
        int tin = (int)Session["tin"];
        if (tin == 0)
            trangchu.Attributes.Add("class", "active");
        else if (tin == 1)
            khuvuc.Attributes.Add("class", "nav-item dropdown active");
        else
            loai.Attributes.Add("class", "nav-item dropdown active");
    }

    protected void LoadKhuVuc()
    {
        DataTable dt = new DataTable();
        dt = dm.BUS_LOAD_KHUVUC().Tables[0];
        string khuvuc_html = "";
        foreach (DataRow dr in dt.Rows)
        {
            string makv = dr["maKV"].ToString();
            string tenkv = dr["tenKV"].ToString();
            string meta_tenkv = convertToUnSign3(tenkv);
            khuvuc_html += "<a class=\"dropdown-item khuvuc\" href=\"nha-dat-"+meta_tenkv+"-1\" data-name=\"BẤT ĐỘNG SẢN " + tenkv.ToUpper() + "\" data-makv=\"" + makv + "\">" + tenkv + "</a>";
        }
        showKhuVuc.InnerHtml = khuvuc_html;
    }

    protected void LoadLoaiBDS()
    {
        DataTable dt = new DataTable();
        dt = dm.BUS_LOAD_LOAIBDS().Tables[0];
        string loaibds_html = "";
        foreach (DataRow dr in dt.Rows)
        {
            string maloai = dr["maLoaiBDS"].ToString();
            string tenloai = dr["tenLoaiBDS"].ToString();
            string meta_tenloai = convertToUnSign3(tenloai);
            loaibds_html += "<a class=\"dropdown-item loaibds\" data-name=\"BẤT ĐỘNG SẢN " + tenloai.ToUpper() + "\" data-maloai=\"" + maloai + "\" href=\"bat-dong-san-"+meta_tenloai+"-1\">" + tenloai + "</a>";
        }
        showLoaiBDS.InnerHtml = loaibds_html;
    }

    public static string convertToUnSign3(string s)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = s.Normalize(NormalizationForm.FormD);
        string kq = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');        
        return kq.ToLower().Replace(" ","-");
    } 

    [WebMethod]
    public static string DangNhap(string taikhoan, string matkhau)
    {
        bus_Danhmuc dm = new bus_Danhmuc();
        int kq = dm.BUS_DANGNHAP(taikhoan, matkhau);
        return Convert.ToString(kq);
    }
}