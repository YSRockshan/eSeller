using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_SalesAgentData
    {
        public Boolean Create(Biz_SalesAgent salesAgent)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SalesAgents.AddObject(salesAgent);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Update(Biz_SalesAgent salesAgent)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SalesAgents", salesAgent);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, salesAgent);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Boolean Delete(long salesAgentId)
        {
            Boolean isSuccess = false;
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesAgentList = from salesAgent in _context.Biz_SalesAgents
                                   where salesAgent.Id == salesAgentId
                                   select salesAgent;

                foreach (Biz_SalesAgent salesAgent in salesAgentList)
                {
                    _context.DeleteObject(salesAgent);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

        public Biz_SalesAgent ReadSalesAgentById(long salesAgentId)
        {
            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var salesAgentList = from salesAgent in _context.Biz_SalesAgents
                                   where salesAgent.Id == salesAgentId
                                   select salesAgent;

                foreach (Biz_SalesAgent salesAgent in salesAgentList)
                {
                    return salesAgent;
                }
                return null;
            }
        }

        public List<Biz_SalesAgent> ReadAllSalesAgents()
        {
            List<Biz_SalesAgent> salesAgentList = null;

            using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                salesAgentList =
                    (from salesAgent in _context.Biz_SalesAgents
                     select salesAgent).ToList();
            }
            return salesAgentList;
        }

    }
}
