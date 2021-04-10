using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LeSheApp.Models
{
    public class cMember
    {
        [PrimaryKey, AutoIncrement]
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordSalt { get; set; }
        public short DistrictId { get; set; }
        public string Address { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public int Balance { get; set; }
        public string ProfileImagePath { get; set; }
        public bool Validate { get; set; }

    }
}
