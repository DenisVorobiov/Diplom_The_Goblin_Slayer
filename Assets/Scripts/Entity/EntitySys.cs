using System.Collections.Generic;
using System.Linq;

public interface IEntitySystem
{
    EntityData GetData(string key);
}

public class EntitySystem : IEntitySystem
{
    public List<EntityData> _entities;

    public EntitySystem()
    {

    }

    public EntityData GetData(string key)
    {
        return _entities.FirstOrDefault(e => e.Name == key);
    }
}