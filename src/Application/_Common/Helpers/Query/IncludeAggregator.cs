﻿using Prome.Viaticos.Server.Application._Common.Interfaces;
using Prome.Viaticos.Server.Application.Common.Helpers.Query;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Prome.Viaticos.Server.Application._Common.Helpers.Query
{


    public class IncludeAggregator<TEntity>
    {
        public IncludeQuery<TEntity, TProperty> Include<TProperty>(Expression<Func<TEntity, TProperty>> selector)
        {
            var visitor = new IncludeVisitor();
            visitor.Visit(selector);

            var pathMap = new Dictionary<IIncludeQuery, string>();
            var query = new IncludeQuery<TEntity, TProperty>(pathMap);

            if (!string.IsNullOrEmpty(visitor.Path))
            {
                pathMap[query] = visitor.Path;
            }

            return query;
        }
    }
}
