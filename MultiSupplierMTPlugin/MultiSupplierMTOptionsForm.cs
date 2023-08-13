using MultiSupplierMTPlugin.Service;
using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace MultiSupplierMTPlugin
{
    public partial class MultiSupplierMTOptionsForm : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;

        private Dictionary<string, string> serviceLocalizedTextMap = new Dictionary<string, string>();

        public MultiSupplierMTOptionsForm(MultiSupplierMTOptions options, IEnvironment environment)
        {
            InitializeComponent();

            this.options = options;
            this.environment = environment;

            localizeContent();
        }

        private void localizeContent()
        {
            this.Text = LocalizationHelper.Instance.GetResourceString("OptionForm");

            this.labelServiceProvider.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.labelServiceProvider");
            foreach (string name in MtServiceHolder.GetUniqueNameList())
            {
                serviceLocalizedTextMap.Add(LocalizationHelper.Instance.GetResourceString("OptionForm.comboBoxServiceProvider." + name), name);
            }
            this.comboBoxServiceProvider.DataSource = new BindingSource(serviceLocalizedTextMap, null);
            this.comboBoxServiceProvider.DisplayMember = "Key";
            this.comboBoxServiceProvider.ValueMember = "Value";

            this.labelRequestType.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.labelRequestType");
            populateComboBoxWithEnum<RequestType>(this.comboBoxRequestType);

            this.checkBoxTagsToEnd.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.checkBoxTagsToEnd");
            this.checkBoxNormalizeWhitespace.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.checkBoxNormalizeWhitespace");

            this.checkBoxTranslateCache.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.checkBoxTranslateCache");

            this.buttonOK.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.buttonOK");
            this.buttonCancel.Text = LocalizationHelper.Instance.GetResourceString("OptionForm.buttonCancel");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            comboBoxServiceProvider.SelectedValue = options.GeneralSettings.CurrentServiceProvider;
            comboBoxServiceProvider.SelectedIndexChanged += new EventHandler(comboBoxServiceProvider_SelectedIndexChanged);

            selectEnumValueInComboBox(comboBoxRequestType, options.GeneralSettings.RequestType);

            checkBoxTagsToEnd.Checked = options.GeneralSettings.InsertRequiredTagsToEnd;
            checkBoxNormalizeWhitespace.Checked = options.GeneralSettings.NormalizeWhitespaceAroundTags;
            
            checkBoxTranslateCache.Checked = options.GeneralSettings.EnableCache;

            setCheckBoxState();
        }
        
        private void comboBoxServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServiceProvider.SelectedValue is string name)
            {
                MultiSupplierMTServiceInterface serviceProvider = MtServiceHolder.GetService(name);

                options = serviceProvider.ShowConfig(options, environment, this);

                if (serviceProvider.IsAvailable(options))
                    this.buttonOK.Enabled = true;
                else
                    this.buttonOK.Enabled = false;
            }
        }

        private void comboBoxRequestType_SelectedIndexChanged(object sender, EventArgs e)
        {
            setCheckBoxState();
        }

        private void MultiSupplierMTOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.OK)
            {
                options.GeneralSettings.CurrentServiceProvider = (string)this.comboBoxServiceProvider.SelectedValue;

                ComboBoxItem selectedRequestTypeItem = (ComboBoxItem)this.comboBoxRequestType.SelectedItem;
                RequestType selectedRequestType = (RequestType)selectedRequestTypeItem.Value;
                options.GeneralSettings.RequestType = selectedRequestType;

                options.GeneralSettings.InsertRequiredTagsToEnd = checkBoxTagsToEnd.Checked;
                options.GeneralSettings.NormalizeWhitespaceAroundTags = checkBoxNormalizeWhitespace.Checked;

                options.GeneralSettings.EnableCache = checkBoxTranslateCache.Checked;
            }
        }

        private void setCheckBoxState()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)this.comboBoxRequestType.SelectedItem;
            RequestType selectedRequestType = (RequestType)selectedItem.Value;

            checkBoxTagsToEnd.Enabled =
               selectedRequestType == RequestType.Plaintext
               || selectedRequestType == RequestType.OnlyFormattingWithXml
               || selectedRequestType == RequestType.OnlyFormattingWithHtml;

            checkBoxNormalizeWhitespace.Enabled =
                selectedRequestType == RequestType.BothFormattingAndTagsWithXml
                || selectedRequestType == RequestType.BothFormattingAndTagsWithHtml;
        }

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

        private void populateComboBoxWithEnum<TEnum>(ComboBox comboBox) where TEnum : Enum
        {
            comboBox.Items.Clear();

            foreach (TEnum value in Enum.GetValues(typeof(TEnum)))
            {
                string localizedText = LocalizationHelper.Instance.GetResourceString("OptionForm.comboBoxRequestType." + value.ToString());
                comboBox.Items.Add(new ComboBoxItem(localizedText, value));
            }
        }

        private void selectEnumValueInComboBox<TEnum>(ComboBox comboBox, TEnum value) where TEnum : Enum
        {
            foreach (ComboBoxItem item in comboBox.Items)
            {
                if (item.Value.Equals(value))
                {
                    comboBox.SelectedItem = item;
                    break;
                }
            }
        }
    }
}
