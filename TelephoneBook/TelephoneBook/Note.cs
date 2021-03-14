using System;
using System.Collections.Generic;
using System.Text;

namespace TelephoneBook
{
    class Note
    {
        public string Surname { set; get; }
        public string Name { set; get; }
        public string ThirdName { set; get; }
        public string Telephone { set; get; }
        public string Country { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string Organization { set; get; }
        public string Post { set; get; }
        public string PlusInfo { set; get; }

        public Note(string surname, string name, string thirdName, string telephone, string country, string dateOfBirth, string organization,
            string post, string plusInfo)
        {
            Surname = surname;
            Name = name;
            ThirdName = thirdName;
            Telephone = telephone;
            Country = country;
            DateOfBirth = DateTime.Parse(dateOfBirth);
            Organization = organization;
            Post = post;
            PlusInfo = plusInfo;
        }
    }
}
