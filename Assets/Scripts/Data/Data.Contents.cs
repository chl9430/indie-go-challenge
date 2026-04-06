using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Data
{
    #region Item
    public enum ItemType
    {
		Weapon,
		Armor
    }

    [Serializable]
	public class ItemData
    {
		public int id;
		public string name;
		public ItemType itemType;
	}

	[Serializable]
	public class WeaponData : ItemData
	{
		public int attack;
	}

	[Serializable]
	public class ArmorData : ItemData
	{
        public int defense;
    }


	[Serializable]
	public class ItemLoader : ILoader<int, ItemData>
	{
		public List<WeaponData> weapons = new List<WeaponData>();
		public List<ArmorData> armors = new List<ArmorData>();

		public Dictionary<int, ItemData> MakeDict()
		{
            Dictionary<int, ItemData> dict = new Dictionary<int, ItemData>();
            foreach (ItemData item in weapons)
            {
                item.itemType = ItemType.Weapon;
                dict.Add(item.id, item);
            }
            foreach (ItemData item in armors)
            {
                item.itemType = ItemType.Armor;
                dict.Add(item.id, item);
            }
            return dict;
        }
	}
	#endregion

	#region Monster

	[Serializable]
	public class MonsterData
	{
		public int id;
		public string name;
	}

	[Serializable]
	public class MonsterLoader : ILoader<int, MonsterData>
	{
		public List<MonsterData> monsters = new List<MonsterData>();

		public Dictionary<int, MonsterData> MakeDict()
		{
			Dictionary<int, MonsterData> dict = new Dictionary<int, MonsterData>();
            foreach (MonsterData monster in monsters)
            {
                dict.Add(monster.id, monster);
            }
            return dict;
		}
	}

	#endregion
}