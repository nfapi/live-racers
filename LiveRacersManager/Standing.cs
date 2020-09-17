using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LiveRacersManager
{
    /// <summary>
    /// Standing class
    /// </summary>
    public class Standing : ShortStanding
    {
        /*
          {
<SessionDriverModel>
<BestLap>81.3296</BestLap>
<BestLapGap>0.7974</BestLapGap>
<BestSectors xmlns:d3p1="http://schemas.datacontract.org/2004/07/System">
<d3p1:decimal>5.6734</d3p1:decimal>
<d3p1:decimal>56.6183</d3p1:decimal>
<d3p1:decimal>18.7782</d3p1:decimal>
</BestSectors>
<ChampionshipUserId i:nil="true"/>
<Class>TN C2 2017 PRO</Class>
<CleanLaps>14</CleanLaps>
<Consistency>98.660468121008591</Consistency>
<Crew>
<CrewDriver>
<Name>S OTTELLA</Name>
<RatingAtTime>0</RatingAtTime>
<RatingGain>64</RatingGain>
<UniqueName>s ottella_0</UniqueName>
</CrewDriver>
</Crew>
<DNFReason i:nil="true"/>
<DomainUserId i:nil="true"/>
<DriverType>0</DriverType>
<EndPosition>6</EndPosition>
<EventClassId i:nil="true"/>
<EventUserId i:nil="true"/>
<FinishStatus>Finished</FinishStatus>
<FinishTimeSecs>1252.1939</FinishTimeSecs>
<Id>ece91a55-538c-415c-bf9d-7c4d638f75fd</Id>
<Incidents>1</Incidents>
<IsSuspended i:nil="true"/>
<LapsLed>0</LapsLed>
<LapsToLeader>0</LapsToLeader>
<Name>S OTTELLA</Name>
<Number>24</Number>
<OriginalFinishTimeSecs>1252.1939</OriginalFinishTimeSecs>
<OverallEndPosition>6</OverallEndPosition>
<PenaltyMass i:nil="true"/>
<PenaltyReason i:nil="true"/>
<Pits>0</Pits>
<Points i:nil="true"/>
<PointsAdjustment i:nil="true"/>
<PointsAdjustmentReason i:nil="true"/>
<PointsAuto i:nil="true"/>
<PositionsPenalty i:nil="true"/>
<SelectedEventClassId i:nil="true"/>
<SessionId>227b23ec-c542-43ad-b963-46ff9d35c81a</SessionId>
<StartPosition>11</StartPosition>
<SuspendedReason i:nil="true"/>
<Team i:nil="true"/>
<TeamId i:nil="true"/>
<TimePenaltySecs i:nil="true"/>
<TimeToLeader>17.2254</TimeToLeader>
<TopSpeed>216.7</TopSpeed>
<TotalLaps>15</TotalLaps>
<UniqueName>s ottella_0</UniqueName>
<Vehicle>#24 Maxi Fontana</Vehicle>
<_BestSectors i:nil="true"/>
</SessionDriverModel>
         */
        public int Number { get; set; }
        public int EndPosition { get; set; }

        public int NewPosition { get; set; }


        public override string ToString()
        {
            return $"{Name}\t{EndPosition}";
        }

        public string ToNewPosition()
        {
            return $"{NewPosition} {Name}";
        }
    }

    public class ShortStanding
    {
        public string Name { get; set; }

        public int TotalLaps { get; set; }

        public int CleanLaps { get; set; }

        public int Incidents { get; set; }
    }
}
