using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WTMFirst.Model
{
    public class ControlCenter : TopBasePoco
    {
        [Display(Name = "中心名称")]
        [Required(ErrorMessage = "必填项")]
        public string Name { get; set; }
         
        [Display(Name = "中心地点")]
        public City Location { get; set; }
        [Display(Name = "中心地点")]
        [Required(ErrorMessage = "必填项")]
        public Guid? LocationId { get; set; }
    }
}
