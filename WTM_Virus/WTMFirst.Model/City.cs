using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WalkingTec.Mvvm.Core;

namespace WTMFirst.Model
{
    public class City : TopBasePoco, ITreeData<City>
    {
        [Required(ErrorMessage ="必填项")]
        [Display(Name = "名称")]
        public string Name { get; set; }
        public List<City> Children { get; }
        [Display(Name = "父级")]
        public City Parent { get; }
        [Display(Name = "父级")]
        public Guid? ParentId { get; set; }
    }
}
