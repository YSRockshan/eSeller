using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public class Biz_SalesAgentPositionData
    {
        public Boolean Create(Biz_SalesAgentPosition salesAgentPosition)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesAgentPositions.AddObject(salesAgentPosition);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

         public Boolean Update(Biz_SalesAgentPosition salesAgentPosition)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesAgentPositions", salesAgentPosition);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesAgentPosition);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long salesAgentPositionId)
        {
            Boolean isSuccess = false;
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesAgentPositionList = from salesAgentPosition in _context.Biz_SalesAgentPositions
                                             where salesAgentPosition.Id == salesAgentPositionId
                                           select salesAgentPosition;

                foreach (Biz_SalesAgentPosition salesAgentPosition in salesAgentPositionList)
                {
                    _context.DeleteObject(salesAgentPosition);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Biz_SalesAgentPosition ReadSalesAgentPositionById(long salesAgentPositionId)
        {
          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesAgentPositionList = from salesAgentPosition in _context.Biz_SalesAgentPositions
                                             where salesAgentPosition.Id == salesAgentPositionId
                                           select salesAgentPosition;

                foreach (Biz_SalesAgentPosition salesAgentPosition in salesAgentPositionList)
                {
                    return salesAgentPosition;
                }
                return null;
            }
        }

        public List<Biz_SalesAgentPosition> ReadAllsalesAgentPositions()
        {
            List<Biz_SalesAgentPosition> salesAgentPositionList = null;

          using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesAgentPositionList =
                    (from salesAgentPosition in _context.Biz_SalesAgentPositions
                     select salesAgentPosition).ToList();
            }
            return salesAgentPositionList;
        }
        public List<Biz_SalesAgentPosition> ReadSalesAgentPositionByCode(string salesRepPositionCode)
        {
            List<Biz_SalesAgentPosition> salesRepPositionList = null;

            using (BizFlexerDBContext context = new BizFlexerDBContext())
            {
                salesRepPositionList = (from SalesAgentPosition in context.Biz_SalesAgentPositions where SalesAgentPosition.Code == salesRepPositionCode select SalesAgentPosition).ToList();
            }
            return salesRepPositionList;
        }

    }
}
