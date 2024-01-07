using System;
using System.Collections.Generic;

namespace Badges.Core.Data
{
    public partial class User
    {
        public User()
        {
            AssignmentsTrainees = new HashSet<AssignmentsTrainee>();
            AttendanceTrainees = new HashSet<AttendanceTrainee>();
            BadgesTrainees = new HashSet<BadgesTrainee>();
            CourseTrainees = new HashSet<CourseTrainee>();
            Courses = new HashSet<Course>();
        }

        public decimal Userid { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Phone { get; set; }
        public string? Image { get; set; }
        public decimal? Roleid { get; set; }

        public virtual Role? Role { get; set; }
        public virtual ICollection<AssignmentsTrainee> AssignmentsTrainees { get; set; }
        public virtual ICollection<AttendanceTrainee> AttendanceTrainees { get; set; }
        public virtual ICollection<BadgesTrainee> BadgesTrainees { get; set; }
        public virtual ICollection<CourseTrainee> CourseTrainees { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
