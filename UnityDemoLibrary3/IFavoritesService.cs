using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnityDemoLibrary3
{
    public interface IFavoritesService
    {
        List<Favorite> getFavorites(string[] favoriteIdList);
    }
}
