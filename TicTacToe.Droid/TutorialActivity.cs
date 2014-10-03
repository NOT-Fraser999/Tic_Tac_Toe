using System;
using System.Threading.Tasks;
using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace TicTacToe.Droid {
  [Activity(Label = "Tutorial", Icon = "@drawable/tictactoeLogo")]
  public class TutorialActivity : Activity {
    protected override void OnCreate(Bundle bundle) {
      base.OnCreate(bundle);
      RequestWindowFeature(WindowFeatures.NoTitle);

      SetContentView(Resource.Layout.Tutorial);
      OverridePendingTransition(Resource.Animation.trans_left_in, Resource.Animation.trans_left_out);

      var textView = FindViewById<TextView>(Resource.Id.TitleTextView);
      var backButton = FindViewById<ImageButton>(Resource.Id.BackButton);

      Typeface typeFace = Typeface.CreateFromAsset(Assets, "fonts/wg_legacy_edition.ttf");

      textView.SetTypeface(typeFace, TypefaceStyle.Normal);

      backButton.Click += BackButtonOnClick;
      /**** Toast Comment ****/
      var t = new Thread(
        async () => {
          await Task.Delay(5000);
          RunOnUiThread(
            () => {
              var toast = Toast.MakeText(
                this,
                "Seriously? Piss off.\n\nYou don't need to play this game.",
                ToastLength.Long);
              toast.SetGravity(GravityFlags.Center, 0, 0);
              toast.Show();
            });
        });
      t.Start();
      /**** Toast Comment ****/
    }

    private void BackButtonOnClick(object sender, EventArgs eventArgs) {
      base.OnBackPressed();
      OverridePendingTransition(Resource.Animation.trans_right_in, Resource.Animation.trans_right_out);
    }
  }
}
