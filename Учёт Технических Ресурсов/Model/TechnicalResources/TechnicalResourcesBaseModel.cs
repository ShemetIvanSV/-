using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Учёт_Технических_Ресурсов.Model
{
    abstract class TechnicalResourcesBaseModel : INotifyPropertyChanged
    {
        private int id;
        private int price;
        private DateTime dateOfRecept = DateTime.Now;
        private bool isUsed;
        private string description;
        private string location;
        private string title;

        public virtual int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }

        public int Price
        {
            get => price;
            set
            {
                price = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateOfRecept
        {
            get => dateOfRecept;
            set
            {
                dateOfRecept = value;
                OnPropertyChanged();
            }
        }

        public bool IsUsed
        {
            get => isUsed;
            set
            {  
                isUsed = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged();
            }
        }

        [Required]
        public string Location
        {
            get => location;
            set
            {
                location = value;
                OnPropertyChanged();
            }
        }

        [Required]
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
