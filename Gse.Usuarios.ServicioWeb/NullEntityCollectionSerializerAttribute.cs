﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Gse.Usuarios.ServicioWeb
{
    public class NullEntityCollectionSerializerAttribute : Attribute, IServiceBehavior
    {
        public void AddBindingParameters(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase, Collection<ServiceEndpoint> endpoints, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyDispatchBehavior(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
            foreach (var d in serviceDescription.Endpoints)
            {
                foreach (var operation in d.Contract.Operations)
                {
                    var operationBehavior = operation.Behaviors.Find<DataContractSerializerOperationBehavior>();
                    operationBehavior.DataContractSurrogate = new NullEntityCollectionDataContractSurrogate();
                    operationBehavior.DataContractResolver = new NullSerializerProxyDataContractResolver();
                }
            }
        }

        public void Validate(ServiceDescription serviceDescription, ServiceHostBase serviceHostBase)
        {
        }
    }

    public class NullSerializerProxyDataContractResolver : DataContractResolver
    {
        public override Type ResolveName(string typeName, string typeNamespace, Type declaredType, DataContractResolver knownTypeResolver)
        {
            return knownTypeResolver.ResolveName(typeName, typeNamespace, declaredType, knownTypeResolver);
        }

        public override bool TryResolveType(Type type, Type declaredType, DataContractResolver knownTypeResolver, out XmlDictionaryString typeName, out XmlDictionaryString typeNamespace)
        {
            knownTypeResolver.TryResolveType(type, declaredType, knownTypeResolver, out typeName, out typeNamespace);
            return true;
        }
    }

    public class NullSerializer : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("nil", "http://www.w3.org/2001/XMLSchema-instance", "true");
        }
    }

    public class NullEntityCollectionDataContractSurrogate : IDataContractSurrogate
    {
        public XmlObjectSerializer Serializer { get; set; }

        public Type GetDataContractType(Type type)
        {
            if (type.GetInterface("IRelatedEnd") != null)
                return typeof(NullSerializer);
            return type;
        }

        public object GetObjectToSerialize(object obj, Type targetType)
        {
            if (obj is IRelatedEnd && !((IRelatedEnd)obj).IsLoaded)
                return new NullSerializer();
            return obj;
        }

        public object GetDeserializedObject(object obj, Type targetType)
        {
            return obj;
        }

        public Type GetReferencedTypeOnImport(string typeName, string typeNamespace, object customData)
        {
            return null;
        }

        public CodeTypeDeclaration ProcessImportedType(CodeTypeDeclaration typeDeclaration, CodeCompileUnit compileUnit)
        {
            return typeDeclaration;
        }

        public object GetCustomDataToExport(Type clrType, Type dataContractType)
        {
            return null;
        }

        public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
        {
            return null;
        }

        public void GetKnownCustomDataTypes(Collection<Type> customDataTypes) { }
    }
}
