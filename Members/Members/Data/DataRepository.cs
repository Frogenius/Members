using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using Members.Models;


namespace Members.Data
{
    public interface DataRepository
    {        
        
            Task<IEnumerable<Member>> GetMembers();
            Task<Member> GetMember(int id);
            Task<bool> AddMember(Member member);
            Task<bool> DeleteMember(int id);
        
    }
}
