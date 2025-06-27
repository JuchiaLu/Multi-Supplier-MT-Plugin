using MultiSupplierMTPlugin.Localized;
using System;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.CheckFailedDetailsLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class CheckFailedDetails : System.Windows.Forms.Form
    {
        private string _detailsMsg;

        public CheckFailedDetails(string detailsMsg)
        {
            InitializeComponent();

            this._detailsMsg = detailsMsg;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Localized();

            LoadOptions();
        }

        private void Localized()
        {
            Text = LLH.G(LLK.Form);

            buttonOK.Text = LLH.G(LLKC.ButtonOK); 
        }

        private void LoadOptions()
        {
            richTextBoxDetailsMsg.Text = _detailsMsg;
        }
    }

    class CheckFailedDetailsLocalizedKey : LocalizedKeyBase
    {
        public CheckFailedDetailsLocalizedKey(string name) : base(name)
        {
        }

        static CheckFailedDetailsLocalizedKey()
        {
            AutoInit<CheckFailedDetailsLocalizedKey>();
        }

        [LocalizedValue("396af704-df57-47e4-a3b3-d7efff0f59c0", "Failed Details", "失败详情")]
        public static CheckFailedDetailsLocalizedKey Form { get; private set; }
    }
}
