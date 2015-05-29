using UnityEngine;
using System.Collections.Generic;

public class Level : MonoBehaviour {

	[SerializeField]
	List<Sprite> tiles;
	public List<Sprite> Tiles { get {
			if (tiles == null)
				tiles = new List<Sprite>();
			return tiles;
		} }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
