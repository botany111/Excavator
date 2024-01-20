using UnityEngine;

public class RealtimeTerrainModification : MonoBehaviour
{
    public Terrain terrain;             // 引用地形组件
    public Vector3 modificationPosition; // 修改位置
    public float modificationRadius = 5f;  // 修改半径
    public float modificationStrength = 0.1f;  // 修改强度

    void Update()
    {
        // 在 Update 方法中实时修改地形
        ModifyTerrain();
    }

    void ModifyTerrain()
    {
        // 计算在地形高度图中的位置
        float xCoord = (modificationPosition.x - terrain.transform.position.x) / terrain.terrainData.size.x;
        float yCoord = (modificationPosition.z - terrain.transform.position.z) / terrain.terrainData.size.z;

        // 计算高度图上的坐标
        int heightmapX = Mathf.RoundToInt(xCoord * terrain.terrainData.heightmapResolution);
        int heightmapY = Mathf.RoundToInt(yCoord * terrain.terrainData.heightmapResolution);

        // 获取当前高度
        float[,] heights = terrain.terrainData.GetHeights(0, 0, terrain.terrainData.heightmapResolution, terrain.terrainData.heightmapResolution);

        // 修改高度（模拟实时修改效果）
        for (int i = heightmapX - Mathf.RoundToInt(modificationRadius); i <= heightmapX + Mathf.RoundToInt(modificationRadius); i++)
        {
            for (int j = heightmapY - Mathf.RoundToInt(modificationRadius); j <= heightmapY + Mathf.RoundToInt(modificationRadius); j++)
            {
                if (i >= 0 && i < terrain.terrainData.heightmapResolution && j >= 0 && j < terrain.terrainData.heightmapResolution)
                {
                    float currentHeight = heights[j, i];
                    float newHeight = Mathf.Clamp(currentHeight + modificationStrength * Time.deltaTime, 0f, 1f);
                    heights[j, i] = newHeight;
                }
            }
        }

        // 更新高度图
        terrain.terrainData.SetHeights(0, 0, heights);
    }
}
