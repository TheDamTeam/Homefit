using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using System.Threading.Tasks;

namespace Homefit.Droid.Activities
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, NoHistory = true)]
    public class SplashActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            // Create your application here
        }
        // Launches the startup task
        protected override void OnResume()
        {
            base.OnResume();
            Task startupWork = new Task(() => { SimulateStartup(); });
            startupWork.Start();
        }
        public override void OnBackPressed() { }

        async void SimulateStartup()
        {

            await Task.Delay(1000); 
           
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }
    }
}