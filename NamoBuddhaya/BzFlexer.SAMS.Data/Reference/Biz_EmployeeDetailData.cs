using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Security;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public partial class Biz_EmployeeDetailData
    {

        public List<Biz_Stakeholder> ReadAllEmplyeeDetail()
        {
            List<Biz_Stakeholder> StakeholderList = null;
            List<Biz_Stakeholder> stakeholders = new List<Biz_Stakeholder>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                StakeholderList = (from Stakeholder in _context.Biz_Stakeholders where Stakeholder.IdStakeholderType==1 select Stakeholder).ToList();
                foreach (Biz_Stakeholder stakeholder in StakeholderList)
                {
                    stakeholder.Biz_StakeholderTypes = new Biz_StakeholderTypeSecurityGroupData().ReadStakeholderTypeById(stakeholder.Id);
                    stakeholders.Add(stakeholder);
                }
            }
            return stakeholders;
        }

        public List<Biz_Stakeholder> GetEmployeeDetailsByNic(string nicNo)
        {
            List<Biz_Stakeholder> _stakeholderList = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _stakeholderList = (from Biz_Stakeholder in _context.Biz_Stakeholders where Biz_Stakeholder.NIC == nicNo select Biz_Stakeholder).ToList();
            }
            return _stakeholderList;
        }
        public List<Biz_Stakeholder> GetEmployeeDetailsByStakeholderType(long stakeholderTypeId)
        {
            List<Biz_Stakeholder> _stakeholderList = null;
            List<Biz_Stakeholder> _stakeholders = new List<Biz_Stakeholder>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _stakeholderList = (from Biz_Stakeholder in _context.Biz_Stakeholders where Biz_Stakeholder.Id == stakeholderTypeId select Biz_Stakeholder).ToList();
                foreach (Biz_Stakeholder stakeholders in _stakeholderList)
                {
                    stakeholders.Biz_StakeholderTypes =
                        new Biz_StakeholderTypeData().ReadStakeholderTypesById(stakeholders.Id);
                    _stakeholders.Add(stakeholders);
                }
            }
            return _stakeholders;
        }
        public Biz_Stakeholder ReadEmployeeDetailsById(long stakeholderId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var StakeholderList = from Biz_Stakeholder in _context.Biz_Stakeholders
                                      where Biz_Stakeholder.Id == stakeholderId
                                      select Biz_Stakeholder;
                foreach (Biz_Stakeholder stakeholder in StakeholderList)
                {
                    return stakeholder;
                }
                return null;
            }
        }

        public void Create(Biz_Stakeholder stakeholder)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_Stakeholders.AddObject(stakeholder);
                _context.SaveChanges();
            }
        }


        public void Update(Biz_Stakeholder stakeholder)
        {
            EntityKey key = null;
            object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_Stakeholders", stakeholder);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, stakeholder);
                }
                _context.SaveChanges();
            }
        }

        public void Delete(long stakeholderId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var StakeholderList = from Stakeholder in _context.Biz_Stakeholders
                                      where Stakeholder.Id == stakeholderId
                                      select Stakeholder;
                foreach (Biz_Stakeholder stakeholder in StakeholderList)
                {
                    _context.DeleteObject(stakeholder);
                }
                _context.SaveChanges();
            }
        }

        public Biz_Stakeholder ReadEmployeeDetailById(long stakeholderId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var StakeholderList = from Stakeholder in _context.Biz_Stakeholders
                                      where Stakeholder.Id == stakeholderId
                                      select Stakeholder;
                foreach (Biz_Stakeholder stakeholder in StakeholderList)
                {
                    return stakeholder;
                }
                return null;
            }
        }

        public List<Biz_Stakeholder> ReadEmployeeDetailByNicNo(string nicNo)
        {
            List<Biz_Stakeholder> StakeholderList = null;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                StakeholderList = (from Stakeholder in _context.Biz_Stakeholders where Stakeholder.NIC == nicNo select Stakeholder).ToList();
            }
            return StakeholderList;
        }
        public List<Biz_Stakeholder> ReadEmployeeDetailByStakeholderTypeId(long stakeholderTypeId)
        {
            List<Biz_Stakeholder> stakeholderList = null;
            List<Biz_Stakeholder> stakeholders = new List<Biz_Stakeholder>();

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderList = (from Stakeholder in _context.Biz_Stakeholders where Stakeholder.IdStakeholderType == stakeholderTypeId select Stakeholder).ToList();
                foreach (Biz_Stakeholder stakeholder in stakeholderList)
                {
                    stakeholder.Biz_StakeholderTypes =
                        new Biz_StakeholderTypeData().ReadStakeholderTypesById(stakeholder.IdStakeholderType);
                    stakeholders.Add(stakeholder);
                }
            }
            return stakeholders;
        }




    }
}
