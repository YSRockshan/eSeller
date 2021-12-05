using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_CurrencyService
    {
        Biz_CurrencyData _currencyData = new Biz_CurrencyData();

        public void CreateCurrency(Biz_Currency currency)
        {
            _currencyData.Create(currency);
        }

        public void UpdateCurrency(Biz_Currency currency)
        {
            _currencyData.Update(currency);
        }

        public void DeleteCurrency(long currencyId)
        {
            _currencyData.Delete(currencyId);
        }

        public Biz_Currency ReadCurrencyById(long currencyId)
        {
            return _currencyData.ReadCurrencyById(currencyId);
        }

        public List<Biz_Currency> ReadAllCurrency()
        {
            return _currencyData.ReadAllCurrency();
        }

        public List<Biz_Currency> ReadCurrencyByCode(string currencyCode)
        {
            return _currencyData.ReadCurrencyByCode(currencyCode);
        }

    }
}
