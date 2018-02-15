using System;

namespace GetStringName
{
    public class GetString
    {
        public void Player(int num)
        {
            int number = num * 2;
            Console.Write(number);
            

        }

        public void  Player(string name)
        {
            char[] charr = name.ToCharArray();
            Array.Reverse(charr);
            Console.Write(charr);
            

        }   
    }
}
