using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace TestMakeAnAPI.Controllers
{
    public class JokesController : ApiController
    {
        private static List<string> _jokes = new List<string>
        {
            "Why do programmers confuse Halloween and Christmas? Because dec 25 is oct 31.",
            "Why do Java devs wear glasses? Because they don't C#.",
            "What was the hipster doing in the recycling bin? Looking for something retro.",
            "What do you call a programmer from Finland? Nerdic",
            "Why do assembly programmers take swimming lessons? Because they're below C-level",
            "What do you call a Frenchman wearing sandals? Philippe Philoppe.",
            "What did the programmer quit his job? Because he didn't get arrays."
        };

        [HttpGet]
        public string GetRandomJoke()
        {
            Random random = new Random();
            return _jokes[random.Next(_jokes.Count)];
        }
    }
}