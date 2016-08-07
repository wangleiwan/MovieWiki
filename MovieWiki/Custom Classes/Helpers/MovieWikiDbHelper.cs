using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MovieWiki.Custom_Classes
{
    public static class MovieWikiDbHelper
    {
        private static readonly string MovieWikiConnectionString = WebConfigurationManager
                    .ConnectionStrings["MovieWikiConnectionString"].ConnectionString;
        private static readonly ArticleFactory ArticleFactory = new ArticleFactory();

        private static List<UserAccount> _allUserAccounts;
        public static List<UserAccount> AllUserAccounts
        {
            get
            {
                if (_allUserAccounts == null)
                {
                    UpdateUserAccounts();
                }
                return _allUserAccounts;
            }
            private set
            {
                _allUserAccounts = value;
            }
        }

        private static List<Article> _allWikiArticles;
        public static List<Article> AllWikiArticles
        {
            get
            {
                if (_allWikiArticles == null)
                {
                    UpdateWikiArticles();
                }
                return _allWikiArticles;
            }
            private set
            {
                _allWikiArticles = value;
            }
        }

        private enum UserAccountTable
        {
            AccountId = 0,
            Username = 1,
            Password = 2
        }

        private enum WikiArticleTable
        {
            ArticleId = 0,
            Author = 1,
            ArticleType = 2,
            Title = 3,
            Description = 4
        }

        private enum WikiArticleEditHistory
        {
            EditId = 0,
            ArticleId = 1,
            AccountId = 2,
            EditTimestamp = 3
        }

        // TODO make list of wikiarticleedithistories functional
        public static bool InsertWikiArticleEditHistory(int aticleId, int accountId, DateTime timestamp)
        {
            int rowsAffected;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO WikiArticleEditHistory VALUES(@aticleId, @accountId, @timestamp);";
                    command.Parameters.AddWithValue("@aticleId", aticleId);
                    command.Parameters.AddWithValue("@accountId", accountId);
                    command.Parameters.AddWithValue("@timestamp", timestamp);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            if (rowsAffected == 1)
            {
                //UpdateWikiArticleEditHistories
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool InsertWikiArticle(int authorId, string articleType, string title, string descriptionXml)
        {
            if (IsExistingWikiArticle(title)) return false;

            int rowsAffected;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO WikiArticle VALUES(@authorId, @articleType, @title, @description);";
                    command.Parameters.AddWithValue("@authorId", authorId);
                    command.Parameters.AddWithValue("@articleType", articleType);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", descriptionXml);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            if (rowsAffected == 1)
            {
                UpdateWikiArticles();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void UpdateWikiArticles()
        {
            AllWikiArticles = GetAllWikiArticles();
        }

        private static List<Article> GetAllWikiArticles()
        {
            var wikiArticles = new List<Article>();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM WikiArticle;";
                    connection.Open();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var articleId = Convert.ToInt32(result[(int)WikiArticleTable.ArticleId]);
                            var author = Convert.ToInt32(result[(int)WikiArticleTable.Author]);
                            var articleType = Convert.ToString(result[(int)WikiArticleTable.ArticleType]);
                            var title = Convert.ToString(result[(int)WikiArticleTable.Title]);
                            var description = Convert.ToString(result[(int)WikiArticleTable.Description]);

                            var article = ArticleFactory.GetInstance(articleType, articleId, author, title, description);
                            wikiArticles.Add(article);
                        }
                        return wikiArticles;
                    }
                }
            }
        }

        public static Article GetWikiArticle(string title)
        {
            return AllWikiArticles.FirstOrDefault(w => w.Title == title);
        }

        public static bool IsExistingWikiArticle(string title)
        {
            return AllWikiArticles.Any(w => string.Equals(w.Title, title, StringComparison.OrdinalIgnoreCase));
        }

        public static bool InsertUserAccount(string username, string password)
        {
            if (IsExistingUsername(username)) return false;

            int rowsAffected;
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO UserAccount VALUES(@username, @password);";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                }
            }
            if (rowsAffected == 1)
            {
                UpdateUserAccounts();
                return true;
            }
            else
            {
                return false;
            }
        }

        private static void UpdateUserAccounts()
        {
            AllUserAccounts = GetAllUserAccounts();
        }

        private static List<UserAccount> GetAllUserAccounts()
        {
            var userAccounts = new List<UserAccount>();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM UserAccount;";
                    connection.Open();
                    using (var result = command.ExecuteReader())
                    {
                        while (result.Read())
                        {
                            var accountId = Convert.ToInt32(result[(int)UserAccountTable.AccountId]);
                            var username = Convert.ToString(result[(int)UserAccountTable.Username]);
                            var password = Convert.ToString(result[(int)UserAccountTable.Password]);

                            userAccounts.Add(new UserAccount(accountId, username, password));
                        }
                        return userAccounts;
                    }
                }
            }
        }

        public static UserAccount GetUserAccount(string username, string password)
        {
            return AllUserAccounts.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        private static bool IsExistingUsername(string username)
        {
            return AllUserAccounts.Any(u => string.Equals(u.Username, username, StringComparison.OrdinalIgnoreCase));
        }

        public static bool IsUserAdmin(string username)
        {
            return username.ToLower() == "admin";
        }
    }
}