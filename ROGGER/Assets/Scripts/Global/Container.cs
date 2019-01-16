using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Container : MonoBehaviour
{
    [System.Serializable]
    public class ContainerItem
    {
        public System.Guid Id;
        public string Name;
        public int Maximum;

        private int amountTaken;

        public ContainerItem()
        {
            Id = System.Guid.NewGuid();
        }

        public int Remaining
        {
            get
            {
                return Maximum - amountTaken;
            }
        }

        public int Get(int amount)
        {
            if (amountTaken + amount > Maximum)
            {
                int toMuch = (amountTaken + amount) - Maximum;
                amountTaken = Maximum;
                return amount - toMuch;
            }
            amountTaken += amount;
            return amount;
        }
    }

    List<ContainerItem> items;
    private void Awake()
    {
        items = new List<ContainerItem>();
    }

    public System.Guid Add(string name, int maximum)
    {
        items.Add(new ContainerItem
       {
           Maximum = maximum,
           Name = name
       });
        return items.Last().Id;
    }

    public int TakeFromContainer(System.Guid id, int amount)
    {
        ContainerItem containerItem = items.Where(x => x.Id == id).FirstOrDefault();
        if (containerItem == null) return -1;
        return containerItem.Get(amount);
    }
}
