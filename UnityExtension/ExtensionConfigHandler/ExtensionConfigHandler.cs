using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityExtension.ExtensionConfigHandler
{
    public class ExtensionConfigHandler : UnityContainerExtensionConfigurationElement
    {
        /// <summary>   
        /// Name of the non-default application domain   
        /// </summary>   
        [ConfigurationProperty("domain")]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }
        /// <summary>   
        /// Relative location of replaceable assemblies   
        /// </summary>   
        [ConfigurationProperty("shadowFiles")]
        public string ShadowFiles
        {
            get { return (string)this["shadowFiles"]; }
            set { this["shadowFiles"] = value; }
        }
        /// <summary>   
        /// Assign the new domain name to the custom container   
        /// </summary>   
        /// <param name="container"></param>   
        public override void Configure(Microsoft.Practices.Unity.IUnityContainer container)
        {
            container.Configure<MyExtension>().CreateAppDomain(Domain, ShadowFiles);
        }
    }
}
