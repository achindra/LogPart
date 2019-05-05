using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.IO;
using System.Text.RegularExpressions;
using System.Web.Hosting;
using System.Threading;
using System.Threading.Tasks;


//
// Log Schema Recovery
//
namespace LSRService
{
    
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Classification : Service
    {

        string DBPATH = HostingEnvironment.MapPath(@"~/App_Data/SamplesDB.sdf");
        string FilePath = HostingEnvironment.MapPath(@"~/App_Data/Temp/"+ System.Web.HttpContext.Current.Session.SessionID.ToString() + @".log");
        int MAXLINE = 100;


        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }


#region ClusterDB

        public string[] GetClusterList()
        {
            List<string> ClusterList = new List<string>();
            
            SqlCeDataReader DBReader = null;

            SqlCeConnection DBConnection = new SqlCeConnection("Data Source=" + DBPATH);

            SqlCeCommand DBCommand = new SqlCeCommand(@"SELECT * FROM CLUSTER", DBConnection);

            try
            {
                DBConnection.Open();
                DBReader = DBCommand.ExecuteReader();

                while (DBReader.Read())
                {
                    ClusterList.Add(DBReader[0].ToString());
                }
            }
            finally
            {
                DBReader.Close();
                DBConnection.Close();
            }
            return ClusterList.ToArray();
        }

        public int AddCluster(string Name, string Description)
        {
            int Status = 0;
            SqlCeConnection DBConnection = new SqlCeConnection("Data Source=" + DBPATH);


            SqlCeCommand DBCommand = new SqlCeCommand(@"INSERT INTO Cluster (Name, Description) VALUES ('" + Name + "', '" + Description + "')", DBConnection);
            try
            {
                DBConnection.Open();
                Status = DBCommand.ExecuteNonQuery();
            }
            finally
            {
                DBConnection.Close();
            }

            return Status;
        }

#endregion ClusterDB

        public string DiscoverSchema(string FileName, string user, ref InnerData UserInnerData)
        {
            //FileInfo FileInfo = new FileInfo(DirName);
            //string FiletoCheck = FilePath + @"/" + FileInfo.Name;
            File.Copy(FileName, FilePath, true);
            string returnValue = findCluster(FileName, "", true, user, FileName, ref UserInnerData);//Thread.CurrentPrincipal.Identity.Name);
            File.Delete(FilePath);
            return returnValue;
        }


        /*
        public string TrainSystem(string DirName, string Cluster, string user)
        {
            InnerData UserInnerData = new InnerData();
            try
            {
                if (File.Exists(DirName))
                {
                    File.Copy(DirName, FilePath, true);
                    findCluster(FilePath, Cluster, false, user, DirName, ref UserInnerData);
                    File.Delete(FilePath);

                    return Cluster;
                }

                if (Directory.Exists(DirName))
                {
                    DirectoryInfo Di = new DirectoryInfo(DirName);
                    foreach (FileInfo fi in Di.GetFiles())
                    {
                        File.Copy(fi.FullName, FilePath, true);
                        findCluster(FilePath, Cluster, false, user, fi.FullName, ref UserInnerData);
                        File.Delete(FilePath);
                    }

                    foreach (DirectoryInfo Dir in Di.GetDirectories())
                    {
                        TrainSystem(Dir.FullName, Cluster, user);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

            return Cluster;

        }
         */

        public async Task<string> TrainSystem(string DirName, string Cluster, string user)
        {
            InnerData UserInnerData = new InnerData();
            try
            {
                if (File.Exists(DirName))
                {
                    File.Copy(DirName, FilePath, true);
                    findCluster(FilePath, Cluster, false, user, DirName, ref UserInnerData);
                    File.Delete(FilePath);

                    return Cluster;
                }

                if (Directory.Exists(DirName))
                {
                    DirectoryInfo Di = new DirectoryInfo(DirName);
                    foreach (FileInfo fi in Di.GetFiles())
                    {
                        File.Copy(fi.FullName, FilePath, true);
                        findCluster(FilePath, Cluster, false, user, fi.FullName, ref UserInnerData);
                        File.Delete(FilePath);
                    }

                    foreach (DirectoryInfo Dir in Di.GetDirectories())
                    {
                        await TrainSystem(Dir.FullName, Cluster, user);
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
            
            return Cluster;
            
        }


        public string Transform(string TextLine)
        {
            string TransformedLine = "";
            string LastPattern = "";

            foreach (string Token in TextLine.Split(new Char[] { ' ', ',', '\t' }))
            {
                if (Token.Trim() != "")
                {
                    string TokenPattern = ConvertRegEx(Token);

                    if (TokenPattern == Token)
                    {
                        string[] SplitTokenList = Regex.Split(Token, "::");
                        if (SplitTokenList.Length > 1)
                        {
                            foreach (string SplitToken in SplitTokenList)
                            {
                                if (SplitToken.Trim() != "")
                                {
                                    TokenPattern = ConvertRegEx(SplitToken);
                                    if (TokenPattern != "Text")
                                    {
                                        LastPattern = TokenPattern;
                                        TransformedLine = TransformedLine + " " + TokenPattern;
                                    }
                                    else if (LastPattern != "Text")
                                    {
                                        LastPattern = TokenPattern;
                                        TransformedLine = TransformedLine + " " + TokenPattern;
                                    }
                                }                                
                            }
                        }
                        else //if (LastPattern != "Text")
                        {
                            LastPattern = TokenPattern;
                            TransformedLine = TransformedLine + " " + TokenPattern;
                        }
                    }
                    else if (TokenPattern != "Text")
                    {
                        LastPattern = TokenPattern;
                        TransformedLine = TransformedLine + " " + TokenPattern;
                    }
                    else if (LastPattern != "Text")
                    {
                        LastPattern = TokenPattern;
                        TransformedLine = TransformedLine + " " + TokenPattern;
                    }
                }
            }

            return TransformedLine;
        }

#region Private


        private string findCluster(string FileName, string ClusterName, bool IsQuery, string UserName, string OriginalFile, ref InnerData UserInnerData)
        {
            List<DistributionList> DistList = new List<DistributionList>();
            List<string> LineofText = new List<string>(MAXLINE);
            int LinesCount = 0;

            //Open file
            StreamReader Reader = new StreamReader(FileName);

            //Transform
            while (!Reader.EndOfStream && LinesCount <= MAXLINE)
            {
                LinesCount++;
                LineofText.Add(Transform(Reader.ReadLine()));
            }
            Reader.Close();

            //Reduce
            LineofText.Sort();
            LineofText.ForEach(delegate(string LinePattern)
            {
                DistributionList Line = DistList.Find(
                    delegate(DistributionList DL)
                    {
                        return DL.Line == LinePattern;
                    }
                );

                if (Line != null)
                {
                    Line.Frequency++;
                }
                else
                {
                    DistributionList Item = new DistributionList();
                    Item.Line = LinePattern;
                    Item.Frequency = 1;
                    DistList.Add(Item);
                }

            });

            string LineofTextData = string.Join("\n", LineofText.ToArray());
            List<string> DistListString = new List<string>();

            foreach (DistributionList DL in DistList)
            {
                DistListString.Add(DL.Line + ":" + DL.Frequency);
            }

            string DistListData = string.Join("\n", DistListString.ToArray());

            //Calculate Hash
            string Hash = "";

            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                Hash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(LineofTextData))//LineofText.ToString()))
                ).Replace("-", String.Empty);
            }

            string fHash = "";
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                fHash = BitConverter.ToString(
                  md5.ComputeHash(Encoding.UTF8.GetBytes(DistListData))//DistList.ToString()))
                ).Replace("-", String.Empty);
            }


            if (UserInnerData != null)
            {
                UserInnerData.TranslationSummary = LineofTextData;
                UserInnerData.FrequencySummary = DistListData;
                UserInnerData.TranslationHash = Hash;
                UserInnerData.FrequencyHash = fHash;
            }

            //Find Hash
            List<string> ClusterList = new List<string>();

            SqlCeDataReader DBReader = null;
            SqlCeDataReader DBReader2 = null;

            /*
            SqlDataReader DBReader = null;
            SqlDataReader DBReader2 = null;
            */

            //SqlConnection DBConnection = new SqlConnection("Data Source="+DBPATH);
            SqlCeConnection DBConnection = new SqlCeConnection("Data Source=" + DBPATH);

            SqlCeCommand DBCommand = new SqlCeCommand(@"SELECT * FROM FEATURES WHERE fHash = '" + fHash + "'", DBConnection);
            SqlCeCommand DBCommand2 = new SqlCeCommand(@"SELECT * FROM FEATURES WHERE Hash = '" + Hash + "'", DBConnection);
            SqlCeCommand DBCommand3 = new SqlCeCommand(@"INSERT INTO FEATURES (Cluster, Hash, fHash, Stack, FirstFile, Trainer) Values (@ClusterName, @Hash, @fHash, @Stack, @FileName, @User)", DBConnection);
            DBCommand3.Parameters.Add(new SqlCeParameter("ClusterName", ClusterName));
            DBCommand3.Parameters.Add(new SqlCeParameter("Hash", Hash));
            DBCommand3.Parameters.Add(new SqlCeParameter("fHash", fHash));
            DBCommand3.Parameters.Add(new SqlCeParameter("Stack", DistListData));
            DBCommand3.Parameters.Add(new SqlCeParameter("FileName", OriginalFile));
            DBCommand3.Parameters.Add(new SqlCeParameter("User", UserName));
            //SqlCeCommand DBCommand3 = new SqlCeCommand(@"INSERT INTO FEATURES (Cluster, Hash, fHash, Stack, FirstFile, Trainer) Values ('" + ClusterName + "','" + Hash + "','" + fHash + "','" + DistListData + "','" + FileName + "','" + UserName + "')", DBConnection);

            /*
            SqlCommand DBCommand = new SqlCommand(@"SELECT * FROM FEATURES WHERE fHash = '" + fHash + "'", DBConnection);
            SqlCommand DBCommand2 = new SqlCommand(@"SELECT * FROM FEATURES WHERE Hash = '" + Hash + "'", DBConnection);
            SqlCommand DBCommand3 = new SqlCommand(@"INSERT INTO FEATURES (fHash, Cluster, Hash, Stack, FirstFile, Trainer) Values ('" + fHash + "','" + ClusterName + "','" + Hash + "','" + LineofText.ToString() + "','" + FileName + "','" + UserName + "')", DBConnection);
            */

            //
            // Synchronization problem if two users simultaneously generate the same fHash and try to update DB.
            //
            try
            {
                DBConnection.Open();
                DBReader = DBCommand.ExecuteReader();

                if (DBReader.Read())
                {
                    ClusterName = DBReader[0].ToString();
                    if (!DBReader.IsClosed)
                        DBReader.Close();
                }
                else
                {
                    DBReader2 = DBCommand2.ExecuteReader();
                    if (DBReader2.Read())
                    {
                        ClusterName = "~" + DBReader2[0].ToString();
                        while (DBReader2.Read())
                        {
                            ClusterName = ClusterName + "," + DBReader2[0].ToString();
                        }
                    }
                    else
                    {
                        ClusterName = "Not Found!";
                        if (!IsQuery)
                        {
                            DBCommand3.ExecuteNonQuery();
                        }
                    }
                    if (!DBReader2.IsClosed)
                        DBReader2.Close();
                }
            }
            catch (Exception ex)
            {
                ClusterName = ex.ToString();
            }
            finally
            {
                /*
                if(!DBReader.IsClosed)
                    DBReader.Close();
                if(!DBReader2.IsClosed)
                    DBReader2.Close();
                 */
                DBConnection.Close();
            }

            return ClusterName;
        }


        private string ConvertRegEx(string SplitToken)
        {
            string Token = SplitToken.Trim(new Char[] { '[', ']', '{', '}', '(', ')', '<', '>', '/', '\\', '\0', '\n', ':', ',', ';', '\'', '\"' });

            if (Regex.Match(Token, @"^[\d]{2}[:][\d]{2}[:][\d]{2}").Success)
                return "Time";
            //dd/mm/yyyy
            else if (Regex.Match(Token, @"^\b(0?[1-9]|[12][0-9]|3[01])[- /.](0?[1-9]|1[012])[- /.](19|20)?[0-9]{2}\b").Success)
                return "Date";
            //mm/dd/yyyy
            else if (Regex.Match(Token, @"^\b(0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])[- /.](19|20)?[0-9]{2}\b").Success)
                return "Date";
            //yyyy-mm-dd
            else if (Regex.Match(Token, @"^\b(19|20)?[0-9]{2}[- /.](0?[1-9]|1[012])[- /.](0?[1-9]|[12][0-9]|3[01])\b").Success)
                return "Date";
            //else if (Regex.Match(Token, @"^[\d]{4}[-][\d]{2}[-][\d]{2}$").Success)
            //    return "Date";
            //else if (Regex.Match(Token.ToLower(), @"^[^@]*([a-f0-9]{8}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{4}-[a-f0-9]{12})").Success)
            else if (Regex.Match(Token, @"^\b[a-fA-F0-9]{8}(?:-[a-fA-F0-9]{4}){3}-[a-fA-F0-9]{12}\b").Success)
                return "GUID";
            //else if (Regex.Match(Token, @"\b([A-Za-z0-9]+(-[A-Za-z0-9]+)*\.)+[A-Za-z]{2,}\b").Success)
            //else if (Regex.Match(Token, @"([A-Z0-9a-z_-]+[\.][A-Z0-9a-z_-]{2,6})$").Success)
            else if (Regex.Match(Token, @"^([0-9A-Fa-f])\:([0-9A-Fa-f])").Success)
                return "PID:TID";
            else if (Regex.Match(Token, @"^[0-9A-Za-z_-~]*(\.[0-9A-Za-z_-~]{2,6})$").Success)
                return "File";
            else if (Regex.Match(Token, @"([a-zA-Z]\:)(\\[^\\/:~*?<>|]*(?<![ ]))*(\.[A-Z0-9a-z_-]{2,6})$").Success)
                return "FilePath";
            else if (Regex.Match(Token, @"([a-zA-Z]\:\\)([^\\/:~*?<>|]*(?<![ ]))*").Success)
                return "Path";
            else if (Regex.Match(Token, @"\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}\b").Success)
                return "EMail";
            else if (Regex.Match(Token, @"\b[a-f0-9A-F]{2}([-:]?)(?:[a-f0-9A-F]{2}\1){4}[a-f0-9A-F]{2}\b").Success)
                return "MAC";
            else if (Regex.Match(Token, @"\b0[xX][0-9a-fA-F]+\b").Success)
                return "Hex";
            //else if (Regex.Match(Token, @"/([1-9][0-9]*)/").Success)
            //    return "Num";
            // +/-num.num (int and float)
            else if (Regex.Match(Token, @"^(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])\.(25[0-5]|2[0-4][0-9]|1[0-9][0-9]|[1-9]?[0-9])$").Success)
                return "IPv4";
            else if (Regex.Match(Token, @"^[-+]?\b[0-9]*\.?[0-9]+\b").Success)
                return "Num";
            //else if (Regex.Match(Token, @"0[xX][A-Fa-f0-9]+").Success)
            //    return "Hex";
            else if (Regex.Match(Token, @"^[A-Z_.]+$").Success) //^[A-Z_]");
                return "CAP";
            else if (Regex.Match(Token, @"^[a-zA-Z_.-]+$").Success)
                return "Text";
            else if (Regex.Match(Token, @"^[a-zA-Z0-9_.-]+$").Success)
                return "AlphaNum";
            
            return SplitToken;
        }
#endregion Private

    }
}
