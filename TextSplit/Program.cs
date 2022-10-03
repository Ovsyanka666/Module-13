using System.Diagnostics;

namespace TextSplit
{
    class Program
    {
        static void Main()
        {
            TimerList(20, "C:\\Users\\Pisiyshka\\Downloads\\Text1.txt");
            TimerLinkedList(20, "C:\\Users\\Pisiyshka\\Downloads\\Text1.txt");

            TenMostFrequentWords("C:\\Users\\Pisiyshka\\Downloads\\Text1.txt");
        }

        static void TenMostFrequentWords(string filePath)    //Метод выводит 10 наиболее часто встречающихся в тескте слов и их частоту
        {
            string text = File.ReadAllText(filePath);
            char[] delimiters = new char[] { ' ', '\r', '\n' };
            var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
            List<string> noPunctuationWords = new List<string>(noPunctuationText.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

            noPunctuationWords.Sort();

            List<WordFrequency> WordsFrequency = new List<WordFrequency>();

            try
            {
                Console.WriteLine("Начинаем подсчёт частоты слов в тексте");
                WordFrequency temp = new WordFrequency();
                int times = 0;
                while (true)
                {
                    temp = WordFrequencyCounter(noPunctuationWords);
                    if (temp.frequency > 100)
                    {
                        WordsFrequency.Add(new WordFrequency(temp.word, temp.frequency));
                        times++;
                    }
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Подсчёт окончен");
            }
            finally
            {
                for (int i = 0; i < WordsFrequency.Count(); i++)
                {
                    for (int j = i + 1; j < WordsFrequency.Count(); j++)
                    {
                        if (WordsFrequency[i].frequency < WordsFrequency[j].frequency)
                        {
                            string tempWord = WordsFrequency[i].word;
                            int tempFrequency = WordsFrequency[i].frequency;

                            WordsFrequency[i].word = WordsFrequency[j].word;
                            WordsFrequency[i].frequency = WordsFrequency[j].frequency;

                            WordsFrequency[j].word = tempWord;
                            WordsFrequency[j].frequency = tempFrequency;
                        }
                    }
                }

                Console.WriteLine("10 наиболее часто встречающихся в тексте слов:");

                for (int i = 0; i < 10; i++)
                {
                    Console.Write(WordsFrequency[i].word + " - " + WordsFrequency[i].frequency + "\n");
                }
            }
        }

        static WordFrequency WordFrequencyCounter(List<string> Text)    //Метод принимает текст и возвращает объект WordFrequency, содержащий слово и его частоту в тексте, при этом удаляет это слово из текста
        {
            bool WordIsInText = true;
            int WordQuantity = 0;
            string TempWord = Text[0];

            while (WordIsInText)
            {
                WordIsInText = Text.Remove(TempWord);
                WordQuantity++;
            }
            WordFrequency WordFrequency = new WordFrequency(TempWord, WordQuantity);          

            return WordFrequency;
        }
          
        static void TimerList(int times, string filePath)       //Метод принимает количество раз заполнения списка и адрес файла, выводит среднюю скорость заполнения списка List<T>
        {
            Console.WriteLine("Проверяем скорость заполнения List<T>");
            int[] Speed = new int[times];

            for (int i = 0; i < times; i++)
            {
                var timer = new Stopwatch();
                timer.Start();

                string text1 = File.ReadAllText(filePath);

                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n' };

                // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
                List<string> words = new List<string>(text1.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));
                                
                timer.Stop();

                if (times <= 20)
                    Console.WriteLine(timer.ElapsedMilliseconds);

                Speed[i] = (int)timer.ElapsedMilliseconds;
            }

            Console.WriteLine("Среднее время выполнения " + Speed.Average());
        }

        static void TimerLinkedList(int times, string filePath)   //Метод принимает количество раз заполнения списка и адрес файла, выводит среднюю скорость заполнения списка LinkedList<T>
        {
            Console.WriteLine("Проверяем скорость заполнения LinkedList<T>");
            int[] Speed = new int[times];

            for (int i = 0; i < times; i++)
            {                
                var timer = new Stopwatch();
                timer.Start();

                string text1 = File.ReadAllText(filePath);

                // Сохраняем символы-разделители в массив
                char[] delimiters = new char[] { ' ', '\r', '\n' };

                // разбиваем нашу строку текста, используя ранее перечисленные символы-разделители
                LinkedList<string> words = new LinkedList<string>(text1.Split(delimiters, StringSplitOptions.RemoveEmptyEntries));

                timer.Stop();

                if (times <= 20)
                    Console.WriteLine(timer.ElapsedMilliseconds);

                Speed[i] = (int)timer.ElapsedMilliseconds;
            }
            Console.WriteLine("Среднее время выполнения " + Speed.Average());
        }
    }    
}
