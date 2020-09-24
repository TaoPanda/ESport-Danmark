using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ESport_Danmark
{
    class Spiller : DatabaseConection
    {
        int id;
        string name;
        string summonerName;
        string rang;
        int telefonnummer;
        string tuneringstype;

        public Spiller(int id)
        {
            TableName = "Spillere";
            GetFromDatabase(id);
        }
        public Spiller(string name, string summonerName, string rang, int telefonnummer, string tuneringstype)
        {
            Name = name;
            SummonerName = summonerName;
            Rang = rang;
            Telefonnummer = telefonnummer;
            Tuneringstype = tuneringstype;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string SummonerName { get => summonerName; set => summonerName = value; }
        public string Rang { get => rang; set => rang = value; }
        public int Telefonnummer { get => telefonnummer; set => telefonnummer = value; }
        public string Tuneringstype { get => tuneringstype; set => tuneringstype = value; }

        public override void InsetData(DataTable dataTable)
        {
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Id = (int)dataRow["id"];
                Name = (string)dataRow["navn"];
                SummonerName = (string)dataRow["summonerName"];
                Rang = (string)dataRow["rang"];
                Telefonnummer = (int)dataRow["relefonnummer"];
                Tuneringstype = (string)dataRow["tuneringstype"];
            }
        }
        public void AddToDatabase()
        {
            string addNewSpillerQurry = $"INSERT INTO Spillere (navn, summonerName, rang, telefonnummer, tuneringstype) VALUES('{Name}', '{SummonerName}', '{Rang}', '{Telefonnummer}', '{Tuneringstype}')";
            Execute(addNewSpillerQurry);
        }
    }
}
