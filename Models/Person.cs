namespace FunctionalProgramming.Models;
public class Person {
    public Person() {
        this.Name = "";
        this.Products = "";
    }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Products { get; set; }
}