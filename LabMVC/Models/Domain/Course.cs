using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC15_04_2021.Models.DomainD
{
    public class Course
    {
        private int id;
        private string initials;
        private string name;
        private int credits;
        private string semester;
        private int scheduleId;
        private int activity;

        public Course()
        {
        }

        public Course(int id, string initials, string name, int credits, string semester, int scheduleId, int activity)
        {
            this.Id = id;
            this.Initials = initials;
            this.Name = name;
            this.Credits = credits;
            this.Semester = semester;
            this.ScheduleId = scheduleId;
            this.Activity = activity;
        }

        public int Id { get => id; set => id = value; }
        public string Initials { get => initials; set => initials = value; }
        public string Name { get => name; set => name = value; }
        public int Credits { get => credits; set => credits = value; }
        public string Semester { get => semester; set => semester = value; }
        public int ScheduleId { get => scheduleId; set => scheduleId = value; }
        public int Activity { get => activity; set => activity = value; }
    }
}
