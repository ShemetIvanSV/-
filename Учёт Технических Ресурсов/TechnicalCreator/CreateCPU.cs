using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateCPU : AddTechnical
    {

        public override void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            var CPU = new CPU()
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
                context.CPUs.Add(CPU);
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return "Создать CPU";
        }
    }
}
