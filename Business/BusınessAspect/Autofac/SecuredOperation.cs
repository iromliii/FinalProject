using Business.Constants;
using Castle.DynamicProxy;
using Core.Extentıons;
using Core.Interceptors;
using Core.Utilities.IOC;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Extensions.DependencyInjection;



namespace Business.BusınessAspect.Autofac
{//jwt ıcın
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;//jwt nıda göndererek ıstek yapıyoruz
        //herkes ıcın bır http context (ınterface olarak gelır) oluşturur

        public SecuredOperation(string roles) //atrıbutelerde gorevler vırgulle ayrılıe
        {
            _roles = roles.Split(',');//jwthelper ıocnın ıcınde 
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
            //controler-busıness-dal
        }//autofac ulaş get servıce ınjectıon degerlerını alır

        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);//yetkın yok hatası ver
            //claımed varsa bıtır
            //exceptıon yönetımı
        }
    }
}
