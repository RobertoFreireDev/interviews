namespace ConsoleExercises.Sort
{
    public static class CompareToExample
    {
        public static void DisplayList(this List<int> list, string title)
        {
            if (list.Count == 0) return;

            var result = list[0].ToString();

            Console.WriteLine(title);
            Console.WriteLine();

            for (int i = 1; i < list.Count; i++)
            {
                result = result + ", " + list[i];
            }

            Console.WriteLine(result);
            Console.WriteLine();
        }

        public static void Sort()
        {
            var list = new List<int>(){2,3,1};

            list.Sort((a, b) =>
            {
                Console.WriteLine("a : " + a + ". b : " + b); 

                if (a == b)
                {
                    return 0;
                }
                else if (a > b)
                {
                    return 1;
                }
                else 
                {
                    return -1;
                }
            });
            /*
            a : 2. b : 3
            a : 2. b : 1
            a : 3. b : 2
            */

            list.DisplayList("custom comparison ascending");
            // 1, 2, 3

            list.Sort((a, b) =>
            {
                Console.WriteLine("a : " + a + ". b : " + b);

                if (a == b)
                {
                    return 0;
                }
                else if (a > b)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            });
            /*
            a : 1. b : 2
            a : 2. b : 3
            a : 1. b : 2
            */

            list.DisplayList("custom comparison descending");
            // 3, 2, 1

            list.Sort((a, b) => a.CompareTo(b));

            list.DisplayList("return CompareTo ascending");
            // 1, 2, 3

            list.Sort((a, b) => b.CompareTo(a));

            list.DisplayList("return CompareTo descending");
            // 3, 2, 1
        }
    }
}
