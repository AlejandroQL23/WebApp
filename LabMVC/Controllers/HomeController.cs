using LabMVC.Models;
using LabMVC.Models.Data;
using LabMVC15_04_2021.Models.DomainD;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;


namespace LabMVC.Controllers
{

    public class HomeController : Controller
    {
        StudentDAO studentDAO;
        ProfessorDAO professorDAO;
        CourseDAO courseDAO;
        
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult InsertCourses([FromBody] Course course)
        {
            
            courseDAO = new CourseDAO(_configuration);
            int resultToReturn = courseDAO.Insert(course);
           
            return Ok(resultToReturn);

        }


        public IActionResult Insert([FromBody] Student student)
        {

            studentDAO = new StudentDAO(_configuration);

            if (studentDAO.VerifyEmail(student.Email))
            {
                return Error();
            }
            else
            {
                int resultToReturn = studentDAO.Insert(student);
                studentDAO.SendEmail(student.Email, "❁→❝Solicitud de inscripción En Espera❞❁",
                              "<html><body ><h1>Estimado/a " + student.Name + "</h1><br/>" +
                              "<br/><h3>Sede: Atlántico<br/>" +
                              "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática Empresarial se encuentra en estado de espera hasta que uno de nuestros administradores revise su solicitud...<br/>" +
                              "<br/>En caso de que su solicitud sea rechazada y tenga alguna consulta con el resultado del registro, puede contactarse con el servicio de atención en la página oficial de Orientación y Registro(https://ori.ucr.ac.cr/), o bien, con el coordinador de la carrera mediante correo institucional(alvaro.mena@ucr.ac.cr)<br/>" +
                              "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
                return Ok(resultToReturn);
            }
        }

        public IActionResult InsertProfessor([FromBody] Professor professor)
        {

            professorDAO = new ProfessorDAO(_configuration);

                int resultToReturn = professorDAO.Insert(professor);
            professorDAO.SendEmail(professor.Email, "❁→❝Trámites de Inscripción Listo❞❁",
                           "<html><body ><h1>Estimado/a " + professor.Name + "</h1><br/>" +
                           "<br/><h3>Sede: Atlántico<br/>" +
                           "<br/>Queremos informarle que el proceso de su inscripción al entorno oficial de Informática Empresarial para la Sede del Atlántico ha sido procesada y terminada con éxito, le hemos asignado una identificación oficial la cual es: " + professor.IdCard + ", el cual necesitará para autenticarse en nuestros sitios oficiales con sesión de Profesor.  <br/>" +
                           "<br/>Le solicitamos atentamente que revise esta y más de su infomación oficial en el entorno de E-Matrícula(https://ematricula.ucr.ac.cr/ematricula/), así mismo, revisar en días posteriores al proceso de matrícula estudiantil si su respectivo entorno está habilitado en Mediación Virtual(https://mv1.mediacionvirtual.ucr.ac.cr/login/index.php)<br/>" +
                           "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
            return Ok(resultToReturn);
           
        }

        public IActionResult UpdateApprovalAcceptDeny([FromBody] Student student)
        {

            studentDAO = new StudentDAO(_configuration);
            if (student.Approval == "Aceptado")
            {
                int resultToReturn = studentDAO.UpdateApproval(student);
                studentDAO.SendEmail(student.Email, "❁→❝Solicitud de inscripción Aceptada❞❁",
               "<html><body ><h1>Estimado/a " + student.Name + "</h1><br/>" +
               "<br/><h3>Sede: Atlántico<br/>" +
               "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido aceptada con éxito, por este medio le recordamos de igual manera que su carné estudiantil es " + student.IdCard + ", el cuál será de suma importancia para los trámites oficiales dentro de la Universidad <br/>" +
               "<br/>Le pedimos porfavor que verifique la carrera en el sitio oficial de E-Matrícula(https://ematricula.ucr.ac.cr/ematricula/) con motivo del cercano proceos de matrícula. Así mismo registrarse en el sitio oficial de la universidad para el manejo de cada curso, Mediación Virtual(https://mv1.mediacionvirtual.ucr.ac.cr/login/index.php)<br/>" +
               "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
                return Ok(resultToReturn);
            }
            else
            {
                int resultToReturn = studentDAO.UpdateApproval(student);
                studentDAO.SendEmail(student.Email, "❁→❝Solicitud de inscripción Rechazada❞❁",
                               "<html><body ><h1>Estimado/a " + student.Name + "</h1><br/>" +
                               "<br/><h3>Sede: Atlántico<br/>" +
                               "<br/>Queremos informarle que su solicitud de inscripción a la carrera de Informática ha sido rechazada, por lo tanto su actividad dentro de la carrera estará automaticamente inactivo dentro de los registros de la carrera <br/>" +
                               "<br/>En caso de tener una consulta con respecto al resultado de su solicitud, porfavor consultar con la Oficina de Orientación y Registros(https://ori.ucr.ac.cr/) o bien al coordinador de la carrera(alvaro.mena@ucr.ac.cr)<br/>" +
                               "<br/>- Oficina de Orientación y Registro.</h3></body></html>");
                return Ok(resultToReturn);

            }
        }

        

        public IActionResult GetStudents()
        { 
            //llamada al modelo para obtener las carreras
            studentDAO = new StudentDAO(_configuration);
            return Ok(studentDAO.Get());
        }


        public IActionResult GetCourses()
        {
            courseDAO = new CourseDAO(_configuration);
            return Ok(courseDAO.Get());

        }

        public IActionResult GetById(string id)
        {
            courseDAO = new CourseDAO(_configuration);
            return Ok(courseDAO.Get(id));

        }
        //[HttpPost]
        public IActionResult DeleteCourse(string id)
        {

            //initials = "IF3000";
            //llamada al modelo para eliminar el estudiante
            // studentDAO = new StudentDAO(_configuration);
            courseDAO = new CourseDAO(_configuration);
            return Ok(courseDAO.DeleteCourse(id));

        }


        //---------------------------------------------------------------------
        public IActionResult UpdateCourse([FromBody] Course course)
        {

            // Major major2 = new Major();
            courseDAO = new CourseDAO(_configuration);
            //major2.Id = student.Major_Id;
            //student.Major = major2;
            return Ok(courseDAO.UpdateCourse(course));

        }

        public IActionResult GetStudentById(string id)
        {
            studentDAO = new StudentDAO(_configuration);
            return Ok(studentDAO.Get(id));

        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
