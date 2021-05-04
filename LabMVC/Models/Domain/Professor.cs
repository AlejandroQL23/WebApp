using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabMVC15_04_2021.Models.DomainD
{
    public class Professor
    {
        private int id;
        private string idCard;
        private string name;
        private string lastName;
        private string email;
        private string password;
        private string phone;
        private string address;
        private string personalFormation;
        private string dateTime;
        private string picture;
        private string rol;
        private int activity;

        public Professor()
        {
        }

        public Professor(int id, string idCard, string name, string lastName, string email, string password, string phone, string address, 
        string personalFormation, string dateTime, string picture, string rol, int activity)
        {
            this.Id = id;
            this.IdCard = idCard;
            this.Name = name;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.Phone = phone;
            this.Address = address;
            this.PersonalFormation = personalFormation;
            this.DateTime = dateTime;
            this.Picture = picture;
            this.Rol = rol;
            this.Activity = activity;
        }

        public int Id { get => id; set => id = value; }
        public string IdCard { get => idCard; set => idCard = value; }
        public string Name { get => name; set => name = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string PersonalFormation { get => personalFormation; set => personalFormation = value; }
        public string DateTime { get => dateTime; set => dateTime = value; }
        public string Picture { get => picture; set => picture = value; }
        public string Rol { get => rol; set => rol = value; }
        public int Activity { get => activity; set => activity = value; }
    }
}
