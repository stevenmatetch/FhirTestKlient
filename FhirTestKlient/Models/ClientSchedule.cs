using Hl7.Fhir.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FhirTestKlient.Models
{
    public class ClientSchedule
    {
        public Schedule Schedule { get; set; }
        public ClientSchedule(Schedule _Schedule)
        {
            Schedule = _Schedule;
        }
        public string GetIdentifierValue
        {
            get
            {
                Identifier id = Schedule.Identifier.FirstOrDefault();
                if (id != null) return id.Value;
                return "";
            }
        }
        public string GetPlanningHorizonStart
        {
            get
            {
                DateTime time = DateTime.Parse(Schedule.PlanningHorizon.Start);
                return time.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
        public string GetPlanningHorizonEnd
        {
            get
            {
                DateTime time = DateTime.Parse(Schedule.PlanningHorizon.End);
                return time.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }
    }
}
