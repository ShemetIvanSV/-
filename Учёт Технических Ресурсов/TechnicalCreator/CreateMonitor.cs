using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов.TechnicalCreator
{
    class CreateMonitor : AddTechnical
    {

        public override void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            var monitor = new Monitor()
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
                context.Monitors.Add(monitor);
                context.SaveChanges();
            }
        }
        public override string ToString()
        {
            return "Создать Монитор";
        }
    }
}
