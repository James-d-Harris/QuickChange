using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemClass : MonoBehaviour
{
    public class smallItem : Currency
    {
        public smallItem() : base("Nickel", 0.05) { }
    }

    public class mediumItem : Currency
    {
        public mediumItem() : base("Quarter", 0.25) { }
    }

    public class largeItem : Currency
    {
        public largeItem() : base("One Dollar", 1.00) { }
    }
}
