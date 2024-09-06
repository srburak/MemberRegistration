using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Core.Aspects.Postsharp.PerformanceAspects
{
    [PSerializable]
    public class PerformanceCounterAspect : OnMethodBoundaryAspect
    {
        private int _interval;
        [NonSerialized]
        private Stopwatch _stopwatch;

        public PerformanceCounterAspect(int interval = 5)
        {
            _interval = interval;
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            //if (!(_interval > 0))
            //{
            //    _interval = 5;
            //}
            _stopwatch = Activator.CreateInstance<Stopwatch>();
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            _stopwatch.Start();
        }

        public override void OnExit(MethodExecutionArgs args)
        {
            _stopwatch.Stop();
            if (_stopwatch.Elapsed.TotalSeconds > _interval)
            {
                Debug.WriteLine("Performance: {0}.{1}->>{2}",
                    args.Method.DeclaringType.FullName, args.Method.Name, _stopwatch.Elapsed.TotalSeconds);
            }
            _stopwatch.Reset();
            base.OnExit(args);
        }
    }
}
