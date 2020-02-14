using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SikhiDB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikhiWeb.Hubs
{
    public class GurbaniConnect: Hub
    {
        private DbContextOptions<SikhiDBContext> GetOptions() {
            DbContextOptionsBuilder<SikhiDBContext> dbContextOptions = new DbContextOptionsBuilder<SikhiDBContext>();
            dbContextOptions.UseMySQL("server=localhost;port=3306;user=root;password=root;database=gurbanidb");
            return dbContextOptions.Options;
        }
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task FetchLines()
        {
            using (SikhiDBContext db = new SikhiDBContext(GetOptions()))
            {
                var lines = db.bani_text_line.Where(x => x.file_source_id == 2007).Select(x => new
                {
                    x.gurmukhi,
                    x.pronunciation,
                    x.pronunciation_information,
                    x.translation
                }).ToList();
                await Clients.All.SendAsync("FetchLines", lines);
            };
        }
    }
}
