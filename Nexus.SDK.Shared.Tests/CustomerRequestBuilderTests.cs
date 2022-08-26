using Nexus.SDK.Shared.Requests;

namespace Nexus.SDK.Shared.Tests
{
    public class CustomerRequestBuilderTests
    {
        [Test]
        public void CustomerRequestBuilderTests_Build_Default()
        {
            var request = new CustomerRequestBuilder("MOCK_CUSTOMER", "Trusted", "EUR").Build();

            Assert.Multiple(() =>
            {
                Assert.That(request, Is.Not.Null);
                Assert.That(request.Email, Is.Null);
                Assert.That(request.CustomerCode, Is.EqualTo("MOCK_CUSTOMER"));
                Assert.That(request.TrustLevel, Is.EqualTo("Trusted"));
                Assert.That(request.Status, Is.EqualTo("ACTIVE"));
                Assert.That(request.CurrencyCode, Is.EqualTo("EUR"));
            });
        }

        [Test]
        [TestCase(CustomerStatus.UNDERREVIEW, "UNDERREVIEW")]
        [TestCase(CustomerStatus.BLOCKED, "BLOCKED")]
        [TestCase(CustomerStatus.NEW, "NEW")]
        [TestCase(CustomerStatus.ACTIVE, "ACTIVE")]
        public void CustomerRequestBuilderTests_Build_Status_Status(CustomerStatus status, string expected)
        {
            var request = new CustomerRequestBuilder("MOCK_CUSTOMER", "Trusted", "EUR")
                .SetStatus(status)
                .Build();

            Assert.Multiple(() =>
            {
                Assert.That(request, Is.Not.Null);
                Assert.That(request.Email, Is.Null);
                Assert.That(request.CustomerCode, Is.EqualTo("MOCK_CUSTOMER"));
                Assert.That(request.TrustLevel, Is.EqualTo("Trusted"));
                Assert.That(request.Status, Is.EqualTo(expected));
                Assert.That(request.CurrencyCode, Is.EqualTo("EUR"));
            });
        }

        [Test]
        public void CustomerRequestBuilderTests_Build_Email()
        {
            var request = new CustomerRequestBuilder("MOCK_CUSTOMER", "Trusted", "EUR")
                .SetEmail("test@test.com")
                .Build();

            Assert.Multiple(() =>
            {
                Assert.That(request, Is.Not.Null);
                Assert.That(request.Email, Is.EqualTo("test@test.com"));
                Assert.That(request.CustomerCode, Is.EqualTo("MOCK_CUSTOMER"));
                Assert.That(request.TrustLevel, Is.EqualTo("Trusted"));
                Assert.That(request.Status, Is.EqualTo("ACTIVE"));
                Assert.That(request.CurrencyCode, Is.EqualTo("EUR"));
            });
        }
    }
}