﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KaspiShop.SalesTerritoryService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SalesTerritoryService.ISalesTerritoryService")]
    public interface ISalesTerritoryService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesTerritoryService/GetList", ReplyAction="http://tempuri.org/ISalesTerritoryService/GetListResponse")]
        string[] GetList();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ISalesTerritoryService/GetList", ReplyAction="http://tempuri.org/ISalesTerritoryService/GetListResponse")]
        System.Threading.Tasks.Task<string[]> GetListAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface ISalesTerritoryServiceChannel : KaspiShop.SalesTerritoryService.ISalesTerritoryService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class SalesTerritoryServiceClient : System.ServiceModel.ClientBase<KaspiShop.SalesTerritoryService.ISalesTerritoryService>, KaspiShop.SalesTerritoryService.ISalesTerritoryService {
        
        public SalesTerritoryServiceClient() {
        }
        
        public SalesTerritoryServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SalesTerritoryServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesTerritoryServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SalesTerritoryServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public string[] GetList() {
            return base.Channel.GetList();
        }
        
        public System.Threading.Tasks.Task<string[]> GetListAsync() {
            return base.Channel.GetListAsync();
        }
    }
}
