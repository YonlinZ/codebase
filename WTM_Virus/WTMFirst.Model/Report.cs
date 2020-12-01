using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WTMFirst.Model
{
    public class Report : BasePoco
    {
        [Required()]
        [Range(30,50, ErrorMessage ="提问必须在30到50之间")] 
        [Display(Name ="体温")]
        public float? Temprature { get;set;}
        [Display(Name ="备注")]
        public string Remark {get;set; }
        [Display(Name ="患者")]
        public Patient Patient { get;set;}
        [Display(Name ="患者")]
        [Required(ErrorMessage="必填项")]
        public int? PatientId { get;set;}

    }
}
