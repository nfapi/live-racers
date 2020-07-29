using System;
using System.Collections.Generic;
using System.Text;

namespace LiveRacersManager
{
    public class ResultList
    {
        public List<Result> value { get; set; }
    }

    public class Result
    {
        /*
          {
      "Id":"bc32ebca-86cd-410f-985f-724b5cda1c1a","Server":"Su\u00e1rez race",
      "Mod":"Turismo Nacional Clase 2 2017 PRO",
      "ModFamilyId":"0a9654d6-e78a-4138-a15a-6a49ae087ee2",
      "Track":"FIAFIM",
      "AllowedVehicles":"TN_C2_2017_PRO",
      "Drivers":1,
      "DurationMins":18.0833333333333333333,
      "Time":720,"SessionType":1,"OriginalSessionType":1,
      "Version":1,"StartDate":"2020-07-23T20:15:22.2341719Z",
      "IsRating":false,"ApplicationId":1,"HasEvent":false,"HasChampionship":false,"EventName":null,
      "ChampionshipName":null,"IsSynced":false,"IsFinished":true,"IsInactive":false,
      "DateFinished":"0001-01-01T00:00:00Z"
    }
         */
        public Guid Id { get; set; }
        public string Server { get; set; }
        public string Track { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public SessionType SessionType { get; set; }

        public int Drivers { get; set; }

        public override string ToString()
        {
            return $"{StartDate.ToLocalTime().ToString("dd/MM/yy HH:mm")} [{SessionType}] ({Drivers}) {Track} ";
        }


    }
    
    public enum SessionType
    {
        Practica = 1,
        Clasificacion = 5,
        Calentamiento = 6,
        Carrera = 7
    }
}
