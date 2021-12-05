using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_CurrencyData
    {
        public List<Biz_Currency> GetCurrenciesByCode(string currencyCode)
        {
            List<Biz_Currency> _currencyList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _currencyList = (from Biz_CurrencyData in _context.Biz_Currencies where Biz_CurrencyData.Code == currencyCode select Biz_CurrencyData).ToList();
            }
            return _currencyList;
        }

        public Biz_Currency ReadCurrencyById(long currencyId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var _currencyList = from BizCurrency in _context.Biz_Currencies where BizCurrency.Id == currencyId select BizCurrency;
                foreach (Biz_Currency currency in _currencyList)
                {
                    return currency;
                }
                return null;
            }
        }

        public void Create(Biz_Currency currency)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Currencies.AddObject(currency);
                _context.SaveChanges();
            }
        }

         public void Update(Biz_Currency currency)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Currencies", currency);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, currency);
                }
                _context.SaveChanges();
            }
        }

         public void Delete(long currencyId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var CurrencyList = from Currency in _context.Biz_Currencies
                                   where Currency.Id == currencyId
                                   select Currency;
                foreach (Biz_Currency currency in CurrencyList)
                {
                    _context.DeleteObject(currency);
                }
                _context.SaveChanges();
            }
        }

    

         public List<Biz_Currency> ReadAllCurrency()
        {
            List<Biz_Currency> CurrencyList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                CurrencyList = (from Currency in _context.Biz_Currencies select Currency).ToList();
            }
            return CurrencyList;
        }
        public List<Biz_Currency> ReadCurrencyByCode(string currencyCode)
        {
            List<Biz_Currency> _CurrencyList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _CurrencyList = (from Currency in _context.Biz_Currencies where Currency.Code == currencyCode select Currency).ToList();
            }
            return _CurrencyList;
        }
    }
}
