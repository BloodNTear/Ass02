using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject.BusinessObject;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MemberManagementContext context = new MemberManagementContext();

        public void Delete(TblProduct member)
        {
            context.TblProducts.Remove(member);
            context.SaveChanges();
        }

        public List<TblProduct> GetList()
        {
            return context.TblProducts.ToList();
        }

        public List<TblProduct> getListSearch(int productID)
        {
            return context.TblProducts.Where(m => m.ProductId == productID).ToList();
        }

        public TblProduct getRow(int productID)
        {
            TblProduct product = context.TblProducts.FirstOrDefault(x => x.ProductId == productID);
            return product;
        }

        public TblProduct getRowCategory(int categoryID)
        {
            TblProduct product = context.TblProducts.Where(m => m.CategoryId == categoryID).FirstOrDefault();
            return product;
        }

        public void Insert(TblProduct product)
        {

            var list = GetList();
            
            if(list.Count > 0)
            {
                var last = list[list.Count - 1];
                product.ProductId = last.ProductId + 1;
            } else
            {
                product.ProductId = 1;
            }
            context.TblProducts.Add(product);
            context.SaveChanges();
        }

        public void Update(TblProduct product)
        {
            int id = product.ProductId;
            TblProduct newproduct = getRow(id);
            if (newproduct != null)
            {
                newproduct.ProductName = product.ProductName;
                newproduct.CategoryId = product.CategoryId;
                newproduct.Weight = product.Weight;
                newproduct.UnitPrice = product.UnitPrice;
                newproduct.UnitslnStock = product.UnitslnStock;
                context.TblProducts.Update(newproduct);
                context.SaveChanges();
            }

        }

        public List<TblProduct> SearchByName(string name)
        {
            List<TblProduct> list = new List<TblProduct>();
            try
            {
                return context.TblProducts.Where<TblProduct>(x => x.ProductName.Contains(name)).ToList();
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TblProduct> SearchbyPrice(decimal price)
        {
            List<TblProduct> list = new List<TblProduct>();
            try
            {
                return context.TblProducts.Where<TblProduct>(x => x.UnitPrice == price).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<TblProduct> SearchbyStock(int stock)
        {
            List<TblProduct> list = new List<TblProduct>();
            try
            {
                return context.TblProducts.Where<TblProduct>(x => x.UnitslnStock == stock).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
