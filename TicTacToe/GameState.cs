namespace TicTacToeWPF
{
    public class GameState
    {
        public Player[,] GameGrid { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public int TurnPassed { get; private set; }
        public bool GameOver { get; private set; }
        
        public List<(int row, int column)> Moves ;

        public event Action<int, int> MoveMade;
        public event Action<int, int> SymbolRemoved;
        public event Action<GameResult> GameEnded;
        public event Action GameRestarted;

        public GameState()
        {
            GameGrid = new Player[3, 3];
            CurrentPlayer = Player.X;
            TurnPassed = 0;
            GameOver = false;
            Moves = new List<(int, int)>();
        }

        private bool CanMakeMove(int row, int column)
        {
            return GameGrid[row, column] == Player.None;
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == Player.X ? Player.O : Player.X;
        }

        public void MakeMove(int r, int c)
        {
            if (!CanMakeMove(r, c) || GameOver)
            {
                return;
            }

            GameGrid[r, c] = CurrentPlayer;
            Moves.Add((r, c));
            TurnPassed++;

            if (Moves.Count > 5)
            {
                var firstMove = Moves[0];
                GameGrid[firstMove.row, firstMove.column] = Player.None;
                SymbolRemoved?.Invoke(firstMove.row, firstMove.column);
                Moves.RemoveAt(0);
                TurnPassed--;
            }

            if (DidMoveEndGame(r, c, out GameResult gameResult))
            {
                GameOver = true;
                MoveMade?.Invoke(r, c);
                GameEnded?.Invoke(gameResult);
            }
            else
            {
                SwitchPlayer();
                MoveMade?.Invoke(r, c);
            }
        }

        private bool DidMoveEndGame(int row, int column, out GameResult gameResult)
        {
            if (CheckWin(row, column, out gameResult))
            {
                return true;
            }

            gameResult = new GameResult { Winner = Player.None, WinInfo = null };
            return false;
        }

        private bool CheckWin(int row, int column, out GameResult gameResult)
        {
            Player player = GameGrid[row, column];

            if (GameGrid[row, 0] == player && GameGrid[row, 1] == player && GameGrid[row, 2] == player)
            {
                gameResult = new GameResult { Winner = player, WinInfo = new WinInfo { Type = WinType.Row, Number = row } };
                return true;
            }

            if (GameGrid[0, column] == player && GameGrid[1, column] == player && GameGrid[2, column] == player)
            {
                gameResult = new GameResult { Winner = player, WinInfo = new WinInfo { Type = WinType.Column, Number = column } };
                return true;
            }

            if (row == column && GameGrid[0, 0] == player && GameGrid[1, 1] == player && GameGrid[2, 2] == player)
            {
                gameResult = new GameResult { Winner = player, WinInfo = new WinInfo { Type = WinType.MainDiagonal } };
                return true;
            }

            if (row + column == 2 && GameGrid[0, 2] == player && GameGrid[1, 1] == player && GameGrid[2, 0] == player)
            {
                gameResult = new GameResult { Winner = player, WinInfo = new WinInfo { Type = WinType.AntiDiagonal } };
                return true;
            }

            gameResult = new GameResult { Winner = Player.None, WinInfo = null };
            return false;
        }

        public void Reset()
        {
            GameGrid = new Player[3, 3];
            CurrentPlayer = Player.X;
            TurnPassed = 0;
            GameOver = false;
            Moves.Clear();
            GameRestarted?.Invoke();
        }
    }
}