using Godot;
using System;

public partial class FloorTile : TileMapLayer
{
    [Export] private int _width = 100;
    [Export] private int _height = 100;
	private int _floorTileId = 1;
	private Vector2I[] _tileSet = new Vector2I[] {
		new Vector2I(0, 0),
		new Vector2I(0, 1), 
		new Vector2I(0, 2), 
		new Vector2I(0, 3),
		new Vector2I(0, 4),
		new Vector2I(0, 5),
	};
   	public override void _Ready()
    {
		_floorTileId = new Random().Next(0, _tileSet.Length);
        SetCells();
    }

	private void SetCells()
	{

		TileSet tileSet = GetTileSet();
		for (int x = 0; x < _width; x++)
		{
			for (int y = 0; y < _height; y++)
			{
				SetCell(new Vector2I(x, y), tileSet.GetSourceId(0), _tileSet[_floorTileId]);
			}
		}
	}


}