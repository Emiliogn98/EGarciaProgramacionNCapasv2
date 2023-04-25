﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SL_WCF.ServiceProducto {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Result", Namespace="http://schemas.datacontract.org/2004/07/SL_WCF")]
    [System.SerializableAttribute()]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(ML.Producto))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(System.Exception))]
    [System.Runtime.Serialization.KnownTypeAttribute(typeof(object[]))]
    public partial class Result : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private bool CorrectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string ErrorMessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.Exception ExField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object ObjectField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private object[] ObjectsField;
        
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
        public bool Correct {
            get {
                return this.CorrectField;
            }
            set {
                if ((this.CorrectField.Equals(value) != true)) {
                    this.CorrectField = value;
                    this.RaisePropertyChanged("Correct");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string ErrorMessage {
            get {
                return this.ErrorMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.ErrorMessageField, value) != true)) {
                    this.ErrorMessageField = value;
                    this.RaisePropertyChanged("ErrorMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Exception Ex {
            get {
                return this.ExField;
            }
            set {
                if ((object.ReferenceEquals(this.ExField, value) != true)) {
                    this.ExField = value;
                    this.RaisePropertyChanged("Ex");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object Object {
            get {
                return this.ObjectField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectField, value) != true)) {
                    this.ObjectField = value;
                    this.RaisePropertyChanged("Object");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public object[] Objects {
            get {
                return this.ObjectsField;
            }
            set {
                if ((object.ReferenceEquals(this.ObjectsField, value) != true)) {
                    this.ObjectsField = value;
                    this.RaisePropertyChanged("Objects");
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
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceProducto.IProducto")]
    public interface IProducto {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Add", ReplyAction="http://tempuri.org/IProducto/AddResponse")]
        SL_WCF.ServiceProducto.Result Add(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Add", ReplyAction="http://tempuri.org/IProducto/AddResponse")]
        System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> AddAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Delete", ReplyAction="http://tempuri.org/IProducto/DeleteResponse")]
        SL_WCF.ServiceProducto.Result Delete(int idProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Delete", ReplyAction="http://tempuri.org/IProducto/DeleteResponse")]
        System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> DeleteAsync(int idProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Update", ReplyAction="http://tempuri.org/IProducto/UpdateResponse")]
        SL_WCF.ServiceProducto.Result Update(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/Update", ReplyAction="http://tempuri.org/IProducto/UpdateResponse")]
        System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> UpdateAsync(ML.Producto producto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/GetAll", ReplyAction="http://tempuri.org/IProducto/GetAllResponse")]
        SL_WCF.ServiceProducto.Result GetAll();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/GetAll", ReplyAction="http://tempuri.org/IProducto/GetAllResponse")]
        System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> GetAllAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/GetById", ReplyAction="http://tempuri.org/IProducto/GetByIdResponse")]
        SL_WCF.ServiceProducto.Result GetById(int IdProducto);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IProducto/GetById", ReplyAction="http://tempuri.org/IProducto/GetByIdResponse")]
        System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> GetByIdAsync(int IdProducto);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IProductoChannel : SL_WCF.ServiceProducto.IProducto, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ProductoClient : System.ServiceModel.ClientBase<SL_WCF.ServiceProducto.IProducto>, SL_WCF.ServiceProducto.IProducto {
        
        public ProductoClient() {
        }
        
        public ProductoClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ProductoClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ProductoClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public SL_WCF.ServiceProducto.Result Add(ML.Producto producto) {
            return base.Channel.Add(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> AddAsync(ML.Producto producto) {
            return base.Channel.AddAsync(producto);
        }
        
        public SL_WCF.ServiceProducto.Result Delete(int idProducto) {
            return base.Channel.Delete(idProducto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> DeleteAsync(int idProducto) {
            return base.Channel.DeleteAsync(idProducto);
        }
        
        public SL_WCF.ServiceProducto.Result Update(ML.Producto producto) {
            return base.Channel.Update(producto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> UpdateAsync(ML.Producto producto) {
            return base.Channel.UpdateAsync(producto);
        }
        
        public SL_WCF.ServiceProducto.Result GetAll() {
            return base.Channel.GetAll();
        }
        
        public System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> GetAllAsync() {
            return base.Channel.GetAllAsync();
        }
        
        public SL_WCF.ServiceProducto.Result GetById(int IdProducto) {
            return base.Channel.GetById(IdProducto);
        }
        
        public System.Threading.Tasks.Task<SL_WCF.ServiceProducto.Result> GetByIdAsync(int IdProducto) {
            return base.Channel.GetByIdAsync(IdProducto);
        }
    }
}
