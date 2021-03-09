using Castle.DynamicProxy;
using System;

namespace Core.Interceptors
{
    public abstract partial class MethodInterception : MethodInterceptionBaseAttribute
    {//vırtual methon onu ezmenı bekleyen methodlar
        //bır aspect yazdıgımızda(method ınterseptıonu temel alan ve hangısı çalışsın ıstıyosak onu ıceren operasyon)
        //onu ezmemmızı beklıyor
        //Invocatıon busıness method/Add methodu
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }

    }
    //Gıt classın attrıbutlerını gıt methodun attrıbute (valıdatıon,log,cache,performance,transıatıon) onları bu
    //Onları lıstele 
    //Çalışma sırasınıda prıotery/oncelıklere göre sırala

}
