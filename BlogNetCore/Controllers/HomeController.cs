using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BlogNetCore.Models;
using DataLayer.Entityes;
using BusinessLayer;
using PresentationLayer;

namespace BlogNetCore.Controllers
{
    public class HomeController : Controller
    {
        //first case about work with context db
        //private EFDBContext _contex;

        //second case about work with context db
        //private IDirectorysRepository _dirRep;

        //third case about work with context db
        private DataManager _dataManager;

        private ServicesManager _servicesManager;
        public HomeController(/*EFDBContext contex, IDirectorysRepository dirRep,*/ DataManager dataManager)
        {
           /* _contex = contex;
            _dirRep = dirRep;*/
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(_dataManager);
        }

        public IActionResult Index()
        {
            HelloModel _model = new HelloModel() { HelloMessage = "Kostiantyn" };

            //first case about work with context db
            //List<Directory> _dirs = _contex.Directory.Include(d => d.Materials).ToList();

            //second case about work with context db
            //List<Directory> _dirs = _dirRep.GetAllDirectorys().ToList();

            //third case about work with context db
            List<Directory> _dirs = _dataManager.Directorys.GetAllDirectorys(true).ToList();
            return View(_dirs);
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
