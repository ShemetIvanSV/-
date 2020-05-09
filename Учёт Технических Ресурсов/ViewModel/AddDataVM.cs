using System;
using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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

    internal class AddDataVM : BaseViewModel
    {
        private ICommand addCommand;
        private int? computerId;
        private ICommand readFilePathCommand;
        private ICommand readPicturePathCommand;
        private TechnicalResourcesBaseModel resourcesBaseModel;
        private TechnicalTypes selectedTechnicalTypes;
        private BaseViewModel viewModelNavigation;

        public AddDataVM()
        {
            ResourcesBaseModel = new Computer();
            TableNames = new ObservableCollection<object>();
            ViewModelNavigation = this;
            ReturnToTypes(TableNames);
        }

        public int? ComputerId
        {
            get => computerId;
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        private DocumentDialogService DocumentDialogService { get; } = new DocumentDialogService();
        private PictureDialogService PictureDialogService { get; } = new PictureDialogService();

        public BaseViewModel ViewModelNavigation
        {
            get => viewModelNavigation;
            set
            {
                viewModelNavigation = value;
                OnPropertyChanged();
            }
        }

        public TechnicalResourcesBaseModel ResourcesBaseModel
        {
            get => resourcesBaseModel;
            set
            {
                resourcesBaseModel = value;
                OnPropertyChanged();
            }
        }

        public TechnicalTypes SelectedTechnicalType
        {
            get => selectedTechnicalTypes;
            set
            {
                selectedTechnicalTypes = value;
                OnPropertyChanged();
            }
        }

        private AddTechnical AddTechnical { get; set; }

        public ObservableCollection<object> TableNames { get; set; }

        public ICommand AddCommand => addCommand ??
                                      (addCommand = new RelayCommand(obj => { TechnicalCreating(); }));

        public ICommand ReadFilePathCommand => readFilePathCommand ??
                                               (readFilePathCommand = new RelayCommand(obj =>
                                               {
                                                   DocumentDialogService.OpenFileDialog();
                                                   ResourcesBaseModel.DocumentPath = DocumentDialogService.FilePath;
                                               }));
        public ICommand ReadPicturePathCommand => readPicturePathCommand ??
                                               (readPicturePathCommand = new RelayCommand(obj =>
                                               {
                                                   PictureDialogService.OpenFileDialog();
                                                   ResourcesBaseModel.PicturePath = PictureDialogService.FilePath;
                                               }));

        private void ReturnToTypes(ObservableCollection<object> collection)
        {
            var tableNames = new TechnicalTypes();

            var technicalNames = Enum.GetValues(tableNames.GetType());

            foreach (var t in technicalNames) collection.Add(t);
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
            catch (DbUpdateException)
            {
                DocumentDialogService.ShowMessage("Данный компьютер не найден");
            }
            catch (DbEntityValidationException)
            {
                DocumentDialogService.ShowMessage("Введите все обязательные данные(помечены *)");
            }
            catch (InvalidOperationException)
            {
                DocumentDialogService.ShowMessage("Данная техника обязательно должна быть связана с ПК");
            }
            catch (Exception)
            {
                DocumentDialogService.ShowMessage("Неизвестная ошибка");
            }
        }
    }
}