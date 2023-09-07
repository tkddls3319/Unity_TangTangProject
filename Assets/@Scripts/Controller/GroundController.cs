using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

class Cell
{
    public HashSet<DropItemController> Objects { get; } = new HashSet<DropItemController>();    
}
public class GroundController : BaseController
{
    Grid _grid;
    Dictionary<Vector3Int, Cell> _cells = new Dictionary<Vector3Int, Cell>();
    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        _grid = gameObject.GetOrAddComponent<Grid>();

        return true;
    }

    public void Add(DropItemController go)
    {
        Vector3Int cellPos = _grid.WorldToCell(go.transform.position);

        Cell cell = GetCell(cellPos);
        if (cell == null)
            return;

        cell.Objects.Add(go);
    }

    public void Remove(DropItemController go)
    {
        Vector3Int cellPos = _grid.WorldToCell(go.transform.position);

        Cell cell = GetCell(cellPos);
        if (cell == null)
            return;

        cell.Objects.Remove(go);
    }

    Cell GetCell(Vector3Int cellPos)
    {
        Cell cell = null;

        if (_cells.TryGetValue(cellPos, out cell) == false)
        {
            cell = new Cell();
            _cells.Add(cellPos, cell);
        }
        return cell;
    }

    public List<DropItemController> GetObjectList(Vector3 pos, float range)
    {
        List<DropItemController> objects = new List<DropItemController>();

      	Vector3Int left = _grid.WorldToCell(pos + new Vector3(-range, 0));
		Vector3Int right = _grid.WorldToCell(pos + new Vector3(+range, 0));
		Vector3Int bottom = _grid.WorldToCell(pos + new Vector3(0, -range));
		Vector3Int top = _grid.WorldToCell(pos + new Vector3(0, +range));

		int minX = left.x;
		int maxX = right.x;
		int minY = bottom.y;
		int maxY = top.y;

		for (int x = minX; x <= maxX; x++)
		{
			for (int y = minY; y <= maxY; y++)
			{
				if (_cells.ContainsKey(new Vector3Int(x, y, 0)) == false)
					continue;

				objects.AddRange(_cells[new Vector3Int(x, y, 0)].Objects);
			}
		}

		return objects;

    }

}
