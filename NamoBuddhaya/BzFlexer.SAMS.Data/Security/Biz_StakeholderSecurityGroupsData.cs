using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_StakeholderSecurityGroupsData
    {

        public void Create(Biz_StakeholderSecurityGroup stakeholderSecurityGroup)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_StakeholderSecurityGroups.AddObject(stakeholderSecurityGroup);
                _context.SaveChanges();
            }
        }
        public void Delete(long stakeholderId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderSecurityGroupList = from StakeholderSecurityGroup in _context.Biz_StakeholderSecurityGroups
                                                   where StakeholderSecurityGroup.IdStakeholder == stakeholderId
                                                   select StakeholderSecurityGroup;
                foreach (Biz_StakeholderSecurityGroup stakeholderSecurityGroup in stakeholderSecurityGroupList)
                {
                    _context.DeleteObject(stakeholderSecurityGroup);
                }
                _context.SaveChanges();
            }
        }


        public List<Biz_StakeholderType> DataBindTodropDownListStakeholderTypes(long securityGroupId)
        {
            List<Biz_StakeholderType> stakeholderTypeList = new List<Biz_StakeholderType>();

            stakeholderTypeList = new Biz_StakeholderTypeSecurityGroupData().ReadAllStakeholderType();

            List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroupList = new List<Biz_StakeholderTypeSecurityGroup>();

            stakeholderTypeSecurityGroupList = this.ReadAllSecurityGroupStakeholderTypesBySecirutyGroupId(securityGroupId);

            List<Biz_StakeholderType> stakeholderTypes = new List<Biz_StakeholderType>();
            stakeholderTypes = (from stakeholderType in stakeholderTypeList
                                where (from stakeholderTypeSecurityGroup in stakeholderTypeSecurityGroupList
                                       select stakeholderTypeSecurityGroup.IdStakeholderType).Contains(
                                           stakeholderType.Id)
                                select stakeholderType).ToList();
            return stakeholderTypes;
        }//->

       

        public List<Biz_StakeholderTypeSecurityGroup> ReadAllSecurityGroupStakeholderTypesBySecirutyGroupId(long securityGroupId)
        {
            List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroupList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeSecurityGroupList =
                    (from stakeholderTypeSecurityGroup in _context.Biz_StakeholderTypeSecurityGroups
                     where stakeholderTypeSecurityGroup.IdSecurityGroup == securityGroupId
                     select stakeholderTypeSecurityGroup).ToList();
            }
            return stakeholderTypeSecurityGroupList;
        }


        public List<Biz_Stakeholder> ReadUnMappedStakeholders(long securityGroupId, long stakeholderTypeId)
        {
            List<Biz_Stakeholder> allStakeholderList = new List<Biz_Stakeholder>();
            allStakeholderList = new Biz_EmployeeDetailData().ReadAllEmplyeeDetail();

            List<Biz_StakeholderTypeStakeholder> stakeholderTypeStakeholders = new List<Biz_StakeholderTypeStakeholder>();
            stakeholderTypeStakeholders = new Biz_StakeholderTypesStakeholderData().ReadAllStakeholderTypeStakeholders();
            stakeholderTypeStakeholders = (from stakeholderTypeStakeholder in stakeholderTypeStakeholders
                                           where stakeholderTypeStakeholder.IdStakeholderType == stakeholderTypeId
                                           select stakeholderTypeStakeholder).ToList();

            List<long> stakeholderTypeStakeholderStkId =
                (from id in stakeholderTypeStakeholders select id.IdStakeholder).ToList();

            List<Biz_Stakeholder> selectedStakeholderList = new List<Biz_Stakeholder>();
            selectedStakeholderList =
                (from stk in allStakeholderList where stakeholderTypeStakeholderStkId.Contains(stk.Id) select stk).
                    ToList();

            List<Biz_StakeholderSecurityGroup> stakeholderSecurityGroupBySecurityGroupIdAndStakeholderTypeId = new List<Biz_StakeholderSecurityGroup>();
            stakeholderSecurityGroupBySecurityGroupIdAndStakeholderTypeId = this.ReadMappedStakeholders(securityGroupId, stakeholderTypeId);

            List<Biz_Stakeholder> unMappedStakeholderList = new List<Biz_Stakeholder>();
            List<Biz_Stakeholder> unMappedStakeholders = new List<Biz_Stakeholder>();
            unMappedStakeholderList = (from stakeholder in selectedStakeholderList
                                       where
                                           !(from stakeholderSecurityGroup in
                                                 stakeholderSecurityGroupBySecurityGroupIdAndStakeholderTypeId
                                             select stakeholderSecurityGroup.IdStakeholder).Contains(
                                                 stakeholder.Id)
                                       select stakeholder).ToList();
            foreach (Biz_Stakeholder stakeholder in unMappedStakeholderList)
            {
                unMappedStakeholders.Add(stakeholder);
            }
            return unMappedStakeholders;


        }

        public List<Biz_StakeholderSecurityGroup> ReadMappedStakeholders(long securityGroupId, long stakeholderTypeId)
        {
            List<Biz_StakeholderSecurityGroup> stakeholderSecurityGroupList = new List<Biz_StakeholderSecurityGroup>();
            List<Biz_StakeholderSecurityGroup> stakeholderSecurityGroups = new List<Biz_StakeholderSecurityGroup>();

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderSecurityGroupList = (from stakeholderSecurityGroup in _context.Biz_StakeholderSecurityGroups
                                                where
                                                    stakeholderSecurityGroup.IdSecurityGroup == securityGroupId &&
                                                    stakeholderSecurityGroup.IdStakeholderType == stakeholderTypeId
                                                select stakeholderSecurityGroup).ToList();
                foreach (Biz_StakeholderSecurityGroup stakeholderSecurityGroup in stakeholderSecurityGroupList)
                {
                    try
                    {

                        stakeholderSecurityGroup.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(stakeholderSecurityGroup.IdStakeholder);

                    }
                    catch (Exception)
                    { }
                    stakeholderSecurityGroups.Add(stakeholderSecurityGroup);
                }
            }
            return stakeholderSecurityGroups;
        }
    }
}
