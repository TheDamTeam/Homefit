using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CoreAnimation;
using CoreGraphics;
using Foundation;
using Homefit.iOS.Renderers;
using Homefit.Views.Controls;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientColorButton), typeof(GradientColorButtonRenderer))]
namespace Homefit.iOS.Renderers
{
    public class GradientColorButtonRenderer : ButtonRenderer
    {
        #region overrides
        /// <summary>
        /// Draw the gradient background button
        /// </summary>
        /// <param name="rect"></param>
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);

            if (Element != null)
            {
                if (Element is GradientColorButton)
                {
                    var gradientLayer = new CAGradientLayer();
                    var button = Element as GradientColorButton;
                    gradientLayer.Frame = rect;
                    gradientLayer.Colors = new CGColor[] {
                        button.StartColor.ToCGColor(),
                        button.EndColor.ToCGColor()
                    };

                    /* horizontal gradient
                    if (button.GradientOrientation == GradientButton.GradientOrientationStates.Horizontal)
                    {*/
                    gradientLayer.StartPoint = new CGPoint(0.0, 0.5);
                    gradientLayer.EndPoint = new CGPoint(1.0, 0.5);
                    /*}
                     vertical gradient
                    else if (button.GradientOrientation == GradientButton.GradientOrientationStates.Vertical)
                    {
                        gradientLayer.StartPoint = new CGPoint(0.5, 0.0);
                        gradientLayer.EndPoint = new CGPoint(0.5, 1.0);
                    }*/


                    gradientLayer.CornerRadius = button.CornerRadius;

                    NativeView.Layer.InsertSublayer(gradientLayer, 0);
                }
            }
        }
        #endregion
    }
}