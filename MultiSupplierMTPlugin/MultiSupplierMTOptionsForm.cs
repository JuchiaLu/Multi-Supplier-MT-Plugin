using MemoQ.MTInterfaces;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MultiSupplierMTPlugin.Services;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using MultiSupplierMTPlugin.Localized;
using MultiSupplierMTPlugin.Helpers;

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
            Text = LLH.G(LLK.OptionForm);

            labelServiceProvider.Text = LLH.G(LLK.OptionForm_LabelServiceProvider);
            foreach (string name in ServiceHolder.GetUniqueNameList())
            {
                if (ILocalizedKeyEnum.TryFromName<LLK>("OptionForm_ComboBoxServiceProvider_" + name, out var keyEnum))
                {
                    serviceLocalizedTextMap.Add(LLH.G(keyEnum), name);
                }
                else
                {
                    serviceLocalizedTextMap.Add(name, name);
                }
            }
            comboBoxServiceProvider.DataSource = new BindingSource(serviceLocalizedTextMap, null);
            comboBoxServiceProvider.DisplayMember = "Key";
            comboBoxServiceProvider.ValueMember = "Value";

            labelRequestType.Text = LLH.G(LLK.OptionForm_LabelRequestType);
            populateComboBoxWithEnum<RequestType>(comboBoxRequestType);

            checkBoxTagsToEnd.Text = LLH.G(LLK.OptionForm_CheckBoxTagsToEnd);
            checkBoxNormalizeWhitespace.Text = LLH.G(LLK.OptionForm_CheckBoxNormalizeWhitespace);

            checkBoxTranslateCache.Text = LLH.G(LLK.OptionForm_CheckBoxTranslateCache);

            buttonOK.Text = LLH.G(LLK.OptionForm_ButtonOK);
            buttonCancel.Text = LLH.G(LLK.OptionForm_ButtonCancel);
        }

        private void loadOptions()
        {
            comboBoxServiceProvider.SelectedValue = options.GeneralSettings.CurrentServiceProvider;

            selectEnumValueInComboBox(comboBoxRequestType, options.GeneralSettings.RequestType);

            checkBoxTagsToEnd.Checked = options.GeneralSettings.InsertRequiredTagsToEnd;
            checkBoxNormalizeWhitespace.Checked = options.GeneralSettings.NormalizeWhitespaceAroundTags;

            checkBoxTranslateCache.Checked = options.GeneralSettings.EnableCache;
        }

        private void comboBoxServiceProvider_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxServiceProvider.SelectedValue is string name)
            {
                MTServiceInterface serviceProvider = ServiceHolder.GetService(name);

                options = serviceProvider.ShowConfig(options, environment, this);

                if (serviceProvider.IsAvailable(options))
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

        private void MultiSupplierMTOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                options.GeneralSettings.CurrentServiceProvider = (string)comboBoxServiceProvider.SelectedValue;

                ComboBoxItem selectedRequestTypeItem = (ComboBoxItem)comboBoxRequestType.SelectedItem;
                RequestType selectedRequestType = (RequestType)selectedRequestTypeItem.Value;
                options.GeneralSettings.RequestType = selectedRequestType;

                options.GeneralSettings.InsertRequiredTagsToEnd = checkBoxTagsToEnd.Checked;
                options.GeneralSettings.NormalizeWhitespaceAroundTags = checkBoxNormalizeWhitespace.Checked;

                options.GeneralSettings.EnableCache = checkBoxTranslateCache.Checked;
            }
        }

        private void updateCheckBoxState()
        {
            ComboBoxItem selectedItem = (ComboBoxItem)comboBoxRequestType.SelectedItem;
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
                if (ILocalizedKeyEnum.TryFromName<LLK>("OptionForm_ComboBoxRequestType_" + value.ToString(), out var keyEnum))
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
                    break;
                }
            }
        }
    }
}
