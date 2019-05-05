<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LogPart.About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Log Classification.</h2>
    </hgroup>

    <article>
        <p>        
            For systems dealing with text data, Classification is one of the core problems. Automated Diagnostics is one of the System where we primarily deal with plain text logs. For most products including Windows Operating Systems, component debug logs are generated in plain text. Plain text, as such, do not have any structure. Though they may have a lot of information but the lack of structure makes it very difficult to mine information out using an unassisted automated system.
        </p>

        <p>        
            There is however a very specific pattern in text data log files. They are comprised of momentory information, error codes and details about them. Each statement in the log is usually linked with the predecessor. There are differentiators and context information embedded. Each product also has its own pattern of generating logs and in their own formatting.
        </p>
        <p>        
            We look for these specific formatting patterns and transform the log using the minimum known set of features. All context specific data is replaced by known feature abbreviations. This normalized content is then reduced by picking all unique patterns. All duplicates are removed and frequency is saved. A hash of this information is saved in database.
        </p>
        <p>        
            When a log is provided for classification the same information hash is built and compared against the information hash saved in database. A match points to a known pattern we have seen for the class of product logs in our samples.</p>

        <p>        
            NOTE: Here we are trying to build a classification system for plain text files. The idea applies to product/component generated debug logs and may not work well with other text data.
        </p>
        <p>        
            <strong>Automated learning is a three step process:</strong><br />&nbsp; 1. Logs are transformed using a fixed and small set of features,
                <br />&nbsp; 2. Result is reduced by frequency of commonly seen patterns.<br />&nbsp; 3. Ranked using hashes built from patterns</p>
        <p>        
            &nbsp;</p>
    </article>

    <aside>
        <h3>Aside Title</h3>
        <p>        
            Common Links</p>
        <ul>
            <li><a runat="server" href="~/">Home</a></li>
            <li><a runat="server" href="~/Discovery.aspx">Discover</a></li>
            <li><a runat="server" href="~/Training.aspx">Training</a></li>
            <li><a runat="server" href="~/About.aspx">About</a></li>
            <li><a runat="server" href="~/Contact.aspx">Contact</a></li>
        </ul>
    </aside>
</asp:Content>