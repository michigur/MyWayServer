using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace MyWayServer.Hubs
{
    public class LocationHub: Hub
    {

        public async Task SendOnBoard(int carId, int ClientId)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateKidOnBoard", ClientId);
        }
        public async Task SendLocation(int carId, double longitude, double latitude)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateDriverLocation", longitude, latitude);
        }
        public async Task SendArriveToDestination(int carId)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateArriveToDestination");
        }
        public async Task OnConnect(int carId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, carId.ToString());
            await base.OnConnectedAsync();
        }

        //public async Task OnConnect(string groupName)
        //{
        //    await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    await base.OnConnectedAsync();
        //}

        public async Task OnDisconnect(int carId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, carId.ToString());
            await base.OnDisconnectedAsync(null);
        }

        //public async Task OnDisconnect(string groupName)
        //{
        //    await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        //    await base.OnDisconnectedAsync(null);
        //}

        public async Task StartDrive(int carId)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("StartDrive");
        }









        //public async Task UpdateLocation(int? routeid, string latitude, string longitude)
        //{

        //        IClientProxy proxy = Clients.Group(routeid.ToString());
        //        await proxy.SendAsync("UpdateCarLocation", latitude, longitude);

        //}

        //public async Task SendMessageToGroup(string user, string message, string groupName)
        //{
        //    IClientProxy proxy = Clients.Group(groupName);
        //    await proxy.SendAsync("ReceiveMessageFromGroup", user, message, groupName);
        //}
        //public async Task SendMessage(string user, string message)
        //{
        //    await Clients.All.SendAsync("ReceiveMessage", user, message);
        //}

        //public async Task OnConnect(string[] groupNames)
        //{
        //    foreach (string groupName in groupNames)
        //        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        //    await base.OnConnectedAsync();
        //}

        //public async Task OnDisconnect(string[] groupNames)
        //{
        //    foreach (string groupName in groupNames)
        //        await Groups.RemoveFromGroupAsync(Context.ConnectionId, groupName);
        //    await base.OnDisconnectedAsync(null);
        //}
    }
}
