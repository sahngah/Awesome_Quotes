using Nancy;
using DbConnection;
using System.Collections.Generic;

namespace QuotingDojoRedux
{
    public class QuotingModule : NancyModule
    {
        public QuotingModule()
        {
            string Query;

            Get("/", args => 
            {
                if ((string)Session["error"] == "error")
                {
                    ViewBag.error = true;
                }
                return View["home"];
            });
            Post("/quotes", args =>
            {
                if (Request.Form.username == "" || Request.Form.quote == "")
                {
                    Session["error"] = "error";   
                    return Response.AsRedirect("/"); 
                }
                Query = $"INSERT INTO quote (username, quote, created_at, updated_at) VALUES (\"{Request.Form.username}\", \"{Request.Form.quote}\", NOW(), NOW())";
                List <Dictionary<string,object>> test_result = DbConnector.ExecuteQuery(Query);
                return Response.AsRedirect("/quotes");
            });
            Get("/quotes", args =>
            {
                Query = "SELECT * FROM quote";
                List<Dictionary<string,object>> result = DbConnector.ExecuteQuery(Query);
                return View["quotes", result];
            });
        }
    } 
}    