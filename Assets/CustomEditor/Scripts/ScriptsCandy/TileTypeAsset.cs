using UnityEngine;

namespace MatchThreeEngine
{
	[CreateAssetMenu(menuName = "Item/Tile")]
	public sealed class TileTypeAsset : ScriptableObject
	{
		public int id;

		public int valor;

		public Sprite sprite;
	}
}
