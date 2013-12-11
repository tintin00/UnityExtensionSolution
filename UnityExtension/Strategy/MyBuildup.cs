using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.ObjectBuilder;
using Microsoft.Practices.ObjectBuilder2;

namespace UnityExtension.Strategy
{
    public class MyBuildup : Microsoft.Practices.ObjectBuilder2.IBuilderStrategy
    {
        AppDomain _AppDomain;
        public AppDomain AppDomain
        {
            set
            {
                _AppDomain = value;
            }
            get
            {
                return _AppDomain;
            }
        }
        public void PreBuildUp(IBuilderContext context)
        {
            Type targetType = BuildKey.GetType(context.BuildKey);
            if (AppDomain != null)
            {
                context.Existing = AppDomain.CreateInstanceAndUnwrap(targetType.Assembly.FullName, targetType.ToString());
                context.BuildComplete = true;
            }
        }
        public void PostBuildUp(IBuilderContext context) { }
        public void PreTearDown(IBuilderContext context) { }
        public void PostTearDown(IBuilderContext context) { }
    }
}
