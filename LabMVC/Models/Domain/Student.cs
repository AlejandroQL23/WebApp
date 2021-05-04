using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC15_04_2021.Models.DomainD
{
    public class Student
    {
        private int id;
        private string idCard;
        private string name;
        private string lastName;
        private string email;
        private string password;
        private string phone;
        private string address;
        private string instagram;
        private string facebook;
        private string rol;
        private int presidency;
        private int activity;
        private string approval;
        private string profilePicure;

        public Student()
        {
        }

        public Student(int id, string idCard, string name, string lastName, string email, string password, string phone, string address, 
            string instagram, string facebook, string rol, int presidency, int activity, string approval, string profilePicure)
        {
            this.Id = id;
            this.IdCard = idCard;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Address = address;
            this.Instagram = instagram;
            this.Facebook = facebook;
            this.Rol = rol;
            this.Presidency = presidency;
            this.Activity = activity;
            this.Approval = approval;
            this.ProfilePicure = profilePicure;
        }     

        public int Id { get => id; set => id = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Instagram { get => instagram; set => instagram = value; }
        public string Facebook { get => facebook; set => facebook = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Presidency { get => presidency; set => presidency = value; }
        public int Activity { get => activity; set => activity = value; }
        public string Approval { get => approval; set => approval = value; }
        public string ProfilePicure { get => profilePicure; set => profilePicure = value; }
    }

}
