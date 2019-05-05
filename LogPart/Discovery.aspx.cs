using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
//using LogPart.ClassificationService;
using LogPart.ServiceReference1;


namespace LogPart
{
    public partial class Discovery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServiceClient Client = new ServiceClient();
                DropDownClusterList.Items.Clear(); 
                DropDownClusterList.Items.Add("");
                DropDownClusterList.Items.Add("New Type..."); 
                foreach (string Item in Client.GetClusterList())
                {
                    DropDownClusterList.Items.Add(Item); 
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            lnkBtnAdvance.Enabled = true;
            lnkBtnAdvance.Text = ">>";
            try
            {
                if (!File.Exists(txtFilePath.Text))
                {
                    lblInformation.Text = "Status: Invalid File Path!";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblInformation.Text = "Status: " + ex.Message;
                return;
            }

            Regex Expression = new Regex(@"^\\\\*");
            string FilePath = txtFilePath.Text;

            if (Expression.Match(FilePath).Success)
            {
                if (File.Exists(FilePath))
                {
                    lblInformation.Text = "SUCCESS: Finding Pattern...";
                    ServiceClient Client = new ServiceClient();
                    InnerData UserInnerData = new InnerData();

                    string Status = Client.DiscoverSchema(FilePath, System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString(), ref UserInnerData);

                    if (Status == "Not Found!")
                    {
                        DropDownClusterList.Items.Clear();
                        DropDownClusterList.Items.Add("");
                        DropDownClusterList.Items.Add("New Type...");
                        foreach (string Item in Client.GetClusterList())
                        {
                            DropDownClusterList.Items.Add(Item);
                        }
                        PanelFeeding.Visible = true;
                        txtFileToTrain.Text = txtFilePath.Text;
                    }
                    
                    txtTranslationSummary.Text = UserInnerData.TranslationSummary;
                    txtTranslationHash.Text = UserInnerData.TranslationHash;
                    txtFrequencySummary.Text = UserInnerData.FrequencySummary;
                    txtFrequencyHash.Text = UserInnerData.FrequencyHash;

                    lnkBtnAdvance.Enabled = true;
                    
                    lblInformation.Text = Status;
                }
                else if (Directory.Exists(FilePath))
                {
                    lblInformation.Text = "FAILED: Provide a File Path.";
                }
                else
                {
                    lblInformation.Text = "FAILED: Invalid Path.";
                }
            }
            else
            {
                lblInformation.Text = @"FAILED: Invalid Network Path. \\SERVER\SHARE\File.log";
            }
        }

        protected void DropDownClusterList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownClusterList.SelectedItem.Text == "New Type...")
            {
                txtProductName.Visible = true;
            }
            else
            {
                txtProductName.Visible = false;
            }
        }

        protected void btnFeed_Click(object sender, EventArgs e)
        {
            
            lnkBtnAdvance.Text=">>";
            UpdatePanelInnerData.Visible = false;
            lnkBtnAdvance.Enabled = false;

            try
            {
                if(!File.Exists(txtFileToTrain.Text))
                {
                    lblStatusAdd.Text = "Status: Invalid File Path";
                    return;
                }
            }
            catch(Exception ex)
            {
                lblStatusAdd.Text = "Status: " + ex.Message;
                return;
            }

            if (DropDownClusterList.SelectedItem.Text == "New Type...")
            {
                if (txtProductName.Text.Trim() != "")
                {
                    bool inList = false;
                    foreach (ListItem Item in DropDownClusterList.Items)
                    {
                        if (Item.Text == txtProductName.Text.Trim())
                        {
                            inList = true;
                            lblStatusAdd.Text = "Status: File Type already in database.";
                            break;
                        }
                    }

                    if (!inList)
                    {
                        ServiceClient Client = new ServiceClient();
                        Client.AddCluster(txtProductName.Text.Trim(), "");
                        Client.TrainSystem(txtFilePath.Text, txtProductName.Text.Trim(), System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString());
                        lblStatusAdd.Text = "Status: Added to System";
                    }
                }
                else
                {
                    lblStatusAdd.Text = "Status: Please provide the file type to add to.";
                }
            }
            else
            {
                if(txtFileToTrain.Text.Trim() != null)
                {
                    ServiceClient Client = new ServiceClient();
                    Client.TrainSystem(txtFileToTrain.Text, DropDownClusterList.SelectedItem.Text, System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString());
                    lblStatusAdd.Text = "Status: Added to System";
                    txtProductName.Visible = false;
                }
                else
                {
                    lblStatusAdd.Text = "Status: Please provide the file type to add to.";
                }
            }
        }

        protected void lnkBtnAdvance_Click(object sender, EventArgs e)
        {
            if (lnkBtnAdvance.Text == ">>")
            {
                lnkBtnAdvance.Text = "<<";
                UpdatePanelInnerData.Visible = true;
            }
            else
            {
                lnkBtnAdvance.Text = ">>";
                UpdatePanelInnerData.Visible = false;
            }
        }

        


    }
}