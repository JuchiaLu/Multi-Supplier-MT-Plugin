using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Forms;
using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin
{
    public partial class MultiSupplierMTOptionsForm : Form
    {
        private class ComboBoxItem
        {
            public string DisplayText { get; set; }
            public object Value { get; set; }

            public ComboBoxItem(string displayText, object value)
            {
                DisplayText = displayText;
                Value = value;
            }

            public override string ToString()
            {
                return DisplayText;
            }
        }

        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private Dictionary<string, string> serviceLocalizedNameDic = new Dictionary<string, string>();

        public MultiSupplierMTOptionsForm(MultiSupplierMTOptions options, IEnvironment environment)
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

            updateCheckBoxState();

            comboBoxServiceProvider.SelectedIndexChanged += new EventHandler(comboBoxServiceProvider_SelectedIndexChanged);
        }

        private void localized()
        {
            Text = LLH.G(LLK.Form);

            labelServiceProvider.Text = LLH.G(LLK.Form_LabelServiceProvider);

            serviceLocalizedNameDic = ServiceHelper.GetServiceList()
                .OrderBy(s => !s.IsBuiltIn())
                .ThenBy(s => getServiceLocalizedName(s.UniqueName()))
                .ToDictionary(
                    s => getServiceLocalizedName(s.UniqueName()),
                    s => s.UniqueName()
                );
            comboBoxServiceProvider.DataSource = new BindingSource(serviceLocalizedNameDic, null);
            comboBoxServiceProvider.DisplayMember = "Key";
            comboBoxServiceProvider.ValueMember = "Value";

            labelRequestType.Text = LLH.G(LLK.Form_LabelRequestType);
            //populateComboBoxWithEnum<RequestType>(comboBoxRequestType);

            checkBoxTagsToEnd.Text = LLH.G(LLK.Form_CheckBoxTagsToEnd);
            checkBoxNormalizeWhitespace.Text = LLH.G(LLK.Form_CheckBoxNormalizeWhitespace);
            
            linkLabelCustomRequestLimit.Text = LLH.G(LLK.Form_LinkLabelCustomRequestLimit); 
            linkLabelCustomDisplayName.Text = LLH.G(LLK.Form_LinkLabelCustomDisplayName);
            linkLabelStatsAndLog.Text = LLH.G(LLK.Form_LinkLabelStatsAndLog);
            linkLabelTranslateCache.Text = LLH.G(LLK.Form_LinkLabelTranslateCache);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.Form_ButtonCancel);
            buttonHelp.Text = LLH.G(LLK.Form_ButtonHelp);
        }

        private void loadOptions()
        {
            comboBoxServiceProvider.SelectedValue = options.GeneralSettings.CurrentServiceProvider;

            var service = ServiceHelper.GetService(options.GeneralSettings.CurrentServiceProvider);
            populateComboBoxRequestType(service.IsXmlSupported(), service.IsHtmlSupported());

            selectEnumValueInComboBox(comboBoxRequestType, options.GeneralSettings.RequestType);

            checkBoxTagsToEnd.Checked = options.GeneralSettings.InsertRequiredTagsToEnd;
            checkBoxNormalizeWhitespace.Checked = options.GeneralSettings.NormalizeWhitespaceAroundTags;

            checkBoxCustomRequestLimit.Checked = options.GeneralSettings.EnableCustomRequestLimit;
            checkBoxCustomDisplayName.Checked = options.GeneralSettings.EnableCustomDisplayName;
            checkBoxStatsAndLog.Checked = options.GeneralSettings.EnableStatsAndLog;
            checkBoxTranslateCache.Checked = options.GeneralSettings.EnableCache;
        }

        private string getServiceLocalizedName(string name)
        {
            if (LocalizedKeyEnumBase.TryFromName<LLK>("Form_ComboBoxServiceProvider_" + name, out var keyEnum))
            {
                return LLH.G(keyEnum);
            }
            else
            {
                return name;
            }
        }

        private void comboBoxServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServiceProvider.SelectedValue is string name)
            {
                MultiSupplierMTService service = ServiceHelper.GetService(name);
                
                populateComboBoxRequestType(service.IsXmlSupported(), service.IsHtmlSupported());
                selectEnumValueInComboBox(comboBoxRequestType, options.GeneralSettings.RequestType);

                options = service.ShowConfig(options, environment, this);

                if (service.IsAvailable(options))
                {
                    buttonOK.Enabled = true;
                }
                else
                {
                    buttonOK.Enabled = false;
                }
            }
        }

        private void comboBoxRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateCheckBoxState();
        }

        private void updateCheckBoxState()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxRequestType.SelectedItem;
            RequestType selectedRequestType = (RequestType)selectedItem.Value;

            bool checkBoxTagsToEndEnabled =
               selectedRequestType == RequestType.Plaintext
               || selectedRequestType == RequestType.OnlyFormattingWithXml
               || selectedRequestType == RequestType.OnlyFormattingWithHtml;

            if (checkBoxTagsToEndEnabled)
            {
                checkBoxTagsToEnd.Enabled = true;
                checkBoxTagsToEnd.Checked = options.GeneralSettings.InsertRequiredTagsToEnd;

                checkBoxNormalizeWhitespace.Enabled = false;
                checkBoxNormalizeWhitespace.Checked = false;
            }
            else
            {
                checkBoxNormalizeWhitespace.Enabled = true;
                checkBoxNormalizeWhitespace.Checked = options.GeneralSettings.NormalizeWhitespaceAroundTags;

                checkBoxTagsToEnd.Enabled = false;
                checkBoxTagsToEnd.Checked = false;
            }
            
        }

        private void populateComboBoxWithEnum<TEnum>(ComboBox comboBox) where TEnum : Enum
        {
            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                if (LocalizedKeyEnumBase.TryFromName<LLK>("Form_ComboBoxRequestType_" + value.ToString(), out var keyEnum))
                {
                    comboBox.Items.Add(new ComboBoxItem(LLH.G(keyEnum), value));
                }
                else
                {
                    comboBox.Items.Add(new ComboBoxItem(value.ToString(), value));
                }
            }
        }

        private void selectEnumValueInComboBox<TEnum>(ComboBox comboBox, TEnum value) where TEnum : Enum
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Value.Equals(value))
                {
                    comboBox.SelectedItem = item;
                    return;
                }
            }
            comboBox.SelectedIndex = 0;
        }

        private void populateComboBoxRequestType(bool xmlSupported, bool htmlSupported)
        {
            comboBoxRequestType.Items.Clear();

            if (xmlSupported && !htmlSupported)
            {
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_Plaintext), RequestType.Plaintext));
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_OnlyFormattingWithXml), RequestType.OnlyFormattingWithXml));
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_BothFormattingAndTagsWithXml), RequestType.BothFormattingAndTagsWithXml));
                comboBoxRequestType.SelectedIndex = 0;
            }
            else if (!xmlSupported && htmlSupported)
            {
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_Plaintext), RequestType.Plaintext));
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_OnlyFormattingWithHtml), RequestType.OnlyFormattingWithHtml));
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_BothFormattingAndTagsWithHtml), RequestType.BothFormattingAndTagsWithHtml));
                comboBoxRequestType.SelectedIndex = 0;
            }
            else if (!xmlSupported && !htmlSupported)
            {
                comboBoxRequestType.Items.Add(new ComboBoxItem(LLH.G(LLK.Form_ComboBoxRequestType_Plaintext), RequestType.Plaintext));
            }
            else if (xmlSupported && htmlSupported)
            {
                populateComboBoxWithEnum<RequestType>(comboBoxRequestType);
            }
        }

        private void linkLabelCustomRequestLimit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new FormCustomLimit(options, environment, (string)comboBoxServiceProvider.SelectedValue))
            {
                form.ShowDialog();
            }
        }

        private void linkLabelCustomDisplayName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new FormCustomDisplayName(options, environment))
            {
                form.ShowDialog();
            }
        }

        private void linkLabelStatsAndLog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new FormStatsAndLog(options, environment))
            {
                form.ShowDialog();
            }
        }

        private void linkLabelTranslateCache_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new FormTranslateCache(options, environment))
            {
                form.ShowDialog();
            }
        }

        private void buttonHelp_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/JuchiaLu/Multi-Supplier-MT-Plugin");
            }
            catch
            {
                // do nothing
            }
        }

        private void MultiSupplierMTOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                options.GeneralSettings.CurrentServiceProvider = (string)comboBoxServiceProvider.SelectedValue;

                ComboBoxItem selectedRequestTypeItem = (ComboBoxItem)comboBoxRequestType.SelectedItem;
                RequestType selectedRequestType = (RequestType)selectedRequestTypeItem.Value;
                options.GeneralSettings.RequestType = selectedRequestType;

                if (checkBoxTagsToEnd.Enabled)
                {
                    options.GeneralSettings.InsertRequiredTagsToEnd = checkBoxTagsToEnd.Checked;
                }
                else if (checkBoxNormalizeWhitespace.Enabled)
                {
                    options.GeneralSettings.NormalizeWhitespaceAroundTags = checkBoxNormalizeWhitespace.Checked;
                }

                options.GeneralSettings.EnableCustomRequestLimit = checkBoxCustomRequestLimit.Checked;
                options.GeneralSettings.EnableCustomDisplayName = checkBoxCustomDisplayName.Checked;
                options.GeneralSettings.EnableStatsAndLog = checkBoxStatsAndLog.Checked;
                options.GeneralSettings.EnableCache = checkBoxTranslateCache.Checked;

                var service = ServiceHelper.GetService(options.GeneralSettings.CurrentServiceProvider);
                if (!service.IsBatchSupported() &&
                    options.GeneralSettings.EnableCustomRequestLimit &&
                    options.GeneralSettings.MaxSegmentsPerRequest != 1)
                {
                    options.GeneralSettings.MaxSegmentsPerRequest = 1;
                }
            }
        }
    }
}
