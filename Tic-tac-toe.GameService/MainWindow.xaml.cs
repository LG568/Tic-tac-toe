using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Tic_tac_toe.GameService;

namespace Tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TextBox[] fieldsList = new TextBox[9];
        private string _fieldsWithX = "";
        private string _fieldsWithO = "";
        public MainWindow()
        {
            InitializeComponent();
            fieldsList[0] = Field1;
            fieldsList[1] = Field2;
            fieldsList[2] = Field3;
            fieldsList[3] = Field4;
            fieldsList[4] = Field5;
            fieldsList[5] = Field6;
            fieldsList[6] = Field7;
            fieldsList[7] = Field8;
            fieldsList[8] = Field9;
        }

        
        private void BtnStartGame_Click(object sender, RoutedEventArgs e)
        {
            var game = new Game();
            game.ClearGameField(fieldsList);
            TxtBox_Player.Text = "Player 1";
            TxtBox_Player.Visibility = Visibility.Visible;
            TxtBox_MakeyourMove.Visibility = Visibility.Visible;
            foreach( TextBox field in fieldsList)
                field.Visibility = Visibility.Visible;

            _fieldsWithX = "";
            _fieldsWithO = "";
        }

        private void PlaceAMark_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox field = (TextBox)sender;
                if (field.Text == "")
                {
                    bool isWinX = false;
                    bool isWinO = false;
                    char fieldNumber = field.Name[field.Name.Length - 1];

                    var game = new Game();

                    field.Text = game.MakeAMove(TxtBox_Player.Text);
                    field.Foreground = game.SetMarkColor(TxtBox_Player.Text);

                    if (TxtBox_Player.Text == "Player 1")
                    {
                        _fieldsWithX += fieldNumber + " ";
                        if (_fieldsWithX.Length > 4)
                            isWinX = game.CheckWin(_fieldsWithX);
                    }
                    else
                    {
                        _fieldsWithO += fieldNumber + " ";
                        if (_fieldsWithO.Length > 4)
                            isWinO = game.CheckWin(_fieldsWithO);
                    }
                    if (isWinX)
                        MessageBox.Show("Player 1 wins!");
                    if (isWinO)
                        MessageBox.Show("Player 2 wins!");

                    if (!isWinX && !isWinO)
                    {
                        if(_fieldsWithX.Length + _fieldsWithO.Length == 18)
                            MessageBox.Show("It's a tie!");
                        else
                            TxtBox_Player.Text = game.NextPlayer(TxtBox_Player.Text);
                    }
                }
            }
        }
    }
}