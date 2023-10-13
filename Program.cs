using System;
using System.Collections.Generic;

namespace Assignment;

// OOP is paradigm to code software as object.
public class Car
{
    readonly string Brand;
    readonly string Color;
    public Car(string brandname, string color)
    {
        this.Brand = brandname;
        this.Color = color;
    }
    public void Describe()
    {
        Console.WriteLine(Color + " " + Brand);
    }
}

// interface
public interface IPet
{
    public void Make_sound();
}

public class Cat : IPet
{
    readonly string name;
    public Cat(string name)
    {
        this.name = name;
    }
    public void Make_sound()
    {
        Console.WriteLine(name + " " + "meow.");
    }
}

public class Dog : IPet
{
    readonly string name;
    public Dog(string name)
    {
        this.name = name;
    }
    public void Make_sound()
    {
        Console.WriteLine(name + " " + "woof.");
    }
}
// polymorphism
public class Mypet
{
    List<IPet> Pets { get; set; } = new(0);

    public void Add_pet(IPet new_pet)
    {
        Pets.Add(new_pet);
    }
    public void Make_sound()
    {
        foreach (IPet Pet in Pets)
        {
            Pet.Make_sound();
        }
    }
}

// MVC pattern UI Business Logic
// Model Business logic
public class Model
{
    public double Compare(double a, double b)
    {
        if (a > b) return a;
        else return b;
    }
}

// View CLI
public class View
{
    readonly IController controller;
    public View(IController controller)
    {
        this.controller = controller;
    }
    public void CreateSurvay()
    {
        double a;
        double b;
        Console.WriteLine("Give me two numbers.");
        Console.WriteLine("First number =");
        a = this.ReadInput();
        Console.WriteLine("Last number =");
        b = this.ReadInput();
        double greater = controller.Compare(a, b);
        Console.WriteLine(greater + " has more value.");
    }
    private double ReadInput()
    {
        double result;
        string? input = Console.ReadLine();
        try
        {
            if (input is null) throw new Exception();
            result = Double.Parse(input);
        }
        catch
        {
            Console.WriteLine("Wrong data try again.");
            result = ReadInput();
        }
        return result;
    }
}

public interface IController
{
    public double Compare(double a, double b);
}
// Controller
public class Controller : IController
{
    readonly Model model;
    readonly View view;
    public Controller(Model model)
    {
        this.model = model;
        view = new View(this);
    }
    public double Compare(double a, double b)
    {
        return model.Compare(a, b);
    }
    public void CreateView()
    {
        view.CreateSurvay();
    }
}

public class Programming
{
    // if else else-if
    public void if_else_elseif(int x)
    {
        if (x > 0) Console.WriteLine("Positive.");
        else if (x == 0) Console.WriteLine("Zero.");
        else Console.WriteLine("Negative.");
        // x = 6 => Positive.
        // x = 0 => Zero.
        // x = -100 => Negative.
    }
    // for foreach
    public void for_foreach(int[] x)
    {
        // x = new int[] { 1, 2, 3 };
        for (int i = 0; i < x.Length; i++)
        {
            Console.WriteLine(x[i]);
        }
        // 1, 2, 3
        foreach (int i in x)
        {
            Console.WriteLine(i);
        }
        // 1, 2, 3
    }
    // switch
    public void switch_coding(string pet = "cat")
    {
        switch (pet)
        {
            case "cat":
                Console.WriteLine("Meow.");
                break;
            case "dog":
                Console.WriteLine("Woof.");
                break;
            default:
                Console.WriteLine("(Don't know this creature. No sound.)");
                break;
        }
        // pet = "cat" => Meow.
        // pet = "dog" => Woof.
        // pet = "etc" => (Don't know this creature. No sound.)
    }
    // while
    public void while_coding()
    {
        int x = 1;
        while (x < 10)
        {
            Console.WriteLine(x);
            x += 1;
        }
        // 1, 2, 3, 4, 5, 6, 7, 8, 9
    }
    // do-while
    public void dowhile_codig()
    {
        int x = 1;
        do
        {
            Console.WriteLine(x);
            x += 1;
        }
        while (x < 10);
        // 1, 2, 3, 4, 5, 6, 7, 8, 9
    }
}

public class Assignment
{
    static void Main()
    {
        Car mycar = new("Toyota", "Black");
        mycar.Describe();
        // Black Toyota.
        //
        Mypet mypet = new();
        Cat cat = new("cat");
        Dog dog = new("dog");
        mypet.Add_pet(cat);
        mypet.Add_pet(dog);
        mypet.Make_sound();
        // Meow.
        // Woof.

        Model model = new();
        Controller controller = new(model);
        controller.CreateView();

        Programming p = new();
        p.if_else_elseif(6);
        // Positive.
        p.if_else_elseif(0);
        // Zero.
        p.if_else_elseif(-100);
        // Negative.

        p.for_foreach(new int[] {1, 2, 3});
        // for => 1, 2, 3
        // foreach => 1, 2, 3

        p.switch_coding("cat");
        // pet = "cat" => Meow.
        p.switch_coding("dog");
        // pet = "dog" => Woof.
        p.switch_coding("etc");
        // pet = "etc" => (Don't know this creature. No sound.)

        p.while_coding();
        // 1, 2, 3, 4, 5, 6, 7, 8, 9
        p.dowhile_codig();
        // 1, 2, 3, 4, 5, 6, 7, 8, 9
    }
}
