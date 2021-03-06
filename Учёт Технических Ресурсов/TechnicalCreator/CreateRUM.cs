﻿using Учёт_Технических_Ресурсов.Model;
using Учёт_Технических_Ресурсов.Model.EquipmentModel;

namespace Учёт_Технических_Ресурсов
{
    class CreateRUM : AddTechnical
    {

        public override void CreateTechnical(TechnicalResourcesBaseModel model, int? computerId)
        {
            var RUM = new RUM()
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
                context.RUMs.Add(RUM);
                context.SaveChanges();
            }
        }

        public override string ToString()
        {
            return "Создать Оперативную память";
        }
    }
}
