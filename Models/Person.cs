namespace LibraryManagementSystem.Models;

abstract class Person
{
    public int Id { get; set; }
    public string Name { get; set; }

    protected Person(string name) { Name = name; }
}

class Librarian : Person
{
    public DateTime HireDate { get; set; }

    public Librarian(string name) : base(name) { }
}

sealed class LibraryMember : Person
{
    public DateTime MembershipDate { get; set; }

    public LibraryMember(string name) : base(name) { }
}

