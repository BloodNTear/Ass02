using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.BusinessObject;
using DataAccess.IRepository;
namespace DataAccess.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private MemberManagementContext context = new MemberManagementContext();

        public void InitAdmin()
        {
            TblMember admin = context.GetDefaultUser();
            TblMember flag = getRow(admin.Email);
            if (flag == null)
            {
                Insert(admin);
            }
            else
            {

            }
        }
        public void Delete(TblMember member)
        {
            context.TblMembers.Remove(member);
            context.SaveChanges();

        }

        public List<TblMember> GetList()
        {
            return context.TblMembers.ToList();
        }

        public TblMember getRow(string tendangnhap)
        {
            TblMember member = context.TblMembers.FirstOrDefault(x => x.Email.Equals(tendangnhap));
            return member;
        }

        public TblMember GetRowByID(int memberID)
        {
            return context.TblMembers.FirstOrDefault(x => x.MemberId == memberID);
        }

        public void Insert(TblMember member)
        {
            var list = GetList();

            if (list.Count > 0)
            {
                var last = list[list.Count - 1];
                member.MemberId = last.MemberId + 1;
            }
            else
            {
                member.MemberId = 1;
            }

            context.TblMembers.Add(member);
            context.SaveChanges();
        }

        public void Update(TblMember member)
        {
            int memberId = member.MemberId;
            TblMember newmember = GetRowByID(memberId);
            if(newmember != null)
            {
                newmember.MemberId = member.MemberId;
                newmember.Password = member.Password;
                newmember.Email = member.Email;
                newmember.CompanyName = member.CompanyName;
                newmember.City = member.City;
                newmember.Country = member.Country;

                context.SaveChanges();
            }
        }
        
    }
}
