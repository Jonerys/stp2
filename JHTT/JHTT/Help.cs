using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JHTT
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            label2.Text = "Данное приложение позволяет ускорить создание таблиц в формате HTML.\n" +
                "Входной язык описан в документации, сопровождающей данное приложение\n" +
                "Для работы с приложением следует:\n" +
                "- загрузить текстовый файл с текстом на входном языке;\n" +
                "- нажать кнопку ОК.\n" +
                "Загрузку текстового файла можно произвести тремя способами:\n" +
                "- ввести путь к файлу вручную;\n" +
                "- нажать кнопку \"Обзор...\" (или сочетание клавиш Ctrl+O) и выбрать в открывшемся окне необходимый файл;\n" +
                "- перетащить файл в окно программы.\n" +
                "Ход работы приложения отображается в окне \"Лог\" в нижней части окна.\n" +
                "В случае возникновения синтаксической ошибки будет указана позиция первой ошибки в тексте.\n" +
                "В случае возникновения ошибки \"Отказано в доступе\" следует запустить приложение от имени администратора.";
            label3.Text = "Руководитель:       Зубаиров А.Ф.\n" +
                "Группа:                  1ПО-47Д\n" +
                "Выполнил:             Войщев П.Р.\n" +
                "           Октябрь 2020";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
