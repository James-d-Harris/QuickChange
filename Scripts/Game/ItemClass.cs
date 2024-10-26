using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public class smallItem : Currency
    {
        public smallItem() : base("Small Item", 1.00) { }
    }

    public class mediumItem : Currency
    {
        public mediumItem() : base("Medium Item", 5.00) { }
    }

    public class largeItem : Currency
    {
        public largeItem() : base("Large Item", 10.00) { }
    }
}
