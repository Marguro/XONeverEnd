﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
namespace TicTacToeWPF
{
public partial class MainWindow : Window
{
    private int xScore = 0;
    private int oScore = 0;
    private readonly Dictionary<Player, ImageSource> imageSources = new()
    {
        { Player.X, new BitmapImage(new Uri("pack://application:,,,/Assets/X15.png")) },
        { Player.O, new BitmapImage(new Uri("pack://application:,,,/Assets/O15.png")) }
    };
    
    private readonly Dictionary<Player, ObjectAnimationUsingKeyFrames> animations = new()
    {
        { Player.X, new ObjectAnimationUsingKeyFrames() },
        { Player.O, new ObjectAnimationUsingKeyFrames() }
    };
    
    private readonly DoubleAnimation fadeOutAnimation = new DoubleAnimation 
    {
        From = 1,
        To = 0,
        Duration = TimeSpan.FromSeconds(.5)
    };
    
    private readonly DoubleAnimation FadeInAnimation = new DoubleAnimation
    {
        From = 0,
        To = 1,
        Duration = TimeSpan.FromSeconds(.5)
    };
    
    private readonly Image[,] imageControls = new Image[3,3];
    private readonly GameState gameState = new GameState();
    public MainWindow() 
    {
        InitializeComponent();
        SetupGameGrid();
        SetupAnimations();
        
        gameState.MoveMade += OnMoveMade;
        gameState.GameEnded += OnGameEnded;
        gameState.GameRestarted += OnGameRestarted;
        gameState.SymbolRemoved += OnSymbolRemoved;
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
    
    private void SetupAnimations()
    {
        animations[Player.X].Duration = TimeSpan.FromSeconds(.25);
        animations[Player.O].Duration = TimeSpan.FromSeconds(.25);
        
        for (int i = 0; i < 16; i++)
        {
            Uri xUri = new Uri($"pack://application:,,,/Assets/X{i}.png");
            BitmapImage xImg = new BitmapImage(xUri);
            DiscreteObjectKeyFrame xKeyFrame = new DiscreteObjectKeyFrame(xImg);
            animations[Player.X].KeyFrames.Add(xKeyFrame);
            
            Uri oUri = new Uri($"pack://application:,,,/Assets/O{i}.png");
            BitmapImage oImg = new BitmapImage(oUri);
            DiscreteObjectKeyFrame oKeyFrame = new DiscreteObjectKeyFrame(oImg);
            animations[Player.O].KeyFrames.Add(oKeyFrame);
        }
    }

    private async Task FadeOut(UIElement uiElement)
    {
        uiElement.BeginAnimation(UIElement.OpacityProperty, fadeOutAnimation);
        await Task.Delay(fadeOutAnimation.Duration.TimeSpan);
        uiElement.Visibility = Visibility.Hidden;
    }
    
    private async Task FadeIn(UIElement uiElement)
    {
        uiElement.Visibility = Visibility.Visible;
        uiElement.BeginAnimation(UIElement.OpacityProperty, FadeInAnimation);
        await Task.Delay(FadeInAnimation.Duration.TimeSpan);
    }
    
    private async Task TransitionToEndScreen(string text, ImageSource winnerImage)
    {
        await Task.WhenAll(FadeOut(TurnPanel), FadeOut(GameCanvas));
        ResultText.Text = text;
        WinnerImage.Source = winnerImage;
        await FadeIn(EndScreen);
    }
    
    private async Task TransitionToGameScreen()
    {
        await FadeOut(EndScreen);
        Line.Visibility = Visibility.Hidden;
        await Task.WhenAll(FadeIn(TurnPanel), FadeIn(GameCanvas));
    }
    
    private (Point, Point) FindLinePoints(WinInfo winInfo)
    {
        double squareSize = GameGrid.Width/3;
        double margin = squareSize/2;

        if (winInfo.Type == WinType.Row)
        {
            double y = winInfo.Number * squareSize + margin;
            return (new Point(0,y), new Point(GameGrid.Width,y));
        }
        if (winInfo.Type == WinType.Column)
        {
            double x = winInfo.Number * squareSize + margin;
            return (new Point(x,0), new Point(x,GameGrid.Height));
        }
        if (winInfo.Type == WinType.MainDiagonal)
        {
            return (new Point(0,0), new Point(GameGrid.Width,GameGrid.Height));
        }
        return (new Point(GameGrid.Width,0), new Point(0,GameGrid.Height));
    }

    private async Task ShowLine(WinInfo winInfo)
    {
        (Point start, Point end) = FindLinePoints(winInfo);
        
        Line.X1 = start.X;
        Line.Y1 = start.Y;

        DoubleAnimation x2Animation = new DoubleAnimation
        {
            From = start.X,
            To = end.X,
            Duration = TimeSpan.FromSeconds(.25)
        };
        
        DoubleAnimation y2Animation = new DoubleAnimation
        {
            From = start.Y,
            To = end.Y,
            Duration = TimeSpan.FromSeconds(.25)
        };
        
        Line.Visibility = Visibility.Visible;
        Line.BeginAnimation(Line.X2Property, x2Animation);
        Line.BeginAnimation(Line.Y2Property, y2Animation);
        await Task.Delay(x2Animation.Duration.TimeSpan);
    }
    
    private void StartBlinking(int row, int column)
    {
        DoubleAnimation blinkAnimation = new DoubleAnimation
        {
            From = 1.0,
            To = 0.0,
            Duration = TimeSpan.FromSeconds(0.5),
            AutoReverse = true,
            RepeatBehavior = RepeatBehavior.Forever 
        };

        imageControls[row, column].BeginAnimation(UIElement.OpacityProperty, blinkAnimation);
    }

    private void StopBlinking(int row, int column)
    {
        imageControls[row, column].BeginAnimation(UIElement.OpacityProperty, null);
    }
    
    private void OnSymbolRemoved(int row, int column)
    {
        StopBlinking(row, column);

        imageControls[row, column].Source = null;
        imageControls[row, column].Visibility = Visibility.Hidden;
    }

    private void OnMoveMade(int row, int column)
    {
        if (gameState.Moves.Count > 5)
        {
            var firstMove = gameState.Moves[0];
            OnSymbolRemoved(firstMove.row, firstMove.column);
            gameState.Moves.RemoveAt(0);
        }

        Player player = gameState.GameGrid[row, column];
        imageControls[row, column].BeginAnimation(Image.SourceProperty, animations[player]); 
        imageControls[row, column].Visibility = Visibility.Visible; 
        PlayerImage.Source = imageSources[gameState.CurrentPlayer];

        if (gameState.Moves.Count == 5)
        {
            var firstMove = gameState.Moves[0];
            StopBlinking(firstMove.row, firstMove.column);
            StartBlinking(firstMove.row, firstMove.column);
        }
    }
    private async void OnGameEnded(GameResult gameResult)
    {
        await Task.Delay(1000);
        if (gameResult.Winner == Player.None)
        {
            await TransitionToEndScreen("It's a draw!", null);
        }
        else
        {
            await ShowLine(gameResult.WinInfo);
            await Task.Delay(1000);
            await TransitionToEndScreen("Winner: ", imageSources[gameResult.Winner]);
            
            if (gameResult.Winner == Player.X)
            {
                xScore++;
            }
            else if (gameResult.Winner == Player.O)
            {
                oScore++;
            }

            Xscore.Text = $"X score: {xScore}";
            Oscore.Text = $"O score: {oScore}";
        }
    }
    
    private async void StartButton_Click(object sender, RoutedEventArgs e)
    {
        await FadeOut(StartScreen);
        await Task.WhenAll(FadeIn(TurnPanel), FadeIn(GameCanvas));
    }
    
    private async void OnGameRestarted()
    {
        
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                StopBlinking(i, j);
                imageControls[i,j].BeginAnimation(Image.SourceProperty, null);
                imageControls[i,j].Source = null;
            }
        }
        PlayerImage.Source = imageSources[gameState.CurrentPlayer];
        await TransitionToGameScreen();
    }
    
    private void GameGrid_MouseDown(object sender, MouseButtonEventArgs e)
    {
        double squareSize = GameGrid.Width/3;
        Point clickPosition = e.GetPosition(GameGrid);
        int row = (int)(clickPosition.Y/squareSize);
        int col = (int)(clickPosition.X/squareSize);
        gameState.MakeMove(row,col);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (gameState.GameOver)
        {
            gameState.Reset();
        }
    }
}
}