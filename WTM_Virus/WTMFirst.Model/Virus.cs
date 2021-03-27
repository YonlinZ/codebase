using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WTMFirst.Model
{
    public enum VirusTypeEnum
    {
        DNA,
        RNA
    }

    public class Virus : TopBasePoco
    {
        [Display(Name = "病毒名称")]
        [Required(ErrorMessage = "必填项")]
        public string VirusName { get; set; }
        [Display(Name = "病毒代码")]
        [Required(ErrorMessage = "必填项")]
        [StringLength(10, ErrorMessage = "病毒代码最多10个字符")]
        public string VirusCode { get; set; }
        [Display(Name = "病毒描述")]
        public string Remark { get; set; }
        [Display(Name = "病毒种类")]
        public VirusTypeEnum VirusType { get; set; }
    }
}
