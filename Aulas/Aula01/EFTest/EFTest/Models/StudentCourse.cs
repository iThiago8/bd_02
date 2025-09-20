﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFTest.Models
{
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    public class StudentCourse
    {
        public int StudentId { get; set; }

        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }


        public int CourseId { get; set; }

        [ForeignKey(nameof(CourseId))]
        public Course? Course { get; set; }

        public DateTime EnrollmentDate { get; set; }
        public DateTime? WithdrawDate { get; set; }
    }
}
