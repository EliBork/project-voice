
using UnityEngine;

public class proceduralTerrain : MonoBehaviour {

	public int width = 245;
	public int length = 256;
	public int depth = 20;
	public float scale = 20f;

//sets terrain to settings on runtime
	void Start() {
		Terrain terrain = GetComponent<Terrain>();

		terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}

	TerrainData GenerateTerrain(TerrainData terrainData){
		terrainData.heightmapResolution = width + 1;
		
		terrainData.size = new Vector3(width, depth, length);

		terrainData.SetHeights(0, 0, GenerateLengths());
		return terrainData;

	}


	float[,] GenerateLengths(){
		float[,] lengths = new float[width, length];
		for(int x = 0; x < width; x++ ){

			for(int y = 0; y < length; y++){

				lengths[x,y] = CalculateLength(x, y);
			}
		}

		return lengths;
	}

	float CalculateLength(int x, int y){
		float xCoord = (float)x / width * scale;
		float yCoord = (float)y / length * scale;

		return Mathf.PerlinNoise(xCoord, yCoord);

	}
}
