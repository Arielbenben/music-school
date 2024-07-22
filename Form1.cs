using PracticeFunc.Model;
using static PracticeFunc.Service.MusicSchoolService;


namespace PracticeFunc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateXmlIfNotExists();
            InsertClassroom("guitar jass");
            AddTeacher("guitar jass", "enosh");
            AddStudent("guitar jass", "ariel", "guitar");

            InstrumentModel ariel = new ("guitar");
            InstrumentModel daniel = new ("dumbs");
            InstrumentModel george = new("piano");


            StudentModel dani = new("ariel", ariel);
            StudentModel beni = new("ben", daniel);
            StudentModel yair = new("yair", george);

            StudentModel[] students = [dani, beni];

            AddManyStudents("guitar jass", students);

            UdateStudentInstrumentNames("dandan", "piano");

            UpdateStudentName("ariel", yair);
            UpdateTeacherName("enosh", "alef");
            //  List<string> list = ["ariel", "ben haim"];



        }
    }
}
