# PeopleBase

Консольное приложение на C# с использованием MS SQL Server. 

Приложение использует плагины: ConsoleTables для вывода таблицы в консоль, ClosedXML для сохранения результатов в xlsx файл и System.Data.SqlClient для работы с MS SQL Server.

Аргументы для использования функционала приложения:

"1": Создание базы "PEOPLE.mdf" по адресу Environment.SpecialFolder.CommonApplicationData и таблицы в ней с полями: ФИО, дата рождения, пол. (FULL_NAME, BIRTH_DATE, GENDER)

"2 ФИО ДатаРождения Пол": Создание записи. Использовать формат в консоли как пример в аргументе.

"3": Вывод всех строк с уникальным значением ФИО + дата рождения, пол, количество полных лет, отсортированных по ФИО.

"4": Заполнение автоматически 1000000 строк (псевдорандом генерация). Вывод приложения содержит время выполнения. Распределение пола относительно равномерное, начальная буква ФИО также равномерна.

"4.1": Заполнение автоматически 100 строк (псевдорандом генерация), в которых пол мужской и ФИО начинается с 'F'. Вывод приложения содержит время выполнения.

"5": Результат выборки из таблицы по критерию: пол 'M', ФИО начинается с 'F'. Вывод приложения содержит время выполнения.

"5.1": Отображение результата выборки из таблицы по критерию: пол мужской, ФИО начинается с "F".

"6": Манипуляция, при которой время исполнения уменьшилось по сравнению с запросом с предыдущим аргументом. Вывод приложения содержит время выполнения.

"6.1": Отображение результата выборки (ускоренный) из таблицы по критерию: пол мужской, ФИО начинается с "F". 

"clear": Удаление всех данных из таблицы с сохранением названий столбцов.

"view": Просмотр неуникальных (всех) строк из таблицы.

"drop": Удаление таблицы.