namespace EE_SuperMarket
{
    public class ItemHolder
    {
        private string ItemIdentifier { get; }
        public int NumberOfItems { get; }
        public int CostPerItem { get; }

        public ItemHolder(string itemIdentifier, int numberOfItems, int costPerItem)
        {
            ItemIdentifier = itemIdentifier;
            NumberOfItems = numberOfItems;
            CostPerItem = costPerItem;
        }

        public override bool Equals(object obj)
        {
            var secondItem = obj as ItemHolder;

            return CostPerItem == secondItem.CostPerItem && 
                   NumberOfItems == secondItem.NumberOfItems &&
                   ItemIdentifier == secondItem.ItemIdentifier;
        }
    }
}