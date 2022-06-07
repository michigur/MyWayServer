using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using MyWayServer.Models;

namespace MyWayServer.Hubs
{
    public class LocationHub: Hub
    {
        private MyWayContext context;
        public LocationHub(MyWayContext context)
        {
            this.context = context;
        }
        //This message is sent by the customer to the car, so the car can start driving
        public async Task SendOnBoard(int carId, int ClientId)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateOnBoard", ClientId);
        }
        //This message is sent by the car to whom ever neds it including the customer app
        public async Task SendLocation(int carId, double longitude, double latitude)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateDriverLocation", longitude, latitude);
        }
        //this message is sent by the customer to the car before paying and going out of the car
        public async Task SendArriveToDestination(int carId)
        {
            IClientProxy proxy = Clients.Group(carId.ToString());
            await proxy.SendAsync("UpdateArriveToDestination");
            //Update the availability of the car in the DB
            //Car c = this.context.Cars.Where(c => c.CarId == carId).FirstOrDefault();
            //if (c != null)
            //{
            //    c.IsAvailable = true;
            //    this.context.Entry(c).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //    this.context.SaveChanges();
            //}
            
        }
        //used by all apps
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

        //sent by the customer after payment and going out of the car
        public async Task OnDisconnect(int carId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, carId.ToString());
            await base.OnDisconnectedAsync(null);
        }

        
    }
}
