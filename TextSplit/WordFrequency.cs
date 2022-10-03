using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextSplit
{
    class WordFrequency
    {
        public string word;
        public int frequency;

        public WordFrequency(string word, int frequency)
        {
            this.word = word;
            this.frequency = frequency;
        }

        public WordFrequency() { }
    }
}
