using System;
using Topics;
using Update;

namespace Hangman_Assignmemnt
{
    class Program
    {
                static void Main(string[] args)
        {

            Random rnd = new Random();

            string[] alphabet = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" };

            
            bool start = true;

            int PlayerNum = 0;

            string PlayerTopic = string.Empty;

            char[] word = new char[100];

            bool win = false;

            int hangIndex = 0;

            string usedletters = string.Empty;

            PlayerNum = PlayerChoice.UserChoice();
            PlayerTopic = PlayerChoice.ChoiceTopic(topicNum, word);

            do
            {
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                


                string letter = UpdateScreen.PlayerInput(alphabet, usedletters);

                usedletters = usedletters + letter;


                char[] letterC = letter.ToCharArray();

                bool error = true;

                int wincounter = 0;


                for (int i = 0; i < PlayerTopic.Length; i++)
                {

                    if (letterC[0] == PlayerTopic[i])
                    {
                        word[i] = PlayerTopic[i];

                        error = false;
                    }
                    if (word[i] == PlayerTopic[i])
                    {
                        wincounter++;
                    }

                    if (wincounter == PlayerTopic.Length)
                    {
                        win = true;
                    }
                }

                if (error)
                {
                    hangIndex++;
                }

                if (UpdateScreen.EndGame(win , hangIndex))
                {
                    break;
                }

            } while (start);
        }
    }
}
