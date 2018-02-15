using System;

namespace GetStringName
{
    public class GetString
    {
        public string Player(string name)
        {


            char[] charr = name.ToCharArray();
            Array.Reverse(charr);
            return new string(charr);

        }




    }
}
