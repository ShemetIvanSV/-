using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    internal class NavigateVM : BaseViewModel
    {
        private ICommand openAddViewCommand;
        private ICommand openApplicationsViewCommand;
        private ICommand openComputersCommand;
        private ICommand openCPUsViewCommand;
        private ICommand openMonitorsViewCommand;
        private ICommand openMotherboardsViewCommand;
        private ICommand openOperatingSystemsViewCommand;
        private ICommand openPrintersViewCommand;
        private ICommand openRUMsViewCommand;
        private ICommand openNavigateViewCommand;
        private BaseViewModel viewModel;
        private ObservableCollection<TechnicalResourcesBaseModel> technicalResources;
        private DateTime selectedDate;


        public ObservableCollection<TechnicalResourcesBaseModel> TechnicalResources
        {
            get { return technicalResources; }
            set
            {
                technicalResources = value;
                OnPropertyChanged();
            }
        }

        public DateTime SelectedDate
        {
            get 
            {

                TechnicalResources.Clear();
                DataWrite(selectedDate.Date);
                return selectedDate; 

            
            }
            set
            {
                selectedDate = value;
                OnPropertyChanged();
            }
        }

        public NavigateVM()
        {
            ViewModelNavigation = this;

            TechnicalResources = new ObservableCollection<TechnicalResourcesBaseModel>();

            InitializeData();
        }

        private async void InitializeData()
        {
            using (var technicaldb = new TechnicalResourcesContext())
            {
                await Task.Run(() => technicaldb.Database.Initialize(true));
            }
        }

        private void DataWrite(DateTime date)
        {
            using (var technicaldb = new TechnicalResourcesContext())
            {
                var resourcesApplicationPrograms = technicaldb.ApplicationPrograms.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesComputers = technicaldb.Computers.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesCPUs = technicaldb.CPUs.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesMonitors = technicaldb.Monitors.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesMotherboards = technicaldb.Motherboards.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesOperatingSystems = technicaldb.OperatingSystems.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesPrinters = technicaldb.Printers.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);
                var resourcesRUMs = technicaldb.RUMs.Where(a => DbFunctions.TruncateTime(a.DateOfCreate) == date);

                foreach (var res in resourcesApplicationPrograms)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesComputers)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesCPUs)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesMonitors)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesMotherboards)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesOperatingSystems)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesPrinters)
                {
                    TechnicalResources.Add(res);
                }
                foreach (var res in resourcesRUMs)
                {
                    TechnicalResources.Add(res);
                }
            }
        }

        public BaseViewModel ViewModelNavigation
        {
            get => viewModel;
            set
            {
                viewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenComputersViewCommand
        {
            get
            {
                return openComputersCommand ??
                       (openComputersCommand = new RelayCommand(obj => { ViewModelNavigation = new ComputersVM(); }));
            }
        }

        public ICommand OpenAddViewCommand
        {
            get
            {
                return openAddViewCommand ??
                       (openAddViewCommand = new RelayCommand(obj => { ViewModelNavigation = new AddDataVM(); }));
            }
        }

        public ICommand OpenCPUsViewCommand
        {
            get
            {
                return openCPUsViewCommand ??
                       (openCPUsViewCommand = new RelayCommand(obj => { ViewModelNavigation = new CPUsVM(); }));
            }
        }

        public ICommand OpenMonitorsViewCommand
        {
            get
            {
                return openMonitorsViewCommand ??
                       (openMonitorsViewCommand = new RelayCommand(obj => { ViewModelNavigation = new MonitorsVM(); }));
            }
        }

        public ICommand OpenPrintersViewCommand
        {
            get
            {
                return openPrintersViewCommand ??
                       (openPrintersViewCommand = new RelayCommand(obj => { ViewModelNavigation = new PrintersVM(); }));
            }
        }

        public ICommand OpenOperatingSystemsViewCommand
        {
            get
            {
                return openOperatingSystemsViewCommand ??
                       (openOperatingSystemsViewCommand = new RelayCommand(obj =>
                       {
                           ViewModelNavigation = new OperatingSystemsVM();
                       }));
            }
        }

        public ICommand OpenMotherboardsViewCommand
        {
            get
            {
                return openMotherboardsViewCommand ??
                       (openMotherboardsViewCommand =
                           new RelayCommand(obj => { ViewModelNavigation = new MotherboardsVM(); }));
            }
        }

        public ICommand OpenApplicationsViewCommand
        {
            get
            {
                return openApplicationsViewCommand ??
                       (openApplicationsViewCommand =
                           new RelayCommand(obj => { ViewModelNavigation = new ApplicationProgramsVM(); }));
            }
        }

        public ICommand OpenRUMsViewCommand
        {
            get
            {
                return openRUMsViewCommand ??
                       (openRUMsViewCommand =
                           new RelayCommand(obj => { ViewModelNavigation = new RUMsVM(); }));
            }
        }

        public ICommand OpenNavigateViewCommand
        {
            get
            {
                return openNavigateViewCommand ??
                       (openNavigateViewCommand =
                           new RelayCommand(obj => { ViewModelNavigation = new NavigateVM(); }));
            }
        }
    }
}