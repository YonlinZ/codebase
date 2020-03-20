using WindowsFormsApp1;

namespace System.Windows.Forms
{
    public static class ExtensionMethods
    {
        /// <summary>
        /// 在新 tab 页显示窗体
        /// </summary>
        /// <param name="form">在新 tab 页上显示的窗体</param>
        /// <param name="parentForm">form 的父窗体</param>
        /// <param name="refreshparentForm">新窗体关闭后是否刷新之前的窗体</param>
        public static void Show(this Form form, Form parentForm, bool refreshparentForm)
        {
            if (parentForm == null)
            {
                throw new ArgumentNullException(nameof(parentForm));
            }

            FormTabBase frmBase = null;
            do
            {
                if (parentForm is FormTabBase)
                {
                    frmBase = parentForm as FormTabBase;
                    break;
                }
            } while ((parentForm = parentForm.ParentForm) != null);

            if (frmBase == null)
            {
                throw new Exception("FormTabBase is null");
            }
            FormTabBase.AddFormTab(frmBase, form, refreshparentForm);
        }
    }

}
