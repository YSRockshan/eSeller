using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_PriceBookDetailsData
    {
        public Boolean Create(Biz_PriceBookDetail priceBookDetail)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_PriceBookDetails.AddObject(priceBookDetail);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_PriceBookDetail priceBookDetail)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_PriceBookDetails", priceBookDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, priceBookDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long priceBookDetailId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var priceBookDetailList = from PriceBookDetail in _context.Biz_PriceBookDetails
                                          where PriceBookDetail.Id == priceBookDetailId
                                          select PriceBookDetail;

                foreach (Biz_PriceBookDetail priceBookDetail in priceBookDetailList)
                {
                    _context.DeleteObject(priceBookDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_PriceBookDetail ReadPriceBookDetailById(long priceBookDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var priceBookDetailList = from PriceBookDetail in _context.Biz_PriceBookDetails
                                          where PriceBookDetail.Id == priceBookDetailId
                                          select PriceBookDetail;

                foreach (Biz_PriceBookDetail priceBookDetail in priceBookDetailList)
                {
                    return priceBookDetail;
                }
                return null;
            }
        }

        public List<Biz_PriceBookDetail> ReadAllPriceBookDetails()
        {
            List<Biz_PriceBookDetail> priceBookDetailList = null;
            List<Biz_PriceBookDetail> priceBookDetails = new List<Biz_PriceBookDetail>();

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                priceBookDetailList =
                    (from PriceBookDetail in _context.Biz_PriceBookDetails
                     select PriceBookDetail).ToList();
            }

            foreach (Biz_PriceBookDetail priceBookDetail in priceBookDetailList)
            {
                priceBookDetail.Biz_Products = new Biz_GeneralProductsData().ReadProductsById(Convert.ToInt16(priceBookDetail.IdProduct));
                priceBookDetails.Add(priceBookDetail);
            }
            return priceBookDetails;
        }

    }
}
