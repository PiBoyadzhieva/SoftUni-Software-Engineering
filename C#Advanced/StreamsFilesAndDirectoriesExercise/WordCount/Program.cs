﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCount
{
    class Program
    {
        public static void Main()
        {
            string textPath = "text.txt";
            string wordsPath = "words.txt";


            string[] textLines = File.ReadAllLines(textPath);
            string[] words = File.ReadAllLines(wordsPath);

            Dictionary<string, int> wordsInfo = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if(!wordsInfo.ContainsKey(word))
                {
                    wordsInfo.Add(word.ToLower(), 0);
                }
            }

            foreach (var currentLine in textLines)
            {
                string[] currentLineWords = currentLine
                    .ToLower()
                    .Split(new char[] { ' ', '-', ',', '?', '!', '.', '\'', ':', ';' });

                foreach (var currentWord in currentLineWords)
                {
                    if(wordsInfo.ContainsKey(currentWord))
                    {
                        wordsInfo[currentWord]++;
                    }
                }
            }

            string actualResultPath = "actualResult.txt";
            string expectedResultPath = "expectedResult.txt";


            foreach (var (key, value) in wordsInfo)
            {
                File.AppendAllText(actualResultPath, $"{key} - {value} {Environment.NewLine}");
            }

            foreach (var (key, value) in wordsInfo.OrderByDescending(x => x.Value))
            {
                File.AppendAllText(expectedResultPath, $"{key} - {value}{Environment.NewLine}");
            }
        }
    }
}