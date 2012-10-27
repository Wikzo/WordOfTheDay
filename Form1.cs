using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WordOfTheDay
{

    public partial class Form1 : Form
    {
        private readonly List<string> _availableWordsTotal = new List<string>();
        private readonly List<string> _learnedWords = new List<string>();
        private string _currentWord = "";

        public Form1()
        {
            InitializeComponent();
            CheckIfTextFilesExist();
 
            GetAllAvailableWords();
            GetLearnedWords();

            if (GetCurrentWord() != "")
            {
                _currentWord = GetCurrentWord();
                UpdateTextToDisplay();
            }
            else
                UpdateTextToDisplay("No word has ben chosen yet.");

            UpdatePercentage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void UpdateTextToDisplay()
        {
            wordToShow.Text = _currentWord;
        }

        private void UpdateTextToDisplay(string text)
        {
            wordToShow.Text = text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void GetRandomWord()
        {
            // TODO: chance of getting an already-learned word

            Random random = new Random(DateTime.Now.Millisecond);
            int wordCount = _availableWordsTotal.Count();
            int index;
            int tries = 0;
            bool duplicate = false;

            // Pick a word that has not been learned yet
            index = random.Next(0, wordCount);

            if (_learnedWords.Contains(_availableWordsTotal[index]))
            {
                while (tries < 500)
                {
                    tries++;
                    index = random.Next(0, wordCount);

                    if (!_learnedWords.Contains(_availableWordsTotal[index]))
                    {
                        duplicate = false;
                        break;
                    }
                    duplicate = true;
                }
            }

            if (duplicate == true)
            {
                string duplicateString = _availableWordsTotal[index] + "_duplicate";
                PutInCurrentWord(duplicateString);
            }
            else
                PutInCurrentWord(_availableWordsTotal[index]);
            

            // TODO: Show meaning of the word (by hovering or right clicking)
            wordToShow.Text = _currentWord;
        }

        private void GetAllAvailableWords()
        {
            using (StreamReader reader = new StreamReader("AllWords.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _availableWordsTotal.Add(line);
                }
            }
        }

        private void GetLearnedWords()
        {
            using (StreamReader reader = new StreamReader("LearnedWords.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    _learnedWords.Add(line);
                }
            }
        }

        private void PutInCurrentWord(string word)
        {
            using (StreamWriter writer = new StreamWriter("CurrentWord.txt"))
            {
                writer.WriteLine(word);
                _currentWord = word;
            }
        }

        string GetCurrentWord()
        {
            using (StreamReader reader = new StreamReader("CurrentWord.txt"))
            {
                string line;
                if ((line = reader.ReadLine()) != null)
                    return line;
                return "";
            }
        }

        void ClearCurrentWordList()
        {
            if (_currentWord != "")
            {
                using (StreamWriter writer = File.AppendText("LearnedWords.txt"))
                {
                    writer.WriteLine(_currentWord);
                }

                _learnedWords.Add(_currentWord);
            }

            File.WriteAllText("CurrentWord.txt", String.Empty);
            _currentWord = "";
            UpdateTextToDisplay("No word has ben chosen yet.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sure?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearCurrentWordList();
            }
            
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure that you have used this word enough times?", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                ClearCurrentWordList();
                GetRandomWord();
                UpdatePercentage();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void CheckIfTextFilesExist()
        {
            if (!File.Exists("AllWords.txt"))
            {
                using (StreamWriter writer = File.CreateText("AllWords.txt"))
                {
                    writer.WriteLine("Word1");
                    writer.WriteLine("Word2");
                    writer.WriteLine("Word3");
                }
            }

            if (!File.Exists("CurrentWord.txt"))
                File.CreateText("CurrentWord.txt");

            if (!File.Exists("LearnedWords.txt"))
                File.Create("LearnedWords.txt");
        }

        void UpdatePercentage()
        {
            if (_learnedWords.Count < _availableWordsTotal.Count)
                percentage.Text = _learnedWords.Count + " / " + _availableWordsTotal.Count;
            else
                percentage.Text = _availableWordsTotal.Count + " / " + _availableWordsTotal.Count;
        }
    }
}
