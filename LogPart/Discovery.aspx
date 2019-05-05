<%@ Page Title="Discover" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Discovery.aspx.cs" Inherits="LogPart.Discovery" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 117px;
        }
        .auto-style2 {
            width: 117px;
        }
        .auto-style4 {
            width: 612px;
        }
        .auto-style5 {
            width: 620px;
        }
        .auto-style6 {
            width: 117px;
            height: 42px;
        }
        .auto-style7 {
            width: 620px;
            height: 42px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>!</h1>
                <h2>Find Log Class</h2>
            </hgroup>
            <p>
                Our system can help you find the class of log by looking at its content.</p>
        </div>
    </section>
    </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:UpdatePanel ID="UpdatePanelLoad" runat="server">
        <ContentTemplate>
            <p>
              <ol class="round">
                <li class="one">
                    <strong>Discover File Schema</strong><br />Provide a file on network share. Share must be accessible to &quot;Everyone&quot;. The file will be copied from network share to WebServer for processing. Discovered schema will be reported back.
                    <p>
                        <table style="width:100%;">
                            <tr>
                                <td class="auto-style1">Network File Path:</td>
                                <td class="auto-style4">
                                    <asp:TextBox ID="txtFilePath" runat="server" BorderStyle="Groove" BorderWidth="1px" Font-Names="Courier New" Font-Size="Smaller" Width="600px" ToolTip="Path to file on Network share to be search for."></asp:TextBox>
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:Button ID="btnUpload" runat="server" BorderStyle="Inset" Font-Size="Smaller" OnClick="btnUpload_Click" Text="Upload" />
                                </td>
                                
                            </tr>
                            <tr>
                                <td class="auto-style1">&nbsp;</td>
                                <td class="auto-style4">
                                    <asp:Label ID="lblInformation" runat="server" Text="Status:"></asp:Label>
                                    <br />If the file recognition is not right, please <a href="mailto:achinbha@microsoft.com?subject=LSR:Error">report</a>.&nbsp;&nbsp;
                                    <asp:LinkButton ID="lnkBtnAdvance" runat="server" Enabled="False" OnClick="lnkBtnAdvance_Click">&gt;&gt;</asp:LinkButton>
                                </td>                                
                            </tr>
                        </table>
                        <asp:UpdatePanel ID="UpdatePanelInnerData" runat="server" Visible="false">
                            <ContentTemplate>
                            <table>
                            <tr>
                                <td>
                                    <asp:TextBox ID="txtTranslationHash" runat="server" BorderStyle="Groove" Width="500px" Font-Names="Courier New" Font-Size="Smaller" ReadOnly="True"></asp:TextBox><br />
                                    <asp:TextBox ID="txtTranslationSummary" runat="server" TextMode="MultiLine" BorderStyle="Ridge" Height="379px" Width="500px" Font-Names="Courier New" Font-Size="Smaller" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFrequencyHash" runat="server" BorderStyle="Groove" Width="500px" Font-Names="Courier New" Font-Size="Smaller" ReadOnly="True"></asp:TextBox><br />
                                    <asp:TextBox ID="txtFrequencySummary" runat="server" TextMode="MultiLine" BorderStyle="Ridge" Height="379px" Width="500px" Font-Names="Courier New" Font-Size="Smaller" ReadOnly="True"></asp:TextBox>
                                </td>                                                                    
                            </tr>
                            </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        <p>
                        </p>
                    </p>
                    </li>
                  </ol>
                    <p>
                </p>
                    <p>
                </p>
                    </p> 
            
        </ContentTemplate>
    </asp:UpdatePanel>
    
    <hr />    

    <asp:UpdatePanel ID="UpdatePanelFeeding" runat="server">
        <ContentTemplate>
            <asp:Panel ID="PanelFeeding" runat="server" Visible="False">
            <p>
                <ol class="round">
                    <li class="two">
                    <strong>Improve the System</strong><br />If the log file is not recognized by the system, tell us what the log file is. Either pick from the known types or add a new class.

                    <table style="width: 100%;">
                        <tr>
                            <td class="auto-style2">Choose File Type</td>
                            <td class="auto-style5">&nbsp;
                                <asp:TextBox ID="txtFileToTrain" runat="server" Font-Size="Smaller" Width="600px" ToolTip="Path to file  on Network share to be used as a sample for training."></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Choose File Type</td>
                            <td class="auto-style7">
                                <asp:DropDownList ID="DropDownClusterList" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownClusterList_SelectedIndexChanged">
                                </asp:DropDownList>
                                <asp:TextBox ID="txtProductName" runat="server" Font-Size="Smaller" Visible="False" Width="117px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Feed the Sample</td>
                            <td class="auto-style5">
                                <asp:Button ID="btnFeed" runat="server" Font-Size="Smaller" OnClick="btnFeed_Click" Text="Feed" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style5">
                                <asp:Label ID="lblStatusAdd" runat="server" Text="Status:"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    
                    </li>
                    </ol>
                <p>
                </p>
                </p>
                </asp:Panel> 
        </ContentTemplate>
    </asp:UpdatePanel>

    
</asp:Content>
