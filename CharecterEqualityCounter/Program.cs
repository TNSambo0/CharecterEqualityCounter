namespace CharecterEqualityCounter
{
    public class AlphabeteCounter
    {
        public class WordCounter
        {
            public int Count { get; set; } = 0;
            public bool Equal { get; set; }
            public string Output { get; set; }
            public Dictionary<string, int> charectersD { get; set; }
        }
        public static WordCounter Count(string str)
        {
            WordCounter wordCounter = new()
            {
                charectersD = new()
            };
            if (str.Length % 2 != 0)
            {
                wordCounter.Equal = false;
                wordCounter.Output = "The length of alphabets entered is not even which makes it impossible to have equal charecters.";
                return wordCounter;
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (!wordCounter.charectersD.ContainsKey(str[i].ToString()))
                    {
                        var value = str.Count(x => x == str[i]);
                        wordCounter.charectersD.Add(str[i].ToString(), value);
                    }
                }
                foreach (var obj in wordCounter.charectersD)
                {
                    var firstcharecter = wordCounter.charectersD.FirstOrDefault();
                    if (obj.Value == firstcharecter.Value && obj.Value > 1)
                    {
                        wordCounter.Count = obj.Value;
                        wordCounter.Equal = true;
                    }
                    else
                    {
                        wordCounter.Count = obj.Value;
                        wordCounter.Equal = false;
                        break;
                    }
                }
                foreach (var item in wordCounter.charectersD)
                {
                    wordCounter.Output += $"{item.Key}-{item.Value}, ";
                }
                return wordCounter;
            }
        }
        public static void Main()
        {
            var word = getInput();
            while (String.IsNullOrEmpty(word))
            {
                Console.Clear();
                word = getInput();
            }
            var results = Count(word);
            if(results.Count%2!=0)
                Console.WriteLine($"Charecter occurrence is not equal.\n{results.Output}");
            else
                Console.WriteLine($"Charecter occurrence is equal by {results.Count}.\n{ results.Output}");
        }
        public static string? getInput()
        {
            Console.Title = "Charecter Equality Counter";
            Console.WriteLine("");
            Console.WriteLine("Welcome to the Charecters Equality Counter\n");
            Console.WriteLine("");
            Console.WriteLine("Please enter a word: ");
            var word = Console.ReadLine();
            return word;
        }
    }
}