namespace ZooShop.Website.Home.Data.Contracts
{
    interface IEntity<TKey>
    {
        TKey Id { get; set; }
    }
}
