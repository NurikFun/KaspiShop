//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KaspiShop.ShopCartItemService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="ProductDTO", Namespace="http://schemas.datacontract.org/2004/07/WCFShopService.Services")]
    [System.SerializableAttribute()]
    public partial class ProductDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal ListPriceField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string NameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int ProductIDField;
        
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
        public decimal ListPrice {
            get {
                return this.ListPriceField;
            }
            set {
                if ((this.ListPriceField.Equals(value) != true)) {
                    this.ListPriceField = value;
                    this.RaisePropertyChanged("ListPrice");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int ProductID {
            get {
                return this.ProductIDField;
            }
            set {
                if ((this.ProductIDField.Equals(value) != true)) {
                    this.ProductIDField = value;
                    this.RaisePropertyChanged("ProductID");
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
    [System.Runtime.Serialization.DataContractAttribute(Name="ShopCartLineDTO", Namespace="http://schemas.datacontract.org/2004/07/WCFShopService.Services")]
    [System.SerializableAttribute()]
    public partial class ShopCartLineDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private KaspiShop.ShopCartItemService.ProductDTO ProductDTOField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int QuantityField;
        
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
        public KaspiShop.ShopCartItemService.ProductDTO ProductDTO {
            get {
                return this.ProductDTOField;
            }
            set {
                if ((object.ReferenceEquals(this.ProductDTOField, value) != true)) {
                    this.ProductDTOField = value;
                    this.RaisePropertyChanged("ProductDTO");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Quantity {
            get {
                return this.QuantityField;
            }
            set {
                if ((this.QuantityField.Equals(value) != true)) {
                    this.QuantityField = value;
                    this.RaisePropertyChanged("Quantity");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ShopCartItemService.IShopCartItemService")]
    public interface IShopCartItemService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/AddItem", ReplyAction="http://tempuri.org/IShopCartItemService/AddItemResponse")]
        void AddItem(KaspiShop.ShopCartItemService.ProductDTO product, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/AddItem", ReplyAction="http://tempuri.org/IShopCartItemService/AddItemResponse")]
        System.Threading.Tasks.Task AddItemAsync(KaspiShop.ShopCartItemService.ProductDTO product, int quantity);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/RemoveLine", ReplyAction="http://tempuri.org/IShopCartItemService/RemoveLineResponse")]
        void RemoveLine(KaspiShop.ShopCartItemService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/RemoveLine", ReplyAction="http://tempuri.org/IShopCartItemService/RemoveLineResponse")]
        System.Threading.Tasks.Task RemoveLineAsync(KaspiShop.ShopCartItemService.ProductDTO product);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/ComputeTotalValue", ReplyAction="http://tempuri.org/IShopCartItemService/ComputeTotalValueResponse")]
        decimal ComputeTotalValue();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/ComputeTotalValue", ReplyAction="http://tempuri.org/IShopCartItemService/ComputeTotalValueResponse")]
        System.Threading.Tasks.Task<decimal> ComputeTotalValueAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/Clear", ReplyAction="http://tempuri.org/IShopCartItemService/ClearResponse")]
        void Clear();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/Clear", ReplyAction="http://tempuri.org/IShopCartItemService/ClearResponse")]
        System.Threading.Tasks.Task ClearAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/Lines", ReplyAction="http://tempuri.org/IShopCartItemService/LinesResponse")]
        KaspiShop.ShopCartItemService.ShopCartLineDTO[] Lines();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IShopCartItemService/Lines", ReplyAction="http://tempuri.org/IShopCartItemService/LinesResponse")]
        System.Threading.Tasks.Task<KaspiShop.ShopCartItemService.ShopCartLineDTO[]> LinesAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IShopCartItemServiceChannel : KaspiShop.ShopCartItemService.IShopCartItemService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ShopCartItemServiceClient : System.ServiceModel.ClientBase<KaspiShop.ShopCartItemService.IShopCartItemService>, KaspiShop.ShopCartItemService.IShopCartItemService {
        
        public ShopCartItemServiceClient() {
        }
        
        public ShopCartItemServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ShopCartItemServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopCartItemServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ShopCartItemServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void AddItem(KaspiShop.ShopCartItemService.ProductDTO product, int quantity) {
            base.Channel.AddItem(product, quantity);
        }
        
        public System.Threading.Tasks.Task AddItemAsync(KaspiShop.ShopCartItemService.ProductDTO product, int quantity) {
            return base.Channel.AddItemAsync(product, quantity);
        }
        
        public void RemoveLine(KaspiShop.ShopCartItemService.ProductDTO product) {
            base.Channel.RemoveLine(product);
        }
        
        public System.Threading.Tasks.Task RemoveLineAsync(KaspiShop.ShopCartItemService.ProductDTO product) {
            return base.Channel.RemoveLineAsync(product);
        }
        
        public decimal ComputeTotalValue() {
            return base.Channel.ComputeTotalValue();
        }
        
        public System.Threading.Tasks.Task<decimal> ComputeTotalValueAsync() {
            return base.Channel.ComputeTotalValueAsync();
        }
        
        public void Clear() {
            base.Channel.Clear();
        }
        
        public System.Threading.Tasks.Task ClearAsync() {
            return base.Channel.ClearAsync();
        }
        
        public KaspiShop.ShopCartItemService.ShopCartLineDTO[] Lines() {
            return base.Channel.Lines();
        }
        
        public System.Threading.Tasks.Task<KaspiShop.ShopCartItemService.ShopCartLineDTO[]> LinesAsync() {
            return base.Channel.LinesAsync();
        }
    }
}
