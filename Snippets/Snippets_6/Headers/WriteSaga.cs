﻿namespace Snippets6.Headers
{
    using System.Threading.Tasks;
    using NServiceBus;

    #region header-outgoing-saga

    public class WriteSaga : Saga<WriteSagaData>,
        IHandleMessages<MyMessage>
    {
        public async Task Handle(MyMessage message, IMessageHandlerContext context)
        {
            SendOptions sendOptions = new SendOptions();
            sendOptions.SetHeader("MyCustomHeader", "My custom value");
            await context.SendAsync(new SomeOtherMessage(), sendOptions);

            ReplyOptions replyOptions = new ReplyOptions();
            replyOptions.SetHeader("MyCustomHeader", "My custom value");
            await context.ReplyAsync(new SomeOtherMessage(), replyOptions);

            PublishOptions publishOptions = new PublishOptions();
            publishOptions.SetHeader("MyCustomHeader", "My custom value");
            await context.PublishAsync(new SomeOtherMessage(), publishOptions);
        }
        #endregion

        protected override void ConfigureHowToFindSaga(SagaPropertyMapper<WriteSagaData> mapper)
        {
        }
    }



    public class WriteSagaData : ContainSagaData
    {
    }

}