using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BusinessObject.BusinessObject;
using DataAccess.IRepository;

namespace DataAccess.Repository
{

    public class OrderRepository : IOrderRepository
    {
        private MemberManagementContext context = new MemberManagementContext();

        public void Delete(int id)
        {
            TblOrder target = GetRowByID(id);
            context.TblOrders.Remove(target);
            context.SaveChanges();
        }

        public List<TblOrder> GetList()
        {
            return context.TblOrders.ToList();
        }

        public TblOrder getRow(int odID)
        {
            TblOrder orders = context.TblOrders.Where(m => m.OrderId == odID).FirstOrDefault();
            return orders;
        }

        public TblOrder GetRowByID(int id)
        {
            TblOrder order = context.TblOrders.FirstOrDefault(x => x.OrderId == id);
            return order;
        }

        public void Insert(TblOrder od)
        {   
            if(od != null)
            {
                var list = GetList();

                if (list.Count > 0)
                {
                    var last = list[list.Count - 1];
                    od.OrderId = last.OrderId + 1;
                }
                else
                {
                    od.OrderId = 1;
                }
                context.TblOrders.Add(od);
                context.SaveChanges();
            }
        }

        public void Update(TblOrder od)
        {
            int id = od.OrderId;
            TblOrder newOrder = getRow(id);
            if (newOrder != null)
            {
                newOrder.OrderId = od.OrderId;
                newOrder.MemberId = od.MemberId;
                newOrder.OrderDate = od.OrderDate;
                newOrder.RequiredDate = od.RequiredDate;
                newOrder.ShippedDate = od.ShippedDate;
                newOrder.Freight = od.Freight;
                context.SaveChanges();
            }
        }

        public List<TblOrder> GetListReport(DateTime startDate, DateTime endDate)
        {
            return context.TblOrders.Where( m => m.OrderDate >= startDate && m.OrderDate <= endDate).OrderByDescending(m => m.OrderDate).ToList();
        }
    }
}
