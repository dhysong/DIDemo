using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnityDemoLibrary3;

namespace UnityDemoTest3
{
    [TestClass]
    public class FavoritesModelTest
    {
        private string[] testFavoriteIdList;

        private Mock<IFavoritesService> mockService;
        private IFavoritesService favoritesService;

        [TestInitialize]
        public void Setup()
        {
            testFavoriteIdList = new string[] { "1234", "1235", "1236" };
            mockService = new Mock<IFavoritesService>();
        }

        private List<Favorite> getFavorites(string[] favoritesIdList)
        {
            List<Favorite> favorites = new List<Favorite>();
            for (int i = 0; i < favoritesIdList.Length; i++)
            {
                favorites.Add(new Favorite() { Id = favoritesIdList[i] });
            }
            return favorites;
        }

        [TestMethod]
        public void Favorites_EmptyStringParameter_ReturnsEmptyFavoritesList()
        {
            testFavoriteIdList = new string[] { "" };

            mockService.Setup(fp => fp.getFavorites(testFavoriteIdList)).Returns(getFavorites(testFavoriteIdList));
            favoritesService = mockService.Object;

            FavoritesModel favoritesModel = new FavoritesModel(favoritesService, testFavoriteIdList);
            List<Favorite> favoritesList = favoritesModel.Favorites;
            Assert.IsNotNull(favoritesList);
        }

        [TestMethod]
        public void Favorites_TestIdListInput_ReturnsFavoritesListWithSameCountAsInput()
        {
                       
            mockService.Setup(fp => fp.getFavorites(testFavoriteIdList)).Returns(getFavorites(testFavoriteIdList));
            favoritesService = mockService.Object;
            
            FavoritesModel favoritesModel = new FavoritesModel(favoritesService, testFavoriteIdList);
            List<Favorite> favoritesList = favoritesModel.Favorites;
            Assert.AreEqual(testFavoriteIdList.Length, favoritesList.Count);
        }

        [TestMethod]
        public void Favorites_TestIdListInput_ReturnsFavoritesListWithSameIdsAndOrderAsInput()
        {

            mockService.Setup(fp => fp.getFavorites(testFavoriteIdList)).Returns(getFavorites(testFavoriteIdList));
            favoritesService = mockService.Object;

            FavoritesModel favoritesModel = new FavoritesModel(favoritesService, testFavoriteIdList);
            List<Favorite> favoritesList = favoritesModel.Favorites;

            for (int i = 0; i < testFavoriteIdList.Length; i++)
            {
                var inputId = testFavoriteIdList[i];
                var outputId = favoritesList[i].Id;
                Assert.AreEqual(inputId, outputId);
            }

        }
    }
}
