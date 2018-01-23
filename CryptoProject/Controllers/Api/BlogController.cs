using CryptoProject.Models;
using CryptoProject.Services;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace CryptoProject.Controllers.Api
{
    [AllowAnonymous]
    [RoutePrefix("api/blog")]
    public class BlogController : ApiController
    {
        IBlogService _IBlogService;

        public BlogController(IBlogService blogService)
        {
            _IBlogService = blogService;
        }

        [Route("blogList"), HttpGet]
        public HttpResponseMessage GetBlog()
        {
            try
            {
                IEnumerable<BlogDomain> response = _IBlogService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //webscraping
        [Route("articles"), HttpPost]
        public HttpResponseMessage Scrape(WebScrapingRequest model)
        {
            var html = new HtmlDocument();
            html.LoadHtml(new WebClient().DownloadString("http://www.altcointoday.com/"));
            var root = html.DocumentNode;

            IEnumerable<HtmlAgilityPack.HtmlNode> myList = new List<HtmlAgilityPack.HtmlNode>();
            myList = ((root.Descendants()
                .Where(n => n.GetAttributeValue("class", "").Equals("sidebar-right"))
                .Single()
                .Descendants("article")));

            List<string> newList = new List<string>();

            foreach (HtmlNode itm in myList)
            {
                newList.Add(itm.InnerHtml);
            }

            return Request.CreateResponse(HttpStatusCode.OK, newList);
        }

    }

}
