using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Configuration;

namespace MovieWikiService
{
    public class MovieWikiService : IMovieWikiService
    {
        private readonly string MovieWikiConnectionString = WebConfigurationManager
                    .ConnectionStrings["MovieWikiConnectionString"].ConnectionString;

        public int InsertWikiArticle(string articleType, string title, string descriptionXml)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO WikiArticle VALUES(@articleType, @title, @description);";
                    command.Parameters.AddWithValue("@articleType", articleType);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", descriptionXml);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int InsertWikiArticleEditHistory(int aticleId, int accountId, DateTime timestamp)
        {
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
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int InsertUserAccount(string username, string password)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "INSERT INTO UserAccount VALUES(@username, @password);";
                    command.Parameters.AddWithValue("@username", username);
                    command.Parameters.AddWithValue("@password", password);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int UpdateWikiArticle(int articleId, string descriptionXml)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "UPDATE WikiArticle "
                        + "SET Description = @description WHERE ArticleId = @articleId;";
                    command.Parameters.AddWithValue("@articleId", articleId);
                    command.Parameters.AddWithValue("@description", descriptionXml);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int DeleteWikiArticle(int articleId)
        {
            if (DeleteWikiArticleEditHistory(articleId) == 0) return 0;

            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM WikiArticle "
                        + "WHERE ArticleId = @articleId;";
                    command.Parameters.AddWithValue("@articleId", articleId);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        private int DeleteWikiArticleEditHistory(int articleId)
        {
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "DELETE FROM WikiArticleEditHistory "
                        + "WHERE ArticleId = @articleId;";
                    command.Parameters.AddWithValue("@articleId", articleId);

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetAllWikiArticles()
        {
            return GetAllRecords("WikiArticle");
        }

        public DataSet GetAllWikiArticleEditHistories()
        {
            return GetAllRecords("WikiArticleEditHistory");
        }

        public DataSet GetAllUserAccounts()
        {
            return GetAllRecords("UserAccount");
        }

        private DataSet GetAllRecords(string tableName)
        {
            var dataSet = new DataSet();
            using (var connection = new SqlConnection())
            {
                connection.ConnectionString = MovieWikiConnectionString;
                var querySql = string.Format("SELECT * FROM {0};", tableName);
                using (var sqlDataAdapter = new SqlDataAdapter(querySql, connection))
                {
                    sqlDataAdapter.Fill(dataSet, tableName);
                    return dataSet;
                }
            }
        }
    }
}
