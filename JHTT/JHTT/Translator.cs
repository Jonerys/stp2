using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    class Translator
    {
        Lexan lex;
        Stack<char> styles = new Stack<char>();
        System.IO.StreamWriter sw;
        public Translator(Lexan lex) {
            this.lex = lex;
        }
        int CreateHead()
        {
            sw.WriteLine("<!-- File created by Jonerys HTML Table Translator {0} {1} -->", DateTime.Now, TimeZoneInfo.Local.DisplayName);
            sw.Write("<html>\n<head>\n<meta charset = \"windows-1251\">\n<style>\n\t.col1 {\n\t width: 150px;\n\t}\n</style>\n</head>\n");
            return 1;
        }
        int CreateBody () {
            bool cellheader = false;
            sw.Write("<body>\n\t<table border=\"1\" cellpadding=\"5\">\n");
            for (int i = 1; i < lex.tokens_stream.tokens.Count; i++)
            {
                switch (lex.tokens_stream.tokens[i].stt)
                {
                    case SynTab.TokType.TOK_EOT: break;
                    case SynTab.TokType.TOK_BOR:
                        {
                            if (!cellheader)
                            {
                                cellheader = true;
                                sw.Write("\t  <td class=\"col1\" ");
                            }
                            else {
                                cellheader = false;
                                sw.Write(">");
                            } 
                        }
                    break;
                    case SynTab.TokType.TOK_CSC: sw.Write("colspan=\"{0}\" ", lex.tokens_stream.tokens[i].int_val); break;
                    case SynTab.TokType.TOK_COMMA: break;
                    case SynTab.TokType.TOK_RSC: sw.Write("rowspan=\"{0}\"", lex.tokens_stream.tokens[i].int_val); break;
                    case SynTab.TokType.TOK_TEXT:
                        {
                            sw.Write(lex.tokens_stream.tokens[i].str_val);
                            while (styles.Count > 0)
                            {
                                switch (styles.Pop())
                                {
                                    case 'b': sw.Write("</b>"); break; 
                                    case 'i': sw.Write("</i>"); break; 
                                    case 'c': sw.Write("</center>"); break; 
                                }
                            }
                            sw.Write("</td>\n");
                        }
                        break;
                    case SynTab.TokType.TOK_BAND: sw.Write("<b>"); styles.Push('b'); break;
                    case SynTab.TokType.TOK_DOLLAR: sw.Write("<i>"); styles.Push('i'); break;
                    case SynTab.TokType.TOK_XOR: sw.Write("<center>"); styles.Push('c'); break;

                    case SynTab.TokType.TOK_LS: sw.Write("\t <tr>\n"); break;
                    case SynTab.TokType.TOK_RS: sw.Write("\t </tr>\n"); break;
                    default: return 0;
                }
            }
            sw.Write("\t</table>\n</body>\n</html>");
            return 1;
        }
        public int CreateHTML()
        {
            try
            {
                sw = new System.IO.StreamWriter("Table.HTML", false, Encoding.Default);
                CreateHead();
                CreateBody();
                sw.Close();
                Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] translator: HTML файл создан успешно\n", DateTime.Now.ToString("HH:mm:ss")), Color.Lime);
            }
            catch (Exception e)
            {
                Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] translator: HTML файл не создан по причине ошибки: {1}\n", DateTime.Now.ToString("HH:mm:ss"), e.Message), Color.Red);
            }
            return 1;
        }
    }
}
