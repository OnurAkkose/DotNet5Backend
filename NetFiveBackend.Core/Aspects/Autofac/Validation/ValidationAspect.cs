using CAFEMENU.Core.CrossCuttingConcerns.Validation;
using CAFEMENU.Core.Utilities.Interceptors;
using CAFEMENU.Core.Utilities.Messages;
using Castle.DynamicProxy;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAFEMENU.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))// gelen nesne bir IValidator tipinde mi?
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType; 
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//(Reflection) çalışma anında bir instance oluştur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];// tipini al
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);// argümanların tipini kes
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
