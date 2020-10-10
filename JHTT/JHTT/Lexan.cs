using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    class Lexan
    {
        public System.Windows.Forms.RichTextBox rtb1;
        // текущий символ входа
        byte cc;
        public int cur_tok;
        int cur_sym;
        uint cur_ln;
        uint cur_col;
        byte[] buffer;
        string path;
        // возвращает очередной символ входа
        int next_char()
        {
            if (cur_sym == buffer.Length) return 0;
            else
            {
                cc = buffer[cur_sym++];
                return 1;
            }
        }
        public CustomTypes.TokenStack tokens_stream = new CustomTypes.TokenStack();
        // принимает целое число
        int parse_number(CustomTypes.Token tok)
        {
            while (true)
            {
                if (ConvTab.TOT[cc] == Consts.DIGIT)
                {
                    tok.int_val *= 10;
                    tok.int_val += cc;
                    tok.int_val -= '0';
                    cur_col++;
                }
                else
                {
                    if (ConvTab.TOT[cc] == Consts.COMMA)
                    {
                        cur_sym--;
                    }
                    else if (ConvTab.TOT[cc] == Consts.CHEAD)
                    {
                        cur_sym--;
                    }
                    return 1;
                }
                if (next_char() == 0) return 0;
            }
        }

        int parse_text(CustomTypes.Token tok)
        {
            while (true)
            {
                if (ConvTab.TOT[cc] == Consts.CTEXT || ConvTab.TOT[cc] == Consts.DIGIT || ConvTab.TOT[cc] == Consts.SBOLD
                    || ConvTab.TOT[cc] == Consts.SITAL || ConvTab.TOT[cc] == Consts.WHITE || ConvTab.TOT[cc] == Consts.COMMA)
                {
                    tok.append(cc);
                    cur_col++;
                    next_char();
                }
                else if (cc == '\n')
                {
                    cur_col = 1;
                    cur_ln++;
                    if (next_char() == 0) return 0;
                }
                else return 1;
            }
        }
        // конструктор
        public Lexan(string path, System.Windows.Forms.RichTextBox rtb1)
        {
            cur_tok = 0;
            cur_ln = 1;
            cur_col = 1;
            cur_sym = 0;
            this.path = path;
            this.rtb1 = rtb1;
        }
        public int parse()
        {
            Program.mainwindow.AppendText(rtb1, String.Format("[{0}] lexan: начат лексический анализ\n", DateTime.Now.ToString("HH:mm:ss")), Color.Lime);
            tokens_stream.add(SynTab.TokType.TOK_UNKNOWN, 0, 0, 0);
            try
            {
                using (System.IO.StreamReader sr = new System.IO.StreamReader(path))
                {
                    string line = "";
                    string temp = "";
                    while ((temp = sr.ReadLine()) != null)
                    {
                        temp += "\n";
                        line += temp;
                    }
                    buffer = Encoding.GetEncoding(1251).GetBytes(line);
                    sr.Close();
                }
            }
            catch (Exception e)
            {
                Program.mainwindow.AppendText(rtb1, String.Format("[{0}] lexan: не удалось открыть файл по причине: {1}\n", DateTime.Now.ToString("HH:mm:ss"), e.Message), Color.Red);
                return 0;
            }
            
            bool cellheader = false;
            bool colspan = false;
            next_char();
            while (cur_sym != buffer.Length)
            {
                switch (ConvTab.TOT[cc])
                {
                    case Consts.CHEAD:
                        if (!cellheader) cellheader = true; else cellheader = false;
                        tokens_stream.add(SynTab.TokType.TOK_BOR, '|', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.ROWOP:
                        tokens_stream.add(SynTab.TokType.TOK_LS, '{', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.ROWCL:
                        tokens_stream.add(SynTab.TokType.TOK_RS, '}', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.COMMA:
                        tokens_stream.add(SynTab.TokType.TOK_COMMA, ',', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.SBOLD:
                        tokens_stream.add(SynTab.TokType.TOK_BAND, '&', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.SITAL:
                        tokens_stream.add(SynTab.TokType.TOK_DOLLAR, '$', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.SCENT:
                        tokens_stream.add(SynTab.TokType.TOK_XOR, '^', cur_ln, cur_col);
                        cur_col++;
                        next_char();
                        break;
                    case Consts.DIGIT:
                        {
                            uint templn = cur_ln;
                            uint tempcol = cur_col;
                            CustomTypes.Token temptok = new CustomTypes.Token();
                            if (!cellheader)
                            {
                                parse_text(temptok);
                                tokens_stream.add(SynTab.TokType.TOK_TEXT, temptok.str_val, templn, tempcol);
                            }
                            else
                            {
                                if (!colspan)
                                {
                                    colspan = true;
                                    parse_number(temptok);
                                    tokens_stream.add(SynTab.TokType.TOK_CSC, temptok.int_val, templn, tempcol);
                                }
                                else
                                {
                                    parse_number(temptok);
                                    tokens_stream.add(SynTab.TokType.TOK_RSC, temptok.int_val, templn, tempcol);
                                    colspan = false;
                                }
                                next_char();
                            }
                            break;
                        }
                    case Consts.CTEXT:
                        {
                            add_text_token();
                            break;
                        }
                    case Consts.WHITE:
                        {
                            add_text_token();
                            break;
                        }
                    default:
                        {
                            if (cc == '\n') { cur_col = 1; cur_ln++; }
                            next_char();
                            break;
                        }
                }
            }
            if (Program.mainwindow.включитьРежимОтладкиToolStripMenuItem.Checked == true) tokens_stream.print(rtb1);
            tokens_stream.add(SynTab.TokType.TOK_EOT, 0, cur_ln, cur_col);
            Program.mainwindow.AppendText(rtb1, String.Format("[{0}] lexan: лексический анализ завершен\n", DateTime.Now.ToString("HH:mm:ss")), Color.Lime);
            return 1;
        }
        void add_text_token()
        {
            CustomTypes.Token temptok = new CustomTypes.Token();
            uint templn = cur_ln;
            uint tempcol = cur_col;
            parse_text(temptok);
            tokens_stream.add(SynTab.TokType.TOK_TEXT, temptok.str_val, templn, tempcol);
        }
    };
}
