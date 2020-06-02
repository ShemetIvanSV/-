using System;
using System.Collections.Generic;
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
    internal class AddDataVM : BaseViewModel
    {
        private ICommand addCommand;
        private int? computerId;
        private ICommand readFilePathCommand;
        private ICommand readPicturePathCommand;
        private TechnicalResourcesBaseModel resourcesBaseModel;
        private AddTechnical selectedAddAddTechnical;
        private BaseViewModel viewModelNavigation;

        public AddDataVM()
        {
            ResourcesBaseModel = new TechnicalResourcesBaseModel();

            ViewModelNavigation = this;

            ReturnToTypes(Technicals);
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

        private DocumentDialogService DocumentDialogService { get; }
            = new DocumentDialogService();

        private PictureDialogService PictureDialogService { get; }
            = new PictureDialogService();

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

        public AddTechnical SelectedAddTechnical
        {
            get => selectedAddAddTechnical;
            set
            {
                selectedAddAddTechnical = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<AddTechnical> Technicals { get; }
            = new ObservableCollection<AddTechnical>();

        public ICommand AddCommand => addCommand ??
                                      (addCommand = new RelayCommand(obj =>
                                      {
                                          TechnicalCreating(SelectedAddTechnical, ResourcesBaseModel);
                                      }));

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

        private void ReturnToTypes(ObservableCollection<AddTechnical> addTechnicals)
        {
            var adds = new List<AddTechnical>
            {
                new CreateApp(),
                new CreateCPU(),
                new CreateComputer(),
                new CreateMonitor(),
                new CreateMotherboard(),
                new CreateOS(),
                new CreatePrinter(),
                new CreateRUM()
            };

            foreach (var add in adds) addTechnicals.Add(add);
        }

        private void TechnicalCreating(AddTechnical addTechnical, TechnicalResourcesBaseModel model)
        {
            try
            {
                addTechnical.CreateTechnical(model, ComputerId);
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