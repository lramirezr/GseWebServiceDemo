﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Gse.WebService.Demo.UsuarioServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="UsuarioServiceReference.IUsuariosService")]
    public interface IUsuariosService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/GetAllUsuario", ReplyAction="http://tempuri.org/IUsuariosService/GetAllUsuarioResponse")]
        Gse.WebService.Entities.Usuario[] GetAllUsuario();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/GetAllUsuario", ReplyAction="http://tempuri.org/IUsuariosService/GetAllUsuarioResponse")]
        System.Threading.Tasks.Task<Gse.WebService.Entities.Usuario[]> GetAllUsuarioAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/GetUsuario", ReplyAction="http://tempuri.org/IUsuariosService/GetUsuarioResponse")]
        Gse.WebService.Entities.Usuario GetUsuario(System.Guid Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/GetUsuario", ReplyAction="http://tempuri.org/IUsuariosService/GetUsuarioResponse")]
        System.Threading.Tasks.Task<Gse.WebService.Entities.Usuario> GetUsuarioAsync(System.Guid Id);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/AddUsuario", ReplyAction="http://tempuri.org/IUsuariosService/AddUsuarioResponse")]
        void AddUsuario(Gse.WebService.Entities.Usuario usuario);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IUsuariosService/AddUsuario", ReplyAction="http://tempuri.org/IUsuariosService/AddUsuarioResponse")]
        System.Threading.Tasks.Task AddUsuarioAsync(Gse.WebService.Entities.Usuario usuario);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IUsuariosServiceChannel : Gse.WebService.Demo.UsuarioServiceReference.IUsuariosService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UsuariosServiceClient : System.ServiceModel.ClientBase<Gse.WebService.Demo.UsuarioServiceReference.IUsuariosService>, Gse.WebService.Demo.UsuarioServiceReference.IUsuariosService {
        
        public UsuariosServiceClient() {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UsuariosServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public Gse.WebService.Entities.Usuario[] GetAllUsuario() {
            return base.Channel.GetAllUsuario();
        }
        
        public System.Threading.Tasks.Task<Gse.WebService.Entities.Usuario[]> GetAllUsuarioAsync() {
            return base.Channel.GetAllUsuarioAsync();
        }
        
        public Gse.WebService.Entities.Usuario GetUsuario(System.Guid Id) {
            return base.Channel.GetUsuario(Id);
        }
        
        public System.Threading.Tasks.Task<Gse.WebService.Entities.Usuario> GetUsuarioAsync(System.Guid Id) {
            return base.Channel.GetUsuarioAsync(Id);
        }
        
        public void AddUsuario(Gse.WebService.Entities.Usuario usuario) {
            base.Channel.AddUsuario(usuario);
        }
        
        public System.Threading.Tasks.Task AddUsuarioAsync(Gse.WebService.Entities.Usuario usuario) {
            return base.Channel.AddUsuarioAsync(usuario);
        }
    }
}
