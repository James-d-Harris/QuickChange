using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the item class
public class ItemClass : MonoBehaviour
{
    // small item class
    public class smallItem : Currency
    {
        public smallItem() : base("Small Item", 4.99) { }
    }

    // medium item class
    public class mediumItem : Currency
    {
        public mediumItem() : base("Medium Item", 9.99) { }
    }

    // large item class
    public class largeItem : Currency
    {
        public largeItem() : base("Large Item", 24.99) { }
    }
}
