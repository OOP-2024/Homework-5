using Microsoft.VisualStudio.TestTools.UnitTesting;
using book;
using System;
using System.Collections.Generic;
using System.Text;

namespace book.Tests
{
    //NE SZERKESZD!!!!!!!!
    [TestClass()]
    public class BookTests
    {
        protected const string author = "J.K. Rowling";
        protected const string title = "Harry Potter";
        protected const int yearOfPublication = 2008;
        protected const int price = 3500;
        static Book book;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            book = new Book(author, title, yearOfPublication, price);
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!
        [TestMethod("A SetPrice-nak az 1000 feletti értéket érintetlenül kell hagynia!")]
        public void SetPrice_Above999_ShouldNotBeChanged()
        {
            book.SetPrice(price);
            Assert.AreEqual(price, book.GetPrice());
        }

        [TestMethod("Az IncreasePrice-nak pozitív értékre módosítania kell az árat!")]
        public void IncreasePrice_ByAPositiveValue_ShouldChangePrice()
        {
            book.SetPrice(price);
            int expectedIncreasedPrice = 4025;
            book.IncreasePrice(15);

            Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        [DataRow(0)]
        [DataRow(-10)]
        [TestMethod("Az IncreasePrice-nak nem pozitív értékre nem szabad módosítania az árat!")]
        public void IncreasePrice_By0OrNegativeValue_ShouldNotChangePrice(int priceInc)
        {
            book.SetPrice(price);
            int expectedIncreasedPrice = book.GetPrice();
            book.IncreasePrice(priceInc);

            Assert.AreEqual(expectedIncreasedPrice, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        //[DataTestMethod]
        [DataRow(1004, 1104)]
        [DataRow(1005, 1105)]
        [DataRow(1006, 1107)]        
        [TestMethod("Az IncreasePrice-nak tört eredmény esetén kerekítenie kell a matematikai szabályoknak megfelelõen!")]
        public void IncreasePrice_FractionalResult_ShouldBeRoundedAccordingToArithmeticRules(int originalPrice, int expectedPrice)
        {
            book.SetPrice(originalPrice);
            book.IncreasePrice(10);

            Assert.AreEqual(expectedPrice, book.GetPrice());
        }

        [DataRow(-1001)]
        [DataRow(-1000)]
        [DataRow(-999)]
        [DataRow(0)]
        [DataRow(999)]
        [TestMethod("Az SetPrice-nak az 1000 alatti értékeket 1000-re kell állítania")]
        public void SetPrice_Below1000_ShouldBeCorrectedTo1000(int price)
        {
            book.SetPrice(price);
            Assert.AreEqual(1000, book.GetPrice());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("Az DisplayInfo kimenetének tartalmaznia kell a címet")]
        public void DisplayInfo_ResultShouldContainTitle()
        {
            string result = book.DisplayInformation();
            Assert.IsTrue(result.Contains(title));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("Az DisplayInfo kimenetének tartalmaznia kell a szerzőt")]
        public void DisplayInfo_ResultShouldContainAuthor()
        {
            string result = book.DisplayInformation();
            Assert.IsTrue(result.Contains(author));
        }

        [TestMethod("Az DisplayInfo kimenetének tartalmaznia kell a publikáció évét")]
        public void DisplayInfo_ResultShouldContainYearOfPublication()
        {
            book.SetYearOfPublication(yearOfPublication);
            string result = book.DisplayInformation();
            Assert.IsTrue(result.Contains(yearOfPublication.ToString()));
        }

        [TestMethod("Az DisplayInfo kimenetének tartalmaznia kell az arat")]
        public void DisplayInfo_ResultShouldContainPrice()
        {
            book.SetPrice(price);
            string result = book.DisplayInformation();

            Assert.IsTrue(result.Contains(price.ToString()));
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A 2 paraméteres konstruktornak az árat 2500-ra kell állítania!")]
        public void TwoParamConstructor_ShouldSetPriceTo2500()
        {
            book = new Book(author, title);
            Assert.AreEqual(2500, book.GetPrice());
        }

        [TestMethod("A 2 paraméteres konstruktornak a megjelenés évét a jelenlegi évre kell állítania!")]
        public void TwoParamConstructor_ShouldSetYearofPublToCurrentYear()
        {
            book = new Book(author, title);
            Assert.AreEqual(DateTime.Now.Year, book.GetYearOfPublication());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [TestMethod("A ToString metódus kimenetének meg kell egyeznie a DisplayInformation kimenetével!")]
        public void ToString_ShouldReturnTheSameAsDisplayInformation()
        {
            Assert.AreEqual(book.ToString(), book.DisplayInformation());
        }

        //NE MODOSITS SEMMIT EBBEN A FILE-BAN!!!!!!!!

        [DataRow(2000, 2000, 0)]
        [DataRow(2001, 2000, 1)]
        [DataRow(2000, 2001, 2)]
        [TestMethod("Az ComparePublicationDate metódusnak 0-t kell adnia, ha a 2 évszám megegyezik, 1-et, ha az 1. nagyobb, 2-t, ha 2.!")]
        public void ComparePublicationDate_ShouldReturn0ForMatchingYears1Or2IfTheFirstOrSecondisGreater(int pubYearA, int pubYearB, int compareResult)
        {
            book.SetYearOfPublication(pubYearA);

            Book bookOther = new Book(author, title, yearOfPublication, price);

            bookOther.SetYearOfPublication(pubYearB);

            Assert.AreEqual(compareResult, Book.ComparePublicationDate(book, bookOther));
        }
    }
}