using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Attributes;

namespace WTMFirst.Model
{
    [MiddleTable]
    public class PatientVirus : TopBasePoco
    {
        public Patient Patient { get; set; }
        public int PatientId { get; set; }
        public Virus Virus { get; set; }
        public Guid VirusId { get; set; }
        [Display(Name = "患者")]
        public List<PatientVirus> Viruses { get; set; }
    }
}
