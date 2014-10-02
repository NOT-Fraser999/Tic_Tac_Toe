using System;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace TicTacToe.Droid {
  [Activity(Label = "Tutorial", Icon = "@drawable/tictactoeLogo")]
  public class TutorialActivity : Activity {
    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      RequestWindowFeature(WindowFeatures.NoTitle);

      SetContentView(Resource.Layout.Tutorial);
      var textView = FindViewById<TextView>(Resource.Id.TutorialTextView);
      var backButton = FindViewById<ImageButton>(Resource.Id.BackButton);

      Typeface typeFace = Typeface.CreateFromAsset(Assets, "fonts/wg_legacy_edition.ttf");

      textView.SetTypeface(typeFace, TypefaceStyle.Normal);

      backButton.Click += BackButtonOnClick;
    }

    private void BackButtonOnClick(object sender, EventArgs eventArgs) {
      Finish();
    }
  }
}
