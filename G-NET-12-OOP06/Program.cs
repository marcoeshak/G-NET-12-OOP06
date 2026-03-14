
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Reflection.Emit;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
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

        #endregion




    }
    }
}
