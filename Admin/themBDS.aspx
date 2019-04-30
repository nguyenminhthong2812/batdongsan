<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/admin.master" AutoEventWireup="true" CodeFile="themBDS.aspx.cs" Inherits="Admin_themBDS" %>

<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    
        <table border='0' cellpadding='3' cellspacing='3' >
        <tr>
            <td colspan='4'><span class='TitleList new' >Thêm mới bất động sản</span>
            </td>
        </tr>
        
        <tr>
            <td style='padding-left: 20px; width: 150px'>Tên BĐS:<span class='markStar'>*</span></td>
            <td colspan="3">
                <span id='sprytextfield5'>
                    <asp:TextBox ID="txtTenBDS" runat="server" TextMode="MultiLine" Columns="100" Rows="5"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTenBDS" 
                        ErrorMessage="Tên BĐS không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                </span>
            </td>           
        </tr>
        
        <tr>
            <td style='padding-left: 20px; width: 150px'>Địa chỉ:<span class='markStar'>*</span></td>
            <td  colspan="3">
                <span id='sprytextfield2'>                   
                        <asp:TextBox ID="txtDiachi" runat="server" TextMode="MultiLine" Columns="100" Rows="5"></asp:TextBox>                       
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDiachi" 
                        ErrorMessage="Địa chỉ không được rỗng" Font-Italic="true" ForeColor="Red" Font-Size="Small"></asp:RequiredFieldValidator>
                </span>
            </td>           
        </tr>
        <tr>
            <td style='padding-left: 20px; width: 150px'>Giá:<span class='markStar'>*</span></td>
            <td style='width: 300px'>
                <span id='sprytextfield4'>
                        <asp:TextBox ID="txtGia" runat="server" Width="100%"></asp:TextBox>
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
                <FCKeditorV2:FCKeditor ID="fckNoidung" runat="server" BasePath="../fckeditor/"  Height="400px"></FCKeditorV2:FCKeditor>
            </td>
        </tr>
        <tr>
            <td  style='padding-left: 20px; width: 150px' ><strong>Ảnh đại diện:</strong></td>     
            <td style='width: 300px' colspan="3">
                <asp:FileUpload ID="txtanhdaidien" runat="server" BorderColor="#FF99FF"
                    BorderStyle="Solid"/>
            </td>
            <%--<td colspan="2"></td>--%>
        </tr>
        <tr>
            <td  style='padding-left: 20px; width: 150px' ><strong>Ảnh chi tiết:</strong></td> 
            <td style='width: 300px' colspan="3">
                <asp:FileUpload ID="txtanhct" runat="server" BorderColor="#FF99FF" AllowMultiple="true"
                    BorderStyle="Solid"/>
            </td>
        </tr>
        <tr>
            <td colspan="4"> </td>            
        </tr>
        <tr>
            <td colspan="4" style="text-align:center">
               <%-- <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                   ShowMessageBox="True" />--%>
                <asp:Label ID="lblthongbao" runat="server" Text="" ForeColor="Blue"></asp:Label>
            </td>
        </tr>
        <tr>
            <%--<td style='width: 139px'>
            </td>--%>
            <td style='width: 358px; text-align: center; height: 50px;' colspan="4">
                <asp:Button ID="btnluu" runat="server" Text="Lưu lại" OnClick="btnluu_Click" BackColor="#E4B63F" 
                   BorderStyle="None" ForeColor="#3333FF" Width="100px" Height="30px"/>
                <asp:Button ID="btnlamlai" runat="server" Text="Làm lại" OnClick="btnlamlai_Click" CausesValidation="False" BackColor="#E4B63F" 
                   BorderStyle="None" ForeColor="#3333FF" Width="100px" Height="30px"/>
                <%--<input type='submit' name='btnsave' id='btnsave' value='Lưu'>
                <input type='reset' name='btnreset' id='btnreset' value='Làm lại'>
                <input type="hidden" name="Action" value="themsanpham" >--%>
            </td>
        </tr>
    </table>
    
    
</asp:Content>

