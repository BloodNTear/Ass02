using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.BusinessObject;
namespace DataAccess.IRepository
{
    public interface IProductRepository
    {
        List<TblProduct> GetList();
        TblProduct getRow(int productID);
        void Insert(TblProduct products);
        void Update(TblProduct products);
        void Delete(TblProduct products);
    }
}
