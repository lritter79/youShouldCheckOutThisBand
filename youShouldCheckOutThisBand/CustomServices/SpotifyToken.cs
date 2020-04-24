using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace youShouldCheckOutThisBand.Models
{

    public class SpotifyToken
    {
        private string _ClientId { get; set; }
        private string _ClientSecret { get; set; }
        public string _MarketCode { get; set; }
        public string AccessToken { get; set; }
        public string TokenType { get; set; }
        public int ExpiresIn { get; set; }


        public SpotifyToken(IConfiguration config)
        {
            _ClientId = config.GetValue<string>("SpotifyApiTokens:ClientId");
            _ClientSecret = config.GetValue<string>("SpotifyApiTokens:ClientSecret");
            _MarketCode = config.GetValue<string>("MarketCode");
            //SpotifyToken token = new SpotifyToken();

            string url5 = "https://accounts.spotify.com/api/token";


            var encode_clientid_clientsecret = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _ClientId, _ClientSecret)));


            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url5);


            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Accept = "application/json";
            webRequest.Headers.Add("Authorization: Basic " + encode_clientid_clientsecret);


            var request = ("grant_type=client_credentials");
            byte[] req_bytes = Encoding.ASCII.GetBytes(request);
            webRequest.ContentLength = req_bytes.Length;


            Stream strm = webRequest.GetRequestStream();
            strm.Write(req_bytes, 0, req_bytes.Length);
            strm.Close();


            HttpWebResponse resp = (HttpWebResponse)webRequest.GetResponse();
            String json = "";
            using (Stream respStr = resp.GetResponseStream())
            {
                using (StreamReader rdr = new StreamReader(respStr, Encoding.UTF8))
                {
                    //should get back a string i can then turn to json and parse for accesstoken
                    json = rdr.ReadToEnd();
                    rdr.Close();
                }
            }
            var keyValuePairs = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

            AccessToken = keyValuePairs.ElementAt(0).Value;
            TokenType = keyValuePairs.ElementAt(1).Value;
            int number;
            if (Int32.TryParse(keyValuePairs.ElementAt(2).Value, out number))
            {
                ExpiresIn = Int32.Parse(keyValuePairs.ElementAt(2).Value);
            }
            
        }

    }
}
