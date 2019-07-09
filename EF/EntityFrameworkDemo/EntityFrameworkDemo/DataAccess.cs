using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityFrameworkDemo
{
    /// <summary>
    /// Vitsen med att ha en separat klass för att hantera allt som har med dataåtkomst
    /// att göra är att göra en applikation mer renodlad. Om man ständigt strävar efter 
    /// att hålla isär data och presentation så kommer man att tacka sig själv i det 
    /// långa loppet.
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Genom att ha en privat klassvariabel som är readonly så gör man det möjligt
        /// att sätta ett värde för klassvariabeln när konstruktorn anropas. Det är bara 
        /// i konstruktorn som det är möjligt att instasifiera klassvariabler som är märkta
        /// med readonly.
        /// </summary>
        private readonly FruitContext _fruitContext;

        public DataAccess()
        {
            // Skapa en instans av FruitContext som används för att prata med Entity Framework.
            _fruitContext = new FruitContext();
        }

        /// <summary>
        /// Denna metod returnerar alla frukter som finns i databasen.
        /// </summary>
        /// <returns>En lista av frukter.</returns>
        public List<Fruit> GetAllFruits()
        {
            var fruits =
            _fruitContext.Fruits
                .Include(x => x.Color)
                .Include(x => x.Category)
                .ToList();

            return fruits;
        }

        /// <summary>
        /// Denna metod returnerar alla frukter som är kopplade till en viss kategori.
        /// </summary>
        /// <param name="categoryString">Namn på kategorin</param>
        /// <returns>En lista av frukter.</returns>
        public List<Fruit> GetAllFruitsBasedOnCategory(string categoryString)
        {
            var fruitsInCategory =
            _fruitContext.Fruits
                .Include(x => x.Color)
                .Include(x => x.Category)
                .Where(x => x.Category.Name.Equals(
                    categoryString,
                    StringComparison.CurrentCultureIgnoreCase))
                .ToList();

            return fruitsInCategory;
        }

        /// <summary>
        /// Denna metod nollställer databasen, dvs DROP och sedan CREATE, och 
        /// populerar sedan databasen med nya fräscha pinfärska värden.
        /// </summary>
        public void ClearAndInitDatabase()
        {
            //_fruitContext.Database.EnsureDeleted();
            //_fruitContext.Database.EnsureCreated();

            _fruitContext.FruitColors.Add(new FruitColor { Name = "Röd" });
            _fruitContext.FruitColors.Add(new FruitColor { Name = "Gul" });
            _fruitContext.FruitColors.Add(new FruitColor { Name = "Orange" });
            _fruitContext.FruitColors.Add(new FruitColor { Name = "Blå" });
            _fruitContext.FruitColors.Add(new FruitColor { Name = "Svart" });

            _fruitContext.SaveChanges();

            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Kärnfrukt" });
            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Stenfrukt" });
            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Citrus" });
            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Melon" });
            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Bär" });
            _fruitContext.FruitCategories.Add(new FruitCategory { Name = "Grönsak" });

            _fruitContext.SaveChanges();

            // ------------------

            AddFruit("Äpple", "Röd", "Kärnfrukt");
            //Fruit fruit = new Fruit
            //{
            //    Name = "Äpple",
            //    Color = GetOrCreateFruitColor(_fruitContext, "Röd"),
            //    Category = GetOrCreateFruitCategory(_fruitContext, "Kärnfrukt"),
            //};
            //_fruitContext.Fruits.Add(fruit);

            AddFruit("Banan", "Gul", "Bär");
            //_fruitContext.Fruits.Add(
            //new Fruit
            //{
            //    Name = "Banan",
            //    Color = GetOrCreateFruitColor(_fruitContext, "Gul"), // new FruitColor { Name = "Gul" },
            //    Category = GetOrCreateFruitCategory(_fruitContext, "Bär"),
            //});

            AddFruit("Honungsmelon", "Gul", "Melon");
            //_fruitContext.Fruits.Add(
            //new Fruit
            //{
            //    Name = "Honungsmelon",
            //    Color = GetOrCreateFruitColor(_fruitContext, "Gul"), // new FruitColor { Name = "Gul" },
            //    Category = GetOrCreateFruitCategory(_fruitContext, "Melon"),
            //});

            AddFruit("Apelsin", "Orange", "Kärnfrukt");
            //_fruitContext.Fruits.Add(
            //new Fruit
            //{
            //    Name = "Apelsin",
            //    Color = GetOrCreateFruitColor(_fruitContext, "Orange"),
            //    Category = GetOrCreateFruitCategory(_fruitContext, "Kärnfrukt"),
            //});

            AddFruit("Aubergine", "Lila", "Grönsak");

            _fruitContext.SaveChanges();
        }

        /// <summary>
        /// Denna metod förenklar skapandet av nya frukter i databasen.
        /// Metoden slår upp värdena som skall läggas till för att se om de redan
        /// har lagts till i databasen. Om värdena saknas så läggs de till i listan
        /// som sedan kommer att sparas i samband med att metoden SaveChanges anropas
        /// i Entity Framework.
        /// </summary>
        /// <param name="fruitName">Namn på frukten.</param>
        /// <param name="color">Namn på färgen.</param>
        /// <param name="category">Namn på fruktkategorin.</param>
        private void AddFruit(string fruitName, string color, string category)
        {
            _fruitContext.Fruits.Add(
            new Fruit
            {
                Name = fruitName,
                Color = GetOrCreateAttribute<FruitColor>(_fruitContext.FruitColors, color),
                Category = GetOrCreateAttribute<FruitCategory>(_fruitContext.FruitCategories, category) 
            });
        }

        /// <summary>
        /// Denna metod ersätter de två metoderna nedan och förenklar uppslag av 
        /// redan befintliga värden för t.ex. FruitCategory och FruitColor.
        /// Metoden är ett exempel på hur man kan använda generics för att förenkla 
        /// kodbasen och för att ta bort onödig kod.
        /// </summary>
        /// <typeparam name="T">Den typ som skall läggas till, exempelvis typeof(FruitColor).</typeparam>
        /// <param name="entities">Listan över redan befintliga värden/poster.</param>
        /// <param name="inputString">Värdet som skall läggas till.</param>
        /// <returns></returns>
        private T GetOrCreateAttribute<T>(
            DbSet<T> entities,
            string inputString)
                where T : FruitEntityBase
        {
            T fruitAttribute = (T)entities.FirstOrDefault(x => x.Name.Equals(
                inputString,
                StringComparison.CurrentCultureIgnoreCase));

            if (fruitAttribute == null)
            {
                fruitAttribute = (T)Activator.CreateInstance(typeof(T));
                fruitAttribute.Name = inputString;
                entities.Add(fruitAttribute);
            }
            return fruitAttribute;
        }

        //private static FruitColor GetOrCreateFruitColor(
        //FruitContext fruitContext,
        //string fruitColorString)
        //{
        //    FruitColor fruitColor =
        //    fruitContext.FruitColors
        //    .FirstOrDefault(a => a.Name.Equals(
        //    fruitColorString,
        //    StringComparison.CurrentCultureIgnoreCase));

        //    if (fruitColor == null)
        //    {
        //        fruitColor = new FruitColor
        //        {
        //            Name = fruitColorString
        //        };
        //        fruitContext.FruitColors.Add(fruitColor);
        //    }

        //    return fruitColor;
        //}

        //private static FruitCategory GetOrCreateFruitCategory(
        //FruitContext fruitContext,
        //string fruitCategoryString)
        //{
        //    FruitCategory fruitCategory =
        //    fruitContext.FruitCategories
        //    .FirstOrDefault(a => a.Name.Equals(
        //    fruitCategoryString,
        //    StringComparison.CurrentCultureIgnoreCase));

        //    if (fruitCategory == null)
        //    {
        //        fruitCategory = new FruitCategory
        //        {
        //            Name = fruitCategoryString
        //        };
        //        fruitContext.FruitCategories.Add(fruitCategory);
        //    }

        //    return fruitCategory;
        //}
    }
}
