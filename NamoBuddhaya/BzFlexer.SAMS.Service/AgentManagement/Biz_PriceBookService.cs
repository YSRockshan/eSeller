using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.AgentManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.AgentManagement
{
    public class Biz_PriceBookService
    {
        Biz_PriceBookData priceBookData = new Biz_PriceBookData();


        public Boolean CreatePriceBook(Biz_PriceBook priceBook)
        {
            Boolean isSuccess = false;
            if (priceBook != null)
            {
                isSuccess = priceBookData.Create(priceBook);
            }
            return isSuccess;
        }


        public Boolean UpdatePriceBook(Biz_PriceBook priceBook)
        {
            Boolean isSuccess = false;
            if (priceBook != null)
            {
                isSuccess = priceBookData.Update(priceBook);
            }
            return isSuccess;
        }


        public Boolean DeletePriceBook(long priceBookId)
        {
            Boolean isSuccess = false;
            if (priceBookId != 0)
            {
                isSuccess = priceBookData.Delete(priceBookId);
            }
            return isSuccess;
        }


        public Biz_PriceBook ReadPriceBookById(long priceBookId)
        {
            return priceBookData.ReadPriceBookById(priceBookId);
        }


        public List<Biz_PriceBook> ReadAllPriceBooks()
        {
            return priceBookData.ReadAllPriceBooks();
        }

        public List<Biz_PriceBook> ReadPriceBookByCode(string priceBookCode)
        {
            return priceBookData.ReadPriceBookByCode(priceBookCode);
        }

    }
}
