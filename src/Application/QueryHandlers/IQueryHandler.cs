using Application.Queries;

namespace Application.QueryHandlers;

public interface IQueryHandler<in T, TR> where T : IQuery
{
    Task<TR> Handle(T query);
}