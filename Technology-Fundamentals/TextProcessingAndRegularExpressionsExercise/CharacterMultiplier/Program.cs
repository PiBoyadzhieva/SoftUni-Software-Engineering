using System;

namespace CharacterMultiplier
{
    public class Program
    {
        public static void Main()
        {
            string[] tokens = Console.ReadLine().Split();
            string firstString = tokens[0];
            string secondString = tokens[1];

            string longerWord = string.Empty;
            string shorterrWord = string.Empty;
            int sum = 0;

            if(firstString.Length >= secondString.Length)
            {
                longerWord = firstString;
                shorterrWord = secondString;
            }
            else
            {
                longerWord = secondString;
                shorterrWord = firstString;
            }

            for (int i = 0; i < shorterrWord.Length; i++)
            {
                sum += shorterrWord[i] * longerWord[i];
            }

            for (int j = shorterrWord.Length; j < longerWord.Length; j++)
            {
                sum += longerWord[j];
            }
            Console.WriteLine(sum);
        }
    }
}
