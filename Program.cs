﻿using System;
using System.Data;
using System.Data.SqlClient;
using PeopleBase;

class Program
{
    static void Main(string[] args)
    {        
        if (args.Length == 0)
        {
            Console.WriteLine("Введите номер аргумента от 1 до 6 для доступа к программе.");
            Console.WriteLine("\"1\": Создание таблицы с полями представляющими ФИО, дату рождения, пол.\n" +
                "\"2 ФИО ДатаРождения Пол\": Создание записи. Использовать формат как пример в аргументе.\n" +
                "\"3\": Вывод всех строк с уникальным значением ФИО + дата рождения, пол, количество полных лет, отсортированных по ФИО.\n" +
                "\"4\": Заполнение автоматически 1000000 строк. Распределение пола относительно равномерное, начальная буква ФИО также равномерное. Заполнение автоматически 100 строк в которых пол мужской и ФИО начинается с \"F\".\n" +
                "\"5\": Результат выборки из таблицы по критерию: пол мужской, ФИО начинается с \"F\". Вывод приложения содержит время выполнения.\n" +
                "\"6\": Манипуляция, при которой время исполнения уменьшилось по сравнению с запросом с предыдущим аргументом.\n" +
                "\"clear\": Удаление всех данных из таблицы с сохранением названий столбцов.");
        }
        else
        {
            var arg = new Arguments(args);
        }
    }
}

