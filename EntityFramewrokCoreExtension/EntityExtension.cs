using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EntityFramewrokCoreExtension
{
    public static class EntityExtension
        {
            public static TEntity SupplyGuidKeyIfEmpty<TEntity>(this TEntity entity, IModel model)
            {
                var key = model.FindEntityType(typeof(TEntity)).FindPrimaryKey();
                var properties = key.Properties;
                if (properties.Count != 1) return entity;
                var prop = properties[0];
                if (prop.ClrType.UnwrapNullableType() != typeof(Guid)) return entity;
                if (Guid.Empty.Equals(prop.PropertyInfo.GetValue(entity)))
                {
                    prop.PropertyInfo.SetValue(entity, Guid.NewGuid());
                }
    
                return entity;
            }
    
            public static Type UnwrapNullableType(this Type type) => Nullable.GetUnderlyingType(type) ?? type;
        }
}