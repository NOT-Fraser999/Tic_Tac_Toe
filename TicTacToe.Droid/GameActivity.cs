using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using TicTacToe.Portable;

namespace TicTacToe.Droid {
  [Activity(Label = "Tic Tac Toe", Icon = "@drawable/tictactoeLogo")]
  public class GameActivity : Activity {
    private readonly ImageButton[,] _gameCells = new ImageButton[3, 3];
    private TicTacToeGame _game;
    private TextView _playerOWinCountView;
    private TextView _playerXWinCountView;
    private TextView _titleTextView;

    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      RequestWindowFeature(WindowFeatures.NoTitle);

      SetContentView(Resource.Layout.Game);
      OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);

      var newGameButton = FindViewById<ImageButton>(Resource.Id.NewGameButton);
      var backButton = FindViewById<ImageButton>(Resource.Id.BackButton);
      _titleTextView = FindViewById<TextView>(Resource.Id.TitleTextView);
      _playerXWinCountView = FindViewById<TextView>(Resource.Id.PlayerXWinTextView);
      _playerOWinCountView = FindViewById<TextView>(Resource.Id.PlayerOWinTextView);

      var count = 0;
      for (int i = 0; i < TicTacToeGame.BoardSize; ++i) {
        for (int j = 0; j < TicTacToeGame.BoardSize; ++j) {
          int id = Resources.GetIdentifier("button" + (++count), "id", PackageName);
          _gameCells[i, j] = FindViewById<ImageButton>(id);
          _gameCells[i, j].Tag = new CellPosition {Row = i, Column = j};
          _gameCells[i, j].Click += OnGameCellClicked;
        }
      }

      Typeface typeFace = Typeface.CreateFromAsset(Assets, "fonts/wg_legacy_edition.ttf");

      _titleTextView.SetTypeface(typeFace, TypefaceStyle.Normal);
      _playerXWinCountView.SetTypeface(typeFace, TypefaceStyle.Normal);
      _playerOWinCountView.SetTypeface(typeFace, TypefaceStyle.Normal);

      backButton.Click += BackButtonOnClick;
      newGameButton.Click += NewGameButtonOnClick;

      NewGame();
    }

    private void OnGameCellClicked(object sender, EventArgs eventArgs) {
      var senderButton = sender as ImageButton;
      if (senderButton == null) {
        return;
      }

      var cell = senderButton.Tag as CellPosition;
      if (cell == null) {
        return;
      }

      var updatedBoardState = _game.NewMoveMade(cell.Row, cell.Column);
      for (int i = 0; i < TicTacToeGame.BoardSize; ++i) {
        for (int j = 0; j < TicTacToeGame.BoardSize; ++j) {
          switch (updatedBoardState[i, j]) {
            case CellState.NormalO:
              _gameCells[i, j].SetImageResource(Resource.Drawable.blueO);
              break;
            case CellState.NormalX:
              _gameCells[i, j].SetImageResource(Resource.Drawable.blueX);
              break;
            case CellState.WinO:
              _gameCells[i, j].SetImageResource(Resource.Drawable.greenO);
              break;
            case CellState.WinX:
              _gameCells[i, j].SetImageResource(Resource.Drawable.greenX);
              break;
            default:
              _gameCells[i, j].SetImageResource(Android.Resource.Color.Transparent);
              break;
          }
        }
      }

      UpdateGameState();
    }

    private void NewGameButtonOnClick(object sender, EventArgs eventArgs) {
      NewGame();
    }

    private void BackButtonOnClick(object sender, EventArgs eventArgs) {
      base.OnBackPressed();
      OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
    }

    private void NewGame() {
      _game = new TicTacToeGame();
      for (int i = 0; i < TicTacToeGame.BoardSize; ++i) {
        for (int j = 0; j < TicTacToeGame.BoardSize; ++j) {
          _gameCells[i, j].SetImageResource(Android.Resource.Color.Transparent);
        }
      }

      UpdateGameState();
    }

    private void UpdateGameState() {
      _playerOWinCountView.Text = string.Format("player o : {0}", TicTacToeGame.WinCountO);
      _playerXWinCountView.Text = string.Format("player x : {0}", TicTacToeGame.WinCountX);
      _titleTextView.Text = string.Format("turn : {0}", _game.PlayerTurn == Player.X ? "x" : "o");
    }
  }
}
