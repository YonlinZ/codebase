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
    public partial class PatientBatchVM : BaseBatchVM<Patient, Patient_BatchEdit>
    {
        public PatientBatchVM()
        {
            ListVM = new PatientListVM();
            LinkedVM = new Patient_BatchEdit();
        }

    }

	/// <summary>
    /// Class to define batch edit fields
    /// </summary>
    public class Patient_BatchEdit : BaseVM
    {

        protected override void InitVM()
        {
        }

    }

}
