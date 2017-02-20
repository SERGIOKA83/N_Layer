 <%@ Page Title="" Language="C#" MasterPageFile="~/Retro_Theater.Master" AutoEventWireup="true" CodeBehind="MyFirstPage.aspx.cs" Inherits="MyWeb.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!-- -->
    <asp:ObjectDataSource ID="List_Coments" runat="server" SelectMethod="ReadAll" TypeName="BLL.ComentsBLL">
    </asp:ObjectDataSource>
    
    <div id="intro">
		<div id="pageHeader">
			<h1><span></span></h1>
            <h2><span></span></h2>
			
		</div>
         
            <div id="quickSummary">
         
         
        
         <p class="p1"><span>Average rating: <%: BLL.AvRating.AverageRating()%> </span></p>
         
			
		</div>
        

    <asp:Repeater ID="rptComents" runat="server" DataSourceID="List_Coments" 
            onitemcommand="rptComents_ItemCommand">

        <HeaderTemplate> 
         
		<div id="preamble">
                      <% BLL.Mov _mov = new BLL.Mov();%>
            <h3><span><%: _mov.ReadBLL(1).Title %></span></h3>
            <asp:Image ID="ImgBinary" runat="server" ImageUrl = "~/PictureH.ashx"  />
            <p><span><%: _mov.ReadBLL(1).Description %> </span></p>
			<h4><span>Comments about this movie:</span></h4>
            
        </HeaderTemplate> 
        
        <ItemTemplate>
			<p class="p1"><span><%# Eval("Coment")%></span></p>
            <p class="p2"><span>----------------------------------------------------------------------</span></p>
        </ItemTemplate> 

        <FooterTemplate>
			
			<p class="p3"><span></span></p>
		</div>

        </FooterTemplate>
          
        </asp:Repeater>

	<div id="supportingText">
		<div id="explanation">
			<h3><span>Enter your comment:</span></h3>
           

			<p class="p1"><span>

	    <asp:TextBox ID="tbxComment" runat="server" BackColor="#CCCCCC" Height="113px" 
                    Width="492px" TextMode="MultiLine" Wrap="True" AutoCompleteType="None" AutoPostBack="False"></asp:TextBox>

	            </span>
		    </p>
			<p class="p2">
        

                <asp:DropDownList ID="ddlRating" runat="server">
                    <asp:ListItem Selected="True">0</asp:ListItem>
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                    <asp:ListItem>9</asp:ListItem>
                    <asp:ListItem>10</asp:ListItem>
                </asp:DropDownList>
        

        <asp:Button ID="btn" runat="server" Text="Send" onclick="btn_Click" />
		    </p>
		</div>
        

	</div>

	
	</asp:Content>
