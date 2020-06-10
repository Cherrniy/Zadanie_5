using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Globalization;
using System.Resources;
using System.Reflection;



namespace _2._1
{
    public partial class frmmain : Form
    {
        private int openDocuments = 0;
        public string CultureDefine;
        private string EnglishCulture;
        private string RussianCulture;
        public ResourceManager resourceManager;

        public frmmain()
        {
           // Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
            InitializeComponent();
            saveToolStripMenuItem.Enabled = false;
            //HelpProvider hp = new HelpProvider();
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            CultureDefine = CultureInfo.InstalledUICulture.ToString();
            resourceManager = new ResourceManager("_2._1.ClosingText", Assembly.GetExecutingAssembly());
        }

        public frmmain(string FormCulture)
        {
            InitializeComponent();
            EnglishCulture = "en-US";
            RussianCulture = "ru-RU";
            CultureDefine = FormCulture;
            resourceManager = new ResourceManager("_2._1.ClosingText", Assembly.GetExecutingAssembly());

        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = new blank();
            frm.DocName = "Untitled " + ++openDocuments;
            frm.Text = frm.DocName;
            frm.MdiParent = this;
            frm.Show();
        }

        private void Frmmain_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void HorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Cut();
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild; frm.Copy();
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild; frm.Paste();
        }

        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild; frm.Delete();
        }

        private void SelectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild; frm.SelectAll();
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveAsToolStripMenuItem.Enabled = true;
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt|All Files(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = new blank();
                frm.Open(openFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = openFileDialog1.FileName;
                frm.Text = frm.DocName;
                frm.Show();
            }
        }

            private void SaveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        public void Save(object sender, System.EventArgs e) {
            blank frm = (blank)this.ActiveMdiChild;
            saveFileDialog1.ShowDialog();
            frm.Save(saveFileDialog1.FileName);
            //frm.DocName = saveFileDialog1.FileName;
            //FileStream filestream = File.Open(frm.DocName, FileMode.Create, FileAccess.Write);
            //if (filestream != null)
            //{
            //    StreamWriter streamwriter = new StreamWriter(filestream);
            //    streamwriter.Write(frm.richTextBox1.Text);
            //    streamwriter.Flush();
            //    filestream.Close();
            //    frm.IsSaved = true;
            //}


            }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            this.Save(frm.DocName,e);
            
            /* blank frm = (blank)this.ActiveMdiChild;
            frm.Save(frm.DocName);
            frm.IsSaved = true;*/
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                blank frm = (blank)this.ActiveMdiChild;
                frm.Save(saveFileDialog1.FileName);
                frm.MdiParent = this;
                frm.DocName = saveFileDialog1.FileName;
                frm.Text = frm.DocName;
                saveAsToolStripMenuItem.Enabled = true;
                frm.IsSaved = true;
            }
            
        }

        private void FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            fontDialog1.ShowColor = true;
            fontDialog1.Font = frm.richTextBox1.SelectionFont;
            fontDialog1.Color = frm.richTextBox1.SelectionColor;
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            { frm.richTextBox1.SelectionFont = fontDialog1.Font;
                frm.richTextBox1.SelectionColor = fontDialog1.Color; }
            frm.Show();
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.MdiParent = this;
            colorDialog1.Color = frm.richTextBox1.SelectionColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            { frm.richTextBox1.SelectionColor = colorDialog1.Color; }
            frm.Show();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About frm = new About();
            frm.ShowDialog();
        }

        private void TbNew_Click(object sender, EventArgs e)
        {
            NewToolStripMenuItem_Click(this, new EventArgs());
        }

        private void TbOpen_Click(object sender, EventArgs e)
        {
            OpenToolStripMenuItem_Click(this, new EventArgs());
        }

        private void TbSave_Click(object sender, EventArgs e)
        {
            SaveToolStripMenuItem_Click(this, new EventArgs());
        }

        private void TbCut_Click(object sender, EventArgs e)
        {
            CutToolStripMenuItem_Click(this, new EventArgs());
        }

        private void TbCopy_Click(object sender, EventArgs e)
        {
            CopyToolStripMenuItem_Click(this, new EventArgs());
        }

        private void TbPaste_Click(object sender, EventArgs e)
        {
            PasteToolStripMenuItem_Click(this, new EventArgs());
        }

        private void HelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, @"D:\help\index.html");
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Frmmain_FormClosing(object sender, FormClosingEventArgs e)
        {
            blank frm = (blank)this.ActiveMdiChild;
            frm.Close();
          /*  if (frm.IsSaved == true)
                if (MessageBox.Show(resourceManager.GetString("MessageText"), "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    this.Save(frm.DocName, e);*/
        }

        private void LanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void EnglishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureDefine = EnglishCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            frmmain frm = new frmmain(CultureDefine);
            this.Hide();
            frm.Show();
        }

        private void RussianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultureDefine = RussianCulture;
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(CultureDefine, false);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(CultureDefine, false);
            frmmain frm = new frmmain(CultureDefine);
            this.Hide();
            frm.Show();
        }

        private void Frmmain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
