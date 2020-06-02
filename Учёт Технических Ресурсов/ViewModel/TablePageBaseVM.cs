using System.Collections.ObjectModel;
using System.Data.Entity.Infrastructure;
using Учёт_Технических_Ресурсов.DialogService;
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
            DocumentDialogService = new DocumentDialogService();
            SelectedEquipment = new T();
            EquipmentsView = new ObservableCollection<T>();
            EqipmentRepository = new R();
            EquipmentsReturn();
        }

        protected DocumentDialogService DocumentDialogService { get; }

        private IEquipmentRepository<T> EqipmentRepository { get; }

        public ObservableCollection<T> EquipmentsView { get; }

        public T SelectedEquipment
        {
            get => selectedEquipment;
            set
            {
                selectedEquipment = value;
                OnPropertyChanged();
            }
        }

        private void EquipmentsReturn()
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
                DocumentDialogService.ShowMessage("Элемент не найден");
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
                DocumentDialogService.ShowMessage("Элемент не найден");
            }
        }
    }
}