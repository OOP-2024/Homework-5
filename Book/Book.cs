using System;
using System.Collections.Generic;
using System.Text;

namespace book
{
    //Egészítse ki a definiált Könyv osztályt 2 konstruktorral.
    //Az egyik konstruktornak a könyv minden adatát meg kell adni, 
    //a másiknak csak a szerzőt és a címet, az ár 2500 Ft, a megjelenés éve pedig az aktuális év.
    //Definiálja felül a ToString metódust a DisplayInformation metódus tartalmával.
    //Írjon osztályszintű összehasonlító metódust(ComparePublicationDate), 
    //amely 1-et ad vissza, ha az első paraméterként megadott könyv az újabb, 
    //2-t ha a második, és 0-t, ha ugyanabban az évben jelentek meg.

    //Értékadás előtti ellenőrzések:
    //- a megjelenés éve, ha nem 1950 és 2021 között van, legyen 2021, egyébként a megadott érték
    //- az ár legyen 1000 forint 1000-nél kisebb értékekre, egyébként a megadott érték

    //Módosítsa a Könyv osztályt használó osztályt ennek megfelelően.
    //A BookTest osztályban hozzon létre 2 könyvet (a 2 konstruktort felhasználva) és
    //jelenítse meg az adataikat a ToString metódust használva.
    //Hasonlítsa össze a két könyv megjelenési évét.

    public class Book
    {

        private string title;
        private string author;
        private int yearOfPublication;
        private int price;

        public Book(string title, string author, int yearOfPublication, int price)
        {
            this.title = title;
            this.author = author;
            this.yearOfPublication = yearOfPublication;
            this.price = price;
        }

        public Book(string title, string author)
        {
            this.title = title;
            this.author = author;
            this.price = 2500;
            this.yearOfPublication = DateTime.Now.Year;
        }

        public static int ComparePublicationDate(Book book1, Book book2)
        {
            if(book1.yearOfPublication > book2.yearOfPublication)
            {
                return 1;
            }

            else if(book1.yearOfPublication < book2.yearOfPublication)
            {
                return 2;
            }

            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return DisplayInformation();
        }

        public void SetTitle(string title)
        {
            this.title = title;
        }

        public void SetAuthor(string author)
        {
            this.author = author;
        }

        public void SetYearOfPublication(int year)
        {

            if (year < 1950 || year > 2021)
            {
                this.yearOfPublication = 2021;
            }

            this.yearOfPublication = year;
        }

        public void SetPrice(int price)
        {

            if (price < 1000)
            {
                this.price = 1000;
                return;
            }

            this.price = price;
        }

        public string GetTitle() { return this.title; }
        public string GetAuthor() { return this.author; }
        public int GetYearOfPublication() { return this.yearOfPublication; }
        public int GetPrice() { return this.price; }

        public void IncreasePrice(int percent)
        {

            if (percent <= 0)
            {
                return;
            }

            double newprice = this.price + Math.Round((this.price * (percent / 100.0)));
            int newpriceint = (int)newprice;

            SetPrice(newpriceint);
        }

        public string DisplayInformation()
        {
            return $"{title}\nSzerző: {author}\nMegjelenés éve: {yearOfPublication}\nKönyv ára: {price}";
        }

    }

}
