using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//add two refrences to access the database
using System.Web.ModelBinding;

namespace Week6
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //get the department and display in the gridview
            getStudents();
        }
        protected void getStudents()
        {
            //connect to db
            var conn = new ContosoEntities();

            //run the query using LINQ
            var Students = from d in conn.Students
                           select d;

            //Display query result in gridview

            grdStudents.DataSource = Students.ToList();
            grdStudents.DataBind();
        }


        protected void grdStudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            // function to delete a student from gridview
            //1. Determine which row in the grid the user has clicked
            Int32 gridIndex = e.RowIndex;

            //2. find the departmentID value in the seleceted row
            Int32 StudentID = Convert.ToInt32(grdStudents.DataKeys[gridIndex].Value);

            //3.connedct to the db
            var conn = new ContosoEntities();

            //4. delete the selected student

            Student d = new Student();
            d.StudentID = StudentID;
            conn.Students.Attach(d);

            conn.Students.Remove(d);
            conn.SaveChanges();


            //5. refresh the gridview
            getStudents();
        }
    }
}