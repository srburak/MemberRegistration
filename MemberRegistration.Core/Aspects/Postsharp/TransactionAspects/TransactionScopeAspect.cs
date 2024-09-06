using PostSharp.Aspects;
using PostSharp.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MemberRegistration.Core.Aspects.Postsharp.TransactionAspects
{
    [PSerializable]
    public class TransactionScopeAspect : OnMethodBoundaryAspect
    {
        TransactionScopeOption _option;
        public TransactionScopeAspect(TransactionScopeOption option)
        {
            _option = option;
        }

        public TransactionScopeAspect()
        {

        }

        public override void OnEntry(MethodExecutionArgs args)// methodun başında çalışacak
        {
            args.MethodExecutionTag = new TransactionScope(_option);
        }

        public override void OnSuccess(MethodExecutionArgs args)// method başarılı olursa çalışacak
        {
            ((TransactionScope)args.MethodExecutionTag).Complete();
        }

        public override void OnExit(MethodExecutionArgs args)// method başarılı olmazsa çalışacak
        {
            ((TransactionScope)args.MethodExecutionTag).Dispose();
        }
    }
}
