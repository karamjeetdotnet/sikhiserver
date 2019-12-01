using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SikhiWeb.Hubs
{
	public class GurbaniConnect: Hub
	{
		public async Task SendMessage(string user, string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}
	}
}
