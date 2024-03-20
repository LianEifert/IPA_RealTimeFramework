using Microsoft.AspNetCore.SignalR;

namespace ProjectEstimaterRealTime
{
    public class SignalRHub : Hub
    {
        public async Task ShowResults(string VotingId, float votingResult)
        {
            await Clients.Group(VotingId).SendAsync("VotingFinished", votingResult, VotingId);
        }
        public async Task joinGroup(string VotingId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, VotingId);
            await Clients.Group(VotingId).SendAsync("UserJoined", VotingId);
        }
        public async Task ShowVote(string VotingId)
        {
            await Clients.Group(VotingId).SendAsync("NewVote", VotingId);
        }
    }
}
