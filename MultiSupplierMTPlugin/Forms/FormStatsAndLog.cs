using MemoQ.MTInterfaces;
using MultiSupplierMTPlugin.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using LLH = MultiSupplierMTPlugin.Localized.LocalizedHelper;
using LLK = MultiSupplierMTPlugin.Localized.LocalizedKeyEnum;

namespace MultiSupplierMTPlugin.Forms
{
    public partial class FormStatsAndLog : Form
    {
        private MultiSupplierMTOptions options;

        private IEnvironment environment;
        
        public FormStatsAndLog(MultiSupplierMTOptions options, IEnvironment environment)
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
        }

        private void localized()
        {
            Text = LLH.G(LLK.FormStatsAndLog);

            labelRequestCount.Text = LLH.G(LLK.FormStatsAndLog_LabelRequestCount);
            labelExceptionCount.Text = LLH.G(LLK.FormStatsAndLog_LabelExceptionCount);

            linkLabelResetStats.Text = LLH.G(LLK.FormStatsAndLog_LinkLabelResetStats);

            buttonOpenLogDir.Text = LLH.G(LLK.FormStatsAndLog_ButtonOpenLogDir);

            buttonOK.Text = LLH.G(LLK.Form_ButtonOK);
        }

        private void loadOptions()
        {
            labelRequestCountValue.Text = StatsHelper.GetRequestTotal().ToString();
            labelExceptionCountValue.Text =  StatsHelper.GetRequestFailed().ToString();
        }


        private void linkLabelResetStats_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            StatsHelper.Reset();

            labelRequestCountValue.Text = "0";
            labelExceptionCountValue.Text = "0";
        }

        private void buttonOpenLogDir_Click(object sender, EventArgs e)
        {
            try
            {
                string logdir = Path.Combine(options.GeneralSettings.DataDir, "Log");
                
                if (!Directory.Exists(logdir))
                {
                    Directory.CreateDirectory(logdir);
                }

                Process.Start(Path.GetFullPath(logdir));
            }
            catch
            {
                MessageBox.Show(LLH.G(LLK.FormStatsAndLog_OpenLogDirFailMsg));
                return;
            }
        }
    }
}
