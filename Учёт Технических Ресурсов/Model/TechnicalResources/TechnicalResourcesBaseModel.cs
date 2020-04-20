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
                OnPropertyChanged("Id");
                id = value;
            }
        }
        public int Price
        {
            get => price;
            set
            {
                OnPropertyChanged("Price");
                price = value;
            }
        }
        public DateTime DateOfRecept
        {
            get => dateOfRecept;
            set
            {
                OnPropertyChanged("DateOfRecept");
                dateOfRecept = value;
            }
        }
        public bool IsUsed
        {
            get => isUsed;
            set
            {
                OnPropertyChanged("IsUsed");
                isUsed = value;
            }
        }

        public string Description
        {
            get => description;
            set
            {
                OnPropertyChanged("Description");
                description = value;
            }
        }

        [Required]
        public string Location
        {
            get => location;
            set
            {
                OnPropertyChanged("Location");
                location = value;
            }
        }

        [Required]
        public string Title
        {
            get => title;
            set
            {
                OnPropertyChanged("Title");
                title = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
