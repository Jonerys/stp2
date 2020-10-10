using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    class CustomTypes
    {
        public class Token
        {
            public SynTab.TokType stt;
            public string str_val;
            public int int_val;
            public uint row;
            public uint col;
            public Token()
            {
                reset();
            }
            public Token(SynTab.TokType tt, string str, uint row, uint col)
            {
                stt = tt;
                str_val = str;
                this.row = row;
                this.col = col;
            }
            public Token(SynTab.TokType tt, int num, uint row, uint col)
            {
                stt = tt;
                int_val = num;
                this.row = row;
                this.col = col;
            }
            public void append(byte c)
            {
                byte[] tempb = new byte[1];
                tempb[0] = c;
                string temp = Encoding.Default.GetString(tempb);
                str_val += temp;
            }
            public void reset()
            {
                stt = SynTab.TokType.TOK_EOT;
                str_val = "";
                int_val = 0;
                row = 1;
                col = 1;
            }
        }

        public class TokenStack
        {
            public List<Token> tokens = new List<Token>();
            // добавляет токен и возвращает его индекс
            public int add(SynTab.TokType tt, string strval, uint row, uint col)
            {
                Token temp = new Token();
                temp.stt = tt;
                temp.str_val = strval;
                temp.row = row;
                temp.col = col;
                tokens.Add(temp);
                return 1;
            }
            public int add(SynTab.TokType tt, int intval, uint row, uint col)
            {
                Token temp = new Token();
                temp.stt = tt;
                temp.int_val = intval;
                temp.row = row;
                temp.col = col;
                tokens.Add(temp);
                return 1;
            }
            // возвращает указанный токен
            public Token get_token(int index)
            {
                Token tok = new Token();
                tok.stt = SynTab.TokType.TOK_UNKNOWN;
                tok = tokens[index];
                return tok;
            }
            public void print(System.Windows.Forms.RichTextBox rtb1)
            {
                Program.mainwindow.AppendText(rtb1, "\n********** РЕЖИМ ОТЛАДКИ **********\n", Color.Lime);
                for (int i = 1; i < tokens.Count; i++)
                {
                    Program.mainwindow.AppendText(rtb1, String.Format("\n" + i + " "), Color.Lime);
                    switch (tokens[i].stt)
                    {
                        case SynTab.TokType.TOK_UNKNOWN: Program.mainwindow.AppendText(rtb1, "UNKNOWN", Color.Yellow); break;
                        case SynTab.TokType.TOK_EOT: Program.mainwindow.AppendText(rtb1, "EOT", Color.Lime); break;
                        case SynTab.TokType.TOK_BOR: Program.mainwindow.AppendText(rtb1, String.Format("CELLHEADER ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_CSC: Program.mainwindow.AppendText(rtb1, String.Format("COLSPAN {0} ln {1} col {2}", tokens[i].int_val, tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_COMMA: Program.mainwindow.AppendText(rtb1, String.Format("COMMA ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_TEXT: {
                                byte[] temp = Encoding.GetEncoding(1251).GetBytes(tokens[i].str_val);
                                Program.mainwindow.AppendText(rtb1, String.Format("TEXT {0} ln {1} col {2}", Encoding.GetEncoding(1251).GetString(temp), tokens[i].row, tokens[i].col), Color.Lime);
                            }
                            break;
                        case SynTab.TokType.TOK_BAND: Program.mainwindow.AppendText(rtb1, String.Format("BOLD ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_DOLLAR: Program.mainwindow.AppendText(rtb1, String.Format("ITALIC ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_XOR: Program.mainwindow.AppendText(rtb1, String.Format("CENTER ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_RSC: Program.mainwindow.AppendText(rtb1, String.Format("ROWSPAN {0} ln {1} col {2}", tokens[i].int_val, tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_LS: Program.mainwindow.AppendText(rtb1, String.Format("ROWOPEN ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        case SynTab.TokType.TOK_RS: Program.mainwindow.AppendText(rtb1, String.Format("ROWCLOSE ln {0} col {1}", tokens[i].row, tokens[i].col), Color.Lime); break;
                        default: Program.mainwindow.AppendText(rtb1, "UNEXPECTED", Color.Red); break;
                    }
                }
                Program.mainwindow.AppendText(rtb1, "\n\n********** РЕЖИМ ОТЛАДКИ **********\n\n", Color.Lime);
            }
        }
    }
}
