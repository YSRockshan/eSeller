using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SlabsData
    {
        public Boolean Create(Biz_Slab slab)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Slabs.AddObject(slab);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_Slab slab)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Slabs", slab);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, slab);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long slabId)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabList = from Slab in _context.Biz_Slabs
                               where Slab.Id == slabId
                               select Slab;

                foreach (Biz_Slab slab in slabList)
                {
                    _context.DeleteObject(slab);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_Slab ReadSlabById(long slabId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var slabList = from Slab in _context.Biz_Slabs
                               where Slab.Id == slabId
                               select Slab;

                foreach (Biz_Slab slab in slabList)
                {
                    return slab;
                }
                return null;
            }
        }


        public List<Biz_Slab> ReadAllSlabs()
        {
            List<Biz_Slab> slabList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                slabList =
                    (from Slab in _context.Biz_Slabs
                     select Slab).ToList();
            }
            return slabList;
        }

        public List<Biz_Slab> ReadSlabByCode(string slabCode)
        {
            List<Biz_Slab> slabList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                slabList =
                    (from Slab in _context.Biz_Slabs
                     where Slab.Code == slabCode
                     select Slab).ToList();
            }
            return slabList;
        }
    }
}
