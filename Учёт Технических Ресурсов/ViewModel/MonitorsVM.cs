using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Diagnostics;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.DialogService;
using Учёт_Технических_Ресурсов.EquipmentDbRepository;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class MonitorsVM : TablePageBaseVM<Monitor, MonitorRepository>
    {
        private ICommand openDocumentCommand;
        private ICommand removeCommand;
        private ICommand saveChangeCommand;
        private BaseViewModel viewModelNavigation;

        public TypeMatrix SelectedMatrix
        {
            get => SelectedEquipment.Matrix;
            set
            { 
                SelectedEquipment.Matrix = value;
                OnPropertyChanged();
            }
        }

        public string SelectedM
        {
            get => SelectedMatrix.ToString();
            set
            {
                var s =SelectedMatrix.ToString();
                    s = value;
                OnPropertyChanged();
            }
        }

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
                                                       DefaultDialogService.ShowMessage("Документ отсутствует");
                                                   }
                                               }));
    }
}
