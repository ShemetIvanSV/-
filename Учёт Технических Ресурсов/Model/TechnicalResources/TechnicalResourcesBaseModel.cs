using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Учёт_Технических_Ресурсов.Model
{
    public class TechnicalResourcesBaseModel : INotifyPropertyChanged
    {
        private DateTime dateOfCreate = DateTime.Now.Date;
        private string description;
        private string document;
        private string picture;
        private int id;
        private bool isUsed;
        private int price;
        private string title;

        public int Id
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

        public DateTime DateOfCreate
        {
            get => dateOfCreate;
            set
            {
                dateOfCreate = value;
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
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged();
            }
        }

        public string DocumentPath
        {
            get => document;
            set
            {
                document = value;
                OnPropertyChanged();
            }
        }

        public string PicturePath
        {
            get => picture;
            set
            {
                picture = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return Title;
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}