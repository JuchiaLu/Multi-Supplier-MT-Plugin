using Mono.Cecil;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace DllGenerator
{
    public partial class FormMain : Form
    {

        public FormMain()
        {
            InitializeComponent();

            openFileDialog.FileName = "MultiSupplierMTPlugin.dll";
            openFileDialog.Filter = "dll file(*.dll)|*.dll";

            folderBrowserDialog.SelectedPath = Path.GetFullPath("./");
        }

        private void buttonSourceDllSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxSourceDll.Text = openFileDialog.FileName;
            }
        }

        private void buttonOutputPathSelect_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            { 
                textBoxOutputDir.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void buttonGenerate_Click(object sender, EventArgs e)
        {
            string dllPath = textBoxSourceDll.Text;
            dllPath = Path.GetFullPath(dllPath);

            string outputDir = textBoxOutputDir.Text;
            outputDir = Path.GetFullPath(outputDir);

            int start = (int)numericUpDownStartNumber.Value;
            int end = (int)numericUpDownEndNumber.Value;

            AssemblyDefinition assembly;
            try
            {
                assembly = AssemblyDefinition.ReadAssembly(dllPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"dll file load fail: \n\n{ex.Message}");
                return;
            }

            if (end < start)
            {
                MessageBox.Show($"End Number must be equal or greater than Start Number");
                return;
            }

            try
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"output dir create fail: \n\n{ex.Message}");
                return;
            }

            try
            {
                string fileName = Path.GetFileNameWithoutExtension(dllPath);
                string assemblyName = assembly.Name.Name;

                for (int i = start; i <= end; i++)
                {
                    assembly.Name.Name = $"{assemblyName}-{Guid.NewGuid()}";

                    string outputPath = Path.Combine(outputDir, $"{fileName}-{i}.dll");

                    assembly.Write(outputPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"dll file save fail: \n\n{ex.Message}");
                return;
            }

            MessageBox.Show($"generate {end-start+1} dll files done");
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            try 
            {
                Process.Start(Path.GetFullPath(textBoxOutputDir.Text));
            }
            catch(Exception ex)
            {
                MessageBox.Show($"output path open fail: \n\n{ex.Message}");
                return;
            }
        }
    }
}
