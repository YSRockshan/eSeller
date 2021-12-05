using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Biz.Security;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_StakeholderTypeSecurityGroupData
    {
        public void Create(Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_StakeholderTypeSecurityGroups.AddObject(stakeholderTypeSecurityGroup);
                _context.SaveChanges();
            }
        }
        public void Delete(long stakeholderTypeId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeSecurityGroupList =
                      from stakeholderTypeSecurityGroup in _context.Biz_StakeholderTypeSecurityGroups
                      where stakeholderTypeSecurityGroup.IdStakeholderType == stakeholderTypeId
                      select stakeholderTypeSecurityGroup;

                foreach (Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup in stakeholderTypeSecurityGroupList)
                {
                    _context.DeleteObject(stakeholderTypeSecurityGroup);
                }
                _context.SaveChanges();
            }
        }
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
        //used in data. sh sec grp 
        public List<Biz_StakeholderType> ReadAllStakeholderType()
        {
            List<Biz_StakeholderType> stakeholderTypeList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeList = (from StakeholderType in _context.Biz_StakeholderTypes select StakeholderType).ToList();
            }
            return stakeholderTypeList;
        }//used in data. sh sec grp 
        public Biz_StakeholderType ReadStakeholderTypeById(long stakeholderTypeId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var stakeholderTypeList = from StakeholderType in _context.Biz_StakeholderTypes where StakeholderType.Id == stakeholderTypeId select StakeholderType;
                foreach (Biz_StakeholderType stakeholderType in stakeholderTypeList)
                {
                    return stakeholderType;
                }
                return null;
            }
        }


        public List<Biz_StakeholderTypeSecurityGroup> ReadMappedSecurityGroupStakeholderType(long securityGroupId)
        {
            List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroupList = null;
            List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroups = new List<Biz_StakeholderTypeSecurityGroup>();
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                stakeholderTypeSecurityGroupList =
                    (from stakeholderTypeSecurityGroup in _context.Biz_StakeholderTypeSecurityGroups
                     where stakeholderTypeSecurityGroup.IdSecurityGroup == securityGroupId
                     select stakeholderTypeSecurityGroup).ToList();
            }
            foreach (Biz_StakeholderTypeSecurityGroup stakeholderTypeSecurityGroup in stakeholderTypeSecurityGroupList)
            {
                try
                {
                    stakeholderTypeSecurityGroup.Biz_StakeholderTypes = new Biz_StakeholderTypeData().ReadStakeholderTypesById(stakeholderTypeSecurityGroup.IdStakeholderType);
                }
                catch (Exception)
                { }
                stakeholderTypeSecurityGroups.Add(stakeholderTypeSecurityGroup);
            }
            return stakeholderTypeSecurityGroups;
        }

        public List<Biz_StakeholderType> ReadUnMappedSecurityGroupStakeholderType(long securityGroupId)
        {
            List<Biz_StakeholderType> stakeholderTypeList = new List<Biz_StakeholderType>();
            // Biz_StakeholderTypeService stakeholderTypeService = new Biz_StakeholderTypeService();

            stakeholderTypeList = new Biz_StakeholderTypeSecurityGroupData().ReadAllStakeholderType();

            List<Biz_StakeholderTypeSecurityGroup> stakeholderTypeSecurityGroupList = new List<Biz_StakeholderTypeSecurityGroup>();
           
            stakeholderTypeSecurityGroupList =
                this.ReadMappedSecurityGroupStakeholderType(securityGroupId);

            List<Biz_StakeholderType> stakeholderTypes = new List<Biz_StakeholderType>();

            stakeholderTypes = (from stakeholderType in stakeholderTypeList where !(from stakeholderTypeSecurityGroup in stakeholderTypeSecurityGroupList select stakeholderTypeSecurityGroup.IdStakeholderType).Contains(stakeholderType.Id) select stakeholderType).ToList();

            return stakeholderTypes;

        }

     

    }
}
