using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UnityDemoLibrary3;

namespace UnityDemo3.Controllers
{
    public class FavoritesController : Controller
    {
        private IFavoritesService favoritesService { get; set; }

        public FavoritesController(IFavoritesService favoritesService)
        {
            this.favoritesService = favoritesService;
        }
        //
        // GET: /Favorites/Details?idList=1234,1235

        public ActionResult Details(string idList)
        {
            FavoritesModel favoritesModel = new FavoritesModel(favoritesService, idList.Split(','));
            return View();
        }

    }
}
