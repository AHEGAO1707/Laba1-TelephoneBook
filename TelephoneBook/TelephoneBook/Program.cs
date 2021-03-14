using System;
using System.Globalization;

namespace TelephoneBook
{
    class Program
    {
        public static Note[] notes = new Note[1];
        public static int isEmpty = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Здравствуйте! Это записная телефонная книжка!");
            Console.WriteLine("");
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("Чтобы создать новую запись введите 1");
                Console.WriteLine("Чтобы редактировать запись введите 2");
                Console.WriteLine("Чтобы удалить запись введите 3");
                Console.WriteLine("Чтобы просмотреть ВСЕ созданные учётные записи введите 4");
                Console.WriteLine("Чтобы просмотреть ВСЕ созданные учётные с КРАТКОЙ информацией введите 5");
                Console.WriteLine("Если Вы хотите закончить работу введите 0");
                Console.WriteLine("");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int x) == true)
                {
                    switch (int.Parse(choice))
                    {
                        case 0:
                            goto Exit;
                        case 1:
                            AddNote();
                            break;
                        case 2:
                            EditNote();
                            break;
                        case 3:
                            DeleteNote();
                            break;
                        case 4:
                            LookAllNotes();
                            break;
                        case 5:
                            LookAllNotesMini();
                            break;
                        default:
                            Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                }
            }
        Exit:
            Console.WriteLine("");
            Console.WriteLine("Спасибо за использование! До свидания!");
        }

        public static void AddNote()
        {
        Add:
            Console.WriteLine("");
            Console.WriteLine("Вы захотели создать новую запись в телефонной книжке!");
            Console.WriteLine("Пожалуйста,введите следующие данные:");
            Console.WriteLine("");
        Sur:
            Console.WriteLine("Фамилия:");
            Console.WriteLine("");
            string sur = Console.ReadLine();
            Console.WriteLine("");
            if (sur == "")
            {
                Console.WriteLine("Извините, это обязательный параметр для создания записи, укажите его, пожалуйста");
                Console.WriteLine("");
                goto Sur;
            }
            else
            {
                sur = sur.Substring(0, 1).ToUpper() + sur.Substring(1, sur.Length - 1).ToLower(); //здесь и далее фамилии, имена, отчества, страны должны быть с большой буквы
            }
        Nam:
            Console.WriteLine("Имя:");
            Console.WriteLine("");
            string nam = Console.ReadLine();
            Console.WriteLine("");
            if (nam == "")
            {
                Console.WriteLine("Извините, это обязательный параметр для создания записи, укажите его, пожалуйста");
                Console.WriteLine("");
                goto Nam;
            }
            else
            {
                nam = nam.Substring(0, 1).ToUpper() + nam.Substring(1, nam.Length - 1).ToLower();
            }
            Console.WriteLine("Отчество (необязательно):");
            Console.WriteLine("");
            string thi = Console.ReadLine();
            Console.WriteLine("");
            if (thi == "")
            {
            }
            else
            {
                thi = thi.Substring(0, 1).ToUpper() + thi.Substring(1, thi.Length - 1).ToLower();
            }
        Tel:
            Console.WriteLine("Номер телефона (допускаются только цифры):");
            Console.WriteLine("");
            string tel = Console.ReadLine();
            Console.WriteLine("");
            if (tel == "")
            {
                Console.WriteLine("Извините, это обязательный параметр для создания записи, укажите его, пожалуйста");
                Console.WriteLine("");
                goto Tel;
            }
            else
            {
                if (long.TryParse(tel, out long l) != true)
                {
                    Console.WriteLine("Ну там же было белым по чёрному написано что допускаются только цифры... Побробуйте ещё раз, пожалуйста.");
                    Console.WriteLine("");
                    goto Tel;
                }
            }
        Cou:
            Console.WriteLine("Страна:");
            Console.WriteLine("");
            string cou = Console.ReadLine();
            Console.WriteLine("");
            if (cou == "")
            {
                Console.WriteLine("Извините, это обязательный параметр для создания записи, укажите его, пожалуйста");
                Console.WriteLine("");
                goto Cou;
            }
            else
            {
                cou = cou.Substring(0, 1).ToUpper() + cou.Substring(1, cou.Length - 1).ToLower();
            }
        Dat:
            Console.WriteLine("Дата рождения (необязательно). Вводите в формате \"дд.мм.гггг\", пожалуйста:");
            Console.WriteLine("");
            string dat = Console.ReadLine();
            Console.WriteLine("");
            if (dat == "")
            {
                dat = "01.01.0001";
            }
            else
            {
                if ((DateTime.TryParseExact(dat, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime d)) != true)
                {
                    Console.WriteLine("Пожалуйста, введите дату рождения в правильном формате.");
                    goto Dat;
                }
            }
            Console.WriteLine("Организация (необязательно):"); //организации, должности и прочие заметки пусть будут с маленкой буквы
            Console.WriteLine("");
            string org = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Должность (необязательно):");
            Console.WriteLine("");
            string pos = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Прочие заметки (необязательно):");
            Console.WriteLine("");
            string plu = Console.ReadLine();
            Console.WriteLine("");
            if (notes[0] != null)
            {
                Array.Resize(ref notes, notes.Length + 1);
                notes[notes.Length - 1] = new Note(sur, nam, thi, tel, cou, dat, org, pos, plu);
            }
            else
            {
                notes[0] = new Note(sur, nam, thi, tel, cou, dat, org, pos, plu);
            }
            Console.WriteLine("");
            Console.WriteLine("Запись была добавлена успешно!");
        Choose:
            Console.WriteLine("");
            Console.WriteLine("Хотите ещё добавить запись? Тогда введите 1. Не хотите? Нажмите 0");
            Console.WriteLine("");
            string choice = Console.ReadLine();
            Console.WriteLine("");
            if (int.TryParse(choice, out int x) == true)
            {
                switch (int.Parse(choice))
                {
                    case 0:
                        break;
                    case 1:
                        goto Add;
                    default:
                        Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                        goto Choose;
                }
            }
            else
            {
                Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                goto Choose;
            }

        }

        public static void EditNote()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы захотели изменить существующую запись в телефонной книжке!");
            for (int i = 1; i < notes.Length + 1; i++)
            {
                if (notes[i - 1] == null)
                {
                    isEmpty++;
                }
            }
            if (isEmpty == notes.Length)
            {
                Console.WriteLine("Захотели Вы то, конечно, захотели... Но вот что изменять то? Записей то нет!");
                Console.WriteLine("Идите-ка Вы в \"Меню\" и добавьте записи что-ли...");
                Console.WriteLine("");
                isEmpty = 0;
            }
            else
            {
                isEmpty = 0;
            ChooseNote:
                Console.WriteLine("Ниже представлен список всех существующих записей в телефонной книге:");
                //именно поэтому при добавлении записи делал красивые фамилии, имена и тд...
                Console.WriteLine("");
                for (int i = 1; i < notes.Length + 1; i++)
                {
                    if (notes[i - 1] == null)
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Видимо эта запись была удалена (обнулена).. К сожалению человек, который это написал не знает как сделать так, чтобы номер записей в массиве изменился соответсвенно :(");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Фамилия: " + notes[i - 1].Surname);
                        Console.WriteLine("Имя: " + notes[i - 1].Name);
                        Console.WriteLine("Отчество: " + notes[i - 1].ThirdName);
                        Console.WriteLine("Номер телефона: " + notes[i - 1].Telephone);
                        Console.WriteLine("Страна: " + notes[i - 1].Country);
                        if (notes[i - 1].DateOfBirth == DateTime.MinValue)
                        {
                            Console.WriteLine("Дата рождения: ");
                        }
                        else
                        {
                            Console.WriteLine("Дата рождения: " + notes[i - 1].DateOfBirth);
                        }
                        Console.WriteLine("Организация: " + notes[i - 1].Organization);
                        Console.WriteLine("Должность: " + notes[i - 1].Post);
                        Console.WriteLine("Прочие заметки: " + notes[i - 1].PlusInfo);
                        Console.WriteLine("");
                    }
                }
            ChooseNumNote:
                Console.WriteLine("Пожалуйста, введите номер записи в телефонной книжке, который Вы хотите отредактировать: ");
                Console.WriteLine("");
                string choice = Console.ReadLine();
                Console.WriteLine("");
                if (int.TryParse(choice, out int x) == true)
                {
                    if ((int.Parse(choice) <= notes.Length) && (int.Parse(choice) >= 1))
                    {
                        if (notes[int.Parse(choice) - 1] == null)
                        {
                            Console.WriteLine("Не надо выбирать для редактирования то, что уже удалено (обнулено), пожалуйста. Выберите другой номер записи.");
                            Console.WriteLine("");
                            goto ChooseNumNote;
                        }
                        else
                        {
                        Change:
                            Console.WriteLine("Итак, Ваша выбранная запись: ");
                            //сделал вывод выбранной записи снова для удобства редактирования нужных данных. Допустим будет 100500 записей. Неудобно жеж.. Всё для пользователей так сказать)
                            Console.WriteLine("");
                            Console.WriteLine("Фамилия: " + notes[int.Parse(choice) - 1].Surname);
                            Console.WriteLine("Имя: " + notes[int.Parse(choice) - 1].Name);
                            Console.WriteLine("Отчество: " + notes[int.Parse(choice) - 1].ThirdName);
                            Console.WriteLine("Номер телефона: " + notes[int.Parse(choice) - 1].Telephone);
                            Console.WriteLine("Страна: " + notes[int.Parse(choice) - 1].Country);
                            if (notes[int.Parse(choice) - 1].DateOfBirth == DateTime.MinValue)
                            {
                                Console.WriteLine("Дата рождения: ");
                            }
                            else
                            {
                                Console.WriteLine("Дата рождения: " + notes[int.Parse(choice) - 1].DateOfBirth);
                            }
                            Console.WriteLine("Организация: " + notes[int.Parse(choice) - 1].Organization);
                            Console.WriteLine("Должность: " + notes[int.Parse(choice) - 1].Post);
                            Console.WriteLine("Прочие заметки: " + notes[int.Parse(choice) - 1].PlusInfo);
                        ChooseEditParameter:
                            Console.WriteLine("");
                            Console.WriteLine("Если Вы хотите добавить/изменить: ");
                            Console.WriteLine("Фамилию - введите 1");
                            Console.WriteLine("Имя - введите 2");
                            Console.WriteLine("Отчество - введите 3");
                            Console.WriteLine("Номер телефона - введите 4");
                            Console.WriteLine("Страну - введите 5");
                            Console.WriteLine("Дату рождения - введите 6");
                            Console.WriteLine("Организацию - введите 7");
                            Console.WriteLine("Должность - введите 8");
                            Console.WriteLine("Прочие заметки -  9");
                            Console.WriteLine("");
                            string choice1 = Console.ReadLine();
                            Console.WriteLine("");
                            if (int.TryParse(choice1, out int z) == true)
                            {
                                switch (int.Parse(choice1))
                                {
                                    case 1:
                                        Console.WriteLine("Введите новую фамилию для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string sur = Console.ReadLine();
                                        if (sur == "")
                                        {
                                            Console.WriteLine("Извините, это обязательный параметр для добавления/редактирования данных в записи, укажите его, пожалуйста");
                                            Console.WriteLine("");
                                            goto case 1;
                                        }
                                        else
                                        {
                                            sur = sur.Substring(0, 1).ToUpper() + sur.Substring(1, sur.Length - 1).ToLower();
                                            notes[int.Parse(choice) - 1].Surname = sur;
                                            Console.WriteLine("");
                                            Console.WriteLine("Фамилия изменена успешно!");
                                            break;
                                        }
                                    case 2:
                                        Console.WriteLine("Введите новое имя для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string nam = Console.ReadLine();
                                        if (nam == "")
                                        {
                                            Console.WriteLine("Извините, это обязательный параметр для добавления/редактирования данных в записи, укажите его, пожалуйста");
                                            Console.WriteLine("");
                                            goto case 2;
                                        }
                                        else
                                        {
                                            nam = nam.Substring(0, 1).ToUpper() + nam.Substring(1, nam.Length - 1).ToLower();
                                            notes[int.Parse(choice) - 1].Name = nam;
                                            Console.WriteLine("");
                                            Console.WriteLine("Имя изменено успешно!");
                                            break;
                                        }
                                    case 3:
                                        Console.WriteLine("Введите новое отчество для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string thi = Console.ReadLine();
                                        if (thi == "")
                                        {
                                            notes[int.Parse(choice) - 1].ThirdName = thi;
                                            Console.WriteLine("");
                                            Console.WriteLine("Отчество изменено успешно!");
                                            break;
                                        }
                                        else
                                        {
                                            thi = thi.Substring(0, 1).ToUpper() + thi.Substring(1, thi.Length - 1).ToLower();
                                            notes[int.Parse(choice) - 1].ThirdName = thi;
                                            Console.WriteLine("");
                                            Console.WriteLine("Отчество изменено успешно!");
                                            break;
                                        }
                                    case 4:
                                        Console.WriteLine("Введите новый номер телефона для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string tel = Console.ReadLine();
                                        if (tel == "")
                                        {
                                            Console.WriteLine("Извините, это обязательный параметр для добавления/редактирования данных в записи, укажите его, пожалуйста");
                                            Console.WriteLine("");
                                            goto case 4;
                                        }
                                        else
                                        {
                                            if (long.TryParse(tel, out long l) != true)
                                            {
                                                Console.WriteLine("Вам уже стучали по голове за такой формат телефона при добавлении записи в телефонную книгу.. Попробуйте еще раз!");
                                                goto case 4;
                                            }
                                            else
                                            {
                                                notes[int.Parse(choice) - 1].Telephone = tel;
                                                Console.WriteLine("");
                                                Console.WriteLine("Номер телефона изменен успешно!");
                                                break;
                                            }
                                        }
                                    case 5:
                                        Console.WriteLine("Введите новую страну для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string cou = Console.ReadLine();
                                        if (cou == "")
                                        {
                                            Console.WriteLine("Извините, это обязательный параметр для добавления/редактирования данных в записи, укажите его, пожалуйста");
                                            Console.WriteLine("");
                                            goto case 5;
                                        }
                                        else
                                        {
                                            cou = cou.Substring(0, 1).ToUpper() + cou.Substring(1, cou.Length - 1).ToLower();
                                            notes[int.Parse(choice) - 1].Country = cou;
                                            Console.WriteLine("");
                                            Console.WriteLine("Страна изменена успешно!");
                                            break;
                                        }
                                    case 6:
                                        Console.WriteLine("Введите новую дату рождения для изменения/добавления: ");
                                        Console.WriteLine("");
                                        string dat = Console.ReadLine();
                                        if (dat == "")
                                        {
                                            dat = "01.01.0001";
                                        }
                                        else
                                        {
                                            if ((DateTime.TryParseExact(dat, "dd.MM.yyyy", null, DateTimeStyles.None, out DateTime d)) != true)
                                            {
                                                Console.WriteLine("Пожалуйста, введите дату рождения в правильном формате.");
                                                goto case 6;
                                            }
                                        }
                                        notes[int.Parse(choice) - 1].DateOfBirth = DateTime.Parse(dat);
                                        Console.WriteLine("");
                                        Console.WriteLine("Дата рождения изменена успешно!");
                                        break;
                                    case 7:
                                        Console.WriteLine("Введите новую организацию для изменения/добавления: ");
                                        Console.WriteLine("");
                                        notes[int.Parse(choice) - 1].Organization = Console.ReadLine();
                                        Console.WriteLine("");
                                        Console.WriteLine("Организация изменена успешно!");
                                        break;
                                    case 8:
                                        Console.WriteLine("Введите новую должность для изменения/добавления: ");
                                        Console.WriteLine("");
                                        notes[int.Parse(choice) - 1].Post = Console.ReadLine();
                                        Console.WriteLine("");
                                        Console.WriteLine("Должность изменена успешно!");
                                        break;
                                    case 9:
                                        Console.WriteLine("Введите новые прочие заметки для изменения/добавления: ");
                                        Console.WriteLine("");
                                        notes[int.Parse(choice) - 1].PlusInfo = Console.ReadLine();
                                        Console.WriteLine("");
                                        Console.WriteLine("Прочие заметки изменены успешно!");
                                        break;
                                    default:
                                        Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                                        goto ChooseEditParameter;

                                }
                            }
                            else
                            {
                                Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                                goto ChooseEditParameter;
                            }
                        EndChoiceEditNote:
                            Console.WriteLine("");
                            Console.WriteLine("Если Вы хотите еще чего-нибудь изменить/добавить в данной записи нажмите 1");
                            Console.WriteLine("Если Вы хотите перевыбрать запись для изменения/добавления данных нажмите 2");
                            Console.WriteLine("Если Вы устали изменять что-либо в записях нажмите 0. Это вернёт Вас в главное \"Меню\"");
                            Console.WriteLine("");
                            string choice2 = Console.ReadLine();
                            Console.WriteLine("");
                            if (int.TryParse(choice2, out int y) == true)
                            {
                                switch (int.Parse(choice2))
                                {
                                    case 1:
                                        goto Change;
                                    case 2:
                                        goto ChooseNote;
                                    case 0:
                                        break;
                                    default:
                                        Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                                        goto EndChoiceEditNote;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                                goto EndChoiceEditNote;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не надо пытаться выбрать то, чего нет в списке записей. Выберите правильный номер записи, пожалуйста");
                        Console.WriteLine("");
                        goto ChooseNumNote;
                    }
                }
                else
                {
                    Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                    Console.WriteLine("");
                    goto ChooseNumNote;
                }
            }
        }

        public static void DeleteNote()
        {

        EndChoiceWhatDelete:
            Console.WriteLine("");
            Console.WriteLine("Вы захотели удалить запись из телефонной книги!");
            for (int i = 1; i < notes.Length + 1; i++)
            {
                if (notes[i - 1] == null)
                {
                    isEmpty++;
                }
            }
            if (isEmpty == notes.Length)
            {
                Console.WriteLine("Захотели Вы то, конечно, захотели... Но вот что удалять то? Записей то нет!");
                Console.WriteLine("Идите-ка Вы в \"Меню\" и добавьте записи что-ли...");
                Console.WriteLine("");
                isEmpty = 0;
            }
            else
            {
                isEmpty = 0;
            ChooseWhatDelete:
                Console.WriteLine("Ниже представлен список всех существующих учётных записей в телефонной книге:");
                //именно поэтому при добавлении записи делал красивые фамилии, имена и тд...
                Console.WriteLine("");

                for (int i = 1; i < notes.Length + 1; i++)
                {
                    if (notes[i - 1] == null)
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Видимо эта запись была удалена (обнулена).. К сожалению человек, который это написал не знает как сделать так, чтобы номер записей в массиве изменился соответсвенно :(");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Фамилия: " + notes[i - 1].Surname);
                        Console.WriteLine("Имя: " + notes[i - 1].Name);
                        Console.WriteLine("Отчество: " + notes[i - 1].ThirdName);
                        Console.WriteLine("Номер телефона: " + notes[i - 1].Telephone);
                        Console.WriteLine("Страна: " + notes[i - 1].Country);
                        if (notes[i - 1].DateOfBirth == DateTime.MinValue)
                        {
                            Console.WriteLine("Дата рождения: ");
                        }
                        else
                        {
                            Console.WriteLine("Дата рождения: " + notes[i - 1].DateOfBirth);
                        }
                        Console.WriteLine("Организация: " + notes[i - 1].Organization);
                        Console.WriteLine("Должность: " + notes[i - 1].Post);
                        Console.WriteLine("Прочие заметки: " + notes[i - 1].PlusInfo);
                        Console.WriteLine("");
                    }
                }
                Console.WriteLine("Пожалуйста, введите номер записи в телефонной книжке, который Вы хотите удалить: ");
                Console.WriteLine("");
                string choice = Console.ReadLine();
                Console.WriteLine("");
                if (int.TryParse(choice, out int x) == true)
                {
                    if ((int.Parse(choice) <= notes.Length) && (int.Parse(choice) >= 1))
                    {
                        if (notes[int.Parse(choice) - 1] == null)
                        {
                            Console.WriteLine("Не надо выбирать для удаления то, что уже удалено (обнулено), пожалуйста. Выберите другой номер записи.");
                            Console.WriteLine("");
                            goto ChooseWhatDelete;
                        }
                        else
                        {

                        }
                        Console.WriteLine("Итак, вот Ваша запись, которую Вы собираетесь удалить: ");
                        //сделал вывод выбранной записи снова для удобства удаления записи. Вдруг пользователь посмотрит на свой контакт снова и передумает удалять Всё для пользователей так сказать)
                        Console.WriteLine("");
                        Console.WriteLine("Фамилия: " + notes[int.Parse(choice) - 1].Surname);
                        Console.WriteLine("Имя: " + notes[int.Parse(choice) - 1].Name);
                        Console.WriteLine("Отчество: " + notes[int.Parse(choice) - 1].ThirdName);
                        Console.WriteLine("Номер телефона: " + notes[int.Parse(choice) - 1].Telephone);
                        Console.WriteLine("Страна: " + notes[int.Parse(choice) - 1].Country);
                        if (notes[int.Parse(choice) - 1].DateOfBirth == DateTime.MinValue)
                        {
                            Console.WriteLine("Дата рождения: ");
                        }
                        else
                        {
                            Console.WriteLine("Дата рождения: " + notes[int.Parse(choice) - 1].DateOfBirth);
                        }
                        Console.WriteLine("Организация: " + notes[int.Parse(choice) - 1].Organization);
                        Console.WriteLine("Должность: " + notes[int.Parse(choice) - 1].Post);
                        Console.WriteLine("Прочие заметки: " + notes[int.Parse(choice) - 1].PlusInfo);
                    PredEndDeleteNoteChoise:
                        Console.WriteLine("");
                        Console.WriteLine("Если Вы всё же решились распрощаться с этой записью введите 1");
                        Console.WriteLine("Если Вы передумали и решили, что хотите удалить какую-другую запись введите 2");
                        Console.WriteLine("Если Вы поняли что вообще не хотите удалять записи введите 3 и попадёте в \"Меню\"");
                        Console.WriteLine("");
                        string choice1 = Console.ReadLine();
                        Console.WriteLine("");
                        if (int.TryParse(choice1, out int y) == true)
                        {
                            switch (int.Parse(choice1))
                            {
                                case 1:
                                    notes[int.Parse(choice) - 1] = null;
                                    Console.WriteLine("Больше Вы эту запись не увидите! Она \"удалена\" (на самом деле обнулена).");
                                ChooseWhatToDoAfterDelete:
                                    Console.WriteLine("");
                                    Console.WriteLine("Хотите удалить чего-то еще? Введите 1");
                                    Console.WriteLine("Хотите вернуться в \"Меню\"? Введите 0");
                                    Console.WriteLine("");
                                    string choice2 = Console.ReadLine();
                                    Console.WriteLine("");
                                    if (int.TryParse(choice2, out int w) == true)
                                    {
                                        switch (int.Parse(choice2))
                                        {
                                            case 1:
                                                goto EndChoiceWhatDelete;
                                            case 0:
                                                break;
                                            default:
                                                Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                                                goto ChooseWhatToDoAfterDelete;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                                        goto ChooseWhatToDoAfterDelete;
                                    }
                                    break;

                                case 2:
                                    goto ChooseWhatDelete;
                                case 3:
                                    break;
                                default:
                                    Console.WriteLine("Какую-то... Странную команду Вы ввели.. Давайте-ка ещё разок!");
                                    goto PredEndDeleteNoteChoise;

                            }
                        }
                        else
                        {
                            Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                            goto PredEndDeleteNoteChoise;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Не надо пытаться выбрать то, чего нет в списке записей. Выберите правильный номер записи, пожалуйста");
                        Console.WriteLine("");
                        goto ChooseWhatDelete;
                    }
                }
                else
                {
                    Console.WriteLine("Ой-ёй... Вы ввели что-то вроде строки... Попробуйте еще раз, пожалуйста :)");
                    Console.WriteLine("");
                    goto ChooseWhatDelete;
                }
            }
        }



        public static void LookAllNotes()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы захотели просмотреть созданные учётные записи!");
            for (int i = 1; i < notes.Length + 1; i++)
            {
                if (notes[i - 1] == null)
                {
                    isEmpty++;
                }
            }
            if (isEmpty == notes.Length)
            {
                Console.WriteLine("Захотели Вы то, конечно, захотели... Но вот что изменять то? Записей то нет!");
                Console.WriteLine("Идите-ка Вы в \"Меню\" и добавьте записи что-ли...");
                Console.WriteLine("");
                isEmpty = 0;
            }
            else
            {
                isEmpty = 0;
                Console.WriteLine("Ниже представлен список всех существующих учётных записей в телефонной книге:");
                //именно поэтому при добавлении записи делал красивые фамилии, имена и тд...
                Console.WriteLine("");
                for (int i = 1; i < notes.Length + 1; i++)
                {
                    if (notes[i - 1] == null)
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Видимо эта запись была удалена (обнулена).. К сожалению человек, который это написал не знает как сделать так, чтобы номер записей в массиве изменился соответсвенно :(");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Фамилия: " + notes[i - 1].Surname);
                        Console.WriteLine("Имя: " + notes[i - 1].Name);
                        Console.WriteLine("Отчество: " + notes[i - 1].ThirdName);
                        Console.WriteLine("Номер телефона: " + notes[i - 1].Telephone);
                        Console.WriteLine("Страна: " + notes[i - 1].Country);
                        if (notes[i - 1].DateOfBirth == DateTime.MinValue)
                        {
                            Console.WriteLine("Дата рождения: ");
                        }
                        else
                        {
                            Console.WriteLine("Дата рождения: " + notes[i - 1].DateOfBirth);
                        }
                        Console.WriteLine("Организация: " + notes[i - 1].Organization);
                        Console.WriteLine("Должность: " + notes[i - 1].Post);
                        Console.WriteLine("Прочие заметки: " + notes[i - 1].PlusInfo);
                        Console.WriteLine("");
                    }
                }
            }
        }

        public static void LookAllNotesMini()
        {
            Console.WriteLine("");
            Console.WriteLine("Вы захотели просмотреть созданные учётные записи c краткой информацией!");
            for (int i = 1; i < notes.Length + 1; i++)
            {
                if (notes[i - 1] == null)
                {
                    isEmpty++;
                }
            }
            if (isEmpty == notes.Length)
            {
                Console.WriteLine("Захотели Вы то, конечно, захотели... Но вот что изменять то? Записей то нет!");
                Console.WriteLine("Идите-ка Вы в \"Меню\" и добавьте записи что-ли...");
                Console.WriteLine("");
                isEmpty = 0;
            }
            else
            {
                isEmpty = 0;
                Console.WriteLine("Ниже представлен список всех существующих учётных записей с краткой информацией в телефонной книге:");
                //именно поэтому при добавлении записи делал красивые фамилии, имена и тд...
                Console.WriteLine("");
                for (int i = 1; i < notes.Length + 1; i++)
                {
                    if (notes[i - 1] == null)
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Видимо эта запись была удалена (обнулена).. К сожалению человек, который это написал не знает как сделать так, чтобы номер записей в массиве изменился соответсвенно :(");
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine("№ " + i);
                        Console.WriteLine("Фамилия: " + notes[i - 1].Surname);
                        Console.WriteLine("Имя: " + notes[i - 1].Name);
                        Console.WriteLine("Номер телефона: " + notes[i - 1].Telephone);
                        Console.WriteLine("");
                    }
                }
            }
        }
    }

}





