using MemberRegistration.Core.CrossCuttingConcerns.Logging.Log4Net;
using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Core.Aspects.Postsharp.ExceptionAspects
{
    [PSerializable]
    public class ExceptionLogAspect : OnMethodBoundaryAspect
    {
        [NonSerialized]
        private Type _loggerType;
        private LoggerService _loggerService;

        public ExceptionLogAspect(Type loggerType)
        {
            _loggerType = loggerType;
        }

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {
            if (_loggerType != null)
            {
                if (_loggerType.BaseType != typeof(LoggerService))
                {
                    throw new Exception("Wrong Logger Type");
                }
                _loggerService = (LoggerService)Activator.CreateInstance(_loggerType);
            }
            base.RuntimeInitialize(method);
        }

        public override void OnException(MethodExecutionArgs args)
        {
            if (_loggerService.IsInfoEnabled)
            {
                _loggerService.Error(args.Exception);
            }
        }
    }
}
