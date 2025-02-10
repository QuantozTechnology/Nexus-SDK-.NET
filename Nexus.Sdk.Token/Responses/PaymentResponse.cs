using System.Text.Json.Serialization;

namespace Nexus.Sdk.Token.Responses;

public record PaymentOperationResponse
{
    [JsonPropertyName("payment")]
    public required PaymentResponse Payment { get; set; }
}

public record PaymentResponse
{
    [JsonPropertyName("tokenCode")]
    public required string TokenCode { get; set; }

    [JsonPropertyName("paymentMethodName")]
    public required string PaymentMethodName { get; set; }

    [JsonPropertyName("requestedAmount")]
    public required decimal RequestedAmount { get; set; }

    [JsonPropertyName("executedAmounts")]
    public required ExecutedAmounts ExecutedAmounts { get; set; }

    [JsonPropertyName("fees")]
    public Fees? Fees { get; set; }

    [JsonPropertyName("paymentReference")]
    public string? PaymentReference { get; set; }

    [JsonPropertyName("paymentCode")]
    public string? PaymentCode { get; set; }

    [JsonPropertyName("status")]
    public string? Status { get; set; }
}