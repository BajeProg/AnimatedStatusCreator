using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;

namespace AnimatedStatusCreator
{
    public partial class MainForm : Form
    {
        StatusObject status = new StatusObject(3200);
        SaveFileDialog dialog = new SaveFileDialog();
        public MainForm()
        {
            InitializeComponent();
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            if (textBox.Text == string.Empty) return;

            foreach (var item in textBox.Text.Split('\n'))
            {
                string text = item.Trim();
                if (string.IsNullOrEmpty(text)) continue;
                status.AddText(new Text(item));
            }

            SaveFile();
        }

        private void SaveFile()
        {
            dialog.FileName = "AnimatedStatus.config.json";
            dialog.FileOk += FileSaved;
            dialog.ShowDialog();
        }

        private void FileSaved(object sender, EventArgs e)
        {
            using (var sw = new StreamWriter(dialog.OpenFile()))
                sw.Write(JsonConvert.SerializeObject(status));

            textBox.Text = string.Empty;
        }
    }
}
