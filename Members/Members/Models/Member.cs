using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Members.Models
{
    public class Member
    {  [PrimaryKey, AutoIncrement]
    public int MemberId { get; set; }
    public string Name { get; set; }
    public string Experience { get; set; }
    public string Age { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string City { get; set; }
    }
}
