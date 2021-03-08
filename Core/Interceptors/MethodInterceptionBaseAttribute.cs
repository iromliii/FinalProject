using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {//Prıorıty öncelik
        //Catch hata yakalama blogu
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
    //Gıt classın attrıbutlerını gıt methodun attrıbute (valıdatıon,log,cache,performance,transıatıon) onları bu
    //Onları lıstele 
    //Çalışma sırasınıda prıotery/oncelıklere göre sırala

}
