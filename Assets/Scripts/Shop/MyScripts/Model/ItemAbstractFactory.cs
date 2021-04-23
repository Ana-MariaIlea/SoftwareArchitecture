using System.Collections;
using System.Collections.Generic;

public abstract class ItemAbstractFactory 
{
    public abstract MyItem MakeItem();

    public MyItem GetObject() 
    {
        return this.MakeItem();
    }
}
