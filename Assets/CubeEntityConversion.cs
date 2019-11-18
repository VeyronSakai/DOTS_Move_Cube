using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class CubeEntityConversion : MonoBehaviour, IConvertGameObjectToEntity
{
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var data = new CubeComponentData();
        dstManager.AddComponentData(entity, data);
    }
}
