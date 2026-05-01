using System;
public abstract class Item
{
    public string Title { get; set; }
    public int Article { get; set; }
    public int Count { get; set; }
    public DateTime DeliveredAt { get; set; }
    public DateTime ExpirationDate { get; set; }
    public float Price { get; set; }
    public int Category { get; set; }

    // Залишаємо цю властивість для зручного розрізнення типів при читанні з файлу
    public abstract string ItemType { get; }

    protected Item(string title, int article, int count, DateTime deliveredAt, DateTime expirationDate, float price, int category)
    {
        Title = title;
        Article = article;
        Count = count;
        DeliveredAt = deliveredAt;
        ExpirationDate = expirationDate;
        Price = price;
        Category = category;
    }
    public virtual float CalculateRemainItemsPrice()
    {
        return Count * Price;
    }
}
public class HomelandItem : Item
{
    public override string ItemType => "Homeland";

    public HomelandItem(string title, int article, int count, DateTime deliveredAt, DateTime expirationDate, float price, int category) 
        : base(title, article, count, deliveredAt, expirationDate, price, category)
    {
    }

    public override float CalculateRemainItemsPrice()
    {
        return Count * Price; 
    }
}
public class ImportItem : Item
{
    public override string ItemType => "Import";
    
    public string ProducerCountry { get; set; }

    public ImportItem(string title, string producerCountry, int article, int count, DateTime deliveredAt, DateTime expirationDate, float price, int category) 
        : base(title, article, count, deliveredAt, expirationDate, price, category)
    {
        ProducerCountry = producerCountry;
    }

    public float CountPriceWithDelivery()
    {
        return Price * 1.05f; 
    }

    public override float CalculateRemainItemsPrice()
    {
        return Count * CountPriceWithDelivery();
    }
}