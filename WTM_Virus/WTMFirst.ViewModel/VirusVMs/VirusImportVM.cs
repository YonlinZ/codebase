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
    public partial class VirusTemplateVM : BaseTemplateVM
    {
        [Display(Name = "病毒名称")]
        public ExcelPropety VirusName_Excel = ExcelPropety.CreateProperty<Virus>(x => x.VirusName);
        [Display(Name = "病毒代码")]
        public ExcelPropety VirusCode_Excel = ExcelPropety.CreateProperty<Virus>(x => x.VirusCode);
        [Display(Name = "病毒描述")]
        public ExcelPropety Remark_Excel = ExcelPropety.CreateProperty<Virus>(x => x.Remark);
        [Display(Name = "病毒种类")]
        public ExcelPropety VirusType_Excel = ExcelPropety.CreateProperty<Virus>(x => x.VirusType);

	    protected override void InitVM()
        {
        }

    }

    public class VirusImportVM : BaseImportVM<VirusTemplateVM, Virus>
    {

    }

}
