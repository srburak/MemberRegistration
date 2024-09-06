using MemberRegistration.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using MemberRegistration.Core.Aspects.Postsharp.ValidationAspects;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {

            CheckIfMemberExists(member);
            CheckIfUserValidFromKps(member);
            _memberDal.Add(member);

        }

        private void CheckIfUserValidFromKps(Member member)
        {
            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("User authentication failed.");
            }
        }

        private void CheckIfMemberExists(Member member)
        {
            if (_memberDal.Get(m => m.TcNo == member.TcNo) != null)
            {
                throw new Exception("This user has registered before");
            }
        }
    }
}
