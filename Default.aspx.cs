using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    private bus_Danhmuc dm = new bus_Danhmuc();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string dangxuat = Request.QueryString["dangxuat"].ToString();
            if (dangxuat == "1")
                Session.Remove("user");
        }
        catch { }
        string khuvuc = RouteData.Values["khuvuc"] == null ? "" : RouteData.Values["khuvuc"].ToString();
        string tenloai = RouteData.Values["tenloai"] == null ? "" : RouteData.Values["tenloai"].ToString();
        int page = RouteData.Values["page"] == null ? 1 : Convert.ToInt32(RouteData.Values["page"]);
        LoadDS_SP(khuvuc, tenloai, page);

        int tin = 0;
        if (khuvuc != "")
            tin = 1;
        if (tenloai != "")
            tin = 2;
        Session["tin"] = tin;
    }

    protected void LoadDS_SP(string khuvuc, string tenloai, int page)
    {
        // get url
        string adrress = "";
        if (khuvuc == "" && tenloai == "")
        {
            adrress = "nha-dat";
        }
        else if (khuvuc != "")
        {
            adrress = "nha-dat-" + khuvuc;
        }
        else if (tenloai != "")
        {
            adrress = "bat-dong-san-" + tenloai;
        }

        DataSet ds = new DataSet();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        ds = dm.BUS_LOAD_DANHSACH_BDS(khuvuc, tenloai, page);
        dt1 = ds.Tables[0];
        dt2 = ds.Tables[1];
        // Gán tiêu đề
        string title = dt2.Rows[0]["TITLE"].ToString();
        title_bds.InnerHtml = title.ToUpper();

        // Hiển thị danh sách sản phẩm
        int tongtrang = 0;
        if (dt1.Rows.Count > 0)
        {
            tongtrang = Convert.ToInt32(dt1.Rows[0]["TONGTRANG"]);
            int sodu = tongtrang % 12;
            tongtrang = tongtrang / 12;
            if (sodu > 0)
                tongtrang++;
        }
        string show_html = "";
        if (tongtrang > 0)
        {
            foreach (DataRow dr in dt1.Rows)
            {
                // xử lý tên bds
                string tieude = dr["tenBDS"].ToString();                
                if (tieude.Length > 70)
                {
                    tieude = tieude.Substring(0, 70);
                    tieude = tieude.Substring(0, tieude.LastIndexOf(" ")) + " ...";
                }
                //xử lý địa chỉ
                string diachi = dr["DiaChi"].ToString();
                if (diachi.Length > 60)
                {
                    diachi = diachi.Substring(0, 60);
                    diachi = diachi.Substring(0, diachi.LastIndexOf(" ")) + " ...";
                }

                string meta_tenbds = convertToUnSign3(dr["tenBDS"].ToString());
                show_html += "<div class=\"col-sm-6 col-lg-3\">";
                show_html += "<div class=\"card\">";
                show_html += "<a class=\"img-bds\" href=\"" + meta_tenbds + "-" + dr["maBDS"].ToString() + "\"><img class=\"card-img-top\" src=\"" + dr["HinhAnh"].ToString() + "\" alt=\"Card image\"></a>";
                show_html += "<div class=\"card-body card-title\">";
                show_html += "<div class=\"title-new\"><a href=\"" + meta_tenbds + "-" + dr["maBDS"].ToString() + "\" class=\"tenbds\" data-mabds = \"" + dr["maBDS"].ToString() + "\">" + tieude + "</a><p class=\"tooltiptext\" >" + dr["tenBDS"].ToString() + "</p></div>";
                show_html += "<div class=\"title-adress\"><p class=\"card-text\">" + diachi + "</p></div>";
                show_html += "<div><span class=\"Gia\">" + dr["Gia"].ToString() + "</span></div>";
                show_html += "</div></div></div>";
            }
        }
        show.InnerHtml = show_html;

        // Thực hiện phân trang
        string htmlphantrang = "";

        

        int prevpage = page - 1;
        int nextpage = page + 1;
        if (prevpage == 0)
            htmlphantrang += "<li class=\"mr-2\"><a href=\"#\" class=\"prev-page\"><img src=\"./Images/prev.png\" alt=\"\"></a></li>";
        else
            htmlphantrang += "<li class=\"mr-2\"><a href=\""+adrress+"-" + prevpage.ToString() + "\" class=\"prev-page\"><img src=\"./Images/prev.png\" alt=\"\"></a></li>";
        if (page < 5)
        {
            if (tongtrang < 7)
            {
                for (int i = 1; i < tongtrang + 1; i++)
                {
                    if (i == page)
                        htmlphantrang += "<li class=\"mr-2\"><a href=\""+adrress+"-" + i.ToString() + "\" class=\"pagenum tranghientai\" data-number = \"" + i + "\" >" + i + "</a></li>";
                    else
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum\" data-number = \"" + i + "\">" + i + "</a></li>";
                }
            }
            else
            {
                for (int i = 1; i < 7; i++)
                {
                    if (i == page)
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum tranghientai\" data-number = \"" + i + "\" >" + i + "</a></li>";
                    else
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum\" data-number = \"" + i + "\">" + i + "</a></li>";
                }
                htmlphantrang += "<li class=\"mr-2\"><a href=\"\" class=\"no-drop\">...</a></li>";
            }
        }
        else
        {
            htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-1\" class=\"pagenum\" data-number = \"1\">1</a></li>";
            htmlphantrang += "<li class=\"mr-2\"><a href=\"\" class=\"no-drop\">...</a></li>";
            int tutrang = page - 2;
            int dentrang = page + 3;
            if (dentrang < tongtrang)
            {
                for (int i = tutrang; i < dentrang; i++)
                {
                    if (i == page)
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum tranghientai\" data-number = \"" + i + "\">" + i + "</a></li>";
                    else
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum\" data-number = \"" + i + "\">" + i + "</a></li>";
                }
                htmlphantrang += "<li class=\"mr-2\"><a href=\"\" class=\"no-drop\">...</a></li>";
                htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + tongtrang.ToString() + "\" class=\"pagenum\" data-number = \"" + tongtrang + "\">" + tongtrang + "</a></li>";
            }
            else
            {

                for (int i = tongtrang - 4; i <= tongtrang; i++)
                {
                    if (i == page)
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum tranghientai\" data-number = \"" + i + "\">" + i + "</a></li>";
                    else
                        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + i.ToString() + "\" class=\"pagenum\" data-number = \"" + i + "\">" + i + "</a></li>";
                }
            }
        }
        htmlphantrang += "<li class=\"mr-2\"><a href=\"" + adrress + "-" + nextpage.ToString() + "\" class=\"next-page\"><img src=\"./Images/next.png\" alt=\"\"></a></li>";
        phantrang.InnerHtml = htmlphantrang;

    }

    public static string convertToUnSign3(string s)
    {
        Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
        string temp = s.Normalize(NormalizationForm.FormD);
        string kq = regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');        
        return kq.ToLower().Replace(" ", "-").Replace("/","-").Replace(".",",");
    }

    [WebMethod]
    public static string DangNhap(string taikhoan, string matkhau)
    {
        bus_Danhmuc dm = new bus_Danhmuc();
        int kq = dm.BUS_DANGNHAP(taikhoan, matkhau);
        HttpContext.Current.Session.Add("user", taikhoan);
        return Convert.ToString(kq);
    }
}