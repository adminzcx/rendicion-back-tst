using MediatR;
using System;

namespace Prome.Viaticos.Server.Application.LunchAggregate.Restaurant.Commands.UpdateRestaurant
{
    public class UpdateRestaurantCommand : IRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public long Cuit { get; set; }

        public int BranchId { get; set; }

        public DateTime StartDate { get; set; }
    }
}
