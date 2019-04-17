///Ethan Hunter, 314243
///4/23/2019
///make a program that tells you all possible words that can be created with letters given.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
namespace _314243_ScrabbleCheating
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string tiles = "";
        public MainWindow()
        {
            InitializeComponent();
            string check = "";
            StreamReader sr = new StreamReader("Words.txt");
            StreamWriter wr = new StreamWriter("NewWords.txt");
            while (!sr.EndOfStream)
            {
                
                string word = sr.ReadLine().ToUpper();
                if ((word.Length < 8)&& (word!=check))
                {
                    wr.WriteLine(word + " ");
                    
                }
                check = word;
            }
            wr.Flush();
            wr.Close();
            sr.Close();
            string output = "";
            ScrabbleGame sg = new ScrabbleGame();
            tiles = sg.drawInitialTiles();
            //MessageBox.Show(tiles[0].ToString());
            preface.Content += tiles + "\" you can make the words: \n";

            StreamReader reader = new StreamReader("NewWords.txt");
            while (!reader.EndOfStream)
            {
                string word = reader.ReadLine();

                /*if (word.Contains(tiles[0]) && word.Contains(tiles[1]) && word.Contains(tiles[2]) && word.Contains(tiles[3]) && word.Contains(tiles[4]) && word.Contains(tiles[5]) && word.Contains(tiles[6]))
                {
                    output += (word.ToString() + "\n");
                }*/
                for (int a = 0; a <= tiles.Length-1; a++)
                {
                    if (word.Contains(tiles[a]))
                    {
                        if (word.Length == 2)
                        {
                            output += word +'\n';
                        }
                    }
                }
            }
            reader.Close();
            lblOut.Content = output;
        }
    }
}