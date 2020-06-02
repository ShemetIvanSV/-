using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreatePrinter : AddTechnical
    {
        public override void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            var printer = new Printer()
            {
                ComputerId = (int)computerId,
                Description = model.Description,
                DocumentPath = model.DocumentPath,
                PicturePath = model.PicturePath,
                Id = model.Id,
                IsUsed = model.IsUsed,
                Price = model.Price,
                Title = model.Title
            };
            using (TechnicalResourcesContext context = new TechnicalResourcesContext())
            {
                context.Printers.Add(printer);
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return "Создать Принтер";
        }
    }

}
