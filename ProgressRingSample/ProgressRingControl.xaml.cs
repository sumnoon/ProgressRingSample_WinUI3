using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Windows.UI.Core;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ProgressRingSample
{
    public sealed partial class ProgressRingControl : UserControl
    {
        private Popup popup = null;
        public ProgressRingControl()
        {
            this.InitializeComponent();
            SystemNavigationManager.GetForCurrentView().BackRequested += ProgressRingControl_BackRequested;
            Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;

            popup = new Popup
            {
                Child = this
            };
        }

        private void CoreWindow_SizeChanged(CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            var bounds = Window.Current.Bounds;
            this.Width = bounds.Width;
            this.Height = bounds.Height;
        }

        private void ProgressRingControl_BackRequested(object sender, BackRequestedEventArgs e)
        {
            //HideProgressRing();
        }
        public void ShowProgressRing()
        {
            IndeterminateProgress.IsActive = true;
            popup.IsOpen = true;
            UpdateUI();
        }

        public void HideProgressRing()
        {
            if (popup.IsOpen)
            {
                IndeterminateProgress.IsActive = false;
                popup.IsOpen = false;
                SystemNavigationManager.GetForCurrentView().BackRequested -= ProgressRingControl_BackRequested;
                Window.Current.CoreWindow.SizeChanged -= CoreWindow_SizeChanged;
            }
        }
    }
}
