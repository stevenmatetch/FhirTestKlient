using FhirTestKlient.Models;
using Hl7.Fhir.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Gaming.Input.ForceFeedback;

namespace FhirTestKlient.ViewModels
{
  public  class ClientScheduleViewModel
    {
        public ObservableCollection<ClientSchedule> schedules { get; set; }

        public ClientScheduleViewModel()
        {
            schedules = new ObservableCollection<ClientSchedule>();
            schedules.Add(SkapaTestSchedule1());
            schedules.Add(SkapaTestSchedule2());
        }
        public ClientSchedule SkapaTestSchedule1()
        {

            Schedule schedule = new Schedule();
            schedule.Identifier = new List<Identifier>();
            schedule.Identifier.Add(new Identifier() { Value = "Schedule 1", Use = Identifier.IdentifierUse.Old });
            schedule.Identifier.Add(new Identifier() { Value = "Schedule 2", Use = Identifier.IdentifierUse.Usual });
            schedule.PlanningHorizon = new Period();
            schedule.PlanningHorizon.Start = DateTime.Now.ToString("yyyy-MM-dd   HH: mm:ss");


            schedule.PlanningHorizon.End = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd   HH: mm:ss");


            return new ClientSchedule(schedule);

        }
        public ClientSchedule SkapaTestSchedule2()
        {

            Schedule schedule = new Schedule();
            schedule.Identifier = new List<Identifier>();
            schedule.Identifier.Add(new Identifier() { Value = "Schedule 4", Use = Identifier.IdentifierUse.Old });
            schedule.Identifier.Add(new Identifier() { Value = "Schedule 3", Use = Identifier.IdentifierUse.Usual });
            schedule.PlanningHorizon = new Period();
            schedule.PlanningHorizon.Start = DateTime.Now.ToString("yyyy-MM-dd   HH: mm:ss");

            schedule.PlanningHorizon.End = DateTime.Now.AddDays(9).ToString("yyyy-MM-dd   HH: mm:ss");

            return new ClientSchedule(schedule);

        }
        public string GetJSONSchedule

        {
            get
            {
                string jsonString;
                jsonString = JsonConvert.SerializeObject(schedules);

                return jsonString;

            }

        }

    }
}
