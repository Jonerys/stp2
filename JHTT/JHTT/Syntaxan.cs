using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    class Syntaxan
    {
        // ссылка на лексический анализатор
        Lexan lex;
        // текущий токен
        CustomTypes.Token tok = new CustomTypes.Token();
        // стек МП-автомата
        Stack<int> sta = new Stack<int>();
        // возвращает очередной токен
        // конструктор
        public int next_token()
        {
            lex.cur_tok++;
            if (lex.cur_tok > lex.tokens_stream.tokens.Count) return 0;
            tok.stt = lex.tokens_stream.tokens[lex.cur_tok].stt;
            tok.int_val = lex.tokens_stream.tokens[lex.cur_tok].int_val;
            tok.str_val = lex.tokens_stream.tokens[lex.cur_tok].str_val;
            tok.row = lex.tokens_stream.tokens[lex.cur_tok].row;
            tok.col = lex.tokens_stream.tokens[lex.cur_tok].col;
            return 1;
        }
        public Syntaxan(Lexan lex)
        {
            this.lex = lex;
        }
        // LR(1)
        public int parse()
        {
            Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: начат синтаксический анализ\n", DateTime.Now.ToString("HH:mm:ss")), Color.Lime);
            if (next_token() == 0) return 0;
            // новое состоние ДКА
            int m;
            // символ на с стеке
            int s;
            // значение в таблице
            int t;
            // проталкиваем символ дна стека
            sta.Push(Convert.ToInt32(SynTab.TokType.TOK_EOT));
            // беск цикл автомата
            while (true)
            {
                // символ с вершины стека
                s = sta.Peek();
                // считываем значение из таблицы символов
                t = SynTab.SYNTA[s][Convert.ToInt32(tok.stt)];
                // допуск
                if (t == Consts.ACC) break;
                else if (t < 0)
                {
                    // свертка
                    // выталкиваем цепочку со стека
                    for (int i = 1; i <= 2 * SynTab.RLEN[-t]; i++) sta.Pop();
                    // получаем новое состояние на стеке
                    s = sta.Peek();
                    // проталкиваем проталкиваем символ, в который свернулась цепочка
                    sta.Push(Convert.ToInt32(SynTab.RSYM[-t]));
                    m = SynTab.SYNTA[s][Convert.ToInt32(SynTab.RSYM[-t])];
                    sta.Push(m);
                }
                else if (t > 0 && t < Consts.MAX_DFA_STATE)
                {
                    // сдвиг     
                    sta.Push(s);
                    sta.Push(t);
                    next_token();
                }
                else if (t > 0)
                {
                    // ошибка синт таблицы
                    Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: ошибка синтаксической таблицы\n", DateTime.Now.ToString("HH:mm:ss")), Color.Red);
                    Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: синтаксический анализ завершен с ошибкой\n", DateTime.Now.ToString("HH:mm:ss")), Color.Yellow);
                    return 0;
                }
                else
                {
                    // синт ошибка
                    Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: обнаружена синтаксическая ошибка, код = {1}\n", DateTime.Now.ToString("HH:mm:ss"), t), Color.Red);
                    Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: ошибка в строке {1}, столбец {2}\n", DateTime.Now.ToString("HH:mm:ss"), tok.row, tok.col), Color.Red);
                    Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: синтаксический анализ завершен с ошибкой\n", DateTime.Now.ToString("HH:mm:ss")), Color.Yellow);
                    return 0;
                }
            }
            Program.mainwindow.AppendText(lex.rtb1, String.Format("[{0}] syntaxan: синтаксический анализ завершен успешно\n", DateTime.Now.ToString("HH:mm:ss")), Color.Lime);
            return 1;
        }
    };
}
