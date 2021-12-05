using BzFlexer.SAMS.Biz.AgentManagement;
using BzFlexer.SAMS.Biz.Connection;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BzFlexer.SAMS.Data.AgentManagement
{
    public partial class Biz_MemberSalesAgentPositionsData
    {
        public Boolean Create(Biz_MemberSalesAgentPosition memberSalesAgentPosition)
        {
            Boolean isSuccess = false;
           using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                _context.Biz_MemberSalesAgentPositions.AddObject(memberSalesAgentPosition);
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Update(Biz_MemberSalesAgentPosition memberSalesAgentPosition)
        {
            EntityKey key = null;
            object original = null;
            Boolean isSuccess = false;

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                key = _context.CreateEntityKey("Biz_MemberSalesAgentPositions", memberSalesAgentPosition);
                if (_context.TryGetObjectByKey(key, out original))
                {
                    _context.ApplyCurrentValues(key.EntitySetName, memberSalesAgentPosition);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Boolean Delete(long memberSalesAgentPositionId)
        {
            Boolean isSuccess = false;
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberSalesAgentPositionList = from MemberSalesAgentPosition in _context.Biz_MemberSalesAgentPositions
                                                 where MemberSalesAgentPosition.Id == memberSalesAgentPositionId
                                                 select MemberSalesAgentPosition;

                foreach (Biz_MemberSalesAgentPosition memberSalesAgentPosition in memberSalesAgentPositionList)
                {
                    _context.DeleteObject(memberSalesAgentPosition);
                }
                _context.SaveChanges();
                isSuccess = true;
            }
            return isSuccess;
        }


        public Biz_MemberSalesAgentPosition GetMemberSalesAgentPositionById(long memberSalesAgentPositionId)
        {
             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                var memberSalesAgentPositionList = from MemberSalesAgentPosition in _context.Biz_MemberSalesAgentPositions
                                                 where MemberSalesAgentPosition.Id == memberSalesAgentPositionId
                                                 select MemberSalesAgentPosition;

                foreach (Biz_MemberSalesAgentPosition memberSalesAgentPosition in memberSalesAgentPositionList)
                {
                    return memberSalesAgentPosition;
                }
                return null;
            }
        }


        public List<Biz_MemberSalesAgentPosition> GetAllMemberSalesAgentPositions()
        {
            List<Biz_MemberSalesAgentPosition> memberSalesAgentPositionList = null;
            List<Biz_MemberSalesAgentPosition> memberSalesAgentPositions = new List<Biz_MemberSalesAgentPosition>();

             using (BizFlexerDBContext _context = new BizFlexerDBContext())
            {
                memberSalesAgentPositionList =
                    (from MemberSalesAgentPosition in _context.Biz_MemberSalesAgentPositions
                     select MemberSalesAgentPosition).ToList();
                foreach (Biz_MemberSalesAgentPosition memberSalesAgentPosition in memberSalesAgentPositionList)
                {
                    memberSalesAgentPosition.Biz_BranchSalesAgents = new Biz_BranchSelesAgentData().ReadBranchSelesAgentById(memberSalesAgentPosition.IdSalesAgent);
                    memberSalesAgentPosition.Biz_BranchSalesAgents.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(memberSalesAgentPosition.Biz_BranchSalesAgents.IdStakeholder);
                    memberSalesAgentPositions.Add(memberSalesAgentPosition);
                }
            }
            return memberSalesAgentPositions;
        }


        public List<Biz_BranchSalesAgent> UnMappedSalesAgents(long branchId)
        {
            List<Biz_BranchSalesAgent> branchSalesAgents = new List<Biz_BranchSalesAgent>();
            List<Biz_BranchSalesAgent> branchSalesAgentList = new List<Biz_BranchSalesAgent>();
            branchSalesAgents = new Biz_BranchSelesAgentData().ReadAllBranchSelesAgents();
            branchSalesAgents = (from brRep in branchSalesAgents where brRep.IdBranch == branchId select brRep).ToList();

            foreach (Biz_BranchSalesAgent branchSalesAgent in branchSalesAgents)
            {
                branchSalesAgent.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailById(branchSalesAgent.IdStakeholder);
                branchSalesAgentList.Add(branchSalesAgent);
            }
            return branchSalesAgentList;
        }

        public List<Biz_BranchSalesAgent> UnMappedSalesAgents(long branchId, long SalesAgentPositionId)
        {
            List<Biz_BranchSalesAgent> branchSalesAgents = new List<Biz_BranchSalesAgent>();
            List<Biz_BranchSalesAgent> branchSalesAgentList = new List<Biz_BranchSalesAgent>();
            List<Biz_BranchSalesAgent> branchSalesAgentListOriginal = new List<Biz_BranchSalesAgent>();
            List<Biz_MemberSalesAgentPosition> memberSalesAgentPositions = new List<Biz_MemberSalesAgentPosition>();

            branchSalesAgents = new Biz_BranchSelesAgentData().ReadAllBranchSelesAgents();
            branchSalesAgents = (from brRep in branchSalesAgents where brRep.IdBranch == branchId select brRep).ToList();
            memberSalesAgentPositions = this.MappedSalesAgents(branchId, SalesAgentPositionId);

            List<long> branchSalesAgentId = new List<long>();
            branchSalesAgentId = (from id in branchSalesAgents select id.Id).ToList();

            List<long> SalesAgentMappedId = new List<long>();
            SalesAgentMappedId = (from id in memberSalesAgentPositions select id.IdSalesAgent).ToList();

            List<long> BranchSalesAgentUnmappedId = new List<long>();
            BranchSalesAgentUnmappedId = branchSalesAgentId.Except(SalesAgentMappedId).ToList();

            branchSalesAgentListOriginal = (from brSalesAgent in new Biz_BranchSelesAgentData().ReadAllBranchSelesAgents()
                                            where
                                                BranchSalesAgentUnmappedId.Contains(brSalesAgent.Id)
                                            select brSalesAgent).ToList();
            foreach (Biz_BranchSalesAgent branchSalesAgent in branchSalesAgentListOriginal)
            {
                branchSalesAgent.Biz_Stakeholders = new Biz_EmployeeDetailData().ReadEmployeeDetailsById(branchSalesAgent.IdStakeholder);
                branchSalesAgentList.Add(branchSalesAgent);
            }
            return branchSalesAgentList;
        }

        public List<Biz_MemberSalesAgentPosition> MappedSalesAgents(long branchId, long SalesAgentPositionId)
        {
            List<Biz_MemberSalesAgentPosition> memberSalesAgentPositions = new List<Biz_MemberSalesAgentPosition>();
            List<Biz_MemberSalesAgentPosition> memberSalesAgentPositionList = new List<Biz_MemberSalesAgentPosition>();
            memberSalesAgentPositions = this.GetAllMemberSalesAgentPositions();

            if (branchId != null && SalesAgentPositionId != null)
            {
                memberSalesAgentPositions = (from repPosition in memberSalesAgentPositions
                                             where
                                                 repPosition.IdBranch == branchId && repPosition.IdSalesAgentPosition == SalesAgentPositionId
                                             select repPosition).ToList();
                foreach (Biz_MemberSalesAgentPosition memberSalesAgentPosition in memberSalesAgentPositions)
                {
                    memberSalesAgentPosition.Biz_BranchSalesAgents = new Biz_BranchSelesAgentData().ReadBranchSelesAgentById(memberSalesAgentPosition.IdSalesAgent);
                    memberSalesAgentPosition.Biz_BranchSalesAgents.Biz_Stakeholders =
                        new Biz_EmployeeDetailData().ReadEmployeeDetailsById(
                            memberSalesAgentPosition.Biz_BranchSalesAgents.IdStakeholder);
                    memberSalesAgentPositionList.Add(memberSalesAgentPosition);
                }
            }
            return memberSalesAgentPositionList;
        }

    }
}
