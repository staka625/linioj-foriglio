/*
Copyright (c) 2022 staka625
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program. If not, see http://www.gnu.org/licenses/.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace liniojForigilo
{
    public partial class liniojforigilo : Form
    {
        private Encoding encoding;
        private Encoding toEncoding;
        public liniojforigilo()
        {
            InitializeComponent();
        }
        private void liniojforigilo_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 6;
        }
        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "file(*.txt;*.csv;*.log)|*.txt;*.csv;*.log|text file(*.txt)|*.txt|csv file(*.csv)|*.csv|log file(*.log)|*.log|all file(*.*)|*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Open the file";
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileNameTextBox.Text = ofd.FileName;
            }
        }

        private void fileNameTextBox_TextChanged(object sender, EventArgs e)
        {
            int cnt = 0;
            foreach (string line in System.IO.File.ReadLines(fileNameTextBox.Text))
            {
                cnt++;
            }
            linesLabel.Text = "Lines : " + cnt.ToString();
            outFileName.Text = PathUtils.GetPathWithoutExtension(fileNameTextBox.Text)
                + "_forigita"
                + System.IO.Path.GetExtension(fileNameTextBox.Text);
            if (System.IO.File.Exists(fileNameTextBox.Text))
            {
                encoding = Encode.GetCode(System.IO.File.ReadAllBytes(fileNameTextBox.Text));
                encodelabel.Text = "Encode : " + encoding.EncodingName;
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            int start = decimal.ToInt32(fromNumericUpDown.Value);
            int end = decimal.ToInt32(toNumericUpDown.Value);
            int cnt = 0;
            string newtext = string.Empty;
            if (start > end)
            {
                MessageBox.Show("From Value is larger than To Value.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (!System.IO.File.Exists(fileNameTextBox.Text))
            {
                return;
            }
            if (System.IO.File.Exists(outFileName.Text))
            {
                if(MessageBox.Show("File exists in the directory. Do you want to overwrite it?",
                    "Verification",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            
            }
            if (toEncoding == null)
            {
                toEncoding = encoding;
            }
            byte[] srcbytes = System.IO.File.ReadAllBytes(fileNameTextBox.Text);
            byte[] dstbytes = Encoding.Convert(encoding, toEncoding, srcbytes);
            string file = toEncoding.GetString(dstbytes);
            string[] lines = file.Split(new char[] { '\n' });
            foreach (string line in lines)
            {
                cnt++;
                if (!(start <= cnt && cnt <= end))
                {
                    newtext += line;
                    newtext += '\n';
                }
            }

            System.IO.File.WriteAllText(outFileName.Text, newtext, toEncoding);
            MessageBox.Show("Line deleting is done!",
                    "Done",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    toEncoding = Encoding.UTF8;
                    break;
                case 1:
                    toEncoding = new System.Text.UTF8Encoding(true, true);
                    break;
                case 2:
                    toEncoding = Encoding.Unicode;
                    break;
                case 3:
                    toEncoding =  new System.Text.UnicodeEncoding(true, true);
                    break;
                case 4:
                    toEncoding = Encoding.GetEncoding(932);
                    break;
                case 5:
                    toEncoding = Encoding.GetEncoding(51932);
                    break;
                case 6:
                    toEncoding = encoding;
                    break;
                case -1:
                    toEncoding = encoding;
                    break;
            }
        }
    }
    public static class PathUtils
    {
        public static string GetPathWithoutExtension(string path)
        {
            var extension = System.IO.Path.GetExtension(path);
            if (string.IsNullOrEmpty(extension))
            {
                return path;
            }
            return path.Replace(extension, string.Empty);
        }
    }
    public static class Encode
    {
        public static Encoding GetCode(byte[] bytes)
        {
            if (bytes.Length < 2)
            {
                return null;
            }
            if ((bytes[0] == 0xfe) && (bytes[1] == 0xff))
            {
                //UTF-16 BE
                return new System.Text.UnicodeEncoding(true, true);
            }
            if ((bytes[0] == 0xff) && (bytes[1] == 0xfe))
            {
                if ((4 <= bytes.Length) &&
                    (bytes[2] == 0x00) && (bytes[3] == 0x00))
                {
                    //UTF-32 LE
                    return new System.Text.UTF32Encoding(false, true);
                }
                //UTF-16 LE
                return new System.Text.UnicodeEncoding(false, true);
            }
            if (bytes.Length < 3)
            {
                return null;
            }
            if ((bytes[0] == 0xef) && (bytes[1] == 0xbb) && (bytes[2] == 0xbf))
            {
                //UTF-8
                return new System.Text.UTF8Encoding(true, true);
            }
            if (bytes.Length < 4)
            {
                return null;
            }
            if ((bytes[0] == 0x00) && (bytes[1] == 0x00) &&
                (bytes[2] == 0xfe) && (bytes[3] == 0xff))
            {
                //UTF-32 BE
                return new System.Text.UTF32Encoding(true, true);
            }

            const byte bEscape = 0x1B;
            const byte bAt = 0x40;
            const byte bDollar = 0x24;
            const byte bAnd = 0x26;
            const byte bOpen = 0x28;    //'('
            const byte bB = 0x42;
            const byte bD = 0x44;
            const byte bJ = 0x4A;
            const byte bI = 0x49;

            int len = bytes.Length;
            byte b1, b2, b3, b4;

            //Encode::is_utf8 は無視

            bool isBinary = false;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 <= 0x06 || b1 == 0x7F || b1 == 0xFF)
                {
                    //'binary'
                    isBinary = true;
                    if (b1 == 0x00 && i < len - 1 && bytes[i + 1] <= 0x7F)
                    {
                        //smells like raw unicode
                        return System.Text.Encoding.Unicode;
                    }
                }
            }
            if (isBinary)
            {
                return null;
            }

            //not Japanese
            bool notJapanese = true;
            for (int i = 0; i < len; i++)
            {
                b1 = bytes[i];
                if (b1 == bEscape || 0x80 <= b1)
                {
                    notJapanese = false;
                    break;
                }
            }
            if (notJapanese)
            {
                return System.Text.Encoding.ASCII;
            }

            for (int i = 0; i < len - 2; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                b3 = bytes[i + 2];

                if (b1 == bEscape)
                {
                    if (b2 == bDollar && b3 == bAt)
                    {
                        //JIS_0208 1978
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bDollar && b3 == bB)
                    {
                        //JIS_0208 1983
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && (b3 == bB || b3 == bJ))
                    {
                        //JIS_ASC
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    else if (b2 == bOpen && b3 == bI)
                    {
                        //JIS_KANA
                        //JIS
                        return System.Text.Encoding.GetEncoding(50220);
                    }
                    if (i < len - 3)
                    {
                        b4 = bytes[i + 3];
                        if (b2 == bDollar && b3 == bOpen && b4 == bD)
                        {
                            //JIS_0212
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                        if (i < len - 5 &&
                            b2 == bAnd && b3 == bAt && b4 == bEscape &&
                            bytes[i + 4] == bDollar && bytes[i + 5] == bB)
                        {
                            //JIS_0208 1990
                            //JIS
                            return System.Text.Encoding.GetEncoding(50220);
                        }
                    }
                }
            }

            //should be euc|sjis|utf8
            //use of (?:) by Hiroki Ohzaki <ohzaki@iod.ricoh.co.jp>
            int sjis = 0;
            int euc = 0;
            int utf8 = 0;
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0x81 <= b1 && b1 <= 0x9F) || (0xE0 <= b1 && b1 <= 0xFC)) &&
                    ((0x40 <= b2 && b2 <= 0x7E) || (0x80 <= b2 && b2 <= 0xFC)))
                {
                    //SJIS_C
                    sjis += 2;
                    i++;
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if (((0xA1 <= b1 && b1 <= 0xFE) && (0xA1 <= b2 && b2 <= 0xFE)) ||
                    (b1 == 0x8E && (0xA1 <= b2 && b2 <= 0xDF)))
                {
                    //EUC_C
                    //EUC_KANA
                    euc += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if (b1 == 0x8F && (0xA1 <= b2 && b2 <= 0xFE) &&
                        (0xA1 <= b3 && b3 <= 0xFE))
                    {
                        //EUC_0212
                        euc += 3;
                        i += 2;
                    }
                }
            }
            for (int i = 0; i < len - 1; i++)
            {
                b1 = bytes[i];
                b2 = bytes[i + 1];
                if ((0xC0 <= b1 && b1 <= 0xDF) && (0x80 <= b2 && b2 <= 0xBF))
                {
                    //UTF8
                    utf8 += 2;
                    i++;
                }
                else if (i < len - 2)
                {
                    b3 = bytes[i + 2];
                    if ((0xE0 <= b1 && b1 <= 0xEF) && (0x80 <= b2 && b2 <= 0xBF) &&
                        (0x80 <= b3 && b3 <= 0xBF))
                    {
                        //UTF8
                        utf8 += 3;
                        i += 2;
                    }
                }
            }
            //M. Takahashi's suggestion
            //utf8 += utf8 / 2;

            System.Diagnostics.Debug.WriteLine(
                string.Format("sjis = {0}, euc = {1}, utf8 = {2}", sjis, euc, utf8));
            if (euc > sjis && euc > utf8)
            {
                //EUC
                return System.Text.Encoding.GetEncoding(51932);
            }
            else if (sjis > euc && sjis > utf8)
            {
                //SJIS
                return System.Text.Encoding.GetEncoding(932);
            }
            else if (utf8 > euc && utf8 > sjis)
            {
                //UTF8
                return System.Text.Encoding.UTF8;
            }

            return null;
        }
    }
}
