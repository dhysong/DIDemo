using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityDemoLibrary3
{
    public class FavoritesModel
    {
        private string[] testFavoriteIdList;

        public List<Favorite> Favorites { get; set; }

        public FavoritesModel(IFavoritesService favoritesService, string[] testFavoriteIdList)
        {
            this.Favorites = favoritesService.getFavorites(testFavoriteIdList);
        }

    }
}
