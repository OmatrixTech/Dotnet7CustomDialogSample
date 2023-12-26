using Custom.Dotnet7.MessageBox.Implementation;
using Custom.Dotnet7.MessageBox.Interfaces;
using Custom.Dotnet7.MessageBox.Utility;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Dotnet7CustomDialogSample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //Initial setup for all type of modal MessageBox
            CustomMessageBoxHandler.GetInstance.ConfigureModalPopupSettings(
            ModalPopupMouseHoverButtonBackgroundColor: new SolidColorBrush(Colors.Blue),
            ModalPopupMouseHoverButtonForegroundColor: new SolidColorBrush(Colors.White),
            ModalPopupBodyBackgroundColor: new SolidColorBrush(Colors.Black),
            ModalPopupMessageTextColor: new SolidColorBrush(Colors.White),
            ModalPopupMessageTextFontSize: 13.0,
            ModalPopupMessageTextFontFamily: new FontFamily("Aerial Black"),
            ModalPopupButtonBottomAlignment: HorizontalAlignment.Right,
            ModalPopupButtonWidth: 80.0,
            ModalPopupButtonTextColor: new SolidColorBrush(Colors.White),
            ModalPopupMessageButtonFontSize: 12.0,
            ModalPopupButtonDisplayBackgroundColor: new SolidColorBrush(Colors.OrangeRed),
            ModalPopupHeaderBackgroundColor: new SolidColorBrush(Colors.OrangeRed),
            ModalPopupHeaderTitleTextColor: new SolidColorBrush(Colors.White),
            ModalPopupHeaderFontFamily: new FontFamily("Aerial Black"),
            ModalPopupHeaderFontSize: 13.0,
            ModalPopupHeaderIcon: CreateImageSourceFromPackUri()) ;
            SetInstance();
        }
        private void SetInstance()
        {
            // Create a service collection
            var services = new ServiceCollection();

            // Add your services to the container
            services.AddSingleton<IModalPopupHandlerService, ModalPopupHandlerService>();
            services.AddTransient<MainWindow>();
            services.AddTransient<MainWindowViewModel>();
            // Build the service provider
            ServiceProvider = services.BuildServiceProvider();

        }
        public ImageSource CreateImageSourceFromPackUri()
        {
            try
            {
                //When image is kept in running assembly
                Uri uri = new Uri(@"pack://application:,,,/Dotnet7CustomDialogSample;component/Images/CameraControl.png", UriKind.RelativeOrAbsolute);
                return new BitmapImage(uri);
            }
            catch (Exception ex)
            {
                // Handle any exceptions:"", such as UriFormatException or FileNotFoundException
                // You can log the exception or return a default image source if needed
                return new BitmapImage();
            }
        }
    }

}
