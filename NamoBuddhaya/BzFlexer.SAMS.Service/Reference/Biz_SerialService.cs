using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_SerialService
    {
        Biz_SerialData serialData = new Biz_SerialData();

      
        public Boolean CreateSerial(Biz_Serial serial)
        {
            Boolean isSuccess = false;
            if (serial != null)
            {
                isSuccess = serialData.Create(serial);
            }
            return isSuccess;
        }

       
        public Boolean UpdateSerial(Biz_Serial serial)
        {
            Boolean isSuccess = false;
            if (serial != null)
            {
                isSuccess = serialData.Update(serial);
            }
            return isSuccess;
        }


        public Boolean DeleteSerials(long serialId)
        {
            Boolean isSuccess = false;
            if (serialId != 0)
            {
                isSuccess = serialData.Delete(serialId);
            }
            return isSuccess;
        }


        public Biz_Serial ReadSerialById(long serialId)
        {
            return serialData.ReadSerialById(serialId);
        }


        public List<Biz_Serial> ReadAllSerials()
        {
            return serialData.ReadAllSerials();
        }

        public Biz_Serial ReadSerialByCode(string serialCode)
        {
            return serialData.ReadSerialByCode(serialCode);
        }

    }
}
