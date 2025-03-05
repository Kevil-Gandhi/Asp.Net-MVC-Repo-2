using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using P_02.Models;


namespace P_02.Controllers
{
    public class smsController : Controller
    {
        SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\Kevil Gandhi\\Documents\\Internal_P_02.mdf\";Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter adp = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlCommand cmd = new SqlCommand();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult courseDisplay()
        {
            List<course> courseList = new List<course>();

            con.Open();
            adp = new SqlDataAdapter("SELECT * FROM course",con);

            adp.Fill(ds);
            dt = ds.Tables[0];

            foreach(DataRow dr in dt.Rows)
            {
                courseList.Add(new course
                {
                    cId = Convert.ToInt32(dr["cId"].ToString()),
                    cName = dr["cName"].ToString()
                });
            }
            return View(courseList);
        }

        [HttpGet]
        public IActionResult courseInsert()
        {
            return View();
        }

        [HttpPost]
        public IActionResult courseInsert(course c)
        {
            con.Open();

            cmd = new SqlCommand($"INSERT INTO course(cName) VALUES ('{c.cName}')",con);
            int r = cmd.ExecuteNonQuery();

            if(r>0)
            {
                return RedirectToAction("courseDisplay");
            }
            return View();
        }

        public IActionResult courseDelete(int cId)
        {
            con.Open();
            cmd = new SqlCommand($"DELETE FROM course where cId={cId}", con);
            int r = cmd.ExecuteNonQuery();
            if(r>0) {
                return RedirectToAction("courseDisplay");
            }
            return View();
        }

        public IActionResult studentDisplay()
        {
            List<student> studentList = new List<student>();
            
            con.Open();
            adp = new SqlDataAdapter("SELECT * FROM student", con);
            ds = new DataSet();

            adp.Fill(ds);
            dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                studentList.Add(new student
                {
                    sId = Convert.ToInt32(dr["sId"].ToString()),
                    sName = dr["sName"].ToString(),
                    sEmail = dr["sEmail"].ToString(),
                    cId = Convert.ToInt32(dr["cId"].ToString())
                });
            }
            return View(studentList);
        }

        [HttpGet]
        public IActionResult studentInsert()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult studentInsert(student s)
        {
            con.Open();

            cmd = new SqlCommand($"INSERT INTO student(sName,sEmail,cId) VALUES ('{s.sName}','{s.sEmail}',{s.cId})",con);
            int r = cmd.ExecuteNonQuery();

            if(r>0) {
                return RedirectToAction("studentDisplay");
            }
            return View();
        }

        public IActionResult studentDelete(int sId)
        {
            con.Open();

            cmd = new SqlCommand($"DELETE FROM student WHERE sId={sId}", con);
            int r = cmd.ExecuteNonQuery();

            if (r > 0)
            {
                return RedirectToAction("studentDisplay");
            }
            return View();
        }

        [HttpGet]
        public IActionResult studentUpdate(int sId)
        {
            return View();
        }

        [HttpPost]
        public IActionResult studentUpdate(student s)
        {
            con.Open();

            cmd = new SqlCommand($"UPDATE student SET sName='{s.sName}', sEmail='{s.sEmail}', cId={s.cId} WHERE sId={s.sId}",con);
            int r = cmd.ExecuteNonQuery();

            if (r > 0)
            {
                return RedirectToAction("studentDisplay");
            }
            return View();
        }

        public IActionResult Display()
        {
            con.Open();

            List<studCourse> studCourseList = new List<studCourse>();
            adp = new SqlDataAdapter($"SELECT student.sId,student.sName,student.sEmail,student.cId,course.cName FROM student,course WHERE student.cId=course.cId", con);

            ds = new DataSet();
            adp.Fill(ds);

            dt = ds.Tables[0];

            foreach (DataRow dr in dt.Rows)
            {
                studCourseList.Add(new studCourse
                {
                    sId = Convert.ToInt32(dr["sId"].ToString()),
                    sName = dr["sName"].ToString(),
                    sEmail = dr["sEmail"].ToString(),
                    cId = Convert.ToInt32(dr["cId"].ToString()),
                    cName = dr["cName"].ToString()
                });
            }
            return View(studCourseList);
        }
    }
}
