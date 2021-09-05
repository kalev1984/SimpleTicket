using System;
using Domain.App;
using Xunit;

namespace Test
{
    public class TicketTests
    {
        [Fact]
        public void TestCreateEmptyTicket()
        {
            var ticket = new Ticket();
            var description = ticket.Description;
            Assert.Null(description);

            var dueDate = ticket.DueDate;
            var actualDate = DateTime.MinValue;
            Assert.Equal(actualDate, dueDate);

            var createdAt = ticket.CreatedAt;
            var timeSpan = DateTime.Now.Subtract(createdAt);
            Assert.True(timeSpan.TotalMilliseconds < 5);

            var id = ticket.Id;
            Assert.Equal(0, id);
        }

        [Fact]
        public void TestCreateTicket()
        {
            var ticket = new Ticket();
            var description = "Test Ticket";
            ticket.Description = description;
            Assert.Equal(description, ticket.Description);

            var dueDate = new DateTime(2021, 08, 30, 12, 00, 00);
            ticket.DueDate = dueDate;
            Assert.Equal(dueDate, ticket.DueDate);

            var id = 0;
            ticket.Id = id;
            Assert.Equal(id, ticket.Id);
        }

        [Fact]
        public void TestTwoTicketsWithSameDateAndDescriptionEqualTrue()
        {
            var ticket1 = new Ticket
            {
                Description = "Test ticket",
                DueDate = new DateTime(2021, 08, 30, 12, 00, 00)
            };
            var ticket2 = new Ticket
            {
                Description = "Test ticket",
                DueDate = new DateTime(2021, 08, 30, 12, 00, 00)
            };
            Assert.Equal(ticket1, ticket2);
        }
    }
}