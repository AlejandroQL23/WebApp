using LabMVC15_04_2021.Models.DomainD;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LabMVC.Models.Data
{
    public class ProfessorDAO
    {

        private readonly IConfiguration _configuration;
        string connectionString;

        public ProfessorDAO(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = _configuration.GetConnectionString("DefaultConnection");

        }
        public ProfessorDAO()
        {

        }

        public int Insert(Professor professor)
        {

            int resultToReturn;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                connection.Open();
                SqlCommand command = new SqlCommand("CreateProfessor", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id_Card", professor.IdCard);
                command.Parameters.AddWithValue("@Name", professor.Name);
                command.Parameters.AddWithValue("@Last_Name", professor.LastName);
                command.Parameters.AddWithValue("@Email", professor.Email);
                command.Parameters.AddWithValue("@Password", professor.Password);
                command.Parameters.AddWithValue("@Phone", professor.Phone);
                command.Parameters.AddWithValue("@Address", professor.Address);

                resultToReturn = command.ExecuteNonQuery();
                connection.Close();

            }

            return resultToReturn;

        }

        public void SendEmail(String addressee, String title, String message)
        {

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("aldifasoft0@gmail.com", "LPAC2021"),
                EnableSsl = true,
            };
            MailMessage mailMessage = new MailMessage("aldifasoft0@gmail.com", addressee, title, message);
            mailMessage.IsBodyHtml = true;
            smtpClient.Send(mailMessage);

        }

    }
}
