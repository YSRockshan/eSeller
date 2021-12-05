using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_SerialData
    {
        public Boolean Create(Biz_Serial serial)
        {
            Boolean isSuccess = false;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Serials.AddObject(serial);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_Serial serial)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Serials", serial);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, serial);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long serialId)
        {
            Boolean isSuccess = false;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var serialList = from Serial in _context.Biz_Serials
                                 where Serial.Id == serialId
                                 select Serial;

                foreach (Biz_Serial serial in serialList)
                {
                    _context.DeleteObject(serial);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_Serial ReadSerialById(long serialId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var serialList = from Serial in _context.Biz_Serials
                                 where Serial.Id == serialId
                                 select Serial;

                foreach (Biz_Serial serial in serialList)
                {
                    return serial;
                }
                return null;
            }
        }

       public List<Biz_Serial> ReadAllSerials()
        {
            List<Biz_Serial> serialList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                serialList =
                    (from Serial in _context.Biz_Serials
                     select Serial).ToList();
            }
            return serialList;
        }
        public Biz_Serial ReadSerialByCode(string serialCode)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var serialList = from Serial in _context.Biz_Serials
                                 where Serial.Code == serialCode
                                 select Serial;

                foreach (Biz_Serial serial in serialList)
                {
                    return serial;
                }
                return null;
            }
        }
    }
}
