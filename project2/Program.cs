using System;

namespace project2
{
    class Program
    {
        public static int editDistance(String str1, String str2, int m, int n)
        {
            // Create a table to store 
            // results of subproblems 
            int[,] dp = new int[m + 1, n + 1];
            int insert = 0;
            int remove = 0;
            int replace = 0;

            // Fill d[][] in bottom up manner 
             for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    if (i == 0)

                        // Min. operations = j 
                        {
                        dp[i, j] = j;
                        Console.Write(j);
                        if(j == 0)
                            {Console.Write("|");}
                        }
                }
            }
            Console.WriteLine();
            for (int j = 0; j <= n; j++)
                {
                        Console.Write("--");
                }
            for (int i = 0; i <= m; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    // If first string is empty, only option is to 
                    // insert all characters of second string 
                    if (i == 0)

                        // Min. operations = j 
                        {}

                    // If second string is empty, only option is to 
                    // remove all characters of second string 
                    else if (j == 0)

                        // Min. operations = i 
                        {dp[i, j] = i;
                        Console.Write(i + "|");}

                    // If last characters are same, ignore last char 
                    // and recur for remaining string 
                    else if (str1[i - 1] == str2[j - 1])
                        {dp[i, j] = dp[i - 1, j - 1];
                        Console.Write(dp[i, j]);}

                    // If the last character is different, consider all 
                    // possibilities and find the minimum 
                    else
                        {
                        Tuple<int, int, int, int> tuple = min(dp[i, j - 1], dp[i - 1, j], dp[i - 1, j - 1], insert, remove, replace);
                        dp[i, j] = 1 + tuple.Item1;
                        insert = tuple.Item2;
                        remove = tuple.Item3;
                        replace = tuple.Item4;
                         
                        Console.Write(dp[i, j]);}
                }
                Console.WriteLine();
            }
            Console.WriteLine(insert + " insert, " + remove + " remove, " + replace + " replace.");

            
            return dp[m, n];
        }

        public static Tuple<int, int, int, int> min(int x, int y, int z, int insert, int remove, int replace)
        {
            if (x <= y && x <= z) {insert ++; return Tuple.Create(x,insert,remove,replace);}
            if (y <= x && y <= z) {remove ++; return Tuple.Create(y,insert,remove,replace);}
            else {replace++; return Tuple.Create(z,insert,remove,replace);}
        }
        static void Main(string[] args)
        {

            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            Console.WriteLine();
            Console.Write("Enter first word:");
            string word1 = Console.ReadLine();
            Console.Write("Enter second word:");
            string word2 = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("MED Value");
            Console.WriteLine();
            int med = editDistance(word1, word2, word1.Length, word2.Length);
            Console.WriteLine("MED value is: " + med);
            Console.WriteLine();
            Console.WriteLine();
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");




        }

    }
}
