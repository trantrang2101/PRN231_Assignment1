using BusinessObject.Model;

namespace DataAccess.DAO
{
    internal class MemberDAO
    {
        private static MemberDAO instance;
        private static StoreContext _storeContext;

        internal MemberDAO(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        internal static MemberDAO getInstance()
        {
            instance ??= new MemberDAO(new StoreContext());
            return instance;
        }

        internal List<Member> GetAllMembers() => _storeContext.Members.ToList();

        internal Member? GetMember(int memberId)
        {
            return _storeContext.Members.Where(m => m.MemberId == memberId).FirstOrDefault();
        }

        internal Member AddMember(Member member)
        {
            var newMember = _storeContext.Members.Add(member).Entity;
            _storeContext.SaveChanges();
            return newMember;
        }

        internal Member UpdateMember(Member member)
        {
            var updateMember = _storeContext.Members.Update(member).Entity;
            _storeContext.SaveChanges();
            return updateMember;
        }

        internal bool DeleteMember(int memberId)
        {
            var foundMember = _storeContext.Members.Where(m => m.MemberId == memberId).FirstOrDefault();
            if (foundMember != null) { return false; }
            Member m = _storeContext.Members.Remove(foundMember).Entity;
            var affectedRow = _storeContext.SaveChanges();
            return (affectedRow > 0);
        }
    }
}
