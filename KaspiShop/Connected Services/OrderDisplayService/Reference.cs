﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KaspiShop.OrderDisplayService {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="PurchaseOrderHeaderDTO", Namespace="http://schemas.datacontract.org/2004/07/WCFShopService.Services")]
    [System.SerializableAttribute()]
    public partial class PurchaseOrderHeaderDTO : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime ModifiedDateField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private int PurchaseOrderIDField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private byte StatusField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal SubTotalField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private decimal TotalDueField;
        
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
        public System.DateTime ModifiedDate {
            get {
                return this.ModifiedDateField;
            }
            set {
                if ((this.ModifiedDateField.Equals(value) != true)) {
                    this.ModifiedDateField = value;
                    this.RaisePropertyChanged("ModifiedDate");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int PurchaseOrderID {
            get {
                return this.PurchaseOrderIDField;
            }
            set {
                if ((this.PurchaseOrderIDField.Equals(value) != true)) {
                    this.PurchaseOrderIDField = value;
                    this.RaisePropertyChanged("PurchaseOrderID");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public byte Status {
            get {
                return this.StatusField;
            }
            set {
                if ((this.StatusField.Equals(value) != true)) {
                    this.StatusField = value;
                    this.RaisePropertyChanged("Status");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal SubTotal {
            get {
                return this.SubTotalField;
            }
            set {
                if ((this.SubTotalField.Equals(value) != true)) {
                    this.SubTotalField = value;
                    this.RaisePropertyChanged("SubTotal");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public decimal TotalDue {
            get {
                return this.TotalDueField;
            }
            set {
                if ((this.TotalDueField.Equals(value) != true)) {
                    this.TotalDueField = value;
                    this.RaisePropertyChanged("TotalDue");
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
        private string LocationNameField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private KaspiShop.OrderDisplayService.ProductDTO ProductDTOField;
        
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
        public string LocationName {
            get {
                return this.LocationNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LocationNameField, value) != true)) {
                    this.LocationNameField = value;
                    this.RaisePropertyChanged("LocationName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public KaspiShop.OrderDisplayService.ProductDTO ProductDTO {
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
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="OrderDisplayService.IOrderDisplayService")]
    public interface IOrderDisplayService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderDisplayService/GetPurchaseOrders", ReplyAction="http://tempuri.org/IOrderDisplayService/GetPurchaseOrdersResponse")]
        KaspiShop.OrderDisplayService.PurchaseOrderHeaderDTO[] GetPurchaseOrders(int businessEntityID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderDisplayService/GetPurchaseOrders", ReplyAction="http://tempuri.org/IOrderDisplayService/GetPurchaseOrdersResponse")]
        System.Threading.Tasks.Task<KaspiShop.OrderDisplayService.PurchaseOrderHeaderDTO[]> GetPurchaseOrdersAsync(int businessEntityID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderDisplayService/GetPurchaseOrderDetails", ReplyAction="http://tempuri.org/IOrderDisplayService/GetPurchaseOrderDetailsResponse")]
        KaspiShop.OrderDisplayService.ShopCartLineDTO[] GetPurchaseOrderDetails(int purchaseID);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IOrderDisplayService/GetPurchaseOrderDetails", ReplyAction="http://tempuri.org/IOrderDisplayService/GetPurchaseOrderDetailsResponse")]
        System.Threading.Tasks.Task<KaspiShop.OrderDisplayService.ShopCartLineDTO[]> GetPurchaseOrderDetailsAsync(int purchaseID);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IOrderDisplayServiceChannel : KaspiShop.OrderDisplayService.IOrderDisplayService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class OrderDisplayServiceClient : System.ServiceModel.ClientBase<KaspiShop.OrderDisplayService.IOrderDisplayService>, KaspiShop.OrderDisplayService.IOrderDisplayService {
        
        public OrderDisplayServiceClient() {
        }
        
        public OrderDisplayServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public OrderDisplayServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderDisplayServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public OrderDisplayServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public KaspiShop.OrderDisplayService.PurchaseOrderHeaderDTO[] GetPurchaseOrders(int businessEntityID) {
            return base.Channel.GetPurchaseOrders(businessEntityID);
        }
        
        public System.Threading.Tasks.Task<KaspiShop.OrderDisplayService.PurchaseOrderHeaderDTO[]> GetPurchaseOrdersAsync(int businessEntityID) {
            return base.Channel.GetPurchaseOrdersAsync(businessEntityID);
        }
        
        public KaspiShop.OrderDisplayService.ShopCartLineDTO[] GetPurchaseOrderDetails(int purchaseID) {
            return base.Channel.GetPurchaseOrderDetails(purchaseID);
        }
        
        public System.Threading.Tasks.Task<KaspiShop.OrderDisplayService.ShopCartLineDTO[]> GetPurchaseOrderDetailsAsync(int purchaseID) {
            return base.Channel.GetPurchaseOrderDetailsAsync(purchaseID);
        }
    }
}
