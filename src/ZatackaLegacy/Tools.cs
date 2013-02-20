﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Diagnostics;
using System.Windows.Input;

namespace Zatacka
{
    /// <summary>
    /// Static class for miscellaneous support methods.
    /// </summary>
    static public class Tools
    {
        /// <summary>
        /// An instance of System.Random used to generate random numbers.
        /// </summary>
        static public Random Generator = new Random();

        /// <summary>
        /// Generates a random floating-point number within the specified range.
        /// </summary>
        /// <param name="Min">Lowest possible return value.</param>
        /// <param name="Max">Highest possible return value.</param>
        /// <returns>The generated number as a double.</returns>
        static public double Random(double Min, double Max)
        {
            return Generator.NextDouble() * (Max - Min) + Min;
        }

        /// <summary>
        /// Generates an integer number within the specified range, including the lowest and highest values.
        /// </summary>
        /// <param name="Min">Lowest possible return value.</param>
        /// <param name="Max">Highest possible return value.</param>
        /// <returns>The generated integer.</returns>
        static public int Random(int Min, int Max)
        {
            return Generator.Next(Min, Max + 1);
        }

        /// <summary>
        /// Converts degrees to radians.
        /// </summary>
        /// <param name="Degrees">The degree to convert.</param>
        /// <returns>The value in radians.</returns>
        static public double DegreesToRadians(double Degrees)
        {
            return Math.PI * Degrees / 180.0;
        }

        /// <summary>
        /// Converts this double from degrees to radians.
        /// </summary>
        /// <returns>The value in radians.</returns>
        static public double ToRadians(this double Degrees)
        {
            return DegreesToRadians(Degrees);
        }

        /// <summary>
        /// Calculates the distance between two points on the 2D plane.
        /// </summary>
        /// <param name="First">The first point.</param>
        /// <param name="Second">The second point.</param>
        /// <returns>The calculated distance.</returns>
        static public double Distance(Point First, Point Second)
        {
            return Math.Sqrt(Math.Pow(First.X - Second.X, 2) + Math.Pow(First.Y - Second.Y, 2));
        }

        /// <summary>
        /// Calculates the distance between this point and another point on the 2D plane.
        /// </summary>
        /// <param name="Target">The other point.</param>
        /// <returns>The calculated distance.</returns>
        static public double DistanceFrom(this Point Source, Point Target)
        {
            return Distance(Source, Target);
        }

        /// <summary>
        /// Returns a Rect instance with this size and a default location of (0, 0).
        /// </summary>
        /// <returns>The Rect instance.</returns>
        static public Rect ToRect(this Size Size)
        {
            return new Rect(new Point(0, 0), Size);
        }

        /// <summary>
        /// Calculates and returns the center point of the rectangle.
        /// </summary>
        /// <param name="Rect"></param>
        /// <returns></returns>
        static public Point Center(this Rect Rect)
        {
            return new Point(Rect.Left + Rect.Width / 2, Rect.Top + Rect.Height / 2);
        }

        /// <summary>
        /// Returns this object casted to the specified type.
        /// </summary>
        /// <typeparam name="T">The type to cast to. Must be compatible with the type of the object or an InvalidCastException will be thrown.</typeparam>
        /// <returns>The casted object.</returns>
        static public T As<T>(this object Object)
        {
            return (T)Object;
        }

        /// <summary>
        /// Executes and measures the specified System.Action and returns its run time in milliseconds.
        /// </summary>
        /// <param name="Action">The System.Action to measure. Possible usage: new System.Action( delegate { ... } )</param>
        /// <returns>The elapsed time in milliseconds.</returns>
        static public long Measure(System.Action Action)
        {
            Stopwatch Timer = new Stopwatch();
            Timer.Start();
            Action.Invoke();
            Timer.Stop();
            return Timer.ElapsedMilliseconds;
        }

        /// <summary>
        /// Returns whether the specified keyboard button is currently pressed.
        /// </summary>
        /// <param name="Button">The keyboard button to test.</param>
        static public bool KeyboardPressed(Key Button)
        {
            return Keyboard.IsKeyDown(Button);
        }

        /// <summary>
        /// Returns whether the specified mouse button is currently pressed.
        /// </summary>
        /// <param name="Button">The mouse button to test.</param>
        static public bool MousePressed(MouseButton Button)
        {
            return Button == MouseButton.Left && Mouse.LeftButton == MouseButtonState.Pressed || Button == MouseButton.Middle && Mouse.MiddleButton == MouseButtonState.Pressed || Button == MouseButton.Right && Mouse.RightButton == MouseButtonState.Pressed || Button == MouseButton.XButton1 && Mouse.XButton1 == MouseButtonState.Pressed || Button == MouseButton.XButton2 && Mouse.XButton2 == MouseButtonState.Pressed;
        }
    }
}
