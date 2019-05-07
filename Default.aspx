<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="FeaturedContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <section class="container hotnews mt-5">
            <h1 class="hotnews-title">BẤT ĐỘNG SẢN <span id="title_bds" runat="server">NỔI BẬT</span></h1>

                <%--phần load sản phẩm--%>
             <div id="loadsp" runat="server">
                <div class="row mt-5" id="show" runat="server">

                </div>
                 <!-- The Modal -->
                 <div class="modal" id="myModalVideo">
                    <div class="modal-dialog">
                      <div class="modal-content video-content">                        
                        <div class="modal-body video-body">          
                          <iframe id="link" width="560" height="315" src="" frameborder="0" allow="accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture" allowfullscreen></iframe>
                        </div>
                      </div>
                    </div>
                  </div>
                <!-- PHÂN TRANG -->
                <div class="row my-5">
                    <div class="col text-center">
                        <ul class="phantrang" id="phantrang" runat="server">
                        </ul>
                    </div>
                </div>
            </div>
    </section>
</asp:Content>

