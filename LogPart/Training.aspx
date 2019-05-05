<%@ Page Title="Training" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Training.aspx.cs" Inherits="LogPart.Training" Async="true" AsyncTimeout="10000" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 117px;
        }
        .auto-style4 {
            width: 612px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>!</h1>
                <h2>Sample Training</h2>
            </hgroup>
            <p>
                Our system can learn form your logs. </p>
        </div>
    </section>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
        <asp:UpdatePanel ID="UpdatePanelTraining" runat="server">
        <ContentTemplate>
            <p>
                <ol class="round">
                <li class="one">
        <strong>Training with Samples</strong>
                    <br />If you have a new family of logs to train us. Put them up in a directory and give to this system. The sample will be analyzed and metadata will be recorded. You can add to existing sample class or create a new class before sample training.
                    <table style="width:100%;">
                        <tr>
                            <td class="auto-style2">Network Share</td>
                            <td class="auto-style4">
                                <asp:TextBox ID="txtDirPath" runat="server" BorderStyle="Groove" Font-Size="Smaller" Width="600px" ToolTip="Network share that contains same class of logs"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">File Type</td>
                            <td class="auto-style4">
                                <asp:DropDownList ID="DropDownClusterList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownClusterList2_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtFileType" runat="server" Font-Size="Smaller" Visible="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style4">
                                <asp:Button ID="btnTrain" runat="server" Font-Size="Smaller" OnClick="btnTrain_Click" Text="Train" />
                                <br />
                                <asp:Label ID="lblStatusTrain" runat="server" Text="Status"></asp:Label>
                            </td>                           
                        </tr>
                    </table>
                    </strong>
                    </li>
                    </ol>
                <p>
                </p>
            </p>
        </ContentTemplate>
    </asp:UpdatePanel>   

    
</asp:Content>
