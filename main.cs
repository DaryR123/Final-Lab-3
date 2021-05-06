
using System;
using System.Collections.Generic;

class LibraryCollection {

  private  List<Patron> PatronList = new List<Patron>();
  private List<Book> BookList = new List<Book>();

  public void AddPatron(Patron patron) {
    PatronList.Add(patron);

    Console.WriteLine("Succesfully added " + patron.FirstName + " " + patron.LastName);
  }

  public void RemovePatron(Patron patron) {
    PatronList.Remove(patron);

    Console.WriteLine("Succesfully removed " + patron.FirstName + " " + patron.LastName);
  }

  public void DisplayPatronInfo() {
    foreach (Patron patron in PatronList) {
      patron.Display();
    }
  }

  public void AddToCollection(Book book) {
    BookList.Add(book);

    Console.WriteLine("Succesfully added book '" + book.Title + "'.");
  }

  public void RemoveFromCollection(Book book) {
    BookList.Remove(book);

    Console.WriteLine("Succesfully removed book '" + book.Title + "'.");
  }

  public void DisplayCollection() {
    foreach (Book book in BookList) {
      book.Display();
    }
  }

  public void ProcessRental(Patron patron) {
    foreach (Rental rental in patron.RentalCart) {
      Console.WriteLine("Succesfully processed rental for " + rental.Book.Title);
      patron.RemoveFromRentalCart(rental.Book);
    }
  }

  public void ProcessReturns(Patron patron, Book book) {
    Rental rental = patron.RentalCart.Find(r => r.Book == book);

    if (rental.DateDue < DateTime.Today) {
      patron.FineAmountDue = patron.FineAmountDue+10;
      Console.WriteLine("There is a fine of 1o dollars");
    }

    patron.RemoveFromRentalCart(book);

    this.AddToCollection(book);

    Console.WriteLine("Processed rental for " + book.Title);
  }

}

