using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.BusinessObject;
namespace DataAccess.IRepository
{
    public interface IOrderRepository
    {
        List<TblOrder> GetList();
        TblOrder getRow(int odID);
        void Insert(TblOrder od);
        void Update(TblOrder od);
        void Delete(int id);
    }
}
