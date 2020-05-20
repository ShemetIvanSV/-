using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.EquipmentDbRepository;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class PrintersVM : TablePageBaseVM<Printer,PrinterRepository>
    {
        private ICommand openDocumentCommand;
        private ICommand removeCommand;
        private ICommand saveChangeCommand;
        private BaseViewModel viewModelNavigation;

        public PrintingTechnology SelectedPrinting
        {
            get => SelectedEquipment.PrintingTechnology;
            set
            {
                SelectedEquipment.PrintingTechnology = value;
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
                                                       var path = SelectedEquipment.DocumentPath;
                                                       Process.Start(@path);
                                                   }
                                                   catch
                                                   {
                                                       DocumentDialogService.ShowMessage("Документ отсутствует");
                                                   }
                                               }));
    }
}
