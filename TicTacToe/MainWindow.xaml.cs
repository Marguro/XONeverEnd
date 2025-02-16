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

namespace TicTacToeWPF;
public partial class MainWindow : Window
{
    private readonly Dictionary<Player, ImageSource> ImageSources = new()
    {
        { Player.X, new BitmapImage(new Uri("pack://application:,,,/Images/X15.png")) },
        { Player.O, new BitmapImage(new Uri("pack://application:,,,/Images/O15.png")) }
    };
    
    private readonly Image[,] imageControls = new Image[3,3];
    private readonly GameState gameState = new GameState();
    public MainWindow()
    {
        InitializeComponent();
        SetupGameGrid();
        
        gameState.MoveMade += OnMoveMade;
        gameState.GameEnded += OnGameEnded;
        gameState.GameRestarted += OnGameRestarted;
    }
    
    private void SetupGameGrid()
    {
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                Image imageControl = new Image();
                GameGrid.Children.Add(imageControl);
                imageControls[i,j] = imageControl;
            }
        }
    }
    private void OnMoveMade(int row, int column)
    {
       
    }
    private void OnGameEnded(GameResult gameResult)
    {
        
    }
    private void OnGameRestarted()
    {
     
    }
    private void GameGrid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        
    }
}