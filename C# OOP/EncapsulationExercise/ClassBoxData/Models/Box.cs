﻿using System;
using System.Text;
using ClassBoxData.Exceptions;

namespace ClassBoxData.Models
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if(value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.LengthZeroOrNegativeException);
                }
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.WidthZeroOrNegativeException);
                }
                this.width = value;
            }
        }
        public double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.HeightZeroOrNegativeException);
                }
                this.height = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 2 * this.Length * this.Width + 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            double lateralSurfaceArea = 2 * this.Length * this.Height + 2 * this.Width * this.Height;
            return lateralSurfaceArea;
        }
        public double Volume()
        {
            double volume = this.Length * this.Width * this.Height;
            return volume;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Surface Area - {this.SurfaceArea():f2}");
            result.AppendLine($"Lateral Surface Area - {this.LateralSurfaceArea():f2}");
            result.AppendLine($"Volume - {this.Volume():f2}");

            return result.ToString().TrimEnd();
        }
    }
}