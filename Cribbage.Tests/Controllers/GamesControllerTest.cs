using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

using Cribbage.Controllers;
using Cribbage.Models;
using Cribbage.Services;

namespace Cribbage.Tests
{
    public class GamesControllerTest
    {
        public class MockGamesService : IGamesService
        {
            private List<Game> games = new List<Game>();

            public MockGamesService()
            {
                games.Add(new Game
                    {
                        GameId = 1,
                    }
                );
                games.Add(new Game
                    {
                        GameId = 3,
                    }
                );
                games.Add(new Game
                    {
                        GameId = 4,
                    }
                );
            }

            public IEnumerable<Game> GetGames() {
                return games;
            }

            public Game GetGame(int id)
            {
                return games.FirstOrDefault(g => g.GameId == id);
            }

            public Game CreateGame()
            {
                var game = new Game
                {
                    GameId = games.Max(g => g.GameId) + 1,
                };
                games.Add(game);
                return game;
            }

            public bool DeleteGame(int id)
            {
                var game = GetGame(id);
                if (game == null)
                    return false;
                games.Remove(game);
                return true;
            }
        }

        [Fact]
        public void TestGetAll()
        {
            var controller = new GamesController(new MockGamesService());
            var result = controller.Get();
            Assert.NotNull(result);
            var games = result.ToList();
            Assert.Equal(3, games.Count);
        }

        [Fact]
        public void TestGetSuccess()
        {
            var controller = new GamesController(new MockGamesService());
            var result = controller.Get(4) as OkObjectResult;
            Assert.NotNull(result);
            var game = result.Value as Game;
            Assert.NotNull(game);
            Assert.Equal(4, game.GameId);
        }

        [Fact]
        public void TestGetFailure()
        {
            var controller = new GamesController(new MockGamesService());
            var result = controller.Get(1234);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestPost()
        {
            var controller = new GamesController(new MockGamesService());
            var game = controller.Post();
            Assert.NotNull(game);
        }

        [Fact]
        public void TestDeleteSuccess()
        {
            var controller = new GamesController(new MockGamesService());
            var result = controller.Delete(4);
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void TestDeleteFailure()
        {
            var controller = new GamesController(new MockGamesService());
            var result = controller.Delete(1234);
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void TestWorkflow()
        {
            var controller = new GamesController(new MockGamesService());
            controller.Post();
            controller.Delete(1234);
            controller.Post();
            controller.Post();
            controller.Delete(1);
            controller.Delete(4);
            Assert.Equal(4, controller.Get().Count());
            Assert.IsType<NotFoundResult>(controller.Get(1));
            Assert.IsType<NotFoundResult>(controller.Get(2));
            Assert.IsType<OkObjectResult>(controller.Get(3));
            Assert.IsType<NotFoundResult>(controller.Get(4));
            Assert.IsType<OkObjectResult>(controller.Get(5));
            Assert.IsType<OkObjectResult>(controller.Get(6));
            Assert.IsType<OkObjectResult>(controller.Get(7));
            Assert.IsType<NotFoundResult>(controller.Get(8));
        }
    }
}
