<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LogPart._Default" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %>.</h1>
                <h2>Automated Learning System for Log Classification.</h2>
            </hgroup>
            <p>
                &nbsp;You can train this system by providing a set of logs and it will learn about specific patterns on its own. </p>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h3>We suggest the following:</h3>
    <ol class="round">
        <li class="one">
            <h5><a href="Discovery.aspx">Feed your Log</a></h5>
            Upload your log to our system and we will find the log family. </li>
        <li class="two">
            <h5>Improve the System</h5>
            If you have a log that the system does not understand. Feed us for sampling.</li>
        <li class="three">
            <h5><a href="Training.aspx">Give Food for Learning</a></h5>
            If you have a new family of logs to train us. Put them up in a directory and give to this system. The sample will be analyzed and metadata will be recorded.
        </li>
    </ol>
</asp:Content>
