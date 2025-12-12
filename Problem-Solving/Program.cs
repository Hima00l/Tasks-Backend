namespace PS
{
    internal class Program
    {
        public static string ShortWord(string[] Word)
        {
            string [] words = Word;

            if (words == null ) 
                throw new ArgumentNullException(nameof(words),"This list is Empty");


            string shortest = words[0];
            foreach (string word in words)
            {
                if(word.Length < shortest.Length)
                    shortest = word;
            }
            return shortest;
        }
        static void Main(string[] args)
        {
            string[] word = { "Code", "Backend", "Circle", "Ai" };
            Console.WriteLine(ShortWord(word));

            
        }
    }
}

