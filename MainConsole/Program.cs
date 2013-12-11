using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using AppDomainUnity.Common;

namespace MainConsole
{
    class Program
    {
        private readonly IUnityContainer stdContainer;
        private IUnityContainer customContainer;
        public Program()
        {
            stdContainer = new UnityContainer();
            customContainer = new UnityContainer();


            // config 정보 읽어들이기
            UnityConfigurationSection section;
            section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            //Unity 컨테이너에 config 정보를 설정한다.
            section.Containers.Default.Configure(stdContainer);
            //UnityConfigurationSection.Configure(stdContainer);
            //section.Containers["customContainer"].Configure(customContainer);
            //UnityConfigurationSection.Configure(customContainer, "customContainer");
        }
        public void Unload()
        {
            customContainer.Dispose();
        }
        public void Reload()
        {
            customContainer = new UnityContainer();
            UnityConfigurationSection section;
            section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Containers["customContainer"].Configure(customContainer);
        }
        public void WaitForUpdate()
        {
            Console.WriteLine("Container has been unloaded ... waiting for update");
            Console.Read();
        }
        public void Spill()
        {
            Console.WriteLine(stdContainer.Resolve<IMyInterface>("local").Speak());
            Console.WriteLine(customContainer.Resolve<IMyInterface>("remote").Speak());
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Spill();
            p.Unload();
            p.WaitForUpdate();
            p.Reload();
            p.Spill();
            p.WaitForUpdate();
        }
    }
}
