using ShopDatabase.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabase.Models
{
    public class Person
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ShoppingCartCount(ShopDbContext db)
        {
                int shoppingCartCount = 0;
                foreach (var item in db.ShoppingCarts)
                {
                    if (Id == item.Client.Id)
                    {
                        shoppingCartCount++;
                    }
                }
                return shoppingCartCount;
        }


    


        public Person() { }
        public Person(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        public void PrintItems(ShopDbContext db)
        {
            Console.WriteLine(this);
            Console.WriteLine("Shopping Cart count: " + ShoppingCartCount(db));
            if (db.ShoppingCarts.Count() > 0)
                foreach (var item in db.ShoppingCarts)
                {
                    if (Id == item.Client.Id)
                        item.PrintItems(db);
                }
        }
    }
}
