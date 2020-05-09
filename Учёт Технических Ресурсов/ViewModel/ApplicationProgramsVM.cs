using System.Diagnostics;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.EquipmentDbRepository;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    internal class ApplicationProgramsVM : TablePageBaseVM<ApplicationProgram, ApplicationRepository>
    {
        private ICommand openDocumentCommand;
        private ICommand removeCommand;
        private ICommand saveChangeCommand;
        private BaseViewModel viewModelNavigation;

        public BaseViewModel ViewModelNavigation
        {
            get => viewModelNavigation;
            set
            {
                viewModelNavigation = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveChangeCommand => saveChangeCommand ??
                                             (saveChangeCommand = new RelayCommand(obj => { EquipmentsSaveChange(); }));

        public ICommand RemoveCommand => removeCommand ??
                                         (removeCommand = new RelayCommand(obj => { EquipmentsRemove(); }));

        public ICommand OpenDocumentCommand => openDocumentCommand ??
                                               (openDocumentCommand = new RelayCommand(obj =>
                                               {
                                                   try
                                                   {
                                                       string path = SelectedEquipment.DocumentPath;
                                                       Process.Start(path);
                                                   }
                                                   catch
                                                   {
                                                       DocumentDialogService.ShowMessage("Документ отсутствует");
                                                   }
                                               }));
    }
}