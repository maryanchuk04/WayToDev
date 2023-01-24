using Microsoft.AspNetCore.SignalR;
using WayToDev.Core.Interfaces.Services;

namespace WayToDev.Client.Hubs;

public class ChatHub : Hub
{
    private readonly IDictionary<string, string> _connections = new Dictionary<string, string>();
    private readonly ISecurityContext _securityContext;
    private readonly IMessageService _messageService;

    public ChatHub(ISecurityContext securityContext, IMessageService messageService)
    {
        _securityContext = securityContext;
        _messageService = messageService;
    }

    public async Task SendMessage(Guid chatId, string message)
    {
        if (message.Trim() != string.Empty)
        {
            var currentUserId = _securityContext.GetCurrentAccountId();
            var res = await _messageService.Send(chatId, currentUserId, message);

            await Clients.Group(chatId.ToString()).SendAsync("SendMessage", res);
        }
    }

    public async Task JoinRoom(string chatId)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, chatId);
        _connections[Context.ConnectionId] = chatId;
        await Clients.Group(chatId).SendAsync("JoinToRoom", "Was connected to room");
        await SendUsersConnected(chatId);
    }

    public async Task JoinToUsersRooms(List<string> chatsIds)
    {
        foreach (var item in chatsIds)
        {
            await JoinRoom(item);
        }
    }


    private Task SendUsersConnected(string chatId)
    {
        var users = _connections.Values.Where(x => x == chatId);

        return Clients.Group(chatId).SendAsync("UsersInRoom", users);
    }
}