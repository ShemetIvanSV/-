using System.Windows.Input;
using Учёт_Технических_Ресурсов.CommandService;
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
        private BaseViewModel viewModel;

        public NavigateVM()
        {
            ViewModelNavigation = this;

            using (var technicaldb = new TechnicalResourcesContext())
            {
                technicaldb.Database.Initialize(true);
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
                           new RelayCommand(obj => { ViewModelNavigation = new ApplicationProgrammsVM(); }));
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
    }
}