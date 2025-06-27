using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.ProvidersManageLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class ProvidersManage : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;


        private DataTable _enableDataTable;

        private DataTable _disableDataTable;


        private bool _needUpdateMainForm = false;


        public ProvidersManage(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
        {
            InitializeComponent();

            this._mtGeneralSettings = mtGeneralSettings;
            this._mtSecureSettings = mtSecureSettings;
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

            labelDisableSrarch.Text = LLH.G(LLK.LabelDisableSrarch);
            labelEnableSearch.Text = LLH.G(LLK.LabelEnableSearch);

            linkLabelReset.Text = LLH.G(LLK.LinkLabelReset);
            toolTip.SetToolTip(linkLabelReset, LLH.G(LLK.LinkLabelResetTip));

            buttonDisable.Text = LLH.G(LLK.ButtonDisable);
            buttonEnable.Text = LLH.G(LLK.ButtonEnable);

            labelDisabledList.Text = LLH.G(LLK.LabelDisabledList);
            labelEnabledList.Text = LLH.G(LLK.labelDisabledList);

            labelNoDisableTip.Text = LLH.G(LLK.LabelNoDisableTip);

            linkLabelMore.Text = LLH.G(LLK.LinkLabelMore);

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            _enableDataTable = CreateProviderDataTable();
            _disableDataTable = CreateProviderDataTable();

            RepopulateProviderTables(_enableDataTable, _disableDataTable, ServiceHelper.GetAllServices(), _mtGeneralSettings.EnableProviders);

            ConfigureDataGridView(dataGridViewEnable, _enableDataTable);
            ConfigureDataGridView(dataGridViewDisable, _disableDataTable);

            ClearSelectionAndScrollToTop(dataGridViewEnable, dataGridViewDisable);
        }


        private DataTable CreateProviderDataTable()
        {
            var table = new DataTable();

            table.Columns.AddRange(new[]
            {
                new DataColumn("UniqueName", typeof(string)),
                new DataColumn("Name", typeof(string)),
                new DataColumn("IsBuiltIn", typeof(bool)),
                new DataColumn("IsLLM", typeof(bool))
            });

            table.DefaultView.Sort = "IsBuiltIn DESC, IsLLM, Name";

            return table;
        }

        private void RepopulateProviderTables(DataTable enableDataTable, DataTable disableDataTable, List<MultiSupplierMTService> allProviders, string[] enableProviders)
        {
            enableDataTable.Clear();
            disableDataTable.Clear();

            var enabledSet = new HashSet<string>(enableProviders);

            foreach (var p in allProviders)
            {
                var targetTable = enabledSet.Contains(p.UniqueName) ? enableDataTable : disableDataTable;
                var row = targetTable.NewRow();
                row["UniqueName"] = p.UniqueName;
                row["Name"] = ServiceLocalizedNameHelper.GetWithSuffix(p.UniqueName, p.IsLLM, p.IsBuiltIn);
                row["IsBuiltIn"] = p.IsBuiltIn;
                row["IsLLM"] = p.IsLLM;
                targetTable.Rows.Add(row);
            }
        }

        private void ConfigureDataGridView(DataGridView dgv, DataTable dataSource)
        {
            dgv.DataSource = dataSource.DefaultView;

            AddRowNumberColumn(dgv);

            dgv.Columns["UniqueName"].Visible = false;
            dgv.Columns["IsBuiltIn"].Visible = false;
            dgv.Columns["IsLLM"].Visible = false;

            dgv.Columns["Name"].FillWeight = 88;
        }

        private void AddRowNumberColumn(DataGridView dgv)
        {
            if (dgv.Columns.Contains("Id"))
                return;

            var idColumn = new DataGridViewTextBoxColumn
            {
                HeaderText = "Id",
                Name = "Id",
                FillWeight = 12,
                ReadOnly = true,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            dgv.Columns.Insert(0, idColumn);

            dgv.CellFormatting += (s, e) =>
            {
                if (e.ColumnIndex == 0 && e.RowIndex >= 0)
                {
                    e.Value = (e.RowIndex + 1).ToString();
                    e.FormattingApplied = true;
                }
            };
        }

        private void ClearSelectionAndScrollToTop(DataGridView dataGridViewEnable, DataGridView dataGridViewDisable)
        {
            dataGridViewEnable.ClearSelection();
            dataGridViewDisable.ClearSelection();

            if (dataGridViewEnable.Rows.Count > 0) dataGridViewEnable.FirstDisplayedScrollingRowIndex = 0;
            if (dataGridViewDisable.Rows.Count > 0) dataGridViewDisable.FirstDisplayedScrollingRowIndex = 0;
        }


        private void ApplyFilter(string filterText, DataTable sourceTable)
        {
            string Escape(string input)
            {
                return input.Replace("'", "''")
                            .Replace("[", "[[]")
                            .Replace("]", "[]]")
                            .Replace("%", "[%]")
                            .Replace("*", "[*]");
            }

            filterText = filterText.Trim().ToLower();

            string filterExpression = string.IsNullOrEmpty(filterText)
                ? ""
                : $"Name LIKE '%{Escape(filterText)}%'";

            sourceTable.DefaultView.RowFilter = filterExpression;
        }

        private void MoveSelectedProviders(DataGridView sourceGrid, DataGridView targetGrid, DataTable sourceTable, DataTable targetTable, bool allowDisableCurrent)
        {
            labelNoDisableTip.Visible = false;
            var movedNames = new HashSet<string>();

            foreach (DataGridViewRow row in sourceGrid.SelectedRows.Cast<DataGridViewRow>())
            {
                if (!(row.DataBoundItem is DataRowView view))
                    continue;

                var dataRow = view.Row;
                var uniqueName = dataRow["UniqueName"].ToString();

                if (!allowDisableCurrent && uniqueName == _mtGeneralSettings.CurrentServiceProvider)
                {
                    labelNoDisableTip.Visible = true;
                    continue;
                }

                targetTable.Rows.Add(dataRow.ItemArray);
                sourceTable.Rows.Remove(dataRow);

                movedNames.Add(uniqueName);
            }

            if (movedNames.Count > 0)
            {
                sourceGrid.ClearSelection();
                HighlightMovedRows(targetGrid, movedNames);
            }
        }

        private void HighlightMovedRows(DataGridView grid, HashSet<string> uniqueNames)
        {
            grid.ClearSelection();
            int firstVisibleIndex = -1;

            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.DataBoundItem is DataRowView view && uniqueNames.Contains(view["UniqueName"].ToString()))
                {
                    row.Selected = true;
                    if (firstVisibleIndex == -1)
                        firstVisibleIndex = row.Index;
                }
            }

            if (firstVisibleIndex != -1)
                grid.FirstDisplayedScrollingRowIndex = firstVisibleIndex;
        }


        private void buttonEnable_Click(object sender, EventArgs e)
        {
            MoveSelectedProviders(dataGridViewDisable, dataGridViewEnable, _disableDataTable, _enableDataTable, true);
        }

        private void buttonDisable_Click(object sender, EventArgs e)
        {
            MoveSelectedProviders(dataGridViewEnable, dataGridViewDisable, _enableDataTable, _disableDataTable, false);
        }

        private void textBoxSearchEnabled_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilter(textBoxEnableSearch.Text, _enableDataTable);
            }
            catch
            {
                textBoxEnableSearch.Text = "";
            }            
        }

        private void textBoxSearchDisabled_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ApplyFilter(textBoxDisableSearch.Text, _disableDataTable);
            }
            catch
            {
                textBoxDisableSearch.Text = "";
            }
        }

        private void linkLabelResort_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var enableProviders = _mtGeneralSettings.EnableProviders;
            RepopulateProviderTables(_enableDataTable, _disableDataTable, ServiceHelper.GetAllServices(), enableProviders);
            ClearSelectionAndScrollToTop(dataGridViewEnable, dataGridViewDisable);
        }


        private void linkLabelMore_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (var form = new OpenAICompatibleProvider(_mtGeneralSettings, _mtSecureSettings))
            {
                form.ShowDialog();

                if (form.DialogResult == DialogResult.OK)
                {
                    ServiceHelper.Init(_mtGeneralSettings.CustomOpenAICompatibleServiceInfos);

                    var enableProviders = _enableDataTable.Rows.Cast<DataRow>().Select((d => d["UniqueName"].ToString())).ToArray();
                    RepopulateProviderTables(_enableDataTable, _disableDataTable, ServiceHelper.GetAllServices(), enableProviders);
                    ClearSelectionAndScrollToTop(dataGridViewEnable, dataGridViewDisable);

                    _needUpdateMainForm = true;
                }
            }
        }

        private void ProvidersManage_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var enableProviders = _enableDataTable.Rows.Cast<DataRow>().Select((d => d["UniqueName"].ToString())).ToArray();
                _mtGeneralSettings.EnableProviders = enableProviders;
            }

            if (_needUpdateMainForm)
                DialogResult = DialogResult.OK;
        }
    }

    class ProvidersManageLocalizedKey : LocalizedKeyBase
    {
        public ProvidersManageLocalizedKey(string name) : base(name)
        {
        }

        static ProvidersManageLocalizedKey()
        {
            AutoInit<ProvidersManageLocalizedKey>();
        }

        [LocalizedValue("ed4a5a1f-1ca2-484e-9c3b-908edbb4ed49", "Providers Manage", "提供商管理")]
        public static ProvidersManageLocalizedKey Form { get; private set; }

        [LocalizedValue("9ee486f6-174d-4899-b7fc-855565f0c892", "Srarch: ", "搜索 :")]
        public static ProvidersManageLocalizedKey LabelDisableSrarch { get; private set; }

        [LocalizedValue("b5831544-e5dc-4fff-97dc-d3422d83524e", "Srarch: ", "搜索：")]
        public static ProvidersManageLocalizedKey LabelEnableSearch { get; private set; }

        [LocalizedValue("ced4be43-038e-4f29-8353-e3b4c18276dd", "↻", "↻")]
        public static ProvidersManageLocalizedKey LinkLabelReset { get; private set; }

        [LocalizedValue("fd555cd4-f439-4de4-a924-00c15fb59e4f", "Reset", "重置")]
        public static ProvidersManageLocalizedKey LinkLabelResetTip { get; private set; }

        [LocalizedValue("f48efc1f-a91e-4130-8106-bfec7099a0a4", "<-", "<-")]
        public static ProvidersManageLocalizedKey ButtonDisable { get; private set; }

        [LocalizedValue("dde7d53b-bb65-4cab-b12a-dbd58270f5a8", "->", "->")]
        public static ProvidersManageLocalizedKey ButtonEnable { get; private set; }

        [LocalizedValue("34b55a8d-4358-41c0-8173-e0052af9c855", "Disabled List", "已禁用列表")]
        public static ProvidersManageLocalizedKey LabelDisabledList { get; private set; }

        [LocalizedValue("e2f3b06e-e5c1-435a-9781-b2905f0ed735", "Enabled List", "已启用列表")]
        public static ProvidersManageLocalizedKey labelDisabledList { get; private set; }

        [LocalizedValue("5b219bf4-80d6-419c-8963-470147257d65", "Can not disable the provider in used !", "无法禁用正在使用的提供商！")]
        public static ProvidersManageLocalizedKey LabelNoDisableTip { get; private set; }

        [LocalizedValue("c9adb833-88c3-4468-9c8c-44004c2376ef", "More?", "更多？")]
        public static ProvidersManageLocalizedKey LinkLabelMore { get; private set; }
    }
}
