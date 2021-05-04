using LabMVC15_04_2021.Models.DomainD;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC.Models.Data
{
    public class CourseDAO
    {
        private readonly IConfiguration _configuration;
        string connectionString;

        public CourseDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        public CourseDAO()
        {

        }

        public int Insert(Course course)
        {

            int resultToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("CreateCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", course.Initials);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Credits", course.Credits);
                command.Parameters.AddWithValue("@Semester", course.Semester);
                command.Parameters.AddWithValue("@Schedule_Id", course.ScheduleId);
                command.Parameters.AddWithValue("@Activity", course.Activity);

                resultToReturn = command.ExecuteNonQuery();
                connection.Close();

            }

            return resultToReturn;

        }


        public List<Course> Get()
        {

            List<Course> courses = new List<Course>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SelectCourseGeneral", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    courses.Add(new Course
                    {
                        Initials = sqlDataReader["Initials"].ToString(),
                        Name = sqlDataReader["Name"].ToString(),
                        Credits = Convert.ToInt32(sqlDataReader["Credits"]),
                        Semester = sqlDataReader["Semester"].ToString(),
                        Activity = Convert.ToInt32(sqlDataReader["Activity"])
                    });

                }

                connection.Close(); //cerramos conexión. 
            }


            return courses; //retornamos resultado al Controller.  

        }


        public Course Get(string id)
        {
            Course course = null;
            //usaremos using para englobar todo lo que tiene que ver con una misma cosa u objeto. En este caso, todo lo envuelto acá tiene que ver con connection, la cual sacamos con la clase SqlConnection y con el string de conexión que tenemos en nuestro appsetting.json
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); //abrimos conexión
                SqlCommand command = new SqlCommand("ReadCourse", connection);//llamamos a un procedimiento almacenado (SP) que crearemos en el punto siguiente. La idea es no tener acá en el código una sentencia INSERT INTO directa, pues es una mala práctica y además insostenible e inmantenible en el tiempo. 
                command.CommandType = System.Data.CommandType.StoredProcedure; //acá decimos que lo que se ejecutará es un SP
                command.Parameters.AddWithValue("@Initials", id);

                //logica del get/select
                SqlDataReader sqlDataReader = command.ExecuteReader();
                course = new Course();
                //leemos la fila proveniente de BD, si es que viene alguna
                if (sqlDataReader.Read())
                {
                    course.Initials = sqlDataReader["Initials"].ToString();
                    course.Name = sqlDataReader["Name"].ToString();
                    course.Credits = Convert.ToInt32(sqlDataReader["Credits"]);
                    course.Semester = sqlDataReader["Semester"].ToString();
                    course.Activity = Convert.ToInt32(sqlDataReader["Activity"]);

                }

                connection.Close(); //cerramos conexión. 
            }


            return course; //retornamos resultado al Controller.  

        }

        public int DeleteCourse(string initials)
        {
            int resultToReturn;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("DeleteCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Initials", initials);
                resultToReturn = command.ExecuteNonQuery();
                connection.Close();
            }

            return resultToReturn;


        }


        //------------------------------------------------------------------------------------



        public int UpdateCourse(Course course)
        {
            int resultToReturn;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateCourse", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;


                command.Parameters.AddWithValue("@Initials", course.Initials);
                command.Parameters.AddWithValue("@Name", course.Name);
                command.Parameters.AddWithValue("@Credits", course.Credits);
                command.Parameters.AddWithValue("@Semester", course.Semester);
                command.Parameters.AddWithValue("@Activity", course.Activity);


                resultToReturn = command.ExecuteNonQuery();
                connection.Close();
            }


            return resultToReturn;


        }

    }
}
