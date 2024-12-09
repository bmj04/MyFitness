using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using MyFItness.Data;
using MyFItness.Models;

namespace MyFItness.Hubs
{
    public class ChatHub : Hub
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ChatHub(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task openConversation(string receiverId)
        {
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            var messages = _context.Messages
                .Where(m => m.SenderId == user.Id && m.ReceiverId == receiverId || m.SenderId == receiverId && m.ReceiverId == user.Id)
                .OrderBy(m => m.Date)
                .ToList();

            await Clients.Caller.SendAsync("Conversation", messages);
        }

        public async Task SendMessage(string receiverId, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", receiverId, message);
            var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext.User);
            _context.Messages.Add(new Message { ReceiverId = receiverId, SenderId = user.Id, Content = message, Date = DateTime.Now });
            await _context.SaveChangesAsync();
        }
    }
}


