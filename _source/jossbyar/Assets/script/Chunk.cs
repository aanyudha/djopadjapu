using UnityEngine;
using System.Collections;

public class Chunk : MonoBehaviour 
{
	//number of ground pieces in a chunk
	public const int CHUNK_SIZE = 1;

	public GameObject groundPrefab;

	public float WidthGroundPrefab
	{ get; private set; }

	void Awake()
	{
		//set the width of the image
		SpriteRenderer rend = groundPrefab.GetComponent<SpriteRenderer>();
		WidthGroundPrefab = rend.bounds.size.x;

		InitialiseChunk();
	}

	public void RepositionChunk(Vector3 newPosition)
	{
		transform.position = newPosition;
	}

	/* Initialise the pieces of ground that make up the chunk */
	public void InitialiseChunk()
	{
		for (int i=0; i<CHUNK_SIZE; i++)
		{
			//instantiate the object
			GameObject groundPiece = GameObject.Instantiate(groundPrefab) as GameObject;

			//set a parent 
			groundPiece.transform.parent = transform;

			Vector3 piecePosition = new Vector3(transform.position.x + i*WidthGroundPrefab, transform.position.y, transform.position.z);
			groundPiece.transform.position = piecePosition;
		}
	}

}
