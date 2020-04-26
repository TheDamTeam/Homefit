using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.Res;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Homefit.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Homefit.Views.Controls.CheckBox), typeof(Homefit.Droid.Renderers.CheckBoxRenderer))]
namespace Homefit.Droid.Renderers
{
    public class CheckBoxRenderer : ViewRenderer<Views.Controls.CheckBox, AppCompatCheckBox>
    {

        public CheckBoxRenderer(Context context) : base(context)
        {

        }
        private void CheckBoxCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            Element.IsChecked = e.IsChecked;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Views.Controls.CheckBox> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                if (Control == null)
                {
                    var checkBox = new AppCompatCheckBox(Context);
                    SetNativeControl(checkBox);
                }
                Control.Checked = e.NewElement.IsChecked;
                Control.SupportButtonTintList = GetBackgroundColorStateList(e.NewElement.Color);
            }
        }
        private ColorStateList GetBackgroundColorStateList(Color color)
        {
            return new ColorStateList(
                new[]
                {
                new[] {-global::Android.Resource.Attribute.StateEnabled}, // checked
                new[] {-global::Android.Resource.Attribute.StateChecked}, // unchecked
                new[] {global::Android.Resource.Attribute.StateChecked} // checked
                },
                new int[]
                {
                color.WithSaturation(0.1).ToAndroid(),
                color.ToAndroid(),
                color.ToAndroid()
                });
        }
    }
}