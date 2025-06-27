using MultiSupplierMTPlugin.Helpers;
using MultiSupplierMTPlugin.Localized;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Forms.StatsAndLogLocalizedKey;
using LLKC = MultiSupplierMTPlugin.Localized.LocalizedKeyCommon;

namespace MultiSupplierMTPlugin.Forms
{
    partial class StatsAndLog : Form
    {
        private MultiSupplierMTGeneralSettings _mtGeneralSettings;

        private MultiSupplierMTSecureSettings _mtSecureSettings;

        public StatsAndLog(MultiSupplierMTGeneralSettings mtGeneralSettings, MultiSupplierMTSecureSettings mtSecureSettings)
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

            tabPageStatistics.Text = LLH.G(LLK.TabPageStatistics);

            labelSuccessRequests.Text = LLH.G(LLK.LabelSuccessRequests);
            labelFailedRequest.Text = LLH.G(LLK.LabelFailedRequests);

            linkLabelResetStats.Text = LLH.G(LLK.LinkLabelResetStats);

            tabPageLogging.Text = LLH.G(LLK.TabPageLogging);

            linkLabelOpenLogFile.Text = LLH.G(LLK.LinkLabelOpenLogFile);
            linkLabelOpenLogDir.Text = LLH.G(LLK.LinkLabelOpenLogDir);

            labelLoggingLevel.Text = LLH.G(LLK.LabelLoggingLevel);
            radioButtonDebug.Text = LLH.G(LLK.RadioButtonDebug);
            radioButtonInfo.Text = LLH.G(LLK.RadioButtonInfo);
            radioButtonWarn.Text = LLH.G(LLK.RadioButtonWarn);
            radioButtonError.Text = LLH.G(LLK.RadioButtonError);

            toolTip.SetToolTip(radioButtonDebug, LLH.G(LLK.RadioButtonDebugTip));
            toolTip.SetToolTip(radioButtonInfo, LLH.G(LLK.RadioButtonInfoTip));
            toolTip.SetToolTip(radioButtonWarn, LLH.G(LLK.RadioButtonWarnTip));
            toolTip.SetToolTip(radioButtonError, LLH.G(LLK.RadioButtonErrorTip));

            buttonOK.Text = LLH.G(LLKC.ButtonOK);
            buttonCancel.Text = LLH.G(LLKC.ButtonCancel);
        }

        private void LoadOptions()
        {
            labelSuccessCountValue.Text = StatsHelper.GetRequestSuccess().ToString();
            labelFailedCountValue.Text = StatsHelper.GetRequestFailed().ToString();

            switch (_mtGeneralSettings.LogLevel)
            {
                case LogLevel.Debug: radioButtonDebug.Checked = true; break;
                case LogLevel.Info: radioButtonInfo.Checked = true; break;
                case LogLevel.Warn: radioButtonWarn.Checked = true; break;
                case LogLevel.Error: radioButtonError.Checked = true; break;
            }
        }


        private void linkLabelResetStats_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatsHelper.Reset();

            labelSuccessCountValue.Text = "0";
            labelFailedCountValue.Text = "0";
        }

        private void linkLabelOpenLogFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                if (LoggingHelper.TryGetLogFilePath(out var logfile))
                    Process.Start(Path.GetFullPath(logfile));
                else
                    throw new Exception("logger no init or init fail");
            }
            catch
            {
                MessageBox.Show(LLH.G(LLK.OpenLogDirFailMsg), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void linkLabelOpenLogDir_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                string logDir = Path.Combine(_mtGeneralSettings.DataDir, "Log");

                if (!Directory.Exists(logDir))
                {
                    Directory.CreateDirectory(logDir);
                }

                Process.Start(logDir);
            }
            catch
            {
                MessageBox.Show(LLH.G(LLK.OpenLogDirFailMsg), "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void StatsAndLog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (radioButtonDebug.Checked) _mtGeneralSettings.LogLevel = LogLevel.Debug;
                else if (radioButtonInfo.Checked) _mtGeneralSettings.LogLevel = LogLevel.Info;
                else if (radioButtonWarn.Checked) _mtGeneralSettings.LogLevel = LogLevel.Warn;
                else if (radioButtonError.Checked) _mtGeneralSettings.LogLevel = LogLevel.Error;

                LoggingHelper.MinLogLevel = _mtGeneralSettings.LogLevel;
            }
        }
    }

    class StatsAndLogLocalizedKey : LocalizedKeyBase
    {
        public StatsAndLogLocalizedKey(string name) : base(name)
        {
        }

        static StatsAndLogLocalizedKey()
        {
            AutoInit<StatsAndLogLocalizedKey>();
        }

        [LocalizedValue("ea435a7b-1cb3-4c8f-a9bb-360641b2b9e3", "Stats And Log", "统计和日志")]
        public static StatsAndLogLocalizedKey Form { get; private set; }

        [LocalizedValue("ff4915a9-f7f7-4685-92dd-cbccba0b731d", "Statistics", "统计")]
        public static StatsAndLogLocalizedKey TabPageStatistics { get; private set; }

        [LocalizedValue("1ad559b0-d204-4ba5-8571-a92f460e87be", "Success Requests", "请求成功")]
        public static StatsAndLogLocalizedKey LabelSuccessRequests { get; private set; }

        [LocalizedValue("c479e88b-6cf4-41ab-9bb8-20732c5335f2", "Failed Requests", "请求失败")]
        public static StatsAndLogLocalizedKey LabelFailedRequests { get; private set; }

        [LocalizedValue("f32a702e-9295-4043-b926-79c3417f0452", "Reset Stats", "重置统计")]
        public static StatsAndLogLocalizedKey LinkLabelResetStats { get; private set; }

        [LocalizedValue("c4422e3d-ca37-4ce0-9dbd-db80511b5921", "Logging", "日志")]
        public static StatsAndLogLocalizedKey TabPageLogging { get; private set; }

        [LocalizedValue("02b6a21c-4887-4356-86df-94f8771de461", "Open Log File", "打开日志文件")]
        public static StatsAndLogLocalizedKey LinkLabelOpenLogFile { get; private set; }

        [LocalizedValue("fe43fa3f-f489-407a-8d59-306b6d69d91f", "Open Log Dir", "打开日志目录")]
        public static StatsAndLogLocalizedKey LinkLabelOpenLogDir { get; private set; }

        [LocalizedValue("937d150b-6fb0-40f2-8d1b-3c54dde88954", "Logging Level", "日志记录级别")]
        public static StatsAndLogLocalizedKey LabelLoggingLevel { get; private set; }

        [LocalizedValue("500bd562-bc5a-46ca-aa41-f61a62c6aaf7", "Debug", "调试")]
        public static StatsAndLogLocalizedKey RadioButtonDebug { get; private set; }

        [LocalizedValue("4e23b8ef-f70a-4fbd-9f1a-635b00e224db", "Info", "信息")]
        public static StatsAndLogLocalizedKey RadioButtonInfo { get; private set; }

        [LocalizedValue("670e883c-1f15-4185-bda5-ce9d532f1f1a", "Warn", "警告")]
        public static StatsAndLogLocalizedKey RadioButtonWarn { get; private set; }

        [LocalizedValue("049c3db8-4bb0-40b2-88e2-31d938ef90e9", "Error", "错误")]
        public static StatsAndLogLocalizedKey RadioButtonError { get; private set; }

        [LocalizedValue("effbf444-64cf-4773-a3f4-0e02d35e0ddd", "Record the most information", "记录最多的信息")]
        public static StatsAndLogLocalizedKey RadioButtonDebugTip { get; private set; }

        [LocalizedValue("6c1aa3db-b379-43f1-ab06-c9cfad73d6fd", "Record more information", "记录较多的信息")]
        public static StatsAndLogLocalizedKey RadioButtonInfoTip { get; private set; }

        [LocalizedValue("b6e5af4a-e8dc-4e35-998a-9de5b5d6b41d", "Record less information", "记录较少的信息")]
        public static StatsAndLogLocalizedKey RadioButtonWarnTip { get; private set; }

        [LocalizedValue("1c58ed5f-8053-4065-9762-a2d3ecc09a6f", "Record the least information", "记录最少的信息")]
        public static StatsAndLogLocalizedKey RadioButtonErrorTip { get; private set; }

        [LocalizedValue("9d5ea46e-76d8-4ef4-b0fd-b4494bbf9ac1", "Dir cteate or open fail", "目录创建或打开失败")]
        public static StatsAndLogLocalizedKey OpenLogDirFailMsg { get; private set; }
    }
}
