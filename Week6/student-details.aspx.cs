using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Week6
{
    public partial class student_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack == false)
            {
                //check the url for an id so we know if we are adding or editing
                if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
                {
                    //get id from the url
                    Int32 StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //connect
                    var conn = new ContosoEntities();

                    //look up thr selected student
                    var objDep = (from s in conn.Students where s.StudentID == StudentID select s).FirstOrDefault();

                    //populate the form
                    txtName.Text = objDep.FirstMidName;
                    txtLName1.Text = objDep.LastName;
                    TxtEDate.Text = objDep.EnrollmentDate.ToString();
                }
            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            //check if we have an id to decide if we're adding or editing
            Int32 StudentID = 0;
            if (!String.IsNullOrEmpty(Request.QueryString["StudentID"]))
            {
                StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);
            }

            //connect
            var conn = new ContosoEntities();

            //use the department class to creat a new student object
            Student s = new Student();

            //fill the properties of the new department object
            s.FirstMidName = txtName.Text;
            s.LastName = txtLName1.Text;
            s.EnrollmentDate = Convert.ToDateTime(TxtEDate.Text);


            //Save the new object to the database
            if (StudentID == 0)
            {
                conn.Students.Add(s);
            }
            else
            {
                s.StudentID = StudentID;
                conn.Students.Attach(s);
                conn.Entry(s).State = System.Data.Entity.EntityState.Modified;
            }
            conn.Students.Add(s);
            conn.SaveChanges();

            //redirect to the departments page
            Response.Redirect("students.aspx");




        }
    }
}