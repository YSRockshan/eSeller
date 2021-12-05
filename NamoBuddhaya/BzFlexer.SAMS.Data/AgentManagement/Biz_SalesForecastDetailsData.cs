using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SalesForecastDetailsData
    {
        public void Crate(Biz_SalesForecastDetail salesForecastDetail)
        {
            try
            {
                using (BizFlexerDBContext _context = new BizFlexerDBContext())
                {
                    _context.Biz_SalesForecastDetails.AddObject(salesForecastDetail);
                    _context.SaveChanges();
                }
            }
            catch (Exception err)
            {

            }
        }


        public void Update(Biz_SalesForecastDetail salesForecastDetail)
        {
            EntityKey key = null;
            Object original = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesForecastDetails", salesForecastDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesForecastDetail);
                }
                _context.SaveChanges();
            }
        }


        public void Delete(long salesForecastDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesForecastDetailList = from SalesForecastDetail in _context.Biz_SalesForecastDetails
                                              where SalesForecastDetail.Id == salesForecastDetailId
                                              select SalesForecastDetail;
                foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetailList)
                {
                    _context.DeleteObject(salesForecastDetail);
                }
                _context.SaveChanges();
            }
        }


        public Biz_SalesForecastDetail ReadsalesForecastDetailbyId(long salesForecastDetailId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {

                var salesForecastDetailList = from SalesForecastDetail in _context.Biz_SalesForecastDetails
                                              where SalesForecastDetail.Id == salesForecastDetailId
                                              select SalesForecastDetail;
                foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetailList)
                {
                    return salesForecastDetail;
                }
                return null;
            }
        }

        public List<Biz_SalesForecastDetail> ReadAllSalesForecastDetail()
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = null;
            List<Biz_SalesForecastDetail> salesForecastDetailsList = new List<Biz_SalesForecastDetail>();
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesForecastDetailList =
                    (from salesForecastDetail in _context.Biz_SalesForecastDetails select salesForecastDetail).ToList();
                foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetailList)
                {
                    salesForecastDetail.Biz_SalesForecasts = new Biz_SalesForecastsData().ReadSalesForecastById(Convert.ToInt16(salesForecastDetail.IdSalesForecast));
                    salesForecastDetailsList.Add(salesForecastDetail);
                }
            }
            return salesForecastDetailsList;
        }

        public List<Biz_SalesForecastDetail> ReadMappedSalesForecastDetail(long salesForecastId)
        {
            List<Biz_SalesForecastDetail> salesForecastDetailList = null;
            List<Biz_SalesForecastDetail> salesForecastDetails = new List<Biz_SalesForecastDetail>();

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {

                salesForecastDetailList = (from SalesForecastDetail in _context.Biz_SalesForecastDetails
                                           where SalesForecastDetail.IdSalesForecast == salesForecastId
                                           select SalesForecastDetail).ToList();

                foreach (Biz_SalesForecastDetail salesForecastDetail in salesForecastDetailList)
                {
                    salesForecastDetail.Biz_Products =
                        new Biz_GeneralProductsData().ReadProductsById(Convert.ToInt16(salesForecastDetail.IdProduct));
                    salesForecastDetails.Add(salesForecastDetail);
                    //salesForecastDetail.UnitOfMeasure = new UnitOfMeasureData().GetUnitOfMeasureById(Convert.ToInt16(salesForecastDetail.UnitOfMeasureId));
                }
                return salesForecastDetails;
            }
        }

        public List<Biz_Product> ReadUnMappedtProduct(long salesForecastId)
        {
            List<Biz_Product> products = new List<Biz_Product>();
            products = new Biz_GeneralProductsData().ReadAllProduct();

            List<long> productListAllId = new List<long>();
            productListAllId = (from id in products select id.Id).ToList();

            List<Biz_SalesForecastDetail> productListMapped = new List<Biz_SalesForecastDetail>();
            productListMapped = this.ReadAllSalesForecastDetail();

            List<long> productListMappedId = new List<long>();
            productListMappedId = (from id in productListMapped select id.IdProduct).ToList();

            List<long> productLisunmappedId = new List<long>();
            productLisunmappedId = productListAllId.Except(productListMappedId).ToList();
            products = (from productss in new Biz_GeneralProductsData().ReadAllProduct()
                        where
                            productLisunmappedId.Contains(productss.Id)
                        select productss).ToList();
            return products;
        }

    }
}
