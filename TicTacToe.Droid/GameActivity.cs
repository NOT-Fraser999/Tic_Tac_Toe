using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TicTacToe.Droid {
  [Activity(Label = "Tic Tac Toe", Icon = "@drawable/tictactoeLogo")]
  public class GameActivity : Activity {
    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      RequestWindowFeature(WindowFeatures.NoTitle);

      SetContentView(Resource.Layout.Game);
      var titleTextView = FindViewById<TextView>(Resource.Id.TitleTextView);
      var newGameButton = FindViewById<ImageButton>(Resource.Id.NewGameButton);
      var backButton = FindViewById<ImageButton>(Resource.Id.BackButton);
      Typeface typeFace = Typeface.CreateFromAsset(Assets, "fonts/wg_legacy_edition.ttf");

      titleTextView.SetTypeface(typeFace, TypefaceStyle.Normal);

      backButton.Click += BackButtonOnClick;
      newGameButton.Click += NewGameButtonOnClick;
    }

    private void NewGameButtonOnClick(object sender, EventArgs eventArgs) {
      Console.WriteLine("New Game Called");
    }

    private void BackButtonOnClick(object sender, EventArgs eventArgs) {
      Finish();
    }
  }
}
