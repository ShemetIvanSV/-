using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;
using Учёт_Технических_Ресурсов.Model.TechnicalResources.ProgramsModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateApp:AddTechnical
    {

        public override void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            var applicationProgram = new ApplicationProgram()
            {
                ComputerId = computerId,
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
                context.ApplicationPrograms.Add(applicationProgram);
                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return "Создать ПО";
        }
    }
}
