namespace Snippets6.PubSub.WithConvention
{
    using NServiceBus;

    public class Usage
    {
        public Usage()
        {
            #region DefiningEventsAs

            EndpointConfiguration endpointConfiguration = new EndpointConfiguration();
            ConventionsBuilder conventions = endpointConfiguration.Conventions();
            conventions.DefiningEventsAs(t =>
                t.Namespace != null &&
                t.Namespace.StartsWith("Domain") &&
                t.Name.EndsWith("Event"));

            #endregion
        }
    }
}