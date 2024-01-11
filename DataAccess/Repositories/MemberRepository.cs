using BusinessObject.Model;
using DataAccess.DAO;
using DataAccess.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        public Member Add(Member member)
        {
            return MemberDAO.getInstance().AddMember(member);
        }

        public bool Delete(int id)
        {
            return MemberDAO.getInstance().DeleteMember(id);
        }

        public Member Get(int id)
        {
            return MemberDAO.getInstance().GetMember(id);
        }

        public List<Member> GetAll()
        {
            return MemberDAO.getInstance().GetAllMembers();
        }

        public Member Update(Member member)
        {
            return MemberDAO.getInstance().UpdateMember(member);
        }
    }
}
