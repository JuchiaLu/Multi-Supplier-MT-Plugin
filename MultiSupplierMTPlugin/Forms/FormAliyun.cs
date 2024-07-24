using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Services;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormAliyun : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public FormAliyun(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            localized();

            loadOptions();

            bindOptionsChangedEvent();
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormAliyun);

            labelKeyId.Text = LLH.G(LLK.FormAliyun_LabelKeyId);
            labelKeySecret.Text = LLH.G(LLK.FormAliyun_LabelKeySecret);

            labelServiceType.Text = LLH.G(LLK.FormAliyun_LabelServiceType);
            radioButtonGeneral.Text = LLH.G(LLK.FormAliyun_RadioButtonGeneral);
            radioButtonProfessional.Text = LLH.G(LLK.FormAliyun_RadioButtonProfessional);

            linkLabelCheck.Text = LLH.G(LLK.Form_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            textBoxKeyId.Text = options.SecureSettings.AliyunSecureOptions.AccessKeyId;
            textBoxKeySecret.Text = options.SecureSettings.AliyunSecureOptions.AccessKeySecret;

            if ("general".Equals(options.GeneralSettings.AliyunGeneralOptions.ServiceType))
            {
                radioButtonGeneral.Checked = true;
            }
            else
            {
                radioButtonProfessional.Checked = true;
            }

            buttonOK.Enabled = options.GeneralSettings.AliyunGeneralOptions.Checked;
        }

        private void bindOptionsChangedEvent()
        {
            void onOptionsChanged(object sender, EventArgs e)
            {
                buttonOK.Enabled = false;
            }

            foreach (Control control in Controls)
            {
                if (control is TextBox textBox)
                {
                    textBox.TextChanged += onOptionsChanged;
                }
                else if (control is RadioButton radioButton)
                {
                    radioButton.CheckedChanged += onOptionsChanged;
                }
            }
        }

        private async void linkLabelCheck_Click(object sender, LinkLabelLinkClickedEventArgs e)
        {
            void setControlsEnabledState(bool enabled)
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox || control is RadioButton || control is LinkLabel)
                    {
                        control.Enabled = enabled;
                    }
                }

                progressBar.Visible = !enabled;
            }

            setControlsEnabledState(false);

            labelCheckResult.Text = "";
            buttonOK.Enabled = false;

            string serviceType = radioButtonGeneral.Checked ? "general" : "ecommerce";
            checkSuccess = await Aliyun.Check(serviceType, textBoxKeyId.Text, textBoxKeySecret.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LLH.G(LLK.Form_LabelCheckResult_CheckedSuccees);
                }
                else
                {
                    labelCheckResult.Text = LLH.G(LLK.Form_LabelCheckResult_CheckedFail);
                }

                setControlsEnabledState(true);
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://www.aliyun.com/product/ai/base_alimt");
            }
            catch 
            {
                // do nothing
            }
        }

        private void onFormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK && checkSuccess)
            {
                options.SecureSettings.AliyunSecureOptions.AccessKeyId = textBoxKeyId.Text;
                options.SecureSettings.AliyunSecureOptions.AccessKeySecret = textBoxKeySecret.Text;
                options.GeneralSettings.AliyunGeneralOptions.ServiceType = radioButtonGeneral.Checked ? "general" : "ecommerce";
                options.GeneralSettings.AliyunGeneralOptions.Checked = true;
            }
        }
    }
}
