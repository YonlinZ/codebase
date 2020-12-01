using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using WTMFirst.Model;


namespace WTMFirst.ViewModel.VirusVMs
{
    public partial class VirusSearcher : BaseSearcher
    {
        [Display(Name = "病毒名称")]
        public String VirusName { get; set; }
        [Display(Name = "病毒代码")]
        public String VirusCode { get; set; }
        [Display(Name = "病毒种类")]
        public VirusTypeEnum? VirusType { get; set; }

        protected override void InitVM()
        {
        }

    }
}
