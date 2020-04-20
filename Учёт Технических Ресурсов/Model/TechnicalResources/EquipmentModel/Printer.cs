namespace Учёт_Технических_Ресурсов.Model.EquipmentModel
{
    public enum PrintingTechnology
    {
        matrix, inkjet, laser
    }
    class Printer : TechnicalResourcesBaseModel
    {
        private PrintingTechnology printingTechnology;
        private int numberOfColors;

        public PrintingTechnology PrintingTechnology
        {
            get { return printingTechnology; }
            set
            {
                OnPropertyChanged("PrintingTechnology");
                printingTechnology = value;
            }
        }

        public int NumberOfColors
        {
            get { return numberOfColors; }
            set
            {
                OnPropertyChanged("NumberOfColors");
                numberOfColors = value;
            }
        }

    }
}
