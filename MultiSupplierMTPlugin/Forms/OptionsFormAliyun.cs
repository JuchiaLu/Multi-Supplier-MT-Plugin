using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Windows.Forms;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class OptionsFormAliyun : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private bool checkSuccess = false;
        
        public OptionsFormAliyun(MultiSupplierMTOptions options, IEnvironment environment)
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
            Text = LLH.G(LLK.OptionFormAliyun);

            labelKeyId.Text = LLH.G(LLK.OptionFormAliyun_LabelKeyId);
            labelKeySecret.Text = LLH.G(LLK.OptionFormAliyun_LabelKeySecret);

            labelServiceType.Text = LLH.G(LLK.OptionFormAliyun_LabelServiceType);
            radioButtonGeneral.Text = LLH.G(LLK.OptionFormAliyun_RadioButtonGeneral);
            radioButtonProfessional.Text = LLH.G(LLK.OptionFormAliyun_RadioButtonProfessional);

            linkLabelCheck.Text = LLH.G(LLK.OptionForm_LinkLabelCheck);

            buttonOK.Text = LLH.G(LLK.OptionForm_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.OptionForm_ButtonCancel);
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
            checkSuccess = await ServiceAliyun.Check(serviceType, textBoxKeyId.Text, textBoxKeySecret.Text);

            if (!IsDisposed) 
            {
                if (checkSuccess)
                {
                    buttonOK.Enabled = true;
                    labelCheckResult.Text = LLH.G(LLK.OptionForm_LabelCheckResult_CheckedSuccees);
                }
                else
                {
                    labelCheckResult.Text = LLH.G(LLK.OptionForm_LabelCheckResult_CheckedFail);
                }

                setControlsEnabledState(true);
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
