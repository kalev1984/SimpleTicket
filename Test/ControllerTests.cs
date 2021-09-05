using System;
using System.Collections.Generic;
using Domain.App;
using Microsoft.AspNetCore.Mvc;
using WebApp.Controllers;
using Xunit;

namespace Test
{
    public class ControllerTests
    {
        [Fact]
        public void TestReturnEmptyTicketList()
        {
            var controller = new TicketController();
            var result = controller.Index() as ViewResult;
            
            var model = (List<Ticket>)result!.Model;
            
            Assert.True(model.Count == 0);
        }

        [Fact]
        public void TestAddTicketReturnListWithOneTicket()
        {
            var controller = new TicketController();
            var ticket = new Ticket
            {
                Description = "Meeting",
                DueDate = DateTime.Now.AddHours(5)
            };
            controller.Create(ticket);
            
            var result = controller.Index() as ViewResult;
            var model = (List<Ticket>) result!.Model;
            Assert.True(model.Count == 1);
            controller.Remove(0);
        }

        [Fact]
        public void TestRemoveTicketReturnEmptyTicketList()
        {
            var controller = new TicketController();
            var ticket = new Ticket
            {
                Description = "Meeting",
                DueDate = DateTime.Now.AddHours(5)
            };
            controller.Create(ticket);
            
            var result = controller.Index() as ViewResult;
            var model = (List<Ticket>) result!.Model;
            Assert.True(model.Count == 1);
            
            controller.Remove(0);
            Assert.True(model.Count == 0);
        }

        [Fact]
        public void TestCannotAddSameTicketsReturnsTicketListWithOneTicket()
        {
            var controller = new TicketController();
            var ticket = new Ticket
            {
                Description = "Meeting",
                DueDate = DateTime.Now.AddHours(5)
            };
            controller.Create(ticket);
            controller.Create(ticket);
            
            var result = controller.Index() as ViewResult;
            var model = (List<Ticket>) result!.Model;
            
            Assert.True(model.Count == 1);
            controller.Remove(0);
        }
    }
}