using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.DialogService;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;
using Учёт_Технических_Ресурсов.TechnicalCreator;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    public enum TechnicalTypes
    {
        Компьютер,
        Монитор,
        Материнская_плата,
        CPU,
        RUM,
        Принтер,
        Операционная_система,
        Программное_обеспечение
    }

    class AddDataVM : BaseViewModel
    {
        private int? computerId;
        private BaseViewModel viewModelNavigation;
        private TechnicalResourcesBaseModel resourcesBaseModel;
        private TechnicalTypes selectedTechnicalTypes;
        private ICommand addCommand;
        private ICommand readFilePathCommand;

        public int? ComputerId
        {
            get { return computerId; }
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        private DefaultDialogService DialogService { get; set; } = new DefaultDialogService();

        public BaseViewModel ViewModelNavigation
        {
            get { return viewModelNavigation; }
            set
            {
                viewModelNavigation = value;
                OnPropertyChanged();
            }
        }

        public TechnicalResourcesBaseModel ResourcesBaseModel
        {
            get { return resourcesBaseModel; }
            set
            {
                resourcesBaseModel = value;
                OnPropertyChanged();
            }
        }

        public TechnicalTypes SelectedTechnicalType
        {
            get { return selectedTechnicalTypes; }
            set
            {
                selectedTechnicalTypes = value;
                OnPropertyChanged();
            }
        }

        private AddTechnical AddTechnical { get; set; }

        public ObservableCollection<object> TableNames { get; set; }

        public AddDataVM()
        {
            ResourcesBaseModel = new Computer();
            TableNames = new ObservableCollection<object>();
            ViewModelNavigation = this;
            ReturnToTypes(TableNames);
        }

        public ICommand AddCommand => addCommand ??
                 (addCommand = new RelayCommand(obj =>
                 {
                     TechnicalCreating();
                 }));

        public ICommand ReadFilePathCommand => readFilePathCommand ??
         (readFilePathCommand = new RelayCommand(obj =>
         {
             DialogService.OpenFileDialog();
             ResourcesBaseModel.DocumentPath = DialogService.FilePath;
         }));

        private void ReturnToTypes(ObservableCollection<object> collection)
        {

            var tableNames = new TechnicalTypes();

            var technicalNames = Enum.GetValues(tableNames.GetType());

            foreach (var t in technicalNames)
            {
                collection.Add(t);
            }
        }

        private void TechnicalCreating()
        {
            try
            {
                switch (SelectedTechnicalType)
                {
                    case TechnicalTypes.CPU:
                        AddTechnical = new CreateCPU(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.RUM:
                        AddTechnical = new CreateRUM(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.Компьютер:
                        AddTechnical = new CreateComputer(ResourcesBaseModel);
                        break;
                    case TechnicalTypes.Материнская_плата:
                        AddTechnical = new CreateMotherboard(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.Монитор:
                        AddTechnical = new CreateMonitor(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.Операционная_система:
                        AddTechnical = new CreateOS(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.Принтер:
                        AddTechnical = new CreatePrinter(ResourcesBaseModel, ComputerId);
                        break;
                    case TechnicalTypes.Программное_обеспечение:
                        AddTechnical = new CreateApp(ResourcesBaseModel, ComputerId);
                        break;
                }

                AddTechnical.CreateTechnical();
            }
            catch (System.Data.Entity.Infrastructure.DbUpdateException)
            {
                DialogService.ShowMessage("Данный компьютер не найден");
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException)
            {
                DialogService.ShowMessage("Введите все обязательные данные(помечены *)");
            }
            catch (InvalidOperationException)
            {
                DialogService.ShowMessage("Данная техника обязательно должна быть связана с ПК");
            }
            catch (Exception)
            {
                DialogService.ShowMessage("Неизвестная ошибка");
            }
        }
    }
}


