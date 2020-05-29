using JsonApiDotNetCore.Models;

namespace JsonApiDotNetCore.Services
{
    public interface IResourceQueryService<T> : 
        IGetAllService<T>,
        IGetByIdService<T>,
        IGetRelationshipService<T>,
        IGetSecondaryService<T>,
        IResourceQueryService<T, int>
        where T : class, IIdentifiable<int>
    { }

    public interface IResourceQueryService<T, in TId> :
        IGetAllService<T, TId>,
        IGetByIdService<T, TId>,
        IGetRelationshipService<T, TId>,
        IGetSecondaryService<T, TId>
        where T : class, IIdentifiable<TId>
    { }
}
