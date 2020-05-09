﻿using System.Diagnostics;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.EquipmentDbRepository;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    class CPUsVM : TablePageBaseVM<CPU, CpuRepository>
    {
        private ICommand saveChangeCommand;
        private ICommand removeCommand;
        private ICommand openDocumentCommand;
        private BaseViewModel viewModelNavigation;

        public BaseViewModel ViewModelNavigation
        {
            get { return viewModelNavigation; }
            set
            {
                viewModelNavigation = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveChangeCommand => saveChangeCommand ??
                 (saveChangeCommand = new RelayCommand(obj =>
                 {
                     EquipmentsSaveChange();
                 }));

        public ICommand RemoveCommand => removeCommand ??
                 (removeCommand = new RelayCommand(obj =>
                 {
                     EquipmentsRemove();
                 }));

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
