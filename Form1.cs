using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WordOfTheDay.Properties;

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
 
            GetLearnedWords();
            GetAllAvailableWords();

            if (GetCurrentWord() != "")
            {
                _currentWord = GetCurrentWord();
                UpdateTextToDisplay();
            }
            else
                UpdateTextToDisplay("No word has been chosen yet.");

            UpdatePercentage();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set window location
            if (Settings.Default.WindowLocation != null)
            {
                this.Location = Settings.Default.WindowLocation;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UpdateTextToDisplay()
        {
            //wordToShow.Text = _currentWord;
            string[] firstWord = _currentWord.Split('=');
            wordToShow.Text = firstWord[0];
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

            if (_availableWordsTotal.Count > 0)
            {
                // See if word has already been learned
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
                    string duplicateString = "!duplicate_" + _availableWordsTotal[index];
                    PutInCurrentWord(duplicateString);
                }
                else
                    PutInCurrentWord(_availableWordsTotal[index]);
            }
            else
            {
                wordToShow.Text = "ERROR - No words in 'AllWords.txt'";
                return;
            }

            // Show only the word and NOT the meaning
            string[] split = _currentWord.Split('=');
            string firstWord = split[0].TrimEnd();
            wordToShow.Text = firstWord;
        }

        private void GetAllAvailableWords()
        {
            using (StreamReader reader = new StreamReader("AllWords.txt", Encoding.Default))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line != "")
                        _availableWordsTotal.Add(line);
                }
            }
        }

        private void GetLearnedWords()
        {
            using (StreamReader reader = new StreamReader("LearnedWords.txt", Encoding.Default))
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
            using (StreamWriter writer = new StreamWriter("CurrentWord.txt", false, Encoding.Default))
            {
                writer.WriteLine(word);
                _currentWord = word;
            }
        }

        string GetCurrentWord()
        {
            using (StreamReader reader = new StreamReader("CurrentWord.txt", Encoding.Default))
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
                // No duplicates
                if (_currentWord.First() != '!')
                {
                    using (StreamWriter writer = File.AppendText("LearnedWords.txt"))
                    {
                        writer.WriteLine(_currentWord);
                    }

                    _learnedWords.Add(_currentWord);
                }
            }

            File.WriteAllText("CurrentWord.txt", String.Empty);
            _currentWord = "";
            UpdateTextToDisplay("No word has been chosen yet.");
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


        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void wordToShow_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void wordToShow_MouseClick(object sender, MouseEventArgs e)
        {
            string description = _currentWord.TrimStart();
            toolTip2.Show(description, wordToShow);
        }

        private void wordToShow_MouseHover(object sender, EventArgs e)
        {
            string description = _currentWord.TrimStart();
            toolTip2.Show(description, wordToShow);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GetRandomWord();
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            toolTip2.Show("Postpone this word for later.", pictureBox1);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Copy window location to app settings
            Settings.Default.WindowLocation = this.Location;

            // Save settings
            Settings.Default.Save();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {}

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
