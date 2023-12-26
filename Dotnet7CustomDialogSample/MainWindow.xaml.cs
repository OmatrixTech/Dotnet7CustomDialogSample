using Custom.Dotnet7.MessageBox.Utility;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Dotnet7CustomDialogSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext=App.ServiceProvider.GetRequiredService<MainWindowViewModel>();
            SharedOccurrenceEventsHandler.ModalConfirmDialogCallBackHandler += CommonEvents_ModalConfirmDialogCallBackHandler;
        }

        private void CommonEvents_ModalConfirmDialogCallBackHandler(object? sender, ProcessEventArgs e)
        {
            if (e.DialogResult)
            {
                //Perform your task
            }
            else
            {
                //do action
            }
        }

        private void FileDialog_Click(object sender, RoutedEventArgs e)
        {
            string inputResult = CustomMessageBoxHandler.GetInstance.DisplayComprehensiveFileMessageBox(headerTitle: "File Handler", browseButtonText: "Browse Folder", modalPopupButtonText: "Ok");
            var str = inputResult;
          
        }

        private void InputDialog_Click(object sender, RoutedEventArgs e)
        {
            string inputResult = CustomMessageBoxHandler.GetInstance.DisplayComprehensiveInputMessageBox(headerTitle: "Input Prompt", inputLabelText: "Enter Text", modalPopupButtonText: "Ok");
            var str = inputResult;
        }

        private void CustomAlertModalPopup_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBoxHandler.GetInstance.DisplayCustomAlertMessageBox(headerTitle: "Information", modalPopupMessageText: "This is a custom message box", messageBoxImageIconType: CustomMessageBoxImage.Exclamation, modalPopupButtonText: "OK");
        }

        private void CustomConfirmModalPopup_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBoxHandler.GetInstance.DisplayCustomConfirmationMessageBox(headerTitle: "Information", modalPopupMessageText: "Do you want to close this popup?Do you want to close this popup?Do you want to close this popup?", messageBoxImageIconType: CustomMessageBoxImage.Warning, modalPopupFirstButtonText: "OK", modalPopupSecondButtonText: "Cancel");
        }

        private void ComprehensiveCustomAlertModalPopup_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBoxHandler.GetInstance.DisplayComprehensiveCustomAlertMessageBox(headerTitle: "Information", modalPopupMessageText: "This is a custom message box", messageBoxImageIconType: CustomMessageBoxImage.Error, modalPopupButtonText: "Okay");
        }

        private void ComprehensiveCustomConfirmModalPopup_Click(object sender, RoutedEventArgs e)
        {
            CustomMessageBoxHandler.GetInstance.DisplayComprehensiveCustomConfirmMessageBox(headerTitle: "Demo Modal Popup", modalPopupMessageText: "Do you want to close this application?", messageBoxImageIconType: CustomMessageBoxImage.Information, modalPopupFirstButtonText: "Yes", modalPopupSecondButtonText: "No");
        }
    }
}