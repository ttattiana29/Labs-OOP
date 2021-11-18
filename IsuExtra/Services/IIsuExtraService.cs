﻿using System;
using System.Collections.Generic;
using Isu.Classes;
using IsuExtra.Classes;

namespace IsuExtra.Services
{
    public interface IIsuExtraService
    {
        Ognp AddOgnp(string name);
        OgnpCourse AddCourse(string name, Ognp ognp);
        OgnpGroup AddOgnpGroup(OgnpCourse ognpCourse, string groupName, DateTime time, string teacher, int room);
        ScheduleGroup AddScheduleGroup(Group mainGroup, DateTime time, string teacher, int room);
        Student AddStudentOgnp(Student student, Ognp ognpName);
        void RemoveStudentOgnp(Student student, string ognpName);
        OgnpCourse GetOgnpCourse(OgnpCourse ognpCourse);
        OgnpGroup GetOgnpGroup(OgnpGroup ognpGroup);
        List<Student> StudentsWithoutOgnpGroup(List<Student> result);
    }
}