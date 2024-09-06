using log4net.Core;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Core.CrossCuttingConcerns.Logging.Log4Net
{
    [PSerializable]
    public class SerializableLogEvent
    {
        LoggingEvent _loggingEvent;

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }

        public string UserName => _loggingEvent.UserName;
        public object Message => _loggingEvent.MessageObject;
    }
}
