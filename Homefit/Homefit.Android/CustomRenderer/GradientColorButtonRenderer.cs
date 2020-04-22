using System;
using Android.Content;
using Android.Graphics.Drawables;
using Homefit.Droid.CustomRenderer;
using Homefit.Views.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(GradientColorButton), typeof(GradientColorButtonRenderer))]
namespace Homefit.Droid.CustomRenderer
{
    public class GradientColorButtonRenderer : Xamarin.Forms.Platform.Android.AppCompat.ButtonRenderer
    {

        GradientDrawable _gradient;

        public GradientColorButtonRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }
            if (Control != null)
            {
                try
                {
                    Control.SetBackground(DrawGradient(e));
                }
                catch (Exception ex)
                {
                    // handle exception
                }
            }
        }
        private GradientDrawable DrawGradient(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            var button = e.NewElement as GradientColorButton;
            /*var orientation = button.GradientOrientation == GradientButton.GradientOrientationStates.Horizontal ?
                GradientDrawable.Orientation.LeftRight : GradientDrawable.Orientation.TopBottom;
                */
            
            _gradient = new GradientDrawable(GradientDrawable.Orientation.LeftRight, new[] {
                button.StartColor.ToAndroid().ToArgb(),
                button.EndColor.ToAndroid().ToArgb(),
            });

            _gradient.SetCornerRadius(button.CornerRadius * 10);
            _gradient.SetStroke(0, button.StartColor.ToAndroid());

            return _gradient;
        }
    }
}