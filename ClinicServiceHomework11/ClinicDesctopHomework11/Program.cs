using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicDesctopHomework11
{
    internal static class Program
    {
        // Если после кодогенерации вылетит ошибка
        // нужно добавить следующую сборку к текущим
        // сборкам приложения
        // System.Runtime.Serialization
        // После этого делаю Rebuild Solution
        // После этого переходим к кодированию функционала
        // клиентского приложения
        // Настроим сбытие клик для кнопки

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles(); // с помощью этой
                                              // инструкции приложение
                                              // подстраивается под
                                              // визуальный стиль той
                                              // ПО под которой
                                              // оно запускается
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm()); // здесь мы запускаем нашу
                                          // форму на исполненин
        }
    }
}
