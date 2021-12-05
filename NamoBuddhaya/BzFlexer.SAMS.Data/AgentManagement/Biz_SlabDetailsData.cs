using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SlabDetailsData
    {
        public Boolean Create(Biz_SlabDetail slabDetail)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SlabDetails.AddObject(slabDetail);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_SlabDetail slabDetail)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SlabDetails", slabDetail);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, slabDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long slabDetailId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabDetailList = from SlabDetail in _context.Biz_SlabDetails
                                     where SlabDetail.Id == slabDetailId
                                     select SlabDetail;

                foreach (Biz_SlabDetail slabDetail in slabDetailList)
                {
                    _context.DeleteObject(slabDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        public Boolean DeleteSlabDetailBySlabId(long slabId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabDetailList = from SlabDetail in _context.Biz_SlabDetails
                                     where SlabDetail.IdSlab == slabId
                                     select SlabDetail;

                foreach (Biz_SlabDetail slabDetail in slabDetailList)
                {
                    _context.DeleteObject(slabDetail);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_SlabDetail ReadSlabDetailById(long slabDetailId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabDetailList = from SlabDetail in _context.Biz_SlabDetails
                                     where SlabDetail.Id == slabDetailId
                                     select SlabDetail;

                foreach (Biz_SlabDetail slabDetail in slabDetailList)
                {
                    return slabDetail;
                }
                return null;
            }
        }

        public List<Biz_SlabDetail> ReadAllSlabDetails()
        {
            List<Biz_SlabDetail> slabDetailList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                slabDetailList =
                    (from SlabDetail in _context.Biz_SlabDetails
                     select SlabDetail).ToList();
            }
            return slabDetailList;
        }
        public List<Biz_SlabDetail> ReadSlabDetailBySlabId(long slabId)
        {
            List<Biz_SlabDetail> slabDetails = new List<Biz_SlabDetail>();
            slabDetails = this.ReadAllSlabDetails();
            slabDetails = (from slabDetail in slabDetails where slabDetail.Id == slabId select slabDetail).ToList();
            return slabDetails;
        }
    }
}
