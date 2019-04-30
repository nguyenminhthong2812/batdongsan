<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="chitiet.aspx.cs" Inherits="chitiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <section class="container hotnews mt-5">
        <%--phần load chi tiết sản phẩm--%>
        <div id="trangchitiet" runat="server">
            <h2 class="text-center title" id="tieudesp" runat="server"></h2>
            <p class="diachi" id="diachisp" runat="server"></p>
            <p class="Gia" id="giasp" runat="server"></p>
            <h5>Hình ảnh khu đất</h5>
            <!-- Carousel -->
            <div class="carousel slide my-3" data-ride="carousel" id="carousel-slider">
                <div class="carousel-inner" role="listbox" id="slide" runat="server">                   
                </div>
            </div>
            <h6>Nội dung chi tiết </h6>
            <article class="noidung" id="noidungsp" runat="server">
            </article>
            <%--<p class="back"><< Quay lại danh sách</p>--%>
        </div>
    </section>
</asp:Content>

