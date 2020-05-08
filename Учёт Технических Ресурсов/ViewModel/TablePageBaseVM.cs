using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using Учёт_Технических_Ресурсов.DialogService;
using Учёт_Технических_Ресурсов.EnumService;
using Учёт_Технических_Ресурсов.EquipmentDbRepository;
using Учёт_Технических_Ресурсов.Model;

namespace Учёт_Технических_Ресурсов.ViewModel
{
    public abstract class TablePageBaseVM<T, R> : BaseViewModel
        where T : TechnicalResourcesBaseModel, new()
        where R : IEquipmentRepository<T>, new()
    {
        private T selectedEquipment;

        protected TablePageBaseVM()
        {
            DefaultDialogService = new DefaultDialogService();
            SelectedEquipment = new T();
            EquipmentsView = new ObservableCollection<T>();
            EqipmentRepository = new R();
            EquipmentsReturn();
        }

        protected DefaultDialogService DefaultDialogService { get; set; }

        protected IEquipmentRepository<T> EqipmentRepository { get; set; }

        public ObservableCollection<T> EquipmentsView { get; set; }

        public T SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanged();
            }
        }

        protected void EquipmentsReturn()
        {
            EquipmentsView.Clear();
            var equipments = EqipmentRepository.Return();
            foreach (var equipment in equipments) EquipmentsView.Add(equipment);
        }

        protected void EquipmentsSaveChange()
        {
            try
            {
                EqipmentRepository.SaveChange(EquipmentsView);
                EquipmentsReturn();
            }

            catch (DbUpdateConcurrencyException)
            {
                DefaultDialogService.ShowMessage("Элемент не найден");
            }
        }

        protected void EquipmentsRemove()
        {
            try
            {
                EqipmentRepository.Remove(SelectedEquipment);
                EquipmentsReturn();
            }

            catch (DbUpdateConcurrencyException)
            {
                DefaultDialogService.ShowMessage("Элемент не найден");
            }
        }
    }
}