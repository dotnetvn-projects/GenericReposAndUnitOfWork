using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Demo.Models;
using Demo.Repositories;
using Demo.DataContext;

namespace Demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UnitOfWork _unitOfWork; 

        public HomeController(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult News()
        {
            NewsSampleData();
            var data = _unitOfWork.NewsRepository.GetAll();
            return View(data);
        }

        public IActionResult Product()
        {
            ProductSampleData();
            var data = _unitOfWork.ProductRepository.GetAll();
            return View(data);
        }

        private void NewsSampleData()
        {
            var lastItem = _unitOfWork.NewsRepository.DbSet.LastOrDefault();
            int count = 1;
            if (lastItem != null)
                count = lastItem.Id + 1;

            for (int i = count; i < (count + 10); i++)
            {
                var n = new News
                {
                    CreatedDate = DateTime.Now,
                    Content = $"I am the content {i}",
                    Title = $"Title {i}"
                };
                _unitOfWork.NewsRepository.Add(n);
            }
            _unitOfWork.SaveChanges();
        }


        private void ProductSampleData()
        {
            var lastItem = _unitOfWork.ProductRepository.DbSet.LastOrDefault();
            int count = 1;
            if (lastItem != null)
                count = lastItem.Id + 1;

            for (int i = count; i < (count + 10); i++)
            {
                var p = new Product
                {
                    CreatedDate = DateTime.Now,
                    Name = $"Product {i}",
                    Price = new Random().Next(20000, 100000),
                    Sku = $"Sku {i}"
                };
                _unitOfWork.ProductRepository.Add(p);
            }

            _unitOfWork.SaveChanges();
        }


        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
