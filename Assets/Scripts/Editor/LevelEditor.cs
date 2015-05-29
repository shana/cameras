using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor (typeof (Level))]
public class LevelEditor : Editor {

	const int InspectorTileSize = 48;
	const int InspectorTilePadding = 2;
	const int TileSelectedBorderSize = 1;
	const int MaxTileSize = 128;
	int selectedTile = -1;
	Level level;

	Level Level { get {
		if (level == null)
			level = target as Level;
		return level;
	}}

	public override void OnInspectorGUI ()
	{
		if (GUILayout.Toggle (selectedTile == -1, "NONE"))
			selectedTile = -1;

		if (Level.Tiles.Count > 0)
			DrawTiles();

		DrawDefaultInspector ();
	}

	void DrawTiles()
	{
		Rect rect = EditorGUILayout.GetControlRect ();
		rect.width = Screen.width - 40;
		int cols = Mathf.FloorToInt (rect.width / InspectorTileSize);
		int rows = Mathf.CeilToInt (Level.Tiles.Count / (float)cols);

		GUILayoutUtility.GetRect (cols * InspectorTileSize, rows * InspectorTileSize);
		float lastTileWidth, lastTileHeight;
		lastTileWidth = lastTileHeight = -InspectorTilePadding;
		float x, y;
		x = rect.x;
		y = rect.y;

		var inspectorWidth = rect.width;
		for (int i = 0; i < Level.Tiles.Count; i++) {
			var tile = Level.Tiles[i];

			var tileWidth = tile.rect.width * InspectorTileSize / MaxTileSize - InspectorTilePadding;
			var tileHeight = tile.rect.height * InspectorTileSize / MaxTileSize - InspectorTilePadding;
			var nextX = x + lastTileWidth + InspectorTilePadding;

			x = nextX > inspectorWidth ? rect.x : nextX;
			y += nextX > inspectorWidth ? lastTileHeight + InspectorTilePadding : 0;
			lastTileHeight = nextX > inspectorWidth ? 0 : lastTileHeight;

			Rect tileRect = new Rect (x, y, tileWidth, tileHeight);

			Texture tex = tile.texture;
			Rect uv = tile.textureRect;
			
			if (uv.width < uv.height)
				rect.width *= uv.width / uv.height;
			if (uv.height < uv.height)
				rect.width *= uv.height / uv.width;
			
			uv.width /= tex.width;
			uv.x /= tex.width;
			uv.height /= tex.height;
			uv.y /= tex.height;

			if (GUI.Button (tileRect, GUIContent.none, GUIStyle.none))
				selectedTile = i;
			
			if (selectedTile == i)
				GUI.DrawTexture (new Rect (tileRect.x - TileSelectedBorderSize, tileRect.y - TileSelectedBorderSize,
				                           tileRect.width + TileSelectedBorderSize * 2, tileRect.height + TileSelectedBorderSize * 2), EditorGUIUtility.whiteTexture);

			GUI.DrawTextureWithTexCoords (tileRect, tex, uv);
			lastTileWidth = tileRect.width;
			lastTileHeight = Mathf.Max(tileRect.height, lastTileHeight);
	}
}
}
