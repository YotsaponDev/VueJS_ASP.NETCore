using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Models;

namespace Server.Models.Member
{
    public interface IMember
    {
        List<MemberEntity> GetAll();
        List<MemberEntity> GetMemberOnly();
        MemberEntity GetById(Guid id);
        MemberReturnViewModel GetByIdViaJWT(string authHeader);
        MemberEntity Create(MemberEntity model);
        MemberEntity Update(Guid id, MemberEntity modelUpdate);
        MemberEntity Delete(Guid id);
        object Login(MemberLoginViewModel model);
    }
}
