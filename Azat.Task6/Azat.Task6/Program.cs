using System.Collections;
using System.Collections.Generic;
using Azat.Task6;

// Задание 1
LocalFileLogger<Apple> log1 = new LocalFileLogger<Apple>();
Console.WriteLine(log1.LogInfo("info method"));
Console.WriteLine(log1.LogWarning("warning method"));
Console.WriteLine(log1.LogError("error!", new Exception()));
LocalFileLogger<Car> log2 = new LocalFileLogger<Car>();
Console.WriteLine(log2.LogInfo("info method"));
Console.WriteLine(log2.LogWarning("warning method"));
Console.WriteLine(log2.LogError("error!", new Exception()));
LocalFileLogger<Man> log3 = new LocalFileLogger<Man>();
Console.WriteLine(log3.LogInfo("info method"));
Console.WriteLine(log3.LogWarning("warning method"));
Console.WriteLine(log3.LogError("error!", new Exception()));

// Задание 2
List<Entity> entity = new List<Entity>() {
    new Entity() {Id = 1, ParentId = 0, Name = "Root entity"},
    new Entity() {Id = 2, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 3, ParentId = 1, Name = "Child of 1 entity"},
    new Entity() {Id = 4, ParentId = 2, Name = "Child of 2 entity"},
    new Entity() {Id = 5, ParentId = 4, Name = "Child of 4 entity"}
};
var diction = GEntity(entity);
string collect = "";
Console.Write(collect);
foreach (var item in diction)
{
    collect = collect+ $"\nKey = {item.Key}";
    item.Value.ForEach(x => collect = collect+  $" Value = List {{Entity {{id = {x.Id}}}}}");
    
}
Console.WriteLine(collect);

Dictionary<int, List<Entity>> GEntity(List<Entity> entity)
{

    return entity
        .GroupBy(x => x.ParentId)
        .ToDictionary(x => x.Key, y => y.ToList());

}
