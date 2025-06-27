using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.ProviderdsCommon.Forms.CommonBottomControlLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.ProviderdsCommon.Forms
{
    partial class CommonBottomControl : UserControl
    {
        private string buttonHelpUrl;
        
        private Func<Task> linkLabelCheckCallBack; 

        private HashSet<Control> excludedControls;
        private ControlCollection includeControls;


        public CommonBottomControl()
        {
            InitializeComponent();

            linkLabelCheck.Text = LLH.G(LLK.LinkLabelCheck);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
            buttonHelp.Text = LLH.G(LLKC.ButtonHelp);
        }


        public void Init(Form form, bool buttonOkState, string buttonHelpUrl,  Func<Task> linkLabelCheckCallBack,
            ControlCollection includeControls, IEnumerable<Control> excludedControls = null)
        {
            progressBar.Visible = false;

            form.AcceptButton = buttonOK;
            form.CancelButton = buttonCancel;

            this.ButtonOkState = buttonOkState;
            this.buttonHelpUrl = buttonHelpUrl;

            this.linkLabelCheckCallBack = linkLabelCheckCallBack;

            this.includeControls = includeControls;
            this.excludedControls = new HashSet<Control>(excludedControls ?? Enumerable.Empty<Control>()) { this };
        }


        public bool ButtonOkState 
        { 
            get { return buttonOK.Enabled; }

            set { buttonOK.Enabled = value; }
        }

        public string FailedDetailsMsg { get; set; }


        public void CleanLabelResult()
        {
            labelSuccess.Text = "";
            linkLabelFailed.Text = "";
        }

        public void ShowLabelResult(bool success, string msg)
        {
            if (success)
            {                
                labelSuccess.Text = msg;
            }
            else 
            {
                linkLabelFailed.Text = msg;
            }

            labelSuccess.Visible = success;
            linkLabelFailed.Visible = !success;
        }


        public void ShowProgressBar()
        {
            progressBar.Visible = true;
        }

        public void HideProgressBar()
        {
            progressBar.Visible = false;
        }


        public Dictionary<Control, bool> DisableControls()
        {
            var originalControlStates = new Dictionary<Control, bool>();

            foreach (Control control in includeControls)
            {
                if (excludedControls.Contains(control))
                    continue;

                originalControlStates[control] = control.Enabled;
                control.Enabled = false;
            }

            originalControlStates[linkLabelCheck] = linkLabelCheck.Enabled;
            linkLabelCheck.Enabled = false;

            originalControlStates[buttonOK] = buttonOK.Enabled;
            buttonOK.Enabled = false;

            return originalControlStates;
        }

        public void RecoverControls(Dictionary<Control, bool> originalControlStates)
        {
            foreach (var kvp in originalControlStates)
            {
                    kvp.Key.Enabled = kvp.Value;
            }
        }

        private async void linkLabelCheck_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var originalControlStates = DisableControls();
            CleanLabelResult();
            ShowProgressBar();

            bool result = false;
            try
            {
                await linkLabelCheckCallBack();
                result = true;
            }
            catch (Exception ex)
            {
                FailedDetailsMsg = ex.Message;
            }

            if (!IsDisposed)
            {
                HideProgressBar();
                ShowLabelResult(result, result ? LLH.G(LLK.LabelResult_CheckedSuccees) : LLH.G(LLK.LabelResult_CheckedFail));
                RecoverControls(originalControlStates);

                ButtonOkState = result;
            }
        }

        private void linkLabelFailed_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(FailedDetailsMsg))
            {
                using (var form = new CheckFailedDetails(FailedDetailsMsg))
                {
                    form.ShowDialog();
                }
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(buttonHelpUrl);
            }
            catch
            {
                // do nothing
            }
        }
    }


    class CommonBottomControlLocalizedKey : LocalizedKeyBase
    {
        public CommonBottomControlLocalizedKey(string name) : base(name)
        {
        }

        static CommonBottomControlLocalizedKey()
        {
            AutoInit<CommonBottomControlLocalizedKey>();
        }

        [LocalizedValue("585eb308-fa75-4952-8889-692e54dbf0bf", "Check", "检测")]
        public static CommonBottomControlLocalizedKey LinkLabelCheck { get; private set; }

        [LocalizedValue("f5195f4d-e383-46cc-ae13-a2cb548b679e", "Checked succeess !", "检测成功！")]
        public static CommonBottomControlLocalizedKey LabelResult_CheckedSuccees { get; private set; }

        [LocalizedValue("98c68a7d-ea6a-4a0e-bb26-51ca50fb13d8", " Checked fail ! Click here for details", "检测失败！点此查看详情")]
        public static CommonBottomControlLocalizedKey LabelResult_CheckedFail { get; private set; }
    }
}
