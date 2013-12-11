using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityExtension.Strategy;
using Microsoft.Practices.Unity.ObjectBuilder;

namespace UnityExtension.Extension
{
    public class MyExtension : Microsoft.Practices.Unity.UnityContainerExtension, IDisposable
    {
        private MyBuildup strategy = new MyBuildup();
        private bool disposed;
        protected override void Initialize()
        {
            Context.Strategies.Add(strategy, UnityBuildStage.PreCreation);
        }
        /// <summary>    /// Build the new appdomain allowing   
        /// </summary>    /// <param name="domain"></param>   
        /// <param name="shadowFiles"></param>   
        public void CreateAppDomain(string domain, string shadowFiles)
        {
            AppDomainSetup appDomainSetup = new AppDomainSetup();
            appDomainSetup.ApplicationBase = Environment.CurrentDirectory + @"\" + shadowFiles;
            appDomainSetup.ShadowCopyFiles = "true";
            strategy.AppDomain = AppDomain.CreateDomain(domain, null, appDomainSetup);
        }
    }
}
