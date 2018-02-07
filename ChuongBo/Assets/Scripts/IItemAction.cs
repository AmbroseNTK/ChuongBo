using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


interface IItemAction
{
    /// <summary>
    /// Define how to show your Item
    /// </summary>
    void Show();
    /// <summary>
    /// How to open this item
    /// </summary>
    void Open();
    /// <summary>
    /// How to use this item
    /// </summary>
    void Use();
}