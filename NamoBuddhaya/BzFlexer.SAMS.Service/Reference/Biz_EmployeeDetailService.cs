using BzFlexer.SAMS.Biz.Reference;
using BzFlexer.SAMS.Data.Reference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BzFlexer.SAMS.Service.Reference
{
    public class Biz_EmployeeDetailService
    {
        Biz_EmployeeDetailData employeeDetailData = new Biz_EmployeeDetailData();

        public void CreateEmployeeDetail(Biz_Stakeholder stakeholder)
        {
            employeeDetailData.Create(stakeholder);
        }

        public void UpdateEmployeeDetail(Biz_Stakeholder stakeholder)
        {
            employeeDetailData.Update(stakeholder);
        }

        public void DeleteEmployeeDetail(long stakeholderId)
        {
            employeeDetailData.Delete(stakeholderId);
        }

        public Biz_Stakeholder ReadEmployeeDetailById(long stakeholderId)
        {
            return employeeDetailData.ReadEmployeeDetailById(stakeholderId);
        }

        public List<Biz_Stakeholder> ReadAllEmplyeeDetail()
        {
            return employeeDetailData.ReadAllEmplyeeDetail();
        }

        public List<Biz_Stakeholder> ReadEmployeeDetailByNicNo(string nicNo)
        {
            return employeeDetailData.ReadEmployeeDetailByNicNo(nicNo);
        }

        public List<Biz_Stakeholder> ReadEmployeeDetailByStakeholderTypeId(long stakeholderTypeId)
        {
            return employeeDetailData.ReadEmployeeDetailByStakeholderTypeId(stakeholderTypeId);
        }

    }
}
