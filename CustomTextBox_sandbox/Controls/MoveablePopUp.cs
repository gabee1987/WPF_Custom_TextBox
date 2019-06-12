using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace CustomTextBox_sandbox.Controls
{
    public class MoveablePopUp : Popup
    {
        public MoveablePopUp()
        {
            this.Loaded += new RoutedEventHandler( GeometriaTextBox_Loaded );
        }

        /// <summary>
        /// EventHandler, ami garantálja a PopUp helyzetének frissítését, a parent Window mozgatása vagy átméretezése során.
        /// </summary>
        /// <param name="sender">MoveablePopUp</param>
        /// <param name="e">RoutedEventArgs</param>
        void GeometriaTextBox_Loaded( object sender, RoutedEventArgs e )
        {
            Window Parentwindow = Window.GetWindow( this );

            if( Parentwindow != null )
            {
                Parentwindow.LocationChanged += delegate ( object sender2, EventArgs args )
                {
                    var offset = this.HorizontalOffset;
                    // Ha megmozdítják a parent Window-t, a PopUp helyzetét arréb rakjuk egy picit, majd vissza az eredeti helyére
                    // ezzel szimulálva a Textboxhoz "ragadást"
                    this.HorizontalOffset = offset + 1;
                    this.HorizontalOffset = offset;
                };
                // Ugyanezt csináljuk, ha a parent Window-t átméretezik
                Parentwindow.SizeChanged += delegate ( object sender3, SizeChangedEventArgs e2 )
                {
                    var offset = this.HorizontalOffset;
                    this.HorizontalOffset = offset + 1;
                    this.HorizontalOffset = offset;
                };
            }
        }
    }
}
