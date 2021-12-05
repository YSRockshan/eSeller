using System;
using System.Collections.Generic;
using System.Linq;
using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Data.Reference;
using System.Data;
using BzFlexer.SAMS.Biz.Connection;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_PriceBookData
    {
        public Boolean Create(Biz_PriceBook priceBook)
        {
            Boolean isSuccess = false;
        using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_PriceBooks.AddObject(priceBook);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

      public Boolean Update(Biz_PriceBook priceBook)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

        using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_PriceBooks", priceBook);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, priceBook);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long priceBookId)
        {
            Boolean isSuccess = false;
        using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var priceBookList = from PriceBook in _context.Biz_PriceBooks
                                    where PriceBook.Id == priceBookId
                                    select PriceBook;

                foreach (Biz_PriceBook priceBook in priceBookList)
                {
                    _context.DeleteObject(priceBook);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }
        




        //public List<Biz_PriceBook> GetAllPriceBooks()
        //{
        //    List<Biz_PriceBook> _priceBookList = null;
        //    List<Biz_PriceBook> _priceBooks = new List<Biz_PriceBook>();

        //   using (BizFlexerDBContext _context = new BizFlexerDBContext())
        //    {
        //        _priceBookList =
        //            (from Biz_PriceBook in _context.PriceBook
        //             select Biz_PriceBook).ToList();

        //        foreach (Biz_PriceBook priceBook in _priceBookList)
        //        {
        //            priceBook.Currency = new Biz_CurrencyData().ReadCurrencyById(Convert.ToInt64(priceBook.Id));
        //        }
        //    }
        //    return _priceBookList;
        //}
        public List<Biz_PriceBook> ReadAllPriceBooks()
        {
            List<Biz_PriceBook> _priceBookList = null;
            List<Biz_PriceBook> _priceBooks = new List<Biz_PriceBook>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _priceBookList =
                    (from Biz_PriceBook in _context.Biz_PriceBooks
                     select Biz_PriceBook).ToList();

                foreach (Biz_PriceBook priceBook in _priceBookList)
                {
                    priceBook.Biz_Currencies = new Biz_CurrencyData().ReadCurrencyById(Convert.ToInt16(priceBook.IdCurrency));
                }
            }
            return _priceBookList;
        }
        // Use in Biz_BranchesPriceBookData.ReadMappedBranchPriceBookByBranchId()
        public Biz_PriceBook ReadPriceBookById(long priceBookId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _priceBookList = from Biz_PriceBook in _context.Biz_PriceBooks
                                    where Biz_PriceBook.Id == priceBookId
                                    select Biz_PriceBook;

                foreach (Biz_PriceBook book in _priceBookList)
                {
                    return book;
                }
                return null;
            }
        }

        
        public List<Biz_PriceBook> ReadPriceBookByCode(string priceBookCode)
        {
            List<Biz_PriceBook> priceBookList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                priceBookList = (from PriceBook in _context.Biz_PriceBooks
                                 where PriceBook.Code == priceBookCode
                                 select PriceBook).ToList();
            }
            return priceBookList;
        }


        public List<Biz_PriceBook> ReadUnMappedBranchPriceBookByBranchId(long branchId)
        {
            List<Biz_PriceBook> priceBooks = new List<Biz_PriceBook>();
            priceBooks = this.ReadAllPriceBooks();

            List<Biz_BranchPriceBook> branchPriceBooks = new List<Biz_BranchPriceBook>();
            branchPriceBooks =new Biz_BranchesPriceBookData().ReadMappedBranchPriceBookByBranchId(branchId);

            List<long> PrBookId = new List<long>();
            PrBookId = (from id in priceBooks select id.Id).ToList();

            List<long> branchPrbookId = new List<long>();
            branchPrbookId = (from id in branchPriceBooks select id.Id).ToList();

            List<long> unMappedId = new List<long>();
            unMappedId = PrBookId.Except(branchPrbookId).ToList();

            List<Biz_PriceBook> priceBookList = new List<Biz_PriceBook>();

            priceBookList = (from priceBook in  this.ReadAllPriceBooks()
                             where unMappedId.Contains(priceBook.Id)
                             select priceBook).ToList();
            return priceBookList;
        }

        public List<Biz_PriceBook> ReadBranchWisePriceBook(long branchId)
        {
            List<Biz_BranchPriceBook> branchPriceBooks = new List<Biz_BranchPriceBook>();
            branchPriceBooks = new Biz_BranchesPriceBookData().ReadMappedBranchPriceBookByBranchId(branchId);

            List<long> branchPrbookId = new List<long>();
            branchPrbookId = (from id in branchPriceBooks select id.Id).ToList();

            List<Biz_PriceBook> priceBookList = new List<Biz_PriceBook>();
            priceBookList = (from priceBook in this.ReadAllPriceBooks()
                             where branchPrbookId.Contains(priceBook.Id)
                             select priceBook).ToList();
            return priceBookList;

        }
    }
}
