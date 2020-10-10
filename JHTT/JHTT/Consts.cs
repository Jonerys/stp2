using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JHTT
{
    public static class Consts
    {
        public const int ACC = 22; /* ACCEPT CODE */
        public const SynTab.TokType START = SynTab.TokType.SYM_ROW; /* START SYMBOL */
        public const int MAX_DFA_STATE = 21; /* LAST DFA STATE */
        public const byte INVAL = 0;   // недопустимый
        public const byte DIGIT = 1;   // цифра
        public const byte CTEXT = 2;   // текст в ячейке
        public const byte COMMA = 4;   // запятая
        public const byte ROWOP = 5;   // начало строки
        public const byte ROWCL = 6;   // конец строки
        public const byte CHEAD = 7;   // граница заголовка ячейки
        public const byte SCENT = 8;   // выравнивание по центру
        public const byte SBOLD = 9;   // полужирный
        public const byte SITAL = 10;  // курсивный
        public const byte WHITE = 11;  // пробельный символ
        public const byte ENTER = 12;
    }
}
