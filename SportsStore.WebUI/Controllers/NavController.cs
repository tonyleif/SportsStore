using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;

namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        //private IProductRepository repository;

        //public NavController(IProductRepository repo)
        //{
        //    repository = repo;
        //}
        public string Menu()
        {
            return "Hello from NavController";
        }
    }
}