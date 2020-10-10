using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace JHTT
{
    public partial class Form1 : Form
    {
        Help help;
        public Form1()
        {
            InitializeComponent();
            label1.Visible = false;
            pictureBox1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:\\";
            ofd.Filter = "jtab files (*.jtab)|*.jtab|All files (*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //Get the path of specified file
                textBox1.Text = ofd.FileName;
            }
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = e.Data.GetData(DataFormats.FileDrop) as string[]; 
            if (files != null && files.Any())
                textBox1.Text = files.First();

            ChangeFormToDragDrop(true);
        }

        private void Form1_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            ChangeFormToDragDrop(false);
        }

        private void Form1_DragLeave(object sender, EventArgs e)
        {
            ChangeFormToDragDrop(true);
        }
        private void ChangeFormToDragDrop(bool state)
        {
            button1.Visible = state;
            button2.Visible = state;
            groupBox1.Visible = state;
            textBox1.Visible = state;
            richTextBox1.Visible = state;
            pictureBox1.Visible = !state;
            label1.Visible = !state;
            label2.Visible = state;
            label3.Visible = state;
            button3.Visible = state;
            textBox2.Visible = state;
        }
        public void AppendText(RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!File.Exists(textBox1.Text)) {
                MessageBox.Show("Указан неверный путь к файлу!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                richTextBox1.Clear();
                Lexan lex = new Lexan(textBox1.Text,richTextBox1);
                int res = lex.parse();
                Syntaxan synt = new Syntaxan(lex);
                if (res == 1) res = synt.parse();
                Translator tr = new Translator(lex);
                if (res == 1) tr.CreateHTML();
            }      
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1.PerformClick();
        }

        private void запускToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2.PerformClick();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            help = new Help();
            help.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
        }
    }
}
