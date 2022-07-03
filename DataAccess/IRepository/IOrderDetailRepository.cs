using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.BusinessObject;
using DataAccess.IRepository;
namespace DataAccess.IRepository
{
    public interface IOrderDetailRepository
    {
        List<TblOrderDetail> GetList();
        TblOrderDetail getRow(int oddID);
        TblOrderDetail GetRowByID(int id);
        void Insert(TblOrderDetail od);
        void Update(TblOrderDetail od);
        void Delete(int id);
    }
}
