

namespace Tortik
{

    public static class Global
    {
        public static int Price = 0;
        public static List<string> Order = new List<string> { };
    }


    internal class ElementsofMenu
    {

        public ElementsofMenu(int el, string discription, int price, Action action)
        {
            this.EL = el;
            this.Discription = discription;
            this.Price = price;
            this.Action = action;

        }

        public int EL;
        public string Discription;
        public int Price;
        public Action Action;


    }


    internal class Program
    {
        static void Main()
        {
            Menu mainMenu = new Menu();
            Menu FormaTorta = new Menu("~>");
            FormaTorta.Zagolovok = "Форма торта";
            FormaTorta.AddItem(0, "Квадрат - 400", 400, FormaTorta.HideMenu);
            FormaTorta.AddItem(1, "Круг - 500", 500, FormaTorta.HideMenu);           
            FormaTorta.PlayMenu = mainMenu;



            Menu SizeTorta = new Menu("~>");
            SizeTorta.Zagolovok = "Размер тортика";
            SizeTorta.AddItem(0, "Обычный(7-8 порций) - 1300", 1300, SizeTorta.HideMenu);
            SizeTorta.AddItem(2, "Средний(10-12 порций) - 1800", 1800, SizeTorta.HideMenu);
            SizeTorta.AddItem(3, "Большой(18-20 порций) - 2500", 2500, SizeTorta.HideMenu);



            SizeTorta.PlayMenu = mainMenu;

            Menu TasteTorta = new Menu("~>");
            TasteTorta.Zagolovok = "Вкус коржей";
            TasteTorta.AddItem(0, "Шоколадные - 300", 300, TasteTorta.HideMenu);
            TasteTorta.AddItem(1, "Ванильные - 350", 350, TasteTorta.HideMenu);
            TasteTorta.AddItem(2, "Шоколадно-ванильеые - 500", 500, TasteTorta.HideMenu);
            TasteTorta.AddItem(3, "Кокосовые - 400", 400, TasteTorta.HideMenu);
            TasteTorta.prices = new int[] { 300, 350, 500, 400 };
            TasteTorta.PlayMenu = mainMenu;

            Menu InsideTorta = new Menu("~>");
            InsideTorta.Zagolovok = "Начинка тортика";
            InsideTorta.AddItem(0, "Шоколадная - 250", 250, InsideTorta.HideMenu);
            InsideTorta.AddItem(1, "Клубничная - 300", 300, InsideTorta.HideMenu);
            InsideTorta.prices = new int[] { 250, 300 };


            InsideTorta.PlayMenu = mainMenu;

            Menu CountYarys = new Menu("~>");
            CountYarys.Zagolovok = "Количество ярусов";
            CountYarys.AddItem(0, "Один ярус - 500", 500, CountYarys.HideMenu);
            CountYarys.AddItem(1, "Два яруса - 800", 800, CountYarys.HideMenu);
            CountYarys.AddItem(2, "Три яруса - 1200", 1200, CountYarys.HideMenu);

            CountYarys.PlayMenu = mainMenu;

           

            mainMenu.Zagolovok = "  Tортики <3";
            mainMenu.AddItem(0, "Форма Тортика", 0, FormaTorta.ShowMenu);
            mainMenu.AddItem(1, "Размер Тортика", 0, SizeTorta.ShowMenu);
            mainMenu.AddItem(2, "Вкус Коржей", 0, TasteTorta.ShowMenu);
            mainMenu.AddItem(3, "Начинка тортика", 0, InsideTorta.ShowMenu);
            mainMenu.AddItem(4, "Количество ярусов", 0, CountYarys.ShowMenu);
            mainMenu.AddItem(6, "Конец оформления заказа", 0, Exit);

            mainMenu.ShowMenu();


            static void Exit()
            {
                Console.WriteLine("Ваш заказ оформлен!");

                string path = "C:\\Users\\tosya\\OneDrive\\Рабочий стол\\История заказов";
                string text = "Описание заказа";
                foreach (string item in Global.Order) { Console.WriteLine(item); };
                string price = "Цена: " + Global.Price;
                if (File.Exists(path))
                {
                    File.AppendAllText(path, text);
                    File.AppendAllText(path, price);
                }
                else
                {
                    File.Create(path);
                }
                Environment.Exit(0);
            }

        }

    }

}