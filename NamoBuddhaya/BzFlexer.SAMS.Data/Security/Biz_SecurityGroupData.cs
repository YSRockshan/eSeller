using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Biz.Security;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.Security
{
    public class Biz_SecurityGroupData
    {
        public void Create(Biz_SecurityGroup securityGroup)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_SecurityGroups.AddObject(securityGroup);
                _context.SaveChanges();
            }
        }
        public void Update(Biz_SecurityGroup securityGroup)
        {
            EntityKey key = null;
            Object original = null;

           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_SecurityGroups", securityGroup);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, securityGroup);
                }
                _context.SaveChanges();
            }
        }
        public void Delete(long securityGroupId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SecurityGroupList = from SecurityGroup in _context.Biz_SecurityGroups
                                        where SecurityGroup.Id == securityGroupId
                                        select SecurityGroup;
                foreach (Biz_SecurityGroup securityGroup in SecurityGroupList)
                {
                    _context.DeleteObject(securityGroup);
                }
                _context.SaveChanges();
            }
        }
        public Biz_SecurityGroup ReadSecurityGroupById(long securityGroupId)
        {
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var SecurityGroupList = from SecurityGroup in _context.Biz_SecurityGroups
                                        where SecurityGroup.Id == securityGroupId
                                        select SecurityGroup;
                foreach (Biz_SecurityGroup securityGroup in SecurityGroupList)
                {
                    return securityGroup;
                }
                return null;
            }
        }
        public List<Biz_SecurityGroup> ReadAllSecurityGroup()
        {
            List<Biz_SecurityGroup> SecurityGroupList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                try
                {
                    SecurityGroupList = (from SecurityGroup in _context.Biz_SecurityGroups select SecurityGroup).ToList();

                }
                catch (Exception exception)
                {

                }
            }
            return SecurityGroupList;
        }
        public List<Biz_SecurityGroup> ReadSecurityGroupByCode(string securityGroupCode)
        {
            List<Biz_SecurityGroup> SecurityGroupList = null;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                SecurityGroupList = (from SecurityGroup in _context.Biz_SecurityGroups where SecurityGroup.Code == securityGroupCode select SecurityGroup).ToList();
            }
            return SecurityGroupList;
        }

    }
}
