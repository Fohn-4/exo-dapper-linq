using PeopleDapperExercice;

string connectionString = "Server=localhost;Database=testdb;Uid=root;Pwd=root;";
DapperRepo repo = new DapperRepo(connectionString);

//add david
repo.AddPerson( new Person { Name = "David", Age = 22 });

//Get all poelpe
foreach( var p in repo.GetAll())
{
    Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Age: {p.Age}");
}

//Get by id
Person found = repo.GetbyId(1);
Console.WriteLine($"Found: {found.Name}, {found.Age}");

found.Age = 35;
repo.UpdatePerson(found);
Console.WriteLine($"{found.Name} is now {found.Age}");

repo.DeletePerson(4);
