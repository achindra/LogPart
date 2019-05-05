<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LogPart.Contact" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        <h1><%: Title %>.</h1>
        <h2>Achindra Bhatnagar.</h2>
    </hgroup>

    <section class="contact">
        <header>
            <h3>Phone:</h3>
        </header>
        <p>
            <span class="label">Mobile:</span>
            (+91) 97317 22511
        </p>
        <p>
            <span class="label">Office Ext:</span>
            <span>87333</span>
        </p>
    </section>

    <section class="contact">
        <header>
            <h3>Email:</h3>
        </header>
        <p>
            &nbsp;<span><a href="mailto:General@example.com">achindra.bhatnagar@microsoft.com</a></span>
        </p>
    </section>

    </asp:Content>