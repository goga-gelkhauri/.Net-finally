using MediatR;
using Web.ViewModels;
using System.Collections.Generic;

namespace Web.Features.MyOrders
{
    public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
    {
        public string UserName { get; set; }

        public GetMyOrders(string userName)
        {
            UserName = userName;
        }
    }
}
