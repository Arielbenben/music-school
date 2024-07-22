using PracticeFunc.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static PracticeFunc.Congiguration.MusicSchollConfiguration;

namespace PracticeFunc.Service
{
    internal static class MusicSchoolService
    {
        public static void CreateXmlIfNotExists()
        {
            if (!File.Exists(musicSchoolPath))
            {
                // create new docmunet
                XDocument document = new();
                // create an element
                XElement musicSchool = new("music-school");
                //document add element
                document.Add(musicSchool);
                // document save changes to provided path
                document.Save(musicSchoolPath);
            }
        }

        public static void InsertClassroom(string classRoomName)
        {
            // open document
            XDocument document = XDocument.Load(musicSchoolPath);
            // find the element "music-school"
            XElement? musicSchool = document.Descendants("music-school").FirstOrDefault();
            // check if the element exists
            if (musicSchool == null)
            {
                return;
            }
            // create new element with the atrribute "name"
            XElement classroom = new("class-room", new XAttribute("name", classRoomName));
            // add the element with the atrribute to the document
            musicSchool.Add(classroom);
            // save the changes in the document
            document.Save(musicSchoolPath);
        }

        public static void AddTeacher(string classRoomName, string teacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? classroom = document.Descendants("class-room").
                FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);

            if (classroom == null)
            {
                return;
            }
            XElement teacher = new("teacher", new XAttribute("name", teacherName));
            classroom.Add(teacher);
            document.Save(musicSchoolPath);
        }

        public static void AddStudent(string classRoomName, string StudentName, string instrumentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            //XElement? classroom = document.Descendants("class-room").
            //FirstOrDefault(room => room.Attribute("name")?.Value == classRoomName);
            XElement? classroom = (from room in document.
                                   Descendants("class-room")
                                   where room.
                                   Attribute("name")?.Value == classRoomName
                                   select room).
                                  FirstOrDefault();
            if (classroom == null)
            {
                return;
            }
            XElement student = new("student", new XAttribute("name", StudentName), new
                XElement("instrument", instrumentName));
            classroom.Add(student);
            document.Save(musicSchoolPath);
        }


        public static void AddManyStudents(string classRoomName, params StudentModel[] students)
        {

            XDocument document = XDocument.Load(musicSchoolPath);

            XElement? classroom = document.Descendants("class-room").
                FirstOrDefault(room => room.
                Attribute("name")?.Value == classRoomName);

            List<XElement> AllStudents = [];

            AllStudents = students.Select(s => new XElement
            ("students", new XAttribute("name", s.Name),
            new XElement("instrument", s.Instrument.Nmae))).ToList();



            if (classroom == null)
            {
                return;
            }

            classroom.Add(AllStudents);
            document.Save(musicSchoolPath);
        }

        public static void UdateStudentInstrumentNames(string studentName, string instrumentName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? student = document.Descendants("student").FirstOrDefault(romm => romm.Attribute("name")?.Value == "ariel");

            if (student == null)
            {
                return;
            }
            student?.SetAttributeValue("name", "ari");
            //XElement instrument = document.Descendants("student").FirstOrDefault(stu => stu.Element("instrument"));
            XElement? instrument = student?.Element("instrument");

            if (instrument == null)
            {
                return;
            }
            instrument.Value = instrumentName;
            document.Save(musicSchoolPath);
        }

        public static void UpdateTeacherName(string teacherName, string newTeacherName)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? teacher = document.Descendants("teacher").FirstOrDefault(romm => romm.Attribute("name")?.Value == teacherName);

            if (teacher == null)
            {
                return;
            }
            teacher?.SetAttributeValue("name", newTeacherName);
            document.Save(musicSchoolPath);
        }

        public static void UpdateStudentName(string name, StudentModel student)
        {
            XDocument document = XDocument.Load(musicSchoolPath);
            XElement? stu = document.Descendants("student").FirstOrDefault(romm => romm.Attribute("name")?.Value == name);

            if (stu == null)
            {
                return;
            }
            
            stu?.SetAttributeValue("name", student.Name);
            XElement? instrument = stu?.Element("instrument");
            //stu?.Element("instrument")?.Value = student.Instrument.Nmae;
            instrument.Value = student.Instrument.Nmae; 
            document.Save(musicSchoolPath);
        }
    }
}
