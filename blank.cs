using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _2._1
{
    public partial class blank : Form
    {
        public string DocName = "";
        public bool IsSaved = false;

        public blank()
        {
            InitializeComponent();
            sbTime.Text = Convert.ToString(System.DateTime.Now.ToLongTimeString());
            sbTime.ToolTipText = Convert.ToString(System.DateTime.Today.ToLongDateString());
        }

        public void Cut() { richTextBox1.Cut(); }
        public void Copy() { richTextBox1.Copy(); }
        public void Paste() { richTextBox1.Paste(); }
        public void SelectAll() { richTextBox1.SelectAll(); }
        public void Delete() { richTextBox1.SelectedText = ""; }

        public void Open(string OpenFileName)
        {
            if (OpenFileName == "") { return; }
            else
            {
                StreamReader sr = new StreamReader(OpenFileName);
                richTextBox1.Text = sr.ReadToEnd();
                sr.Close();
                DocName = OpenFileName;
                IsSaved = true;
            }
        }



       private void Blank_Load(object sender, EventArgs e)
        {

        }

        private void ContextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Paste();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        public void Save(string SaveFileName)
        {
            DocName = SaveFileName;
            FileStream filestream = File.Open(DocName, FileMode.Create, FileAccess.Write);
            if (filestream != null)
            {
                StreamWriter streamwriter = new StreamWriter(filestream);
                streamwriter.Write(richTextBox1.Text);
                streamwriter.Flush();
                filestream.Close();
                IsSaved = true;
            }


            //if (SaveFileName == "") { return; }
            //else
            //{
            //    StreamWriter sw = new StreamWriter(SaveFileName);
            //    sw.WriteLine(richTextBox1.Text);
            //    sw.Close();
            //    DocName = SaveFileName;
            //}
        }

        private void Blank_FormClosing(object sender, FormClosingEventArgs e)
        {

            frmmain frmm = (frmmain)this.MdiParent;
            if (IsSaved == true)
                if (MessageBox.Show(frmm.resourceManager.GetString("MessageText"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    frmm.Save(DocName, e);
            //if (IsSaved == true)
            //    if (MessageBox.Show("Do you want save changes in " + this.DocName + "?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    { this.Save(this.DocName); }

        }

        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            sbAmound.Text = "Аmount of symbols" + richTextBox1.Text.Length.ToString();
        }
    }
}
