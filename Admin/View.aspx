<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="View.aspx.cs" Inherits="Admin_View" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <%--<script type="text/javascript">
    function An_hien_tbao() {
            //lb_thongbao_luu.SetValue("Đã lưu thông tin!!!");
        lblthongbao.SetVisible(true);
            setTimeout(function () {
                lblthongbao.SetText("");
            }, 4000);
    }
    </script>--%>
    <asp:FormView ID="Viewedit" runat="server" onitemcommand="Viewedit_ItemCommand">
    <ItemTemplate>
        <table border='0' cellpadding='3' cellspacing='3' >
        <tr>
            <td colspan='4'><span class='TitleList new' >Cập nhật bất động sản</span>
            </td>
        </tr>
        
        <tr>
            <td style='padding-left: 20px; width: 150px'>Tên BĐS:<span class='markStar'>*</span></td>
            <td colspan="3">
                <span id='sprytextfield5'>
                    <asp:TextBox ID="txtTenBDS" runat="server" TextMode="MultiLine" Columns="100" Rows="5" Text='<%# Eval("tenBDS") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenBDS" 
                        ErrorMessage="Tên BĐS không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator><%--</span>--%>
                </span>
            </td>           
        </tr>
        
        <tr>
            <td style='padding-left: 20px; width: 150px'>Địa chỉ:<span class='markStar'>*</span></td>
            <td  colspan="3">
                <span id='sprytextfield2'>                   
                        <asp:TextBox ID="txtDiachi" runat="server" TextMode="MultiLine" Columns="100" Rows="5" Text='<%# Eval("DiaChi") %>'></asp:TextBox>                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiachi" 
                        ErrorMessage="Địa chỉ không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                </span>
            </td>           
        </tr>
        <tr>
            <td style='padding-left: 20px; width: 150px'>Giá:<span class='markStar'>*</span></td>
            <td style='width: 300px'>
                <span id='sprytextfield4'>
                        <asp:TextBox ID="txtGia" runat="server" Width="100%" Text='<%# Eval("Gia") %>'></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtGia" 
                        ErrorMessage="Giá không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>                       
                </span>
            </td>
            <td  colspan="2">
            </td>
        </tr>
        
        <tr>
            <td style='padding-left: 20px; width: 150px'>Khu vực:<span class='markStar'>*</span></td>
            <td style='width: 300px'>
                <span id='Span1'>
                        <asp:DropDownList ID="drlKhuvuc" runat="server" Width="100%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drlKhuvuc" 
                        ErrorMessage="Khu vực không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>                      
                </span>
            </td>
            <td style='text-align:right; width: 150px'>Loại BĐS<span class='markStar'>*</span></td>
            <td style='width: 300px'>
                <span id='Span2'>
                        <asp:DropDownList ID="drlLoaiBDS" runat="server" Width="100%"></asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="drlLoaiBDS" 
                        ErrorMessage="Loại BDS không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                        
                </span>
            </td>            
        </tr>
         <tr>
            <td style='padding-left: 20px; width: 150px'>Tin nổi bật:</td>
            <td>
                <asp:CheckBox ID="chkNoiBat" runat="server" Checked="false" />
            </td>
            <td style='text-align:right; width: 150px'>Đã bán</td>
            <td>
                <asp:CheckBox ID="chkDaBan" runat="server" Checked="false" />
            </td>
        </tr>
        <tr>
            <td colspan="4"> </td>            
        </tr>
        <tr>
            <td style='padding-left: 20px; width: 150px'>
                Nội dung:</td>
            <td  colspan="3"></td>            
        </tr>
        <tr>
            <td colspan="4" style="width:100%">               
                <FCKeditorV2:FCKeditor ID="fckNoidung" runat="server" BasePath="../fckeditor/"  Height="400px" Value='<%# Eval("NoiDung") %>'></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td  style='padding-left: 20px; width: 250px' ><strong>Ảnh đại diện:</strong></td>     
            <td style='width: 300px'>
                <asp:FileUpload ID="txtanhdaidien" runat="server" BorderColor="#FF99FF"
                    BorderStyle="Solid"  />
            </td>
            <td colspan="2"> 
                
                <asp:Label ID="lblanhdaidien" runat="server" Text='<%# Eval("hinhanh") %>' Visible="false"></asp:Label>
                <asp:GridView ID="gv_anhdaidien" runat="server" AutoGenerateColumns="False" 
                    Width="100%" ShowHeader="False" BorderStyle="None"
                    GridLines="None">
                    <AlternatingRowStyle BorderStyle="None" />
                    <Columns>
                        <%--<asp:CommandField DeleteText="xóa" ShowDeleteButton="True" >                        
                            <ItemStyle Width="10%" />
                        </asp:CommandField>
                        <asp:BoundField DataField="hinhanh" >
                       
                        </asp:BoundField>--%>
                        <asp:TemplateField>
                        <ItemTemplate>
                            
                           <table>
                                <tr>
                                    <td style="width:70px;text-align:center;height:70px; margin:0px; border:1px solid #999;">
                                        <asp:Image ID="Image1" runat="server" Width="100px" 
                                        ImageUrl='<%# "~/"+Eval("hinhanh") %>'/>
                                        
                                    </td>
                                </tr>
                            </table>
                            </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BorderStyle="None" />
                </asp:GridView>
            </td>
            <%--<td colspan="2"></td>--%>
        </tr>
        <tr>
            <td  style='padding-left: 20px; width: 250px' ><strong>Ảnh chi tiết:</strong></td> 
            <td style='width: 300px'>
                <asp:FileUpload ID="txtanhct" runat="server" BorderColor="#FF99FF" AllowMultiple="true"
                    BorderStyle="Solid"/>
            </td>
            <td colspan="2">
                 <asp:GridView ID="gv_tenfile" runat="server" AutoGenerateColumns="False" 
                    Width="100%" ShowHeader="False" BorderStyle="None" onrowdeleting="gv_tenfile_RowDeleting" 
                    GridLines="None">
                    <AlternatingRowStyle BorderStyle="None" />
                    <Columns>
                        <%--<asp:CommandField DeleteText="xóa" ShowDeleteButton="True" >                        
                            <ItemStyle Width="10%" />
                        </asp:CommandField>--%>
                        <%--<asp:BoundField DataField="hinhanh" >
                       
                        </asp:BoundField>--%>
                        <asp:TemplateField>
                        <ItemTemplate>
                            <table>
                                <tr>
                                    <td style="width:70px;text-align:center;height:70px; margin:0px; border:1px solid #999;">
                                        <asp:Image ID="Image1" runat="server" Width="100px" 
                                        ImageUrl='<%# "~/"+Eval("anhct") %>'/>
                                        <asp:Label ID="lblanhct" runat="server" Text='<%# Eval("anhct") %>' Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                            </ItemTemplate>
                    </asp:TemplateField>
                    </Columns>
                    <EditRowStyle BorderStyle="None" />
                </asp:GridView>
            </td>
        </tr>
         <%--<tr>
            <td  style='padding-left: 20px; width: 150px' ><strong>Ảnh cũ :</strong></td>     
            <td>
                <asp:Image ID="Image2" runat="server" Width="100px" 
                    ImageUrl='<%# "~/"+Eval("hinhanh") %>' />
                Tên Ảnh :<asp:Label ID="lblanh" runat="server" Text='<%# Eval("hinhanh") %>'></asp:Label>
            </td>
            <td colspan="2"></td>
        </tr>--%>
        <tr>
            <td colspan="4"></td>
        </tr>
        
        <tr>
            <%--<td style='width: 139px'>
            </td>--%>
            <td style='width: 358px; text-align: center; height: 32px;' colspan="4">
                <asp:Button ID="btnadd" runat="server"  BackColor="#E4B63F" 
                   BorderStyle="None" ForeColor="#3333FF" Width="100px" Height="30px" Text="Cập Nhật" CommandArgument='<%# Eval("maBDS")%>' 
                   CommandName="Capnhat" />
               &nbsp;
               <%-- <asp:Button ID="btnclear" runat="server" BackColor="#E4B63F" BorderStyle="None" 
                   ForeColor="#3333FF" Text="Xóa BĐS này"
                   CausesValidation="False" CommandArgument='<%# Eval("maBDS")%>' 
                   CommandName="Xoa" />
               &nbsp;&nbsp;
               <asp:Button ID="btncancel" runat="server" BackColor="#E4B63F" 
                   BorderStyle="None" ForeColor="#3333FF" Text="Home"                   
                   CausesValidation="False" CommandName="Quaylai" 
                   PostBackUrl="~/Book/Home.aspx" />--%>
            </td>
        </tr>
            <tr>
            <td colspan="4" style="text-align:center">
               <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                   ShowMessageBox="True" />--%>
                <asp:Label ID="lblthongbao" runat="server" Text="" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
    </table>
    </ItemTemplate>
</asp:FormView>
<div class="thongbao">
    <asp:Label ID="lblthongbao" runat="server" Text="" ForeColor="Blue"></asp:Label>
</div>
</asp:Content>

