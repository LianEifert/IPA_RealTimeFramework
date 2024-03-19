using Microsoft.AspNetCore.SignalR;

namespace ProjectEstimaterRealTime
{
    public class SignalRHub : Hub
    {
        public async Task ShowResults(string groupName, float votingResult)
        {
            await Clients.Group(groupName).SendAsync("VotingFinished", votingResult);
        }
        public async Task joinGroup(string groupName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
            await Clients.Group(groupName).SendAsync("UserJoined");
        }
        public async Task ShowVote(string groupName)
        {
            await Clients.Group(groupName).SendAsync("NewVote");
        }
    }
}
