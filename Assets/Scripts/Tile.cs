using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour {

	[SerializeField]
	Sprite sprite;
	public Sprite Sprite { get { return sprite; } }

	[SerializeField]
	int width;
	public int Width { get { return width; } }

	[SerializeField]
	int height;
	public int Height { get { return height; } }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
