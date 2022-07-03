using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.BusinessObject;

namespace DataAccess.IRepository
{
    public interface IMemberRepository
    {
        List<TblMember> GetList();
        TblMember getRow(String tendangnhap);
        TblMember GetRowByID(int memberID);
        void Insert(TblMember member);
        void Update(TblMember member);
        void Delete(TblMember member); 
    }
}
