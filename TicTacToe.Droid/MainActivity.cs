using System;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TicTacToe.Droid {
  [Activity(Label = "Tic Tac Toe", MainLauncher = true, Icon = "@drawable/tictactoeLogo")]
  public class MainActivity : Activity {
    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      RequestWindowFeature(WindowFeatures.NoTitle);

      SetContentView(Resource.Layout.Main);
      OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);

      var tutorialButton = FindViewById<Button>(Resource.Id.TutorialButton);
      var startGameButton = FindViewById<Button>(Resource.Id.StartGameButton);
      Typeface typeFace = Typeface.CreateFromAsset(Assets, "fonts/wg_legacy_edition.ttf");

      tutorialButton.SetTypeface(typeFace, TypefaceStyle.Normal);
      startGameButton.SetTypeface(typeFace, TypefaceStyle.Normal);

      tutorialButton.Click += TutorialButtonOnClick;
      startGameButton.Click += StartGameButtonOnClick;
    }

    private void TutorialButtonOnClick(object sender, EventArgs eventArgs) {
      var intent = new Intent(this, typeof(TutorialActivity));
      OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
      StartActivity(intent);
    }

    private void StartGameButtonOnClick(object sender, EventArgs eventArgs) {
      var intent = new Intent(this, typeof(GameActivity));
      OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
      StartActivity(intent);
    }
  }
}
