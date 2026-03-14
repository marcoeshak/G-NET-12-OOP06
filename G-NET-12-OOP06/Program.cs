
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Timers;
using static G_NET_12_OOP06.Program;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace G_NET_12_OOP06
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region Part 1

            #region Q 01
            /*
        Abstraction:
            Abstraction is the concept of hiding complex implementation details and showing only the essential features of an object.It focuses on what an object does rather than how it does it.

        Encapsulation:
            Encapsulation is the process of wrapping data(variables) and methods(functions) together inside a class and restricting direct access to some of the object's components using access modifiers like private, public, etc.

         Difference between Abstraction and Encapsulation:

         Abstraction hides unnecessary details and shows only the required functionality.

         Encapsulation protects the data by restricting direct access and allowing it through methods.

          Real - world example:
          Consider a car .

        Abstraction: When you drive a car, you only use the steering wheel, pedals, and gear.You don't need to know how the engine or transmission works internally. The complex details are hidden from you.

         Encapsulation: Inside the car system, the engine data and operations are kept together, and you cannot directly modify them.You interact with the car through controls like the accelerator or brake, which safely manage how the internal system behaves.

         So, abstraction hides complexity, while encapsulation protects data and controls access to it.

            */
            #endregion

            #region Q 02

            /*
             
            Methods Implementation  /// 

           Abstract class: Can contain both abstract methods and methods with implementation.

          Interface: Contains only method declarations(no implementation).

          Fields / Variables

          Abstract class: Can have fields (variables).

          Interface: Cannot have instance fields.

          Constructors   ///

          Abstract class: Can have constructors.

          Interface: Cannot have constructors.

          Inheritance  ///

          Abstract class: A class can inherit from only one abstract class.

          Interface: A class can implement multiple interfaces.

          When to choose each one  ///

         Choose an abstract class when classes share common behavior or code that can be reused.

         Choose an interface when you want to define a contract that different classes must follow, even if they are not related.

            */

            #endregion

            #region Q 03
            /* 
             
            A)       //////

            No, you cannot.

            Because Appliance is an abstract class, and abstract classes cannot be instantiated.
                They are only used as base classes for other classes.
            You must create an object from a derived class
            */

            /*
             
            B)   ////////

                1)

                public abstract double PowerConsumption();   ////

               It is an abstract method.

             It has no implementation in the base class.

            Every derived class must override it.

            Reason:
            Each appliance has a different power consumption, so the base class cannot define a single implementation.


            2)

            public virtual string Status() => "Standby";    ///

            It is a virtual method.

             It has a default implementation.

             Derived classes can override it if needed.

             Reason:
              Most appliances may be Standby, but some appliances may have a different status(like WashingMachine).


            3)

            public string Label() => $"{Brand} - {PowerConsumption()}W";   ///


             It is a concrete method.

            It already has a full implementation.
    
            Derived classes do not need to override it.

            Reason:
            The same label format works for all appliances.
            */

            /*
             
            C)

            It will return:

            Standby
            Because the Toaster class does not override the Status() method, so it uses the default implementation from the Appliance class.
           
            */

            #endregion

            #region Q 04
            /*
           A)   ////
           A partial class is a class whose definition can be split across multiple files, but the compiler combines them into one class at compile time.

           Developers split a class into multiple files to:

           Organize large classes

           Separate different responsibilities

           Allow multiple developers to work on the same class

           In this example:

           Calculator.cs contains the main logic

           Calculator.Logging.cs contains the logging functionality

           */

            /*
             
            B)
             
                A partial method is a method that is declared in one part of a partial class and optionally implemented in another part.

            Example    ///

            partial void OnCalculated(double result);

             If the implementation in Calculator.Logging.cs is deleted, the code will still compile.

             This is because partial methods are optional, and if they are not implemented, the compiler removes the method call completely.
           
            */

            /*
             
            C)

            An extension method allows you to add new methods to an existing class without modifying the original class.

            Example:   ///

            public static string ToCurrency(this double value)
            Rules for extension methods:

            The method must be inside a static class.

            The method itself must be static.

            The first parameter must use the this keyword to specify the type being extended.

            */

            /*
             
            D)

                     Add(19.5, 0.5)    ///  1
                    Result = 20  ///

                OnCalculated() runs and prints:  // 2
                Log: result = 20   //

                ToCurrency() formats the result as currency   /// 3
                    $20.00   //

                Final Output
                Log: result = 20
                $20.00
                
                */

            #endregion

            #endregion

            #region Part 2

            /*
             
            //  Ticket.cs 
            // Base abstract class for all ticket types
            public abstract class Ticket
            {
            public int Id { get; }
            public string Movie { get; }
            public double Price { get; }
            public bool IsBooked { get; private set; }

            protected Ticket(int id, string movie, double price)
            {
                Id = id;
                Movie = movie;
                Price = price;
            }

            // Abstract method → must be implemented differently by each ticket type
            public abstract double CalculateFinalPrice();

            // Virtual method → can be overridden optionally
            public virtual string Category()
            {
                return "General";
            }

            // Concrete methods → shared across all tickets
            public void Book() => IsBooked = true;
            public void Cancel() => IsBooked = false;
             }

             //  StandardTicket.cs 
             public class StandardTicket : Ticket
                {
            public string Seat { get; }

            public StandardTicket(int id, string movie, double price, string seat)
                : base(id, movie, price)
            {
                Seat = seat;
            }

            public override double CalculateFinalPrice() => Price * 1.14;

            public override string Category() => "Standard";
              }

              //  VIPTicket.cs 
             public class VIPTicket : Ticket
            {
            public bool LoungeAccess { get; }
            public double Fee { get; }

            public VIPTicket(int id, string movie, double price, bool loungeAccess, double fee)
                : base(id, movie, price)
            {
                LoungeAccess = loungeAccess;
                Fee = fee;
            }

            public override double CalculateFinalPrice() => (Price + Fee) * 1.14;

            public override string Category() => "VIP";
             }

             //  IMAXTicket.cs 
             public class IMAXTicket : Ticket
             {
            public bool Is3D { get; }

            public IMAXTicket(int id, string movie, double price, bool is3D)
                : base(id, movie, price)
            {
                Is3D = is3D;
            }

            public override double CalculateFinalPrice() => Price * 1.14;

            public override string Category() => "IMAX";
             }

            //  Cinema.Tickets.cs 
            using System;
            using System.Collections.Generic;

            public partial class Cinema
               {
            private List<Ticket> tickets = new List<Ticket>();

            public void AddTicket(Ticket ticket) => tickets.Add(ticket);

            public Ticket[] GetTickets() => tickets.ToArray();

            public void OpenCinema()
            {
            Console.WriteLine("=== Cinema Opened ===");
            Console.WriteLine("Projector ON\n");
            }

             public void CloseCinema()
            {
            Console.WriteLine("\nProjector OFF");
            Console.WriteLine("=== Cinema Closed ===");
             }
            }

            //  Cinema.Reporting.cs 
            using System;

            public partial class Cinema
                {
              public void PrintAllTickets()
             {
             Console.WriteLine("--- All Tickets (from Cinema.Reporting) ---");

            foreach (var t in tickets)
            {
                Console.WriteLine(
                    $"[Ticket #{t.Id}] {t.Movie} | {t.Category()} | " +
                    $"Price: {t.Price} | Final: {t.CalculateFinalPrice():F2} | " +
                    $"Booked: {(t.IsBooked ? "Yes" : "No")}"
                );
            }

            Console.WriteLine();
                 }
             }

            //  TicketExtensions.cs 
            using System;
            using System.Linq;

            public static class TicketExtensions
               {
           // Generate formatted receipt for a single ticket
          public static string GenerateReceipt(this Ticket ticket)
              {
            return
               $@"========== RECEIPT ==========
             Movie    : {ticket.Movie}
             Type     : {ticket.GetType().Name}
             Price    : {ticket.Price}
              Final    : {ticket.CalculateFinalPrice():F2}
              Status   : {(ticket.IsBooked ? "Booked" : "Not Booked")}
                =============================";
               }

              // Calculate total revenue from an array of tickets
            public static double TotalRevenue(this Ticket[] tickets) => tickets.Sum(t => t.CalculateFinalPrice());
                 }

            //  Program.cs 
            using System;

            class Program
              {
           static void Main()
           {
             Cinema cinema = new Cinema();
             cinema.OpenCinema();

            // Ticket t = new Ticket(0, "Test", 100); // ERROR: Cannot create instance of abstract class

            Ticket t1 = new StandardTicket(1, "Inception", 80, "A5");
            Ticket t2 = new VIPTicket(2, "Avengers", 200, true, 50);
            Ticket t3 = new IMAXTicket(3, "Dune", 130, true);

            t1.Book();
            t2.Book();
            t3.Book();

            cinema.AddTicket(t1);
            cinema.AddTicket(t2);
            cinema.AddTicket(t3);

            cinema.PrintAllTickets();

            Console.WriteLine("--- Polymorphism: Final Price per Ticket ---");
            Ticket[] tickets = { t1, t2, t3 };
            foreach (var t in tickets)
                Console.WriteLine($"{t.GetType().Name} => Final Price: {t.CalculateFinalPrice():F2}");

            Console.WriteLine("\n--- Extension Method: Receipt ---");
            Console.WriteLine(t2.GenerateReceipt());

            Console.WriteLine("\n--- Extension Method: Total Revenue ---");
            Console.WriteLine($"Total Revenue: {tickets.TotalRevenue():F2}");

            cinema.CloseCinema();
                 }
                }

               */
            #endregion


       }
    }
}
