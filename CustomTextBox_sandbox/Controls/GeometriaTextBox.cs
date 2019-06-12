using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CustomTextBox_sandbox.Controls
{
    public class GeometriaTextBox : TextBox
    {
        #region PopUpErrorText
        public object PopUpErrorText
        {
            get
            {
                return (object)GetValue( PopUpErrorTextProperty );
            }
            set
            {
                SetValue( PopUpErrorTextProperty, value );
            }
        }

        public static readonly DependencyProperty PopUpErrorTextProperty = DependencyProperty.Register(
          nameof( PopUpErrorText ),
          typeof( object ),
          typeof( GeometriaTextBox ),
          new UIPropertyMetadata( null ) );
        #endregion

        #region IsPopUpVisible
        public bool IsPopUpVisible
        {
            get
            {
                return (bool)GetValue( IsPopUpVisibleProperty );
            }
            set
            {
                SetValue( IsPopUpVisibleProperty, value );
            }
        }

        public static readonly DependencyProperty IsPopUpVisibleProperty = DependencyProperty.Register(
          nameof( IsPopUpVisible ),
          typeof( bool ),
          typeof( GeometriaTextBox ),
          new UIPropertyMetadata( null ) );
        #endregion

        /// <summary>
        /// Validációtól függően, a hibásan beírt karakter után megjelenít egy Pupup-ot, a TextBox alatt. A PopUp-on szereplő szöveg Bindolható.
        /// </summary>
        public void ShowPopUp()
        {
            if( IsPopUpVisible )
                return;
            IsPopUpVisible = true;

            DispatcherTimer dt = new DispatcherTimer();
            dt.Interval = new TimeSpan( 0, 0, 2 );
            dt.Tick += delegate ( object sender1, EventArgs e1 )
                                { IsPopUpVisible = false; dt.Stop(); };
            dt.Start();

            System.Media.SystemSounds.Beep.Play();
        }

        /// <summary>
        /// Eltünteti a TextBox alatti PopUp-ot.
        /// </summary>
        public void HidePopUp()
        {
            IsPopUpVisible = false;
        }
    }
}
