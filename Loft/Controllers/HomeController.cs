using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Loft.Models;
using DataLayer;
using DataLayer.Entityes;
using Microsoft.EntityFrameworkCore;
using BuissnesLayer.Interfaces;
using BuissnesLayer;
using PresentationLayer;
using PresentationLayer.Models;

namespace Loft.Controllers
{
    public class HomeController : Controller
    {
        //private EFDBContext _context;
        //private IDirectorysRepository _dirRep;
        private DataManager _datamanager;
        private ServicesManager _servicesmanager;

        public HomeController (/*EFDBContext context, IDirectorysRepository dirRep,*/ DataManager dataManager)
        {
            //_context = context;
            //dirRep = _dirRep;
            _datamanager = dataManager;
            _servicesmanager = new ServicesManager(_datamanager);
        }

        public IActionResult Index()
        {
            //List<Directory> _dirs = _datamanager.Directorys.GetAllDirectorys(true).ToList();
            // List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList();
            // List<Directory> _dirs = _context.Directory.Include(x=>x.Materials).ToList();
            List<DirectoryViewModel> _dirs = _servicesmanager.Directorys.GetDirectoryesList();
            return View(_dirs);
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
