﻿using Nexus.SDK.Shared.Responses;
using Nexus.Token.SDK.Requests;
using Nexus.Token.SDK.Responses;

namespace Nexus.Token.SDK.Facades
{
    public class OrdersFacade : TokenServerFacade
    {
        public OrdersFacade(ITokenServerProvider provider) : base(provider)
        {
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public async Task<OrderResponse> GetOrder(string orderCode)
        {
            return await _provider.GetOrder(orderCode);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public async Task<PagedResponse<OrderResponse>> GetOrders(IDictionary<string, string>? query)
        {
            return await _provider.GetOrders(query);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderRequest"></param>
        /// <returns></returns>
        public async Task<SignableResponse> CreateOrder(OrderRequest orderRequest)
        {
            return await _provider.CreateOrder(orderRequest);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="orderCode"></param>
        /// <returns></returns>
        public async Task<SignableResponse> CancelOrder(string orderCode)
        {
            return await _provider.CancelOrder(orderCode);
        }
    }
}
