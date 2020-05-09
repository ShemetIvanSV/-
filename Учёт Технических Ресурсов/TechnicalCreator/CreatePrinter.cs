using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreatePrinter : AddTechnical
    {
        public CreatePrinter(TechnicalResourcesBaseModel ResourcesBaseModel, int? computerId)
       : base(ResourcesBaseModel, computerId)
        {
            Printer = new Printer()
            {
                PicturePath = this.PicturePath,
                DocumentPath = this.DocumentPath,
                ComputerId = (int)computerId,
                Price = this.Price,
                IsUsed = this.IsUsed,
                Description = this.Description,
                Title = this.Title
            };
        }

        public Printer Printer { get; set; }

        public override TechnicalResourcesBaseModel CreateTechnical()
        {
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.Printers.Add(Printer);
                context.SaveChanges();
                return Printer;
            }
        }
    }
}
