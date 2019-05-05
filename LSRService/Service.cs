using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace LSRService
{
    [ServiceContract]
    public interface Service
    {

        [OperationContract]
        string GetData(int value);

        [OperationContract]
        CompositeType GetDataUsingDataContract(CompositeType composite);

        [OperationContract]
        string[] GetClusterList();

        [OperationContract]
        int AddCluster(string Name, string Description);

        [OperationContract]
        string DiscoverSchema(string FileName, string user, ref InnerData UserInnerData);

        //[OperationContract]
        //string DiscoverSchema(string FileName, string user, ref InnerData UserInnerData);
        //string findCluster(string FileName, string ClusterName, bool IsQuery, string UserName);

        [OperationContract]
        Task<string> TrainSystem(string DirName, string Cluster, string user);

        [OperationContract]
        string Transform(string TextLine);



        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }


    }

    [DataContract]
    public class InnerData
    {
        string sTranslationSummary = "";
        string sFrequencySummary = "";
        string sTranslationHash = "";
        string sFrequencyHash = "";

        [DataMember]
        public string TranslationSummary
        {
            get { return sTranslationSummary; }
            set { sTranslationSummary = value; }
        }

        [DataMember]
        public string FrequencySummary
        {
            get { return sFrequencySummary; }
            set { sFrequencySummary = value; }
        }

        [DataMember]
        public string TranslationHash
        {
            get { return sTranslationHash; }
            set { sTranslationHash = value; }
        }

        [DataMember]
        public string FrequencyHash
        {
            get { return sFrequencyHash; }
            set { sFrequencyHash = value; }
        }
    }

    public class DistributionList
    {
        public string Line { get; set; }
        public uint Frequency { get; set; }
    }
}
