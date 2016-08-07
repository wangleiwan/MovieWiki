using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWiki.Custom_Classes
{
    public class WikiArticleEditHistory
    {
        public int EditId { get; set; }
        public int ArticleId { get; set; }
        public int AccountId { get; set; }
        public DateTime EditTimestamp { get; set; }

        public WikiArticleEditHistory(int editId, int articleId, int accountId, DateTime editTimeStamp)
        {
            EditId = editId;
            ArticleId = articleId;
            AccountId = accountId;
            EditTimestamp = editTimeStamp;
        }
    }
}