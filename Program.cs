using ProductManagerTenta1.Data;
using ProductManagerTenta1.Models;
using System;
using System.Linq;
using System.Threading;
using static System.Console;

namespace ProductManagerTenta1
{
    class Program
    {
        static ProductManagerContext context = new ProductManagerContext();
        static void Main(string[] args)
        {
            CursorVisible = false;

            bool applicationRunning = true;

            do
            {
                WriteLine("1. Categories");
                WriteLine("2. Articles");
                WriteLine("3. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        Category_Menu();

                        break;

                    case ConsoleKey.D2:

                        Article_Menu();

                        break;

                    case ConsoleKey.D3:

                        applicationRunning = false;

                        break;
                }

            } while (applicationRunning);

        }
        private static void Category_Menu()
        {
            bool exit = true;
            Clear();
            do
            {
                WriteLine("1. Add category");
                WriteLine("2. List categories");
                WriteLine("3. Add product to category");
                WriteLine("4. Add category to category");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();


                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddCategory();

                        break;

                    case ConsoleKey.D2:

                        Listcategories();

                        break;

                    case ConsoleKey.D3:

                        AddArticleToCategory();

                        break;
                    case ConsoleKey.D4:

                        AddCategoryToCategory();

                        break;

                    case ConsoleKey.Escape:

                        exit = false;
                        break;

                }

            } while (exit);
        }
        private static void AddCategoryToCategory()
        {
            WriteLine("Parent Category ID:");
            WriteLine("Child Category ID: ");

            SetCursorPosition(20, 0);
            int parentCategoryId = Convert.ToInt32(ReadLine());

            SetCursorPosition(19, 1);
            int childCategoryId = Convert.ToInt32(ReadLine());

            Clear();

            var parentId = context.Categories.FirstOrDefault(x => x.Id == parentCategoryId);
            var childId = context.Categories.FirstOrDefault(x => x.Id == childCategoryId);

            parentId.Categories.Add(childId);
            context.SaveChanges();

            WriteLine("Category added to category");
            Thread.Sleep(2000);
            Clear();


        }
        private static void AddArticleToCategory()
        {
            var categoryList = context.Categories.Select(x => new { x.Id, x.CategoryName, x.Articles }).ToList();

            WriteLine($"{"ID",-25} {"Category",-25} {"Total products",-25}");
            WriteLine("--------------------------------------------------------------------------------------");

            foreach (var categories in categoryList)
            {
                Console.WriteLine($"{categories.Id,-25} {categories.CategoryName,-25}  {categories.Articles.Count,-25}");
            }

            WriteLine(" ");
            Write("Selected  ID> ");

            int categoryId = Convert.ToInt32(ReadLine());

            Clear();

            foreach (var Category in categoryList)
            {
                if (categoryId == Category.Id)
                {


                    Clear();
                    WriteLine($@"{"Name:"} {Category.CategoryName}");
                }
            }
            WriteLine("");
            WriteLine("[A] Add product");

            var input = ReadKey(true).Key;

            var isIncorrectInput = (input != ConsoleKey.A);
            while (isIncorrectInput)
            {

            }
            if (input == ConsoleKey.A)
            {
                Clear();

                WriteLine("Search product:");
                SetCursorPosition(16, 0);
                string searchProduct = ReadLine();
                Clear();

                var articleList = context.Articles.Select(x => new { x.Id, x.Name })
                     .Where(x => x.Name.Contains(searchProduct)).ToList();

                if (searchProduct != null)
                {
                    WriteLine($"{"ID",-25} {"Name",-25}              ");
                    WriteLine("-----------------------------------------------------------------");

                    foreach (var articles in articleList)
                    {

                        Console.WriteLine($" {articles.Id,-25} {articles.Name,-25} ");
                    }
                }

                WriteLine("");
                Write("Product  ID> ");

                int selectProductId = Convert.ToInt32(ReadLine());
                Clear();
                if (selectProductId != 0)
                {
                    var category = context.Categories.FirstOrDefault(x => x.Id == categoryId);
                    var article = context.Articles.FirstOrDefault(x => x.Id == selectProductId);

                    category.Articles.Add(article);
                    context.SaveChanges();

                    Write("Product added to category");
                    Thread.Sleep(2000);
                    Clear();
                }
            }
        }
        private static void Listcategories()
        {
            var categoryList = context.Categories.Select(x => new { x.CategoryName, x.Articles }).ToList();

            WriteLine($"{"Category",-25} {"Total products",-25}");
            WriteLine("--------------------------------------------------------------------------------------");

            foreach (var categories in categoryList)
            {
                Console.WriteLine($"{categories.CategoryName,-25}  {categories.Articles.Count,-25}");
            }


            var isCorrectInput = ReadKey(true).Key;

            while (isCorrectInput != ConsoleKey.Escape)
            {
                isCorrectInput = ReadKey(true).Key;
            }
            if (isCorrectInput == ConsoleKey.Escape)
            {

            }
            Clear();
        }
        private static void AddCategory()
        {
            Write("Name:");
            SetCursorPosition(6, 0);
            string name = ReadLine();

            WriteLine("  ");
            Write("Is this correct? (Y)es (N)o");

            var isCorrectInput = ReadKey(true).Key;

            while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
            {
                isCorrectInput = ReadKey(true).Key;
            }
            if (isCorrectInput == ConsoleKey.Y)
            {
                var category = new Category();

                if (category.CategoryName == name)
                {
                    Clear();
                    WriteLine("Category already exists");
                    Thread.Sleep(2000);

                }
                else
                {
                    Clear();

                    var categories = new Category(name);

                    SaveCategory(categories);
                    WriteLine("Category added");

                    Thread.Sleep(2000);
                    Clear();
                }
            }
        }
        private static void SaveCategory(Category category)
        {
            context.Categories.Add(category);
            context.SaveChanges();

        }
      
        private static void Article_Menu()
        {
            CursorVisible = false;

            bool appliationRunning = true;

            do
            {
                WriteLine("1. Add article");
                WriteLine("2. Search article");
                WriteLine("3. Exit");

                ConsoleKeyInfo input = ReadKey(true);

                Clear();

                switch (input.Key)
                {
                    case ConsoleKey.D1:

                        AddArticle();

                        break;

                    case ConsoleKey.D2:


                        SearchArticle();

                        break;

                    case ConsoleKey.D3:

                        appliationRunning = false;

                        break;
                }

                Clear();

            } while (appliationRunning);
        }
        private static void EditArticle(Article article)
        {

            CursorVisible = true;
            Clear();
            WriteLine("Article number: ");
            WriteLine("Name: ");
            WriteLine("Description: ");
            WriteLine("Price: ");

            SetCursorPosition(36, 0);
            Write($"{article.ArticleNumber}");

            SetCursorPosition(36, 1);
            var name = ReadLine();

            SetCursorPosition(36, 2);
            var description = ReadLine();

            SetCursorPosition(36, 3);
            var price = Convert.ToDecimal(ReadLine());

            CursorVisible = false;

            WriteLine("Is this correct? (Y)es (N)o ");
            var isCorrectInput = ReadKey(true).Key;

            while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
            {
                isCorrectInput = ReadKey(true).Key;
            }
            if (isCorrectInput == ConsoleKey.Y)
            {
                Clear();
               
                UppdateArticle(article, name, description, price);
                WriteLine("Article saved");
                Thread.Sleep(2000);

            }

        }
        private static void UppdateArticle(Article article, string name, string description, decimal price)
        {
            var articles = context.Articles.SingleOrDefault(a => a.ArticleNumber == article.ArticleNumber);

            articles.Name = name;
            articles.Description = description;
            articles.Price = price;
            context.SaveChanges();
        }
        private static void RemoveArticle(Article article)
        {
            CursorVisible = false;
            WriteLine("  ");
            WriteLine("  ");
            WriteLine("Delete this article ? (Y)es(N)o");

            var input = ReadKey(true).Key;

            var isIncorrectInput = (input != ConsoleKey.Y && input != ConsoleKey.N);
            while (isIncorrectInput)
            {

            }
            if (input == ConsoleKey.Y)
            {

                DeleteArticle(article);

                Clear();
                WriteLine("Articles Deleted");
                Thread.Sleep(2000);
                Clear();
            }
        }
        private static void DeleteArticle(Article article)
        {
            context.Articles.Remove(article);
            context.SaveChanges();
        }
        private static void SearchArticle()
        {
            Write("Article number: ");

            string articleNumber = ReadLine();

            Clear();
            var article = FindArticle(articleNumber);

            if (article != null)
            {
                WriteLine($"{"Article number:",-25}" + article.ArticleNumber);
                WriteLine($"{"Name:",-25}" + article.Name);
                WriteLine($"{"Description:",-25}" + article.Description);
                WriteLine($"{"Price:",-25}" + article.Price);

                WriteLine("   ");
                WriteLine(" [E] Edit   [D] Delete   [Esc] Main menu ");

                ConsoleKeyInfo input = ReadKey(true);

                CursorVisible = true;
                switch (input.Key)
                {
                    case ConsoleKey.E:

                        EditArticle(article);

                        break;

                    case ConsoleKey.D:
                        RemoveArticle(article);
                        break;

                    case ConsoleKey.Escape:


                        break;
                }
            }
            else
            {
                WriteLine("Article not found");
                Thread.Sleep(2000);
            }
            Clear();
        }
        private static Article FindArticle(string articleNumber)
        => context.Articles.FirstOrDefault(x => x.ArticleNumber == articleNumber);
        private static void AddArticle()
        {

            bool correctInput = false;
            do
            {
                Clear();
                CursorVisible = true;

                WriteLine("Article number:  ");
                WriteLine("Name: ");
                WriteLine("Description: ");
                WriteLine("Price: ");

                SetCursorPosition(36, 0);
                var articleNumber = ReadLine();

                SetCursorPosition(36, 1);
                var name = ReadLine();

                SetCursorPosition(36, 2);
                var description = ReadLine();

                SetCursorPosition(36, 3);
                var price = Convert.ToDecimal(ReadLine());

                CursorVisible = false;

                WriteLine("Is this correct? (Y)es (N)o ");

                var isCorrectInput = ReadKey(true).Key;

                while (isCorrectInput != ConsoleKey.Y && isCorrectInput != ConsoleKey.N)
                {
                    isCorrectInput = ReadKey(true).Key;
                }
                if (isCorrectInput == ConsoleKey.Y)
                {
                    var article = new Article(articleNumber, name, description, price);

                    if (article.ArticleNumber == articleNumber)
                    {
                        Clear();


                        SaveArticle(article);

                        WriteLine("Article saved");
                        Thread.Sleep(2000);
                        break;


                    }
                    else if (article.ArticleNumber != articleNumber)
                    {
                        Clear();

                        WriteLine("Article already exists");
                        Thread.Sleep(2000);
                        break;

                    }

                }

                else if (isCorrectInput == ConsoleKey.N)
                {
                    correctInput = true;
                }

            }
            while (correctInput);
        }
        private static void SaveArticle(Article article)
        {
            context.Articles.Add(article);
            context.SaveChanges();
        }

    }
}
