using Prome.Viaticos.Server.Domain._Common;
using System;

namespace Prome.Viaticos.Server.Domain.Entities.LunchAggregate
{
    public class LunchAdvice : BaseEntity
    {
        protected LunchAdvice()
        { }

        public LunchAdvice(string title, string description)
            : base()
        {
            Title = title;
            Description = description;
            AdviceDate = DateTime.Now;
        }

        public virtual Lunch Lunch { get; set; }

        public DateTime AdviceDate { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }
    }
}

