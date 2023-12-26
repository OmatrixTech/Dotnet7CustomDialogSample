using Custom.Dotnet7.MessageBox.Interfaces;
using Custom.Dotnet7.MessageBox.Utility;
using Prism.Commands;
using Prism.Mvvm;

namespace Dotnet7CustomDialogSample
{
    public class MainWindowViewModel:BindableBase
    {
        //Custom Alert
        private DelegateCommand _ExecuteCustomAlertPopupCommand;

        public DelegateCommand ExecuteCustomAlertPopupCommand =>
            _ExecuteCustomAlertPopupCommand ?? (_ExecuteCustomAlertPopupCommand = new DelegateCommand(ExecuteCustomAlertPopupHandler));

        private void ExecuteCustomAlertPopupHandler()
        {
            modalPopupHandlerService.DisplayCustomAlertMessageBox(headerTitle: "Custom Message", modalPopupMessageText: "This is a custom message box", messageBoxImageIconType: CustomMessageBoxImage.Exclamation, modalPopupButtonText: "OK");
        }

        //custom confirm modal popup
        private DelegateCommand _ExecuteCustomConfirmPopupCommand;

        public DelegateCommand ExecuteCustomConfirmPopupCommand =>
            _ExecuteCustomConfirmPopupCommand ?? (_ExecuteCustomConfirmPopupCommand = new DelegateCommand(ExecuteCustomConfirmPopupHandler));

        private void ExecuteCustomConfirmPopupHandler()
        {
            modalPopupHandlerService.DisplayCustomConfirmationMessageBox(headerTitle: "Custom Message", modalPopupMessageText: "Do you want to close this popup?Do you want to close this popup?Do you want to close this popup?", messageBoxImageIconType: CustomMessageBoxImage.Warning, modalPopupFirstButtonText: "OK", modalPopupSecondButtonText: "Cancel");
        }

        //Comprehensive alert
        private DelegateCommand _ExecuteComprehensiveAlertPopupCommand;

        public DelegateCommand ExecuteComprehensiveAlertPopupCommand =>
            _ExecuteComprehensiveAlertPopupCommand ?? (_ExecuteComprehensiveAlertPopupCommand = new DelegateCommand(ExecuteComprehensiveAlertPopupHandler));

        private void ExecuteComprehensiveAlertPopupHandler()
        {
            modalPopupHandlerService.DisplayComprehensiveCustomAlertMessageBox(headerTitle: "Custom Message", modalPopupMessageText: "This is a custom message box", messageBoxImageIconType: CustomMessageBoxImage.Error, modalPopupButtonText: "Okay");
        }
        //Comprehensive confirm modal popup
        private DelegateCommand _ExecuteComprehensiveConfirmPopupCommand;

        public DelegateCommand ExecuteComprehensiveConfirmPopupCommand =>
            _ExecuteComprehensiveConfirmPopupCommand ?? (_ExecuteComprehensiveConfirmPopupCommand = new DelegateCommand(ExecuteComprehensiveConfirmPopupHandler));

        private void ExecuteComprehensiveConfirmPopupHandler()
        {
            modalPopupHandlerService.DisplayComprehensiveCustomConfirmMessageBox(headerTitle: "Custom Message", modalPopupMessageText: "This is a custom confirm message box", messageBoxImageIconType: CustomMessageBoxImage.Question, modalPopupFirstButtonText: "Okay", modalPopupSecondButtonText: "Close");
        }

        //Input dialog
        private DelegateCommand _ExecuteCustomInputPopupCommand;

        public DelegateCommand ExecuteCustomInputPopupCommand =>
            _ExecuteCustomInputPopupCommand ?? (_ExecuteCustomInputPopupCommand = new DelegateCommand(ExecuteInputPopupHandler));

        private void ExecuteInputPopupHandler()
        {
            string inputResult = modalPopupHandlerService.DisplayComprehensiveInputMessageBox(headerTitle: "Custom Message", inputLabelText: "Enter your text", modalPopupButtonText: "Okay");
            var str = inputResult;
        }
        //File Dialog
        private DelegateCommand _ExecuteCustomFilePopupCommand;

        public DelegateCommand ExecuteCustomFilePopupCommand =>
            _ExecuteCustomFilePopupCommand ?? (_ExecuteCustomFilePopupCommand = new DelegateCommand(ExecuteFilePopupHandler));

        private void ExecuteFilePopupHandler()
        {
            string inputResult = modalPopupHandlerService.DisplayComprehensiveFileMessageBox(headerTitle: "File Dialog Popup", browseButtonText: "Browse your custom Folder", modalPopupButtonText: "Okay");
            var str = inputResult;
        }


        IModalPopupHandlerService? modalPopupHandlerService = null;
        public MainWindowViewModel(IModalPopupHandlerService modalPopupHandlerService)
        {
            this.modalPopupHandlerService = modalPopupHandlerService;
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
    }
}
