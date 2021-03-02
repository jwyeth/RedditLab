using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using RedditLab.Models;
using Newtonsoft.Json;

namespace RedditLab.Models
{
    public class RedditDAL
    {
        public string GetData()
        {
            string url = $@"https://www.reddit.com/r/aww/.json";

            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());


            string JSON = rd.ReadToEnd();

            
            return JSON;
        }

        public List<Child> GetPosts()
        {
            string postData = GetData();
            Post p = JsonConvert.DeserializeObject<Post>(postData);
            return p.data.children.ToList();

        }
    }
}
