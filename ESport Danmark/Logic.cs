using System;
using System.Collections.Generic;
using System.Text;

namespace ESport_Danmark
{
    class Logic
    {
        Spiller spilleren;
        ApiConnection api = new ApiConnection();
        List<Spiller> spillers;

        internal Spiller Spilleren { get => spilleren; set => spilleren = value; }
        internal ApiConnection Api { get => api; set => api = value; }
        internal List<Spiller> Spillers { get => spillers; set => spillers = value; }

        public void GetAllSpillers()
        {
            Spillers = new List<Spiller>();
            bool moreSpillers = true;
            int tryId = 0;
            do
            {
                try
                {
                    tryId++;
                    Spilleren = new Spiller(tryId);
                    Spillers.Add(Spilleren);
                }
                catch
                {
                    moreSpillers = false;
                }
            } while (moreSpillers);
        }
        public int CheckPhoneNummber(string telefonnummer)
        {
            //0=true
            int uniqeNumber = 0;
            try
            {
                GetAllSpillers();
                foreach(Spiller spiller in Spillers)
                {
                    if(spiller.Telefonnummer == Convert.ToInt32(telefonnummer))
                    {
                        //1=false type 1
                        uniqeNumber = 1;
                    }
                }
            }
            catch
            {
                //2=false type 2
                uniqeNumber = 2;
            }

            return uniqeNumber;
        }
        public bool CheckTurnementtype(string tuneringstype)
        {
            if (tuneringstype.ToLower() == "5v5" || tuneringstype.ToLower() == "3v3" || tuneringstype.ToLower() == "1v1")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddSpiller(string name, string summonerName, string rang, int telefonnummer, string tuneringstype)
        {
            spilleren = new Spiller(name, summonerName, rang, telefonnummer, tuneringstype);
            spilleren.AddToDatabase();
        }
    }
}
