﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18010
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LogPart.ServiceReference1 {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CompositeType", Namespace="http://schemas.datacontract.org/2004/07/LSRService")]
    [System.SerializableAttribute()]
    public partial class CompositeType : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool BoolValueField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string StringValueField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public bool BoolValue {
            get {
                return this.BoolValueField;
            }
            set {
                if ((this.BoolValueField.Equals(value) != true)) {
                    this.BoolValueField = value;
                    this.RaisePropertyChanged("BoolValue");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string StringValue {
            get {
                return this.StringValueField;
            }
            set {
                if ((object.ReferenceEquals(this.StringValueField, value) != true)) {
                    this.StringValueField = value;
                    this.RaisePropertyChanged("StringValue");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="InnerData", Namespace="http://schemas.datacontract.org/2004/07/LSRService")]
    [System.SerializableAttribute()]
    public partial class InnerData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FrequencyHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string FrequencySummaryField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TranslationHashField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string TranslationSummaryField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FrequencyHash {
            get {
                return this.FrequencyHashField;
            }
            set {
                if ((object.ReferenceEquals(this.FrequencyHashField, value) != true)) {
                    this.FrequencyHashField = value;
                    this.RaisePropertyChanged("FrequencyHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FrequencySummary {
            get {
                return this.FrequencySummaryField;
            }
            set {
                if ((object.ReferenceEquals(this.FrequencySummaryField, value) != true)) {
                    this.FrequencySummaryField = value;
                    this.RaisePropertyChanged("FrequencySummary");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TranslationHash {
            get {
                return this.TranslationHashField;
            }
            set {
                if ((object.ReferenceEquals(this.TranslationHashField, value) != true)) {
                    this.TranslationHashField = value;
                    this.RaisePropertyChanged("TranslationHash");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TranslationSummary {
            get {
                return this.TranslationSummaryField;
            }
            set {
                if ((object.ReferenceEquals(this.TranslationSummaryField, value) != true)) {
                    this.TranslationSummaryField = value;
                    this.RaisePropertyChanged("TranslationSummary");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.Service")]
    public interface Service {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetData", ReplyAction="http://tempuri.org/Service/GetDataResponse")]
        string GetData(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetData", ReplyAction="http://tempuri.org/Service/GetDataResponse")]
        System.Threading.Tasks.Task<string> GetDataAsync(int value);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetDataUsingDataContract", ReplyAction="http://tempuri.org/Service/GetDataUsingDataContractResponse")]
        LogPart.ServiceReference1.CompositeType GetDataUsingDataContract(LogPart.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetDataUsingDataContract", ReplyAction="http://tempuri.org/Service/GetDataUsingDataContractResponse")]
        System.Threading.Tasks.Task<LogPart.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(LogPart.ServiceReference1.CompositeType composite);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetClusterList", ReplyAction="http://tempuri.org/Service/GetClusterListResponse")]
        string[] GetClusterList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/GetClusterList", ReplyAction="http://tempuri.org/Service/GetClusterListResponse")]
        System.Threading.Tasks.Task<string[]> GetClusterListAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/AddCluster", ReplyAction="http://tempuri.org/Service/AddClusterResponse")]
        int AddCluster(string Name, string Description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/AddCluster", ReplyAction="http://tempuri.org/Service/AddClusterResponse")]
        System.Threading.Tasks.Task<int> AddClusterAsync(string Name, string Description);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/DiscoverSchema", ReplyAction="http://tempuri.org/Service/DiscoverSchemaResponse")]
        LogPart.ServiceReference1.DiscoverSchemaResponse DiscoverSchema(LogPart.ServiceReference1.DiscoverSchemaRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/DiscoverSchema", ReplyAction="http://tempuri.org/Service/DiscoverSchemaResponse")]
        System.Threading.Tasks.Task<LogPart.ServiceReference1.DiscoverSchemaResponse> DiscoverSchemaAsync(LogPart.ServiceReference1.DiscoverSchemaRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/TrainSystem", ReplyAction="http://tempuri.org/Service/TrainSystemResponse")]
        string TrainSystem(string DirName, string Cluster, string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/TrainSystem", ReplyAction="http://tempuri.org/Service/TrainSystemResponse")]
        System.Threading.Tasks.Task<string> TrainSystemAsync(string DirName, string Cluster, string user);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/Transform", ReplyAction="http://tempuri.org/Service/TransformResponse")]
        string Transform(string TextLine);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/Service/Transform", ReplyAction="http://tempuri.org/Service/TransformResponse")]
        System.Threading.Tasks.Task<string> TransformAsync(string TextLine);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DiscoverSchema", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DiscoverSchemaRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string FileName;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public string user;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=2)]
        public LogPart.ServiceReference1.InnerData UserInnerData;
        
        public DiscoverSchemaRequest() {
        }
        
        public DiscoverSchemaRequest(string FileName, string user, LogPart.ServiceReference1.InnerData UserInnerData) {
            this.FileName = FileName;
            this.user = user;
            this.UserInnerData = UserInnerData;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DiscoverSchemaResponse", WrapperNamespace="http://tempuri.org/", IsWrapped=true)]
    public partial class DiscoverSchemaResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=0)]
        public string DiscoverSchemaResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://tempuri.org/", Order=1)]
        public LogPart.ServiceReference1.InnerData UserInnerData;
        
        public DiscoverSchemaResponse() {
        }
        
        public DiscoverSchemaResponse(string DiscoverSchemaResult, LogPart.ServiceReference1.InnerData UserInnerData) {
            this.DiscoverSchemaResult = DiscoverSchemaResult;
            this.UserInnerData = UserInnerData;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ServiceChannel : LogPart.ServiceReference1.Service, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<LogPart.ServiceReference1.Service>, LogPart.ServiceReference1.Service {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string GetData(int value) {
            return base.Channel.GetData(value);
        }
        
        public System.Threading.Tasks.Task<string> GetDataAsync(int value) {
            return base.Channel.GetDataAsync(value);
        }
        
        public LogPart.ServiceReference1.CompositeType GetDataUsingDataContract(LogPart.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContract(composite);
        }
        
        public System.Threading.Tasks.Task<LogPart.ServiceReference1.CompositeType> GetDataUsingDataContractAsync(LogPart.ServiceReference1.CompositeType composite) {
            return base.Channel.GetDataUsingDataContractAsync(composite);
        }
        
        public string[] GetClusterList() {
            return base.Channel.GetClusterList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetClusterListAsync() {
            return base.Channel.GetClusterListAsync();
        }
        
        public int AddCluster(string Name, string Description) {
            return base.Channel.AddCluster(Name, Description);
        }
        
        public System.Threading.Tasks.Task<int> AddClusterAsync(string Name, string Description) {
            return base.Channel.AddClusterAsync(Name, Description);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        LogPart.ServiceReference1.DiscoverSchemaResponse LogPart.ServiceReference1.Service.DiscoverSchema(LogPart.ServiceReference1.DiscoverSchemaRequest request) {
            return base.Channel.DiscoverSchema(request);
        }
        
        public string DiscoverSchema(string FileName, string user, ref LogPart.ServiceReference1.InnerData UserInnerData) {
            LogPart.ServiceReference1.DiscoverSchemaRequest inValue = new LogPart.ServiceReference1.DiscoverSchemaRequest();
            inValue.FileName = FileName;
            inValue.user = user;
            inValue.UserInnerData = UserInnerData;
            LogPart.ServiceReference1.DiscoverSchemaResponse retVal = ((LogPart.ServiceReference1.Service)(this)).DiscoverSchema(inValue);
            UserInnerData = retVal.UserInnerData;
            return retVal.DiscoverSchemaResult;
        }
        
        public System.Threading.Tasks.Task<LogPart.ServiceReference1.DiscoverSchemaResponse> DiscoverSchemaAsync(LogPart.ServiceReference1.DiscoverSchemaRequest request) {
            return base.Channel.DiscoverSchemaAsync(request);
        }
        
        public string TrainSystem(string DirName, string Cluster, string user) {
            return base.Channel.TrainSystem(DirName, Cluster, user);
        }
        
        public System.Threading.Tasks.Task<string> TrainSystemAsync(string DirName, string Cluster, string user) {
            return base.Channel.TrainSystemAsync(DirName, Cluster, user);
        }
        
        public string Transform(string TextLine) {
            return base.Channel.Transform(TextLine);
        }
        
        public System.Threading.Tasks.Task<string> TransformAsync(string TextLine) {
            return base.Channel.TransformAsync(TextLine);
        }
    }
}
