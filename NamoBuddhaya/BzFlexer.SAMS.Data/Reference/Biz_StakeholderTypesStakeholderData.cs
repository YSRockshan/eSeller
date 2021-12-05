using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Reference
{
    public class Biz_StakeholderTypesStakeholderData
    {
        public List<Biz_StakeholderTypeStakeholder> ReadAllStakeholderTypeStakeholders()
        {
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderList = null;
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderLists = new List<Biz_StakeholderTypeStakeholder>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeStakeholderList =
                    (from StakeholderTypeStakeholder in _context.Biz_StakeholderTypeStakeholders
                     select StakeholderTypeStakeholder).ToList();
                foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholderList)
                {
                    stakeholderTypeStakeholder.Biz_Stakeholders =
                        new Biz_EmployeeDetailData().ReadEmployeeDetailsById(stakeholderTypeStakeholder.Id);
                    stakeholderTypeStakeholder.Biz_StakeholderTypes =
                        new Biz_StakeholderTypeData().ReadStakeholderTypesById(stakeholderTypeStakeholder.Id);
                    stakeholderTypeStakeholderLists.Add(stakeholderTypeStakeholder);
                }
            }
            return stakeholderTypeStakeholderLists;
        }
        public Boolean Create(Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder)
        {
            Boolean isSuccess = false;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_StakeholderTypeStakeholders.AddObject(stakeholderTypeStakeholder);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

       public Boolean Update(Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_StakeholderTypeStakeholders", stakeholderTypeStakeholder);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, stakeholderTypeStakeholder);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

         public Boolean Delete(long stakeholderTypeStakeholderId)
        {
            Boolean isSuccess = false;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeStakeholderList = from StakeholderTypeStakeholder in _context.Biz_StakeholderTypeStakeholders
                                                     where StakeholderTypeStakeholder.Id == stakeholderTypeStakeholderId
                                                     select StakeholderTypeStakeholder;

                foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholderList)
                {
                    _context.DeleteObject(stakeholderTypeStakeholder);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }

         public Biz_StakeholderTypeStakeholder ReadStakeholderTypeStakeholderById(long stakeholderTypeStakeholderId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeStakeholderList = from StakeholderTypeStakeholder in _context.Biz_StakeholderTypeStakeholders
                                                     where StakeholderTypeStakeholder.Id == stakeholderTypeStakeholderId
                                                     select StakeholderTypeStakeholder;

                foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholderList)
                {
                    return stakeholderTypeStakeholder;
                }
                return null;
            }
        }

       

        public List<Biz_StakeholderTypeStakeholder> ReadMappedStakeholderTypeStakeholder(long stakeholderTypeId)
        {
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();
            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderList = new List<Biz_StakeholderTypeStakeholder>();
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeStakeholders = (from stakeholderTypeStakeholder in _context.Biz_StakeholderTypeStakeholders
                                               where stakeholderTypeStakeholder.IdStakeholderType == stakeholderTypeId
                                               select stakeholderTypeStakeholder).ToList();
                foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholders)
                {
                    stakeholderTypeStakeholder.Biz_Stakeholders =
                        new Biz_EmployeeDetailData().ReadEmployeeDetailById(stakeholderTypeStakeholder.IdStakeholder);
                    stakeholderTypeStakeholderList.Add(stakeholderTypeStakeholder);
                }
            }
            return stakeholderTypeStakeholderList;
        }

        public List<Biz_Stakeholder> ReadUnmappedStakeholderByStakeholderTypetId(long stakeholderTypeId)
        {
            List<Biz_Stakeholder> stakeholders = new List<Biz_Stakeholder>();
            List<Biz_Stakeholder> stakeholdersList = new List<Biz_Stakeholder>();
            stakeholders = new Biz_EmployeeDetailData().ReadAllEmplyeeDetail();

            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();
            stakeholderTypeStakeholders = this.ReadAllStakeholderTypeStakeholders();

            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholderList = new List<Biz_StakeholderTypeStakeholder>();
            stakeholderTypeStakeholderList = (from stakeholderTypeStakeholder in stakeholderTypeStakeholders
                                              where stakeholderTypeStakeholder.IdStakeholderType == stakeholderTypeId
                                              select stakeholderTypeStakeholder).ToList();
            
            stakeholdersList = (from stakeholder in stakeholders
                                where !(from typeStakeholder in stakeholderTypeStakeholderList select typeStakeholder.IdStakeholder).Contains(stakeholder.Id)
                                select stakeholder).ToList();
            return stakeholdersList;
        }

        public Biz_StakeholderTypeStakeholder ReadStakeholderTypeStakeholderByIdAndStkType(long stakeholderId, long stakeholderTypeId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeStakeholderList = from StakeholderTypeStakeholder in _context.Biz_StakeholderTypeStakeholders
                                                     where StakeholderTypeStakeholder.IdStakeholder == stakeholderId
                                                     && StakeholderTypeStakeholder.IdStakeholderType == stakeholderTypeId
                                                     select StakeholderTypeStakeholder;

                foreach (Biz_StakeholderTypeStakeholder stakeholderTypeStakeholder in stakeholderTypeStakeholderList)
                {
                    return stakeholderTypeStakeholder;
                }
                return null;
            }
        }

    }
}
