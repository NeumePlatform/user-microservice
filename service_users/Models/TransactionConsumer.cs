using System;
using System.Text.Json;
using MassTransit;
using TransactionModel;
using userBusiness.Models;

namespace service_users.Models
{
    public class TransactionConsumer : IConsumer<TransactionModel.Transaction>
    {
        private readonly IUser _user;

        public TransactionConsumer(IUser user)
        {
            _user = user;
        }

        public async Task Consume(ConsumeContext<TransactionModel.Transaction> context)
        {
            var serializedMessage = JsonSerializer.Serialize(context.Message, new JsonSerializerOptions { });

            Console.WriteLine($"NotificationCreated event consumed. Message: {serializedMessage}");
            //Console.WriteLine($"UserID: {context.Message.customerID}");
            Console.WriteLine(_user.UpdateUserSubscription(context.Message.customerID));
        }
    }
}

