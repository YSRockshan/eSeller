using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SlabValueDetailsData
    {
        public  Boolean Create(Biz_SlabValueDetail slabValueDetail)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SlabValueDetails.AddObject(slabValueDetail);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Boolean Update(Biz_SlabValueDetail slabValueDetail)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SlabValueDetails", slabValueDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, slabValueDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Boolean Delete(long slabValueDetailId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabValueDetailList = from SlabValueDetail in _context.Biz_SlabValueDetails
                                          where SlabValueDetail.ld == slabValueDetailId
                                          select SlabValueDetail;

                foreach (Biz_SlabValueDetail slabValueDetail in slabValueDetailList)
                {
                    _context.DeleteObject(slabValueDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Biz_SlabValueDetail ReadSlabValueDetailById(long slabValueDetailId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabValueDetailList = from SlabValueDetail in _context.Biz_SlabValueDetails
                                          where SlabValueDetail.ld == slabValueDetailId
                                          select SlabValueDetail;

                foreach (Biz_SlabValueDetail slabValueDetail in slabValueDetailList)
                {
                    return slabValueDetail;
                }
                return null;
            }
        }
        public List<Biz_SlabValueDetail> ReadAllSlabValueDetails()
        {
            List<Biz_SlabValueDetail> slabValueDetailList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                slabValueDetailList =
                    (from SlabValueDetail in _context.Biz_SlabValueDetails
                     select SlabValueDetail).ToList();
            }
            return slabValueDetailList;
        }

    }
}
