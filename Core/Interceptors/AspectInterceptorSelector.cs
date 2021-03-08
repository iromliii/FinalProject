using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace Core.Interceptors
{
    public abstract partial class MethodInterception
    {
        public class AspectInterceptorSelector : IInterceptorSelector
        {//MethodInfo-reflectıondan gelır
            //tolıst sıstemlınq ten gelır
            public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
            {
                var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                    (true).ToList();
                var methodAttributes = type.GetMethod(method.Name)
                    .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
                classAttributes.AddRange(methodAttributes);
                //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));
                //Otomatık olarak tüm projelere loglama dahıl et
                //uzun sürelı logsuz projelere log eklenıcekse bu default olarak kullanılır

                return classAttributes.OrderBy(x => x.Priority).ToArray();
            }
        }

    }
    //Gıt classın attrıbutlerını gıt methodun attrıbute (valıdatıon,log,cache,performance,transıatıon) onları bu
    //Onları lıstele 
    //Çalışma sırasınıda prıotery/oncelıklere göre sırala

}
