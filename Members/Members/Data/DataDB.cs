using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Members.Models;
using SQLite;

namespace Members.Data
{
    public class DataDB : DataRepository
    {
        public SQLiteAsyncConnection db;
        public DataDB(string connPath)
        {
            db = new SQLiteAsyncConnection(connPath);
            db.CreateTableAsync<Member>().Wait();
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            return await Task.FromResult(await db.Table<Member>().ToListAsync());
        }

        public async Task<Member> GetMember(int id)
        {
            return await db.Table<Member>().Where(a => a.MemberId == id).FirstOrDefaultAsync();
        }

        public async Task<bool> AddMember(Member member)
        {
            if (member.MemberId > 0)
            {
                await db.UpdateAsync(member);
            }
            else
            {
                await db.InsertAsync(member);
            }
            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteMember(int id)
        {
            await db.DeleteAsync<Member>(id);
            return await Task.FromResult(true);
        }
    }
}
