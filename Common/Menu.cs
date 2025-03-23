namespace HomeTask3.Common;

public static class Menu
{
    public static void menu1()
    {
        //mehsul menyusu
        Console.WriteLine(
            $"1. Add product\n" + //ok
            $"2. Remove product\n" + //ok
            $"3. Update product\n" + //ok
            $"4. Add customer\n" + //ok
            $"5. Remove customer\n" + //ok
            $"6. Sale product\n" + //ok
            $"7. Reporting\n" + //ok
            $"8. exit" //ok
            );
    }

    public static void menu2()
    {
        //hesabatliliq
        Console.WriteLine(
            $"1. All cutomers\n" + //ok
            $"2. All products\n" + //ok
            $"3. All transactions\n" + //ok
            $"4. Total customer count\n" + //ok
            $"5. Total product count\n" + //ok
            $"6. Total revenue\n" + //ok
            $"7. Total quantity sold\n" + //ok
            $"8. Exit"
            );
    }
}
