using System.Collections.Generic;

public class ItemData {
    public int ID { get; set; }
    public ItemProperties ItemProperties { get; set; }
}

public class ItemProperties
{

    public string Name { get; set; }
    public string Type { get; set; }
    public string SlotType { get; set; }
    public string SpriteName { get; set; }
    public float Damage { get; set; }
    public float KnockBack { get; set; }
    public float XScale { get; set; }
    public float YScale { get; set; }
    public float Cooldown { get; set; }
    public float LastingAttack { get; set; }
    public ItemPolygonPath ItemPolygonPath { get; set; }
}

public class ItemPolygonPath
{
    public List<ItemVector2D> ItemVector2D { get; set; }
}

public class ItemVector2D
{
    public float X { get; set; }
    public float Y { get; set; }
}



//Name, Type, Slot Type, Sprite filename without file extension, Weapon Damage(Optional), Close Weapon X Scale(Optional),
//Close Weapon Y Scale(Optional), Cooldown, LastingAttack, PolygonPath(Optional)
//{ 4, new string[] { "Bow", "RangeWeapon", "Single", "bow", "15", "30", "10" }},