﻿using System.Text.Json.Serialization;

namespace Nexus.Token.SDK.Responses;

public record AccountResponse
{
    [JsonPropertyName("customerCode")]
    public string CustomerCode { get; }

    [JsonPropertyName("accountCode")]
    public string AccountCode { get; }

    [JsonPropertyName("dcCode")]
    public string CryptoCode { get; }

    [JsonPropertyName("customerCryptoAddress")]
    public string PublicKey { get; set; }

    [JsonConstructor]
    public AccountResponse(string customerCode, string accountCode, string cryptoCode, string accountAddress)
    {
        CustomerCode = customerCode;
        AccountCode = accountCode;
        CryptoCode = cryptoCode;
        AccountAddress = accountAddress;
    }
}

public record UpdateTokenAccountResponse
{
    [JsonPropertyName("signedTransactionEnvelope")]
    public string StellarTransactionEnvelope { get; }

    [JsonPropertyName("requiredSignatures")]
    public AlgorandTransactionResponse[] AlgorandTransactions { get; }

    [JsonConstructor]
    public UpdateTokenAccountResponse(string stellarTransactionEnvelope, AlgorandTransactionResponse[] algorandTransactions)
    {
        StellarTransactionEnvelope = stellarTransactionEnvelope;
        AlgorandTransactions = algorandTransactions;
    }
}

public class AccountBalancesResponse
{
    [JsonPropertyName("balances")]
    public IEnumerable<AccountBalance> Balances { get; }

    public bool IsConnectedToToken(string tokenCode)
    {
        return Balances.Any(balance => balance.TokenCode == tokenCode);
    }

    [JsonConstructor]
    public AccountBalancesResponse(IEnumerable<AccountBalance> balances)
    {
        Balances = balances;
    }
}

public record AccountBalance
{
    [JsonPropertyName("tokenCode")]
    public string TokenCode { get; }

    [JsonPropertyName("amount")]
    public decimal Amount { get; }

    [JsonPropertyName("enabled")]
    public bool Enabled { get; }

    [JsonConstructor]
    public AccountBalance(string tokenCode, decimal amount, bool enabled)
        => (TokenCode, Amount, Enabled) = (tokenCode, amount, enabled);
}
