﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PopAppShops.Console.GamersClient {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.CollectionDataContractAttribute(Name="ArrayOfString", Namespace="https://my-game.azurewebsites.net", ItemName="string")]
    [System.SerializableAttribute()]
    public class ArrayOfString : System.Collections.Generic.List<string> {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categories", Namespace="https://my-game.azurewebsites.net")]
    [System.SerializableAttribute()]
    public partial class Categories : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string CreatedByField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false)]
        public string Name {
            get {
                return this.NameField;
            }
            set {
                if ((object.ReferenceEquals(this.NameField, value) != true)) {
                    this.NameField = value;
                    this.RaisePropertyChanged("Name");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string CreatedBy {
            get {
                return this.CreatedByField;
            }
            set {
                if ((object.ReferenceEquals(this.CreatedByField, value) != true)) {
                    this.CreatedByField = value;
                    this.RaisePropertyChanged("CreatedBy");
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
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://my-game.azurewebsites.net", ConfigurationName="GamersClient.players")]
    public interface players {
        
        // CODEGEN: Generating message contract since element name GetCategoryResult from namespace https://my-game.azurewebsites.net is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/GetCategory", ReplyAction="*")]
        PopAppShops.Console.GamersClient.GetCategoryResponse GetCategory(PopAppShops.Console.GamersClient.GetCategoryRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/GetCategory", ReplyAction="*")]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetCategoryResponse> GetCategoryAsync(PopAppShops.Console.GamersClient.GetCategoryRequest request);
        
        // CODEGEN: Generating message contract since element name payload from namespace https://my-game.azurewebsites.net is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/Create", ReplyAction="*")]
        PopAppShops.Console.GamersClient.CreateResponse Create(PopAppShops.Console.GamersClient.CreateRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/Create", ReplyAction="*")]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.CreateResponse> CreateAsync(PopAppShops.Console.GamersClient.CreateRequest request);
        
        // CODEGEN: Generating message contract since element name GetConfigResult from namespace https://my-game.azurewebsites.net is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/GetConfig", ReplyAction="*")]
        PopAppShops.Console.GamersClient.GetConfigResponse GetConfig(PopAppShops.Console.GamersClient.GetConfigRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://my-game.azurewebsites.net/GetConfig", ReplyAction="*")]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetConfigResponse> GetConfigAsync(PopAppShops.Console.GamersClient.GetConfigRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCategoryRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCategory", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.GetCategoryRequestBody Body;
        
        public GetCategoryRequest() {
        }
        
        public GetCategoryRequest(PopAppShops.Console.GamersClient.GetCategoryRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetCategoryRequestBody {
        
        public GetCategoryRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetCategoryResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetCategoryResponse", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.GetCategoryResponseBody Body;
        
        public GetCategoryResponse() {
        }
        
        public GetCategoryResponse(PopAppShops.Console.GamersClient.GetCategoryResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://my-game.azurewebsites.net")]
    public partial class GetCategoryResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PopAppShops.Console.GamersClient.ArrayOfString GetCategoryResult;
        
        public GetCategoryResponseBody() {
        }
        
        public GetCategoryResponseBody(PopAppShops.Console.GamersClient.ArrayOfString GetCategoryResult) {
            this.GetCategoryResult = GetCategoryResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Create", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.CreateRequestBody Body;
        
        public CreateRequest() {
        }
        
        public CreateRequest(PopAppShops.Console.GamersClient.CreateRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://my-game.azurewebsites.net")]
    public partial class CreateRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public PopAppShops.Console.GamersClient.Categories payload;
        
        public CreateRequestBody() {
        }
        
        public CreateRequestBody(PopAppShops.Console.GamersClient.Categories payload) {
            this.payload = payload;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class CreateResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="CreateResponse", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.CreateResponseBody Body;
        
        public CreateResponse() {
        }
        
        public CreateResponse(PopAppShops.Console.GamersClient.CreateResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://my-game.azurewebsites.net")]
    public partial class CreateResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string CreateResult;
        
        public CreateResponseBody() {
        }
        
        public CreateResponseBody(string CreateResult) {
            this.CreateResult = CreateResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetConfigRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetConfig", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.GetConfigRequestBody Body;
        
        public GetConfigRequest() {
        }
        
        public GetConfigRequest(PopAppShops.Console.GamersClient.GetConfigRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class GetConfigRequestBody {
        
        public GetConfigRequestBody() {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetConfigResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetConfigResponse", Namespace="https://my-game.azurewebsites.net", Order=0)]
        public PopAppShops.Console.GamersClient.GetConfigResponseBody Body;
        
        public GetConfigResponse() {
        }
        
        public GetConfigResponse(PopAppShops.Console.GamersClient.GetConfigResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="https://my-game.azurewebsites.net")]
    public partial class GetConfigResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string GetConfigResult;
        
        public GetConfigResponseBody() {
        }
        
        public GetConfigResponseBody(string GetConfigResult) {
            this.GetConfigResult = GetConfigResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface playersChannel : PopAppShops.Console.GamersClient.players, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class playersClient : System.ServiceModel.ClientBase<PopAppShops.Console.GamersClient.players>, PopAppShops.Console.GamersClient.players {
        
        public playersClient() {
        }
        
        public playersClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public playersClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public playersClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public playersClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PopAppShops.Console.GamersClient.GetCategoryResponse PopAppShops.Console.GamersClient.players.GetCategory(PopAppShops.Console.GamersClient.GetCategoryRequest request) {
            return base.Channel.GetCategory(request);
        }
        
        public PopAppShops.Console.GamersClient.ArrayOfString GetCategory() {
            PopAppShops.Console.GamersClient.GetCategoryRequest inValue = new PopAppShops.Console.GamersClient.GetCategoryRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.GetCategoryRequestBody();
            PopAppShops.Console.GamersClient.GetCategoryResponse retVal = ((PopAppShops.Console.GamersClient.players)(this)).GetCategory(inValue);
            return retVal.Body.GetCategoryResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetCategoryResponse> PopAppShops.Console.GamersClient.players.GetCategoryAsync(PopAppShops.Console.GamersClient.GetCategoryRequest request) {
            return base.Channel.GetCategoryAsync(request);
        }
        
        public System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetCategoryResponse> GetCategoryAsync() {
            PopAppShops.Console.GamersClient.GetCategoryRequest inValue = new PopAppShops.Console.GamersClient.GetCategoryRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.GetCategoryRequestBody();
            return ((PopAppShops.Console.GamersClient.players)(this)).GetCategoryAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PopAppShops.Console.GamersClient.CreateResponse PopAppShops.Console.GamersClient.players.Create(PopAppShops.Console.GamersClient.CreateRequest request) {
            return base.Channel.Create(request);
        }
        
        public string Create(PopAppShops.Console.GamersClient.Categories payload) {
            PopAppShops.Console.GamersClient.CreateRequest inValue = new PopAppShops.Console.GamersClient.CreateRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.CreateRequestBody();
            inValue.Body.payload = payload;
            PopAppShops.Console.GamersClient.CreateResponse retVal = ((PopAppShops.Console.GamersClient.players)(this)).Create(inValue);
            return retVal.Body.CreateResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.CreateResponse> PopAppShops.Console.GamersClient.players.CreateAsync(PopAppShops.Console.GamersClient.CreateRequest request) {
            return base.Channel.CreateAsync(request);
        }
        
        public System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.CreateResponse> CreateAsync(PopAppShops.Console.GamersClient.Categories payload) {
            PopAppShops.Console.GamersClient.CreateRequest inValue = new PopAppShops.Console.GamersClient.CreateRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.CreateRequestBody();
            inValue.Body.payload = payload;
            return ((PopAppShops.Console.GamersClient.players)(this)).CreateAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        PopAppShops.Console.GamersClient.GetConfigResponse PopAppShops.Console.GamersClient.players.GetConfig(PopAppShops.Console.GamersClient.GetConfigRequest request) {
            return base.Channel.GetConfig(request);
        }
        
        public string GetConfig() {
            PopAppShops.Console.GamersClient.GetConfigRequest inValue = new PopAppShops.Console.GamersClient.GetConfigRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.GetConfigRequestBody();
            PopAppShops.Console.GamersClient.GetConfigResponse retVal = ((PopAppShops.Console.GamersClient.players)(this)).GetConfig(inValue);
            return retVal.Body.GetConfigResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetConfigResponse> PopAppShops.Console.GamersClient.players.GetConfigAsync(PopAppShops.Console.GamersClient.GetConfigRequest request) {
            return base.Channel.GetConfigAsync(request);
        }
        
        public System.Threading.Tasks.Task<PopAppShops.Console.GamersClient.GetConfigResponse> GetConfigAsync() {
            PopAppShops.Console.GamersClient.GetConfigRequest inValue = new PopAppShops.Console.GamersClient.GetConfigRequest();
            inValue.Body = new PopAppShops.Console.GamersClient.GetConfigRequestBody();
            return ((PopAppShops.Console.GamersClient.players)(this)).GetConfigAsync(inValue);
        }
    }
}