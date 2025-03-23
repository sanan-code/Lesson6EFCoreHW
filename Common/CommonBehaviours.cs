namespace HomeTask3.Common;

public class CommonBehaviours
{
    public int Select()
    {
        int result = 0;
        Console.Write("Select: ");
        result = int.Parse(Console.ReadLine());
        return result;
    }

    public void Sleep(int s, int ms)
    {
        for (int i = 0; i < s; i++)
        {
            Console.Write(". ");
            Thread.Sleep(ms);
        }
    }
}
