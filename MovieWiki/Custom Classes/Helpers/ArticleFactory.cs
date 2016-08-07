using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWiki.Custom_Classes
{
    public class ArticleFactory
    {
        // Used when building an article's template
        public Article GetInstance(string articleType, string[] parameters)
        {
            switch (articleType)
            {
                case "CrewMemberArticle": return new CrewMemberArticle(parameters);
                case "CharacterArticle": return new CharacterArticle();
                case "MovieArticle": return new MovieArticle();
                case "PropArticle": return new PropArticle();
                default: throw new Exception("Error creating article");
            }
        }

        // Used when getting articles from the database
        public Article GetInstance(string articleType, int articleId, int author, string title, string description)
        {
            var article = GetInstance(articleType, null);
            article.ArticleId = articleId;
            article.Author = author;
            article.Title = title;
            article.ParseData(description);

            return article;
        }
    }
}