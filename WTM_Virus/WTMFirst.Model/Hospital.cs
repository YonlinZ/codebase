using System;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;

namespace WTMFirst.Model
{
    public enum HospitalLevel
    {
        [Display(Name = "三级")]
        Class3,
        [Display(Name = "二级")]
        Class2,
        [Display(Name = "一级")]
        Class1
    }
    public class Hospital : TopBasePoco
    {
        [Display(Name = "医院名称")]
        [Required(ErrorMessage="必填项")]
        public string Name { get; set; }
        [Required(ErrorMessage="必填项")]
        [Display(Name = "医院级别")]
        public HospitalLevel? Level { get; set; }
        [Display(Name = "医院地点")]
        public City Location { get; set; }
        [Display(Name = "医院地点")]
        [Required(ErrorMessage="必填项")]
        public Guid? LocationId { get; set; }
    }
}
