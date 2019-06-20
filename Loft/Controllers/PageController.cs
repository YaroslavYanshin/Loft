using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuissnesLayer;
using PresentationLayer;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;
using static DataLayer.Enums.PageEnums;

namespace Loft.Controllers
{
    
    public class PageController : Controller
    {
        private DataManager _dataManager;
        private ServicesManager _servicesManager;

        public PageController(DataManager dataManager)
        {
            _dataManager = dataManager;
            _servicesManager = new ServicesManager(dataManager);
        }
        public IActionResult Index(int pageId, PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageType.Directory: _viewModel = _servicesManager.Directorys.DirectoryDBToViewModelById(pageId); break;
                case PageType.Material: _viewModel = _servicesManager.Materials.MaterialDBModelToView(pageId); break;
                default: _viewModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        
        public IActionResult PageEditor(int pageId, PageType pageType, int directoryId =0)
        {
            PageEditModel _editModel;
            switch (pageType)
            {
                case PageType.Directory:
                    if (pageId != 0) _editModel = _servicesManager.Directorys.GetDirectoryEdetModel(pageId);
                    else _editModel = _servicesManager.Directorys.CreateNewDirectoryEditModel();
                    break;
                case PageType.Material:
                    if (pageId != 0) _editModel = _servicesManager.Materials.GetMaterialEdetModel(pageId);
                    else _editModel = _servicesManager.Materials.CreateNewMaterialEditModel(directoryId);
                    break;
                default: _editModel = null; break;
            }
            ViewBag.PageType = pageType;
            return View(_editModel);
        }
    }
}