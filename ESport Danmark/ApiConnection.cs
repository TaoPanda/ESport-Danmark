using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ESport_Danmark
{
    class ApiConnection
    {
        bool validName;

        public bool ValidName { get => validName; set => validName = value; }

        public void ValidateSpillerNavn(string spillerNavn)
        {
            ValidName = true;
            try
            {
                //fik hjælp af Christian til apien.
                string json = new WebClient().DownloadString(@$"https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/{spillerNavn}?api_key=RGAPI-88764941-ae00-4be1-9f34-52386878bab9");
                ValidName = true;
            }
            catch
            {
                ValidName = false;
            }
        }
    }
}
