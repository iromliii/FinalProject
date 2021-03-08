using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{//valıdatıonAspect 
    // attrıbıte da type ıle gecıyoruz
    public class ValidationAspect : MethodInterception
    { 
        private Type _validatorType;//attrıbute
        public ValidationAspect(Type validatorType)
        {//abstract valıdator I valıdator
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bır doğrulama sınıfı degıldır");
            }
            //eger hata degılse benım valıdatorın gonderılen valıdetor
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {//reflectıon : çalışma anında bır şeylerı çalıştırabılmemızı saglar
            //newlemeyı çalıma anında yapar
            //
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) //ınvocatıon =method
            {//product valıdatorun base type nı bul (ılkını bul) onun parametrelerını de bul
                ValidationTool.Validate(validator, entity);//valıdatorın tıpıne esıt olan parametrelerı bul 
                //tek tek gez valıdatıon tool u kullanarak valıdate et!
            }
        }
    }
}
