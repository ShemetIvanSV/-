﻿using System.ComponentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    public enum TypeMatrix
    {
        IPS,
        PLS,
        TNF,
        OLED
    }

    public class Monitor : TechnicalResourcesBaseModel
    {
        private Computer computer;
        private int? computerId;
        private TypeMatrix matrix;

        public int? ComputerId
        {
            get => computerId;
            set
            {
                computerId = value;
                OnPropertyChanged();
            }
        }

        public TypeMatrix Matrix
        {
            get => matrix;
            set
            {
                matrix = value;
                OnPropertyChanged();
            }
        }

        public Computer Computer
        {
            get => computer;
            set
            {
                computer = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Title;
        }
    }
}