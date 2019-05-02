using System;
using System.Collections;
using System.Collections.Generic;

namespace Delegates
{

    public class Animal
    {
        public void Eat() => Console.WriteLine("Eat");
    }

    public class Bird : Animal
    {
        public void Fly() => Console.WriteLine("Fly");
    }

    public class Human : Animal { }

    delegate Animal ReturnAnimalDelegate();
    delegate Bird ReturnBirdDelegate();

    delegate void TakeAnimalDelegate(Animal a);
    delegate void TakeBirdDelegate(Bird b);

    class Program
    {
        public static Bird GetBird() => new Bird();
        public static Animal GetAnimal() => new Animal();

        public static void Eat(Animal a) => a.Eat();
        public static void Fly(Bird b) => b.Fly();

        static void Main(string[] args)
        {
            //delegates covariance
            Animal a = new Bird();
            //ReturnAnimalDelegate d = GetAnimal;
            ReturnAnimalDelegate d = GetBird; // covariante in its return type
            a = d();

            //not possible:
            //ReturnAnimalDelegate d2 = GetAnimal;
            //d2().Fly();
            //Bird b = new Animal();

            //Delegates contravariance
            //TakeBirdDelegate d2 = Fly;
            TakeBirdDelegate d2 = Eat;
            d2(new Bird());
            // method group to delegate conversions are contravariant
            // in their argument types

            // In summarize in the case of delegates the return type is covariant
            // and the parameters are contravariant

            //not possible:
            //TakeAnimalDelegate d3 = Fly;
            //d3(new Animal());
        }
    }
}