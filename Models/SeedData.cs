using Azure.Core;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.Differencing;
using Microsoft.EntityFrameworkCore;
using MvcRentApp.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MvcRentApp.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RentContext(serviceProvider.GetRequiredService<DbContextOptions<RentContext>>()))
            {
                if (context == null || context.Offices == null)
                {
                    throw new ArgumentNullException("Null RentContext");
                }
                // Если в базе данных уже есть офисы,
                // то возвращается инициализатор заполнения и офисы не добавляются
                if (context.Offices.Any())
                {
                    return;
                }
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "8 Марта, д.34",
                    BuisnessCenterFloor = 1,
                    OfficeNumber = "3а(8Марта34)",
                    OfficeSquare = 21.6,
                    RentalRate = 1200,
                    OfficeState = "Свободно",
                    OfficeLayout = "3а_8Марта.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "8 Марта, д.34",
                    BuisnessCenterFloor = 2,
                    OfficeNumber = "3б(8Марта34)",
                    OfficeSquare = 12.1,
                    RentalRate = 1000,
                    OfficeState = "Свободно",
                    OfficeLayout = "3б_8Марта.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "8 Марта, д.34",
                    BuisnessCenterFloor = 3,
                    OfficeNumber = "3в(8Марта34)",
                    OfficeSquare = 18.0,
                    RentalRate = 1000,
                    OfficeState = "Свободно",
                    OfficeLayout = "3в_8Марта.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "8 Марта, д.34",
                    BuisnessCenterFloor = 4,
                    OfficeNumber = "3г(8Марта34)",
                    OfficeSquare = 24.5,
                    RentalRate = 1000,
                    OfficeState = "Свободно",
                    OfficeLayout = "3г_8Марта.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "8 Марта, д.34",
                    BuisnessCenterFloor = 5,
                    OfficeNumber = "3д(8Марта34)",
                    OfficeSquare = 14.1,
                    RentalRate = 1000,
                    OfficeState = "Свободно",
                    OfficeLayout = "3д_8Марта.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "Трамвайная, д.4А",
                    BuisnessCenterFloor = 1,
                    OfficeNumber = "2(Трамвайная)",
                    OfficeSquare = 22.7,
                    RentalRate = 1000,
                    OfficeState = "Свободно",
                    OfficeLayout = "2_Трамвайная.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "Трамвайная, д.4А",
                    BuisnessCenterFloor = 2,
                    OfficeNumber = "3(Трамвайная)",
                    OfficeSquare = 19.5,
                    RentalRate = 900,
                    OfficeState = "Свободно",
                    OfficeLayout = "3_Трамвайная.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "Трамвайная, д.4А",
                    BuisnessCenterFloor = 3,
                    OfficeNumber = "5(Трамвайная)",
                    OfficeSquare = 15.9,
                    RentalRate = 900,
                    OfficeState = "Свободно",
                    OfficeLayout = "5_Трамвайная.jpg"
                });
                context.Offices.Add(new Office
                {
                    BuisnessCenterAdress = "бульвар Хадии Давлетшиной, д.18/3",
                    BuisnessCenterFloor = 1,
                    OfficeNumber = "4(Х.Давлетшиной18/3)",
                    OfficeSquare = 16.0,
                    RentalRate = 1100,
                    OfficeState = "Свободно",
                    OfficeLayout = "4_ХД18.jpg"
                });
                context.SaveChanges();
            }
        }
    }
}
