using Mapster;

namespace SigmaSoftware.Service.Extensions;
public static class MapExtension
{
    public static TEntity MapToEntity<TEntity, TModel>(this TModel model)
    {
        var entity = model.Adapt<TEntity>();
        return entity;
    }
    
    public static TDto MapToDto<TEntity, TDto>(this TEntity entity)
    {
        var dto = entity.Adapt<TDto>();
        return dto;
    }

    public static List<TDto> MapToDtos<TEntity, TDto>(this List<TEntity>? entities)
    {
        if (entities is null)
            return new();

        return entities.Select(u => u.MapToDto<TEntity, TDto>()).ToList();
    }

    public static TEntity MapForUpdate<TEntity, TModel>(this TModel model, TEntity entity)
    {
        entity = model.Adapt(entity);
        return entity;
    }
}
