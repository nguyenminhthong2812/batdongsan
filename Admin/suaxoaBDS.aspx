<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" EnableEventValidation="false" CodeFile="suaxoaBDS.aspx.cs" Inherits="Admin_suaxoaBDS" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type = "text/javascript">
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Bạn có muốn xóa hay không?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
<span class='TitleList edit' >Cập nhật bất động sản (sửa/xoá)</span>
<div class='titleBan search' >TÌM KIẾM</div>
<div class='content search' style='text-align:center;'>
        <%--<div class='search_name'><span class='info'>TÊN BĐS </span>
            <br />
            <div style="padding-left:65px"><asp:TextBox ID="txtsearchTen" runat="server" Width="390px" TextMode="MultiLine"></asp:TextBox></div>
        </div>
        <div class='search_price'><span class='info'>Danh mục</span>
            <br /><span class='giainfo'>Khu vực:</span><asp:DropDownList ID="drlmakv" runat="server" Width="170px"></asp:DropDownList><span class='giainfo'>Loại BĐS</span><asp:DropDownList ID="drlloaibds" runat="server" Width="170px"></asp:DropDownList></div>
        <div style="padding-left:10px">          
            <asp:Button ID="btntimkiem" runat="server" Text="Tìm kiếm" Height="30px" Width="80px" OnClick="btntimkiem_Click"  />
        </div>--%>
        <table style="width:90%">
            <tr style="height:25px">
                <td>
                    <span>Tên BDS:</span>
                </td>
                <td colspan="3" style="height:25px">
                    <asp:TextBox ID="txtsearchTen" runat="server" Width="100%" Height="100%"></asp:TextBox>
                </td>
            </tr>
            <tr style="height:25px">
                <td style="width:15%">
                    <span>Khu vực:</span>
                </td>
                <td style="width:30%;height:25px">
                    <asp:DropDownList ID="drlmakv" runat="server" Width="100%"></asp:DropDownList>
                </td>
                <td style="text-align:right;width:15%">
                    <span>Loại BĐS:</span>
                </td>
                <td style="width:30%;height:25px">
                    <asp:DropDownList ID="drlloaibds" runat="server" Width="100%"></asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td colspan="4" style="text-align:center">
                    <asp:Button ID="btntimkiem" runat="server" Text="Tìm kiếm" Height="30px" Width="80px" OnClick="btntimkiem_Click"  />
                </td>
            </tr>
        </table>
   
</div>
<div class='result'>
    <div class='paging'>
        <%--<%
            String gia1 = String.valueOf(giafrom);
            String gia2 = String.valueOf(giato);
            for (int i = 1; i <= sotrang; i++) {
                if (trang == i) {%>
        <a href='searchsanpham_update?Action=Search&txtsearch_name=<%=tenmathang%>&txtsearch_price_from=<%=gia1%>&txtsearch_price_to=<%=gia2%>&trang=<%=i%>' class='active'><%=i%></a>
        <%} else {%>
        <a href='searchsanpham_update?Action=Search&txtsearch_name=<%=tenmathang%>&txtsearch_price_from=<%=gia1%>&txtsearch_price_to=<%=gia2%>&trang=<%=i%>' ><%=i%></a>
        <%}
            }%>--%>
        <span class='resultmsg'>Tìm thấy <%--<%=sosp%>--%> kết quả!</span></div>
    <div class='resultSearch'>
        <div class='prod_detail giohang_detail'> 
            <table width='730px' border='0' cellspacing='2' cellpadding='5'>
                <tr  class='giohang_tabletitle'>
                    <td>Sản phẩm</td>
                    <td style="text-align:right">Xoá/Sửa</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <div>              
                            <asp:GridView ID="GridSp" runat="server" AutoGenerateColumns="false" 
                            BorderWidth="0px" GridLines="None" ShowHeader="False"   DataKeyNames="maBDS" PageSize="5"
                            OnRowCommand="GridSp_RowCommand" OnPageIndexChanging="GridSp_PageIndexChanging" EnableViewState="true" ShowFooter="false">
                
                                <Columns>                     
                                   <asp:TemplateField>
                                        <ItemTemplate>
                                            <table border="0" cellpadding="0" cellspacing="0" style="width:730px;">
                                                <%--<tr>
                                                    <td colspan="2" style="width:730px; height:20px; background-image:url('../Images/Top.jpg')">
                                                    </td>
                                                </tr>--%>
                                                <tr class='giohang_table_content'>
                                                    <td>
                                                        <div>   
                                                        <table style=' text-align:left;' width='100%' border='0' cellspacing='0' cellpadding='5'>
                                                                <tr>
                                                                   <td rowspan='2'  style="width:70px;text-align:center;height:70px; margin:0px; border:1px solid #999;">
                                                                        <asp:ImageButton ID="Image1" runat="server"
                                                                                     PostBackUrl='<%# "View.aspx?ID="+ Eval("maBDS") %>'
                                                                                    ImageUrl='<%# "~/" + Eval("hinhanh") %>' Width="100%" 
                                                                            Height="70px"
                                                                            />
                                                                    </td>   
                                                                    <td class='giohang_model'>
                                                                        <%--<div id="Tenbaiviet">
                                                                            <ul>
                                                                                <li>--%>
                                                                                    <a id="tenBDS" href='View.aspx?ID=<%# Eval("maBDS")%>' ><span>
                                                                                    <asp:Label ID="lbltensach" runat="server" Text='<%# Eval("tenBDS") %>'></asp:Label></span></a>

                                                                                <%--/li>                                   
                                                                            </ul>
                                                                        </div>      --%>                      
                                                                    </td> 
                                                                                         
                                                                </tr>
                                                                <tr>                                        
                                                                    <td class='info'>                                               
                                                                                 
                                                                                <b>Địa chỉ :</b><asp:Label ID="DiaChi"
                                                                                        runat="server" Text='<%# Eval("DiaChi") %>' ForeColor="#0033CC"></asp:Label>
                                                                                <b>
                                                                                <br />
                                                                                 Giá :</b><asp:Label ID="Gia"
                                                                                        runat="server" Text='<%# Eval("Gia") %>' ForeColor="#0033CC"></asp:Label>
                                                                                <%--<br />
                                                        
                                                                                 &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" PostBackUrl='<%# "View.aspx?ID="+ Eval("maBDS") %>'
                                                                                     ImageUrl="~/Images/Edit.gif" CommandArgument='<%# Eval("maBDS")%>' 
                                                                                     CommandName="Sua" ToolTip="Sửa Sách" /><strong> Sửa </strong>
                                                                                 &nbsp;
                                                       
                                                                                 <asp:ImageButton ID="ImageButton2" runat="server" OnClientClick="Confirm()"
                                                                                     ImageUrl="~/Images/Delete.gif"                                                            
                                                                                     CommandArgument='<%# Eval("maBDS")%>' CommandName="Xoa" />                                                                                                  
                                                                                &nbsp;<b>Xóa</b></td>--%>
                                                                </tr>
                                                           </table>
                                                        </div>
                                                    </td>
                                                    <td style="width:50%;text-align:right" class="btnrs">
                                                        <asp:ImageButton ID="ImageButton3" runat="server" PostBackUrl='<%# "View.aspx?ID="+ Eval("maBDS") %>'
                                                                                     ImageUrl="~/Images/Edit.gif" CommandArgument='<%# Eval("maBDS")%>' 
                                                                                     CommandName="Sua" ToolTip="Sửa BĐS"  Width="50px"/><%--<strong> Sửa </strong>--%>
                                                         <asp:ImageButton ID="ImageButton4" runat="server" OnClientClick="Confirm()"
                                                                                     ImageUrl="~/Images/Delete.gif"                                                            
                                                                                     CommandArgument='<%# Eval("maBDS")%>' CommandName="Xoa"  ToolTip="Xóa BĐS" Width="50px"/><%--<b>Xóa</b>--%>
                                                       <%-- <a href=""class='btnrs' >Xoá</a>
                                                        <a href=""class='btnrs' >Suwa</a>--%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                               <%-- <PagerSettings
                                Mode="Numeric" Position="TopAndBottom" PageButtonCount="10"/>
                                <PagerStyle BackColor="Lavender" ForeColor="Blue" Font-Size="Larger" Height="50px" />--%>
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <RowStyle ForeColor="#000066" CssClass="Rowstyle" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#00547E" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>
                                <SortedAscendingHeaderStyle BackColor="#007DBB"></SortedAscendingHeaderStyle>
                                <SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>
                                <SortedDescendingHeaderStyle BackColor="#00547E"></SortedDescendingHeaderStyle>
                            </asp:GridView>
                        </div>     
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <table>
                            <tr>
                                <td style="width: 100%;">
                                    <div style="overflow: inherit;">
                                        <asp:Repeater ID="rptPaging" runat="server" OnItemCommand="rptPaging_ItemCommand">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnPage" Style="font-size: 8pt;
                                                        display: block;
                                                        float: left;
                                                        border: solid 1px #AAE;
                                                        padding: 0.3em 0.5em;
                                                        margin-left: 5px;" CommandName="Page"
                                                    CommandArgument='<%#Eval("stt")%>' runat="server" ForeColor="black"
                                                    Height="20px"><%#Eval("stt") %></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
      </div>
    </div>
</div>

</asp:Content>

