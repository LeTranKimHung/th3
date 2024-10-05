using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB3_02
{
    public partial class Form1 : Form
    {
        private string currentFilePath = string.Empty;
        public Form1()
        {
            InitializeComponent();
        }

        private void địnhDạngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.ShowColor = true;
            fontDialog.ShowApply = true;
            fontDialog.ShowEffects = true;
            fontDialog.ShowHelp = true;
            if(fontDialog.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.ForeColor = fontDialog.Color;
                richTextBox1.Font = fontDialog.Font;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            richTextBox1.Font = new Font("Tahoma", 14);
            NewVanBan();
            tsbfont.SelectedItem = "Tahoma";
            tsbsize.SelectedItem = 14;
        }
        private void NewVanBan()
        {
            foreach(FontFamily item in new InstalledFontCollection().Families)
            {
                tsbfont.Items.Add(item.Name);              
            }
            int[] fontsize = { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
            foreach (int size in fontsize) 
            {
                tsbsize.Items.Add(size);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
            tsbfont.SelectedItem = "Tahoma";
            tsbsize.SelectedItem = 14;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Text File (*.txt)|*.txt| Rich text format(*.rtf)|*.rtf";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileExtension = System.IO.Path.GetExtension(openFileDialog.FileName).ToLower();
                    if (fileExtension == ".txt")
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName, System.Text.Encoding.UTF8))
                        {
                            richTextBox1.Text = sr.ReadToEnd();
                        }

                    }
                    else if (fileExtension == ".rtf")
                    {
                        using (System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog.FileName, System.Text.Encoding.UTF8))
                        {
                            richTextBox1.Text = sr.ReadToEnd();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Định dạng tệp không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message,"Error Message",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentFilePath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Rich text format (*.rtf)|*,rtf";
                    saveFileDialog.Title = " Lưu văn bản";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        currentFilePath = saveFileDialog.FileName;
                        MessageBox.Show("Lưu văn bản thành công ", "Thông báo", MessageBoxButtons.OK);
                    }

                }
                else 
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu văn bản thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch(Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox1.Font = new Font("Tahoma", 14);
            tsbfont.SelectedItem = "Tahoma";
            tsbsize.SelectedItem = 14;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(currentFilePath))
                {
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Rich text format (*.rtf)|*,rtf";
                    saveFileDialog.Title = " Lưu văn bản";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.SaveFile(saveFileDialog.FileName, RichTextBoxStreamType.RichText);
                        currentFilePath = saveFileDialog.FileName;
                        MessageBox.Show("Lưu văn bản thành công ", "Thông báo", MessageBoxButtons.OK);
                    }

                }
                else
                {
                    richTextBox1.SaveFile(currentFilePath, RichTextBoxStreamType.RichText);
                    MessageBox.Show("Lưu văn bản thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Bold)
                {
                    style &= ~FontStyle.Bold;
                }
                else
                {
                    style |= FontStyle.Bold;
                }
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Italic)
                {
                    style &= ~FontStyle.Italic;
                }
                else
                {
                    style |= FontStyle.Italic;
                }
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                if (richTextBox1.SelectionFont.Underline)
                {
                    style &= ~FontStyle.Underline;
                }
                else
                {
                    style |= FontStyle.Underline;
                }
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }
        }       
    }
}
