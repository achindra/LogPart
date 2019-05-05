using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;  //<< Switch off for Local Testing
//using LogPart.ClassificationService; //<< Switch on for Local Testing
using LogPart.ServiceReference1;

namespace LogPart
{
    public partial class Training: System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ServiceClient Client = new ServiceClient();                        
                DropDownClusterList2.Items.Clear();
                DropDownClusterList2.Items.Add("");
                DropDownClusterList2.Items.Add("New Type...");
                foreach (string Item in Client.GetClusterList())
                {
                    DropDownClusterList2.Items.Add(Item);
                }
            }
        }

        
        protected async void btnTrain_Click(object sender, EventArgs e)
        {
            try
            {
                if (!Directory.Exists(txtDirPath.Text))
                {
                    lblStatusTrain.Text = "Status: Invalid Directory Path!";
                    return;
                }
            }
            catch (Exception ex)
            {
                lblStatusTrain.Text = "Status: " + ex.Message; 
                return;
            }

            if (DropDownClusterList2.SelectedItem.Text == "New Type...")
            {
                if (txtFileType.Text.Trim() != "")
                {
                    bool inList = false;
                    foreach (ListItem Item in DropDownClusterList2.Items)
                    {
                        if (Item.Text == txtFileType.Text.Trim())
                        {
                            inList = true;
                            lblStatusTrain.Text = "Status: File Type already in database.";
                            break;
                        }
                    }

                    if (!inList)
                    {
                        ServiceClient Client = new ServiceClient();
                        Client.AddCluster(txtFileType.Text.Trim(), "");
                        lblStatusTrain.Text = "Status: Mining Data...";
                        string Cluster = await Client.TrainSystemAsync(txtDirPath.Text, txtFileType.Text.Trim(), System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString());
                        lblStatusTrain.Text = "Status: Added to System - " + Cluster;
                    }
                }
                else
                {
                    lblStatusTrain.Text = "Status: Please provide the file type to add to.";
                }
            }
            else
            {
                if (txtDirPath.Text.Trim() != "")
                {
                    ServiceClient Client = new ServiceClient();
                    lblStatusTrain.Text = "Status: Mining Data...";
                    string Cluster =  await Client.TrainSystemAsync(txtDirPath.Text, DropDownClusterList2.SelectedItem.Text, System.Security.Principal.WindowsIdentity.GetCurrent().Name.ToString());
                    lblStatusTrain.Text = "Status: Added to System - " + Cluster;
                    txtFileType.Visible = false;
                }
                else
                {

                }
            }
        }

        protected void DropDownClusterList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownClusterList2.SelectedItem.Text == "New Type...")
            {
                txtFileType.Visible = true;
            }
            else
            {
                txtFileType.Visible = false;
            }
        }

    }
}