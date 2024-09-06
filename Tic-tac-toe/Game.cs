using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;

namespace Tic_tac_toe
{
    public class Game
    {
        enum Mark
        {
            X,
            O,
            Empty
        }

        Dictionary<string, string> playerMoveDict = new Dictionary<string, string>();
        List<string> winningCombinations = new List<string>();

        public Game()
        {
            playerMoveDict.Add("Player 1", "X");
            playerMoveDict.Add("Player 2", "O");

            winningCombinations.Add("//1 2 3");
            winningCombinations.Add("//1 4 7");
            winningCombinations.Add("//1 5 9");
            winningCombinations.Add("//2 5 8");
            winningCombinations.Add("//3 6 9");
            winningCombinations.Add("//3 5 7");
            winningCombinations.Add("//4 5 6");
            winningCombinations.Add("//7 8 9");
        }

        public void ClearGameField(TextBox[] fieldslist)
        {
            foreach (TextBox field in fieldslist)
                field.Text = "";
        }

        public string MakeAMove(string player)
        {
            return playerMoveDict[player];
        }

        public SolidColorBrush SetMarkColor(string player)
        {
            if (player == "Player 1")
                return new SolidColorBrush(Colors.Blue);
            else
                return new SolidColorBrush(Colors.Red);
        }

        public string NextPlayer(string currentPlayer)
        {
            if (currentPlayer == "Player 1")
                return "Player 2";
            else
                return "Player 1";
        }

        public bool CheckWin(string fields)
        {
            // Winning combinations:
            //1 2 3;    1 4 7;  1 5 9;  2 5 8;
            //3 6 9;    3 5 7;  4 5 6;  7 8 9.
            if (fields.Contains('1') && fields.Contains('2') && fields.Contains('3') ||
                fields.Contains('1') && fields.Contains('4') && fields.Contains('7') ||
                fields.Contains('1') && fields.Contains('5') && fields.Contains('9') ||
                fields.Contains('2') && fields.Contains('5') && fields.Contains('8') ||
                fields.Contains('3') && fields.Contains('6') && fields.Contains('9') ||
                fields.Contains('3') && fields.Contains('5') && fields.Contains('7') ||
                fields.Contains('4') && fields.Contains('5') && fields.Contains('6') ||
                fields.Contains('7') && fields.Contains('8') && fields.Contains('9'))
                return true;
             else
                return false;
        }
    }
}
