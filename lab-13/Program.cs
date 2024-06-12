using Lab_10;
using lab_12;
using static Lab_10.Logic;

namespace lab_13
{
  internal class Program
  {
    public static bool randomnessFlag = false;
    public static Watch CreateWatchObject()
    {
      string menu = "";
      while (menu != "4" && menu != "1" && menu != "2" && menu != "3")
      {
        Console.WriteLine("1. Watch\n2. AnalogWatch\n3. DigitalWatch\n 4. SmartWatch");
        menu = GetString("тип часов");
      }

      Watch watch;

      if (randomnessFlag)
      {
        if (menu == "1")
          watch = new Watch();
        else if (menu == "2")
          watch = new AnalogWatch();
        else if (menu == "3")
          watch = new DigitalWatch();
        else
          watch = new SmartWatch();
        watch.RandomInit();
        return watch;
      }
      else
      {
        if (menu == "1")
          return new Watch(GetString("бренд"), GetShort("год выпуска"));
        else if (menu == "2")
          return new AnalogWatch(GetString("бренд"), GetShort("год выпуска"), GetString("стиль часов"));
        else if (menu == "3")
          return new DigitalWatch(GetString("бренд"), GetShort("год выпуска"), GetString("тип дисплея"));
        else
          return new SmartWatch(GetString("бренд"), GetShort("год выпуска"), GetString("тип дисплея"), GetString("название операционной системы"), GetShort("присутствует ли датчик пульса. Любое значение больше единицы будет давать true") >= 1);
      }
    }

    static void Main(string[] args)
    {
      Console.BackgroundColor = ConsoleColor.White;
      Console.ForegroundColor = ConsoleColor.Black;
      Console.Clear();


      MyCollection<Watch> list = null;  // = new DoublyLinkedList();
      MyObservableCollection<Watch> observables = null;

      string menu = "",
        errorMessage = "",
        menuOptions = "base",           //base, list, observe
        linkedlistoption = "base",      // base - базовое, add - добавление, delete - удаление,
        observablesoption = "base";
      
      bool doShowColl = false;




      while (true)
      {
        #region Отображение информации о списке и ошибке при наличии
        Console.Clear();
        switch (menuOptions)
        {
          case "list":
            if (list != null && doShowColl)
              Console.WriteLine(list.ShowItems());
            else if (list != null && !doShowColl)
              Console.WriteLine("Коллекция не отображается.");
            else
              Console.WriteLine("Ссылка на коллекцию отсутствует.");
            break;

          case "observe":
            if (observables != null && doShowColl)
              Console.WriteLine(list.ShowItems());
            else if (observables != null && !doShowColl)
              Console.WriteLine("Коллекция не отображается.");
            else
              Console.WriteLine("Ссылка на коллекцию отсутствует.");

            break;
        }

        if (errorMessage != "")
        {
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine(errorMessage);
          Console.ForegroundColor = ConsoleColor.Black;
          errorMessage = "";
        }
        #endregion


        #region Отображение диалоговых опций
        switch (menuOptions)
        {
          case "base":
            Console.WriteLine("1.Работа с MyCollection.\n2.Работа с MyObservableCollection.\n0. Exit.");
            break;

          case "list":
            switch (linkedlistoption)
            {
              case "base":
                Console.WriteLine("1. " + (list == null ? "Создать" : "Пересоздать") + " коллекцию.\n2. Добавить объект в коллекцию.\n3. Удаление объекта из коллекции.\n4. Отображать список: " + (doShowColl ? "on" : "off") + ".\n5.Сформировать новый список через рнг\n0. Выход.");
                break;
              case "add":
                Console.WriteLine("1. В начало.\n2. По номеру.\n3. В конец.\n4. Добавлять случайно созданный объект: " + (randomnessFlag ? "on" : "off") + ".\n0. Назад.");
                break;
              case "delete":

                Console.WriteLine("1. Первого.\n2. По году выпуска.\n3. По названию бренда.\n4. Удалить последний.\n0. Назад.");
                break;
            }
            break;

          case "observe":
            switch (observablesoption)
            {
              case "base":
                Console.WriteLine("1. " + (list == null ? "Создать" : "Пересоздать") + " коллекцию.\n2. Добавить объект в коллекцию.\n3. Удаление объекта из коллекции.\n4. Отображать список: " + (doShowColl ? "on" : "off") + ".\n5.Сформировать новый список через рнг\n0. Выход.");
                break;
              case "add":
                Console.WriteLine("1. В начало.\n2. По номеру.\n3. В конец.\n4. Добавлять случайно созданный объект: " + (randomnessFlag ? "on" : "off") + ".\n0. Назад.");
                break;
              case "delete":

                Console.WriteLine("1. Первого.\n2. По году выпуска.\n3. По названию бренда.\n4. Удалить последний.\n0. Назад.");
                break;
            }
            break;
        }
        #endregion



        menu = Console.ReadLine();



        #region Ночь полна ужасов
        switch (menu)
        {
          case "1":
            switch (menuOptions)
            {
              case "base":
                menuOptions = "list";
                break;

              case "list":
                switch (linkedlistoption)
                {
                  case "base": // базовое
                    if (list != null)
                      list.CollectionReset();
                    else
                      list = new MyCollection<Watch>();
                    break;

                  case "add": //добавление в начало
                    list.AddFirst(CreateWatchObject());
                    break;

                  case "delete": //удаление в первого
                    errorMessage = list.DeleteFirst();
                    if (list.Count == 0)
                      linkedlistoption = "base";
                    break;
                }
                break;
              case "observe":
                switch (observablesoption)
                { 
                  case "base":

                    break;
                  case "add":
                    observables.Insert(0, );
                  break;
                }
                    break; 
            }
            break;

          case "2":
            switch (menuOptions)
            {
              case "base":
                menuOptions = "observe";
                break;
              case "list":
                switch (linkedlistoption)
                {
                  case "base": // переключение на добавление
                    if (list != null)
                      linkedlistoption = "add";
                    else
                      errorMessage = "Нельзя добавить объект в несущестувующую коллекции.";
                    break;

                  case "add": //добавление по индексу
                    errorMessage = list.Insert(CreateWatchObject(), GetShort("номер добавляемого элемента") - 1);
                    break;

                  case "delete": //удаление по индексу
                    errorMessage = list.DeleteByYear(GetShort("год выпуска"));
                    if (list.Count == 0)
                      linkedlistoption = "base";
                    break;
                }
                break;
            }
            break;

          case "3":
            switch (menuOptions)
            {
              case "list":
                switch (linkedlistoption)
                {
                  case "base": // переключение на удаление
                    if (list != null && list.Count != 0)
                      linkedlistoption = "delete";
                    else
                      errorMessage = "Нельзя удалить объект из " + (list == null ? "несущестувующей" : "пустой") + " коллекции.";
                    break;

                  case "add": //добавление в конец
                    list.Add(CreateWatchObject());
                    break;

                  case "delete": //удаление по имени
                    errorMessage = list.DeleteByName(GetString("название брэнда"));
                    if (list.Count == 0)
                      linkedlistoption = "base";
                    break;
                }
                break;
            }
            break;

          case "4":
            switch (menuOptions)
            {
              case "list":
                switch (linkedlistoption)
                {
                  case "base":
                    doShowColl = doShowColl ? false : true;
                    break;

                  case "add":
                    randomnessFlag = randomnessFlag ? false : true;
                    break;
                  case "delete":
                    errorMessage = list.DeleteLast();
                    if (list.Count == 0)
                      linkedlistoption = "base";
                    break;
                }
                break;
            }
            break;

          case "5":
            switch (menuOptions)
            {
              case "list":
                switch (linkedlistoption)
                {
                  case "base":
                    if (list != null)
                    {
                      Console.Clear();
                      list = new MyCollection<Watch>(GetInt("длину списка"));
                    }
                    else
                      errorMessage = "Создайте список, прежде чем его редактировать.";
                    break;
                }
                break;
            }
            break;


          //    case "delete":
          //    list.DeleteByName(GetString("имя брэнда для удаления"));
          //    break;
          //}

          case "0": //выход
            switch (menuOptions)
            {
              case "base":
                Environment.Exit(0);
                break;
              case "list":
                switch (linkedlistoption)
                {
                  case "base":
                    menuOptions = "base";
                    break;
                  case "add":
                    linkedlistoption = "base";
                    break;
                  case "delete":
                    linkedlistoption = "base";
                    break;
                }
                break;
            }
            break;
        }

        #endregion
      }
    }
  }
}