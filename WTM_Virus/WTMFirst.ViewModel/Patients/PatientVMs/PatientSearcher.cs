using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTMFirst.Model;


namespace WTMFirst.ViewModel.Patients.PatientVMs
{
    public partial class PatientSearcher : BaseSearcher
    {
        [Display(Name = "姓名")]
        public String PatientName { get; set; }
        [Display(Name = "身份证")]
        public String IdNumber { get; set; }
        [Display(Name = "性别")]
        public GenderEnum? Gender { get; set; }
        [Display(Name = "状态")]
        public PatientStatusEnum? Status { get; set; }
        public List<ComboSelectListItem> AllVirusess { get; set; }
        [Display(Name = "病毒")]
        public List<Guid> SelectedVirusesIDs { get; set; }

        protected override void InitVM()
        {
            AllVirusess = DC.Set<Virus>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.VirusName);
        }

    }
}
