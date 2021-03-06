﻿// <copyright file="Complex32Test.cs" company="Math.NET">
// Math.NET Numerics, part of the Math.NET Project
// http://numerics.mathdotnet.com
// http://github.com/mathnet/mathnet-numerics
// http://mathnetnumerics.codeplex.com
// Copyright (c) 2009-2010 Math.NET
// Permission is hereby granted, free of charge, to any person
// obtaining a copy of this software and associated documentation
// files (the "Software"), to deal in the Software without
// restriction, including without limitation the rights to use,
// copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following
// conditions:
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
// OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
// WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// </copyright>

namespace MathNet.Numerics.UnitTests.ComplexTests
{
    using System;
    using System.Numerics;
    using NUnit.Framework;

    /// <summary>
    /// Complex32 tests.
    /// </summary>
    [TestFixture]
    public class Complex32Test
    {
        /// <summary>
        /// Can add a complex number and a double using operator.
        /// </summary>
        [Test]
        public void CanAddComplexNumberAndDoubleUsingOperator()
        {
            Assert.That((Complex32.NaN + float.NaN).IsNaN());
            Assert.That((float.NaN + Complex32.NaN).IsNaN());
            Assert.That((float.PositiveInfinity + Complex32.One).IsInfinity());
            Assert.That((Complex32.Infinity + 1.0f).IsInfinity());
            Assert.That((Complex32.One + 0.0f) == Complex32.One);
            Assert.That((0.0f + Complex32.One) == Complex32.One);
            Assert.That(new Complex32(1.1f, -2.2f) + 1.1f == new Complex32(2.2f, -2.2f));
            Assert.That(-2.2f + new Complex32(-1.1f, 2.2f) == new Complex32(-3.3f, 2.2f));
        }

        /// <summary>
        /// Can add/subtract complex numbers using operator.
        /// </summary>
        [Test]
        public void CanAddSubtractComplexNumbersUsingOperator()
        {
            Assert.That((Complex32.NaN - Complex32.NaN).IsNaN());
            Assert.That((Complex32.Infinity - Complex32.One).IsInfinity());
            Assert.That((Complex32.One - Complex32.Zero) == Complex32.One);
            Assert.That((new Complex32(1.1f, -2.2f) - new Complex32(1.1f, -2.2f)) == Complex32.Zero);
        }

        /// <summary>
        /// Can add two complex numbers.
        /// </summary>
        [Test]
        public void CanAddTwoComplexNumbers()
        {
            Assert.That(Complex32.NaN.Add(Complex32.NaN).IsNaN());
            Assert.That(Complex32.Infinity.Add(Complex32.One).IsInfinity());
            Assert.That(Complex32.One.Add(Complex32.Zero) == Complex32.One);
            Assert.That(new Complex32(1.1f, -2.2f).Add(new Complex32(-1.1f, 2.2f)) == Complex32.Zero);
        }

        /// <summary>
        /// Can add two complex numbers using operator.
        /// </summary>
        [Test]
        public void CanAddTwoComplexNumbersUsingOperator()
        {
            Assert.That((Complex32.NaN + Complex32.NaN).IsNaN());
            Assert.That((Complex32.Infinity + Complex32.One).IsInfinity());
            Assert.That((Complex32.One + Complex32.Zero) == Complex32.One);
            Assert.That((new Complex32(1.1f, -2.2f) + new Complex32(-1.1f, 2.2f)) == Complex32.Zero);
        }

        /// <summary>
        /// Can get hash code.
        /// </summary>
        [Test]
        public void CanCalculateHashCode()
        {
            var complex = new Complex32(1, 0);
            Assert.AreEqual(1065353216, complex.GetHashCode());
            complex = new Complex32(0, 1);
            Assert.AreEqual(-1065353216, complex.GetHashCode());
            complex = new Complex32(1, 1);
            Assert.AreEqual(-16777216, complex.GetHashCode());
        }

        /// <summary>
        /// Can compute exponential.
        /// </summary>
        /// <param name="real">Real part.</param>
        /// <param name="imag">Imaginary part.</param>
        /// <param name="expectedReal">Expected real part.</param>
        /// <param name="expectedImag">Expected imaginary part.</param>
        [TestCase(0.0f, 0.0f, 1.0f, 0.0f)]
        [TestCase(0.0f, 1.0f, 0.54030230586813977f, 0.8414709848078965f)]
        [TestCase(-1.0f, 1.0f, 0.19876611034641295f, 0.30955987565311222f)]
        [TestCase(-111.0f, 111.0f, -2.3259065941590448e-49f, -5.1181940185795617e-49f)]
        public void CanComputeExponential(float real, float imag, float expectedReal, float expectedImag)
        {
            var value = new Complex32(real, imag);
            var expected = new Complex32(expectedReal, expectedImag);
            AssertHelpers.AlmostEqual(expected, value.Exponential(), 7);
        }

        /// <summary>
        /// Can compute natural logarithm.
        /// </summary>
        /// <param name="real">Real part.</param>
        /// <param name="imag">Imaginary part.</param>
        /// <param name="expectedReal">Expected real part.</param>
        /// <param name="expectedImag">Expected imaginary part.</param>
        [Test, Sequential]
        public void CanComputeNaturalLogarithm([Values(0.0f, 0.0f, -1.0f, -111.1f, 111.1f)] float real, [Values(0.0f, 1.0f, 1.0f, 111.1f, -111.1f)] float imag, [Values(float.NegativeInfinity, 0.0f, 0.34657359027997264f, 5.0570042869255571f, 5.0570042869255571f)] float expectedReal, [Values(0.0f, 1.5707963267948966f, 2.3561944901923448f, 2.3561944901923448f, -0.78539816339744828f)] float expectedImag)
        {
            var value = new Complex32(real, imag);
            var expected = new Complex32(expectedReal, expectedImag);
            AssertHelpers.AlmostEqual(expected, value.NaturalLogarithm(), 7);
        }

        /// <summary>
        /// Can compute power.
        /// </summary>
        [Test]
        public void CanComputePower()
        {
            var a = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            var b = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(
                new Complex32(9.99998047207974718744e-1f, -1.76553541154378695012e-6f), a.Power(b), 7);
            a = new Complex32(0.0f, 1.19209289550780998537e-7f);
            b = new Complex32(0.0f, -1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(1.00000018725172576491f, 1.90048076369011843105e-6f), a.Power(b), 7);
            a = new Complex32(0.0f, -1.19209289550780998537e-7f);
            b = new Complex32(0.0f, 0.5f);
            AssertHelpers.AlmostEqual(new Complex32(-2.56488189382693049636e-1f, -2.17823120666116144959f), a.Power(b), 6);
            a = new Complex32(0.0f, 0.5f);
            b = new Complex32(0.0f, -0.5f);
            AssertHelpers.AlmostEqual(new Complex32(2.06287223508090495171f, 7.45007062179724087859e-1f), a.Power(b), 7);
            a = new Complex32(0.0f, -0.5f);
            b = new Complex32(0.0f, 1.0f);
            AssertHelpers.AlmostEqual(new Complex32(3.70040633557002510874f, -3.07370876701949232239f), a.Power(b), 7);
            a = new Complex32(0.0f, 2.0f);
            b = new Complex32(0.0f, -2.0f);
            AssertHelpers.AlmostEqual(new Complex32(4.24532146387429353891f, -2.27479427903521192648e1f), a.Power(b), 6);
            a = new Complex32(0.0f, -8.388608e6f);
            b = new Complex32(1.19209289550780998537e-7f, 0.0f);
            AssertHelpers.AlmostEqual(new Complex32(1.00000190048219620166f, -1.87253870018168043834e-7f), a.Power(b), 7);
            a = new Complex32(0.0f, 0.0f);
            b = new Complex32(0.0f, 0.0f);
            AssertHelpers.AlmostEqual(new Complex32(1.0f, 0.0f), a.Power(b), 7);
            a = new Complex32(0.0f, 0.0f);
            b = new Complex32(1.0f, 0.0f);
            AssertHelpers.AlmostEqual(new Complex32(0.0f, 0.0f), a.Power(b), 7);
            a = new Complex32(0.0f, 0.0f);
            b = new Complex32(-1.0f, 0.0f);
            AssertHelpers.AlmostEqual(new Complex32(float.PositiveInfinity, 0.0f), a.Power(b), 7);
            a = new Complex32(0.0f, 0.0f);
            b = new Complex32(-1.0f, 1.0f);
            AssertHelpers.AlmostEqual(new Complex32(float.PositiveInfinity, float.PositiveInfinity), a.Power(b), 7);
            a = new Complex32(0.0f, 0.0f);
            b = new Complex32(0.0f, 1.0f);
            Assert.That(a.Power(b).IsNaN());
        }

        /// <summary>
        /// Can compute root.
        /// </summary>
        [Test]
        public void CanComputeRoot()
        {
            var a = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            var b = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(0.0f, 0.0f), a.Root(b), 7);
            a = new Complex32(0.0f, -1.19209289550780998537e-7f);
            b = new Complex32(0.0f, 0.5f);
            AssertHelpers.AlmostEqual(new Complex32(0.038550761943650161f, 0.019526430428319544f), a.Root(b), 6);
            a = new Complex32(0.0f, 0.5f);
            b = new Complex32(0.0f, -0.5f);
            AssertHelpers.AlmostEqual(new Complex32(0.007927894711475968f, -0.042480480425152213f), a.Root(b), 6);
            a = new Complex32(0.0f, -0.5f);
            b = new Complex32(0.0f, 1.0f);
            AssertHelpers.AlmostEqual(new Complex32(0.15990905692806806f, 0.13282699942462053f), a.Root(b), 7);
            a = new Complex32(0.0f, 2.0f);
            b = new Complex32(0.0f, -2.0f);
            AssertHelpers.AlmostEqual(new Complex32(0.42882900629436788f, 0.15487175246424678f), a.Root(b), 7);
            a = new Complex32(0.0f, -8.388608e6f);
            b = new Complex32(1.19209289550780998537e-7f, 0.0f);
            AssertHelpers.AlmostEqual(new Complex32(float.PositiveInfinity, float.NegativeInfinity), a.Root(b), 7);
        }

        /// <summary>
        /// Can compute square.
        /// </summary>
        [Test]
        public void CanComputeSquare()
        {
            var complex = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(0, 2.8421709430403888e-14f), complex.Square(), 7);
            complex = new Complex32(0.0f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(-1.4210854715201944e-14f, 0.0f), complex.Square(), 7);
            complex = new Complex32(0.0f, -1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(-1.4210854715201944e-14f, 0.0f), complex.Square(), 7);
            complex = new Complex32(0.0f, 0.5f);
            AssertHelpers.AlmostEqual(new Complex32(-0.25f, 0.0f), complex.Square(), 7);
            complex = new Complex32(0.0f, -0.5f);
            AssertHelpers.AlmostEqual(new Complex32(-0.25f, 0.0f), complex.Square(), 7);
            complex = new Complex32(0.0f, -8.388608e6f);
            AssertHelpers.AlmostEqual(new Complex32(-70368744177664.0f, 0.0f), complex.Square(), 7);
        }

        /// <summary>
        /// Can compute square root.
        /// </summary>
        [Test]
        public void CanComputeSquareRoot()
        {
            var complex = new Complex32(1.19209289550780998537e-7f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(
                new Complex32(0.00037933934912842666f, 0.00015712750315077684f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(
                new Complex32(0.00024414062499999973f, 0.00024414062499999976f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, -1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(
                new Complex32(0.00024414062499999973f, -0.00024414062499999976f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, 0.5f);
            AssertHelpers.AlmostEqual(new Complex32(0.5f, 0.5f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, -0.5f);
            AssertHelpers.AlmostEqual(new Complex32(0.5f, -0.5f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, -8.388608e6f);
            AssertHelpers.AlmostEqual(new Complex32(2048.0f, -2048.0f), complex.SquareRoot(), 7);
            complex = new Complex32(8.388608e6f, 1.19209289550780998537e-7f);
            AssertHelpers.AlmostEqual(new Complex32(2896.3093757400989f, 2.0579515874459933e-11f), complex.SquareRoot(), 7);
            complex = new Complex32(0.0f, 0.0f);
            AssertHelpers.AlmostEqual(Complex32.Zero, complex.SquareRoot(), 7);
        }

        /// <summary>
        /// Can convert a double to a complex.
        /// </summary>
        [Test]
        public void CanConvertDoubleToComplex()
        {
            Assert.That(((Complex32)float.NaN).IsNaN());
            Assert.That(((Complex32)float.NegativeInfinity).IsInfinity());
            Assert.AreEqual((Complex32)1.1f, new Complex32(1.1f, 0));
        }

        /// <summary>
        /// Can create a complex number using constructor.
        /// </summary>
        [Test]
        public void CanCreateComplexNumberUsingConstructor()
        {
            var complex = new Complex32(1.1f, -2.2f);
            Assert.AreEqual(1.1f, complex.Real, "Real part is 1.1f.");
            Assert.AreEqual(-2.2f, complex.Imaginary, "Imaginary part is -2.2f.");
        }

        /// <summary>
        /// Can create a complex number with modulus argument.
        /// </summary>
        [Test]
        public void CanCreateComplexNumberWithModulusArgument()
        {
            var complex = Complex32.WithModulusArgument(2, (float)-Math.PI / 6);
            Assert.AreEqual((float)Math.Sqrt(3), complex.Real, 1e-7f, "Real part is Sqrt(3).");
            Assert.AreEqual(-1.0f, complex.Imaginary, 1e-7f, "Imaginary part is -1.");
        }

        /// <summary>
        /// Can create a complex number with real imaginary initializer.
        /// </summary>
        [Test]
        public void CanCreateComplexNumberWithRealImaginaryInitializer()
        {
            var complex = Complex32.WithRealImaginary(1.1f, -2.2f);
            Assert.AreEqual(1.1f, complex.Real, "Real part is 1.1f.");
            Assert.AreEqual(-2.2f, complex.Imaginary, "Imaginary part is -2.2f.");
        }

        /// <summary>
        /// Can determine if imaginary is unit.
        /// </summary>
        [Test]
        public void CanDetermineIfImaginaryUnit()
        {
            var complex = new Complex32(0, 1);
            Assert.IsTrue(complex.IsImaginaryOne(), "Imaginary unit");
        }

        /// <summary>
        /// Can determine if a complex is infinity.
        /// </summary>
        [Test]
        public void CanDetermineIfInfinity()
        {
            var complex = new Complex32(float.PositiveInfinity, 1);
            Assert.IsTrue(complex.IsInfinity(), "Real part is infinity.");
            complex = new Complex32(1, float.NegativeInfinity);
            Assert.IsTrue(complex.IsInfinity(), "Imaginary part is infinity.");
            complex = new Complex32(float.NegativeInfinity, float.PositiveInfinity);
            Assert.IsTrue(complex.IsInfinity(), "Both parts are infinity.");
        }

        /// <summary>
        /// Can determine if a complex is not a number.
        /// </summary>
        [Test]
        public void CanDetermineIfNaN()
        {
            var complex = new Complex32(float.NaN, 1);
            Assert.IsTrue(complex.IsNaN(), "Real part is NaN.");
            complex = new Complex32(1, float.NaN);
            Assert.IsTrue(complex.IsNaN(), "Imaginary part is NaN.");
            complex = new Complex32(float.NaN, float.NaN);
            Assert.IsTrue(complex.IsNaN(), "Both parts are NaN.");
        }

        /// <summary>
        /// Can determine Complex32 number with a value of one.
        /// </summary>
        [Test]
        public void CanDetermineIfOneValueComplexNumber()
        {
            var complex = new Complex32(1, 0);
            Assert.IsTrue(complex.IsOne(), "Complex32 number with a value of one.");
        }

        /// <summary>
        /// Can determine if a complex is a real non-negative number.
        /// </summary>
        [Test]
        public void CanDetermineIfRealNonNegativeNumber()
        {
            var complex = new Complex32(1, 0);
            Assert.IsTrue(complex.IsReal(), "Is a real non-negative number.");
        }

        /// <summary>
        /// Can determine if a complex is a real number.
        /// </summary>
        [Test]
        public void CanDetermineIfRealNumber()
        {
            var complex = new Complex32(-1, 0);
            Assert.IsTrue(complex.IsReal(), "Is a real number.");
        }

        /// <summary>
        /// Can determine if a complex is a zero number.
        /// </summary>
        [Test]
        public void CanDetermineIfZeroValueComplexNumber()
        {
            var complex = new Complex32(0, 0);
            Assert.IsTrue(complex.IsZero(), "Zero complex number.");
        }

        /// <summary>
        /// Can divide a complex number and a double using operators.
        /// </summary>
        [Test]
        public void CanDivideComplexNumberAndDoubleUsingOperators()
        {
            Assert.That((Complex32.NaN * 1.0f).IsNaN());
            Assert.AreEqual(new Complex32(-2, 2), new Complex32(4, -4) / -2);
            Assert.AreEqual(new Complex32(0.25f, 0.25f), 2 / new Complex32(4, -4));
            Assert.AreEqual(Complex32.Infinity, 2.0f / Complex32.Zero);
            Assert.AreEqual(Complex32.Infinity, Complex32.One / 0);
        }

        /// <summary>
        /// Can divide two complex numbers.
        /// </summary>
        [Test]
        public void CanDivideTwoComplexNumbers()
        {
            Assert.That(Complex32.NaN.Multiply(Complex32.One).IsNaN());
            Assert.AreEqual(new Complex32(-2, 0), new Complex32(4, -4).Divide(new Complex32(-2, 2)));
            Assert.AreEqual(Complex32.Infinity, Complex32.One.Divide(Complex32.Zero));
        }

        /// <summary>
        /// Can divide two complex numbers using operators.
        /// </summary>
        [Test]
        public void CanDivideTwoComplexNumbersUsingOperators()
        {
            Assert.That((Complex32.NaN / Complex32.One).IsNaN());
            Assert.AreEqual(new Complex32(-2, 0), new Complex32(4, -4) / new Complex32(-2, 2));
            Assert.AreEqual(Complex32.Infinity, Complex32.One / Complex32.Zero);
        }

        /// <summary>
        /// Can multiple a complex number and a double using operators.
        /// </summary>
        [Test]
        public void CanMultipleComplexNumberAndDoubleUsingOperators()
        {
            Assert.That((Complex32.NaN * 1.0f).IsNaN());
            Assert.AreEqual(new Complex32(8, -8), new Complex32(4, -4) * 2);
            Assert.AreEqual(new Complex32(8, -8), 2 * new Complex32(4, -4));
        }

        /// <summary>
        /// Can multiple two complex numbers.
        /// </summary>
        [Test]
        public void CanMultipleTwoComplexNumbers()
        {
            Assert.That(Complex32.NaN.Multiply(Complex32.One).IsNaN());
            Assert.AreEqual(new Complex32(0, 16), new Complex32(4, -4).Multiply(new Complex32(-2, 2)));
        }

        /// <summary>
        /// Can multiple two complex numbers using operators.
        /// </summary>
        [Test]
        public void CanMultipleTwoComplexNumbersUsingOperators()
        {
            Assert.That((Complex32.NaN * Complex32.One).IsNaN());
            Assert.AreEqual(new Complex32(0, 16), new Complex32(4, -4) * new Complex32(-2, 2));
        }

        /// <summary>
        /// Can negate.
        /// </summary>
        [Test]
        public void CanNegateValue()
        {
            var complex = new Complex32(1.1f, -2.2f);
            Assert.AreEqual(new Complex32(-1.1f, 2.2f), complex.Negate());
        }

        /// <summary>
        /// Can negate using operator.
        /// </summary>
        [Test]
        public void CanNegateValueUsingOperator()
        {
            var complex = new Complex32(1.1f, -2.2f);
            Assert.AreEqual(new Complex32(-1.1f, 2.2f), -complex);
        }

        /// <summary>
        /// Can subtract a complex number and a double using operator.
        /// </summary>
        [Test]
        public void CanSubtractComplexNumberAndDoubleUsingOperator()
        {
            Assert.That((Complex32.NaN - float.NaN).IsNaN());
            Assert.That((float.NaN - Complex32.NaN).IsNaN());
            Assert.That((float.PositiveInfinity - Complex32.One).IsInfinity());
            Assert.That((Complex32.Infinity - 1.0f).IsInfinity());
            Assert.That((Complex32.One - 0.0f) == Complex32.One);
            Assert.That((0.0f - Complex32.One) == -Complex32.One);
            Assert.That(new Complex32(1.1f, -2.2f) - 1.1f == new Complex32(0.0f, -2.2f));
            Assert.That(-2.2f - new Complex32(-1.1f, 2.2f) == new Complex32(-1.1f, -2.2f));
        }

        /// <summary>
        /// Can subtract two complex numbers.
        /// </summary>
        [Test]
        public void CanSubtractTwoComplexNumbers()
        {
            Assert.That(Complex32.NaN.Subtract(Complex32.NaN).IsNaN());
            Assert.That(Complex32.Infinity.Subtract(Complex32.One).IsInfinity());
            Assert.That(Complex32.One.Subtract(Complex32.Zero) == Complex32.One);
            Assert.That(new Complex32(1.1f, -2.2f).Subtract(new Complex32(1.1f, -2.2f)) == Complex32.Zero);
        }

        /// <summary>
        /// Can test for equality.
        /// </summary>
        [Test]
        public void CanTestForEquality()
        {
            Assert.AreNotEqual(Complex32.NaN, Complex32.NaN);
            Assert.AreEqual(Complex32.Infinity, Complex32.Infinity);
            Assert.AreEqual(new Complex32(1.1f, -2.2f), new Complex32(1.1f, -2.2f));
            Assert.AreNotEqual(new Complex32(-1.1f, 2.2f), new Complex32(1.1f, -2.2f));
        }

        /// <summary>
        /// Can test for equality using operators.
        /// </summary>
        [Test]
        public void CanTestForEqualityUsingOperators()
        {
            Assert.That(Complex32.NaN != Complex32.NaN);
            Assert.That(Complex32.Infinity == Complex32.Infinity);
            Assert.That(new Complex32(1.1f, -2.2f) == new Complex32(1.1f, -2.2f));
            Assert.That(new Complex32(-1.1f, 2.2f) != new Complex32(1.1f, -2.2f));
        }

        /// <summary>
        /// Can use Plus.
        /// </summary>
        [Test]
        public void CanUsePlus()
        {
            var complex = new Complex32(1.1f, -2.2f);
            Assert.AreEqual(complex, complex.Plus());
        }

        /// <summary>
        /// Can use "+" operator.
        /// </summary>
        [Test]
        public void CanUsePlusOperator()
        {
            var complex = new Complex32(1.1f, -2.2f);
            Assert.AreEqual(complex, +complex);
        }

        /// <summary>
        /// With negative modulus argument throws <c>ArgumentOutOfRangeException</c>.
        /// </summary>
        [Test]
        public void WithNegativeModulusArgumentThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => Complex32.WithModulusArgument(-1, 1), "Throws exception because modulus is negative.");
        }

        /// <summary>
        /// Can compute magnitude.
        /// </summary>
        /// <param name="real">Real part.</param>
        /// <param name="imag">Imaginary part.</param>
        /// <param name="expected">Expected value.</param>
        [Test, Sequential]
        public void CanComputeMagnitude([Values(0.0f, 0.0f, -1.0f, -111.1f)] float real, [Values(0.0f, 1.0f, 1.0f, 111.1f)] float imag, [Values(0.0f, 1.0f, 1.4142135623730951f, 157.11912677965086f)] float expected)
        {
            Assert.AreEqual(expected, new Complex32(real, imag).Magnitude);
        }

        /// <summary>
        /// Can compute sign.
        /// </summary>
        /// <param name="real">Real part.</param>
        /// <param name="imag">Imaginary part.</param>
        /// <param name="expectedReal">Expected real value.</param>
        /// <param name="expectedImag">Expected imaginary value.</param>
        [Test, Sequential]
        public void CanComputeSign([Values(float.PositiveInfinity, float.PositiveInfinity, float.NegativeInfinity, float.NegativeInfinity, 0.0f, -1.0f, -111.1f)] float real, [Values(float.PositiveInfinity, float.NegativeInfinity, float.PositiveInfinity, float.NegativeInfinity, 0.0f, 1.0f, 111.1f)] float imag, [Values((float)Constants.Sqrt1Over2, (float)Constants.Sqrt1Over2, (float)-Constants.Sqrt1Over2, (float)-Constants.Sqrt1Over2, 0.0f, -0.70710678118654746f, -0.70710678118654746f)] float expectedReal, [Values((float)Constants.Sqrt1Over2, (float)-Constants.Sqrt1Over2, (float)-Constants.Sqrt1Over2, (float)Constants.Sqrt1Over2, 0.0f, 0.70710678118654746f, 0.70710678118654746f)] float expectedImag)
        {
            Assert.AreEqual(new Complex32(expectedReal, expectedImag), new Complex32(real, imag).Sign);
        }

        /// <summary>
        /// Can convert a decimal to a complex.
        /// </summary>
        [Test]
        public void CanConvertDecimalToComplex()
        {
            var orginal = new decimal(1.234567890);
            var complex = (Complex32)orginal;
            Assert.AreEqual((float)1.234567890, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert a byte to a complex.
        /// </summary>
        [Test]
        public void CanConvertByteToComplex()
        {
            const byte Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert a short to a complex.
        /// </summary>
        [Test]
        public void CanConvertShortToComplex()
        {
            const short Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert an int to a complex.
        /// </summary>
        [Test]
        public void CanConvertIntToComplex()
        {
            const int Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert a long to a complex.
        /// </summary>
        [Test]
        public void CanConvertLongToComplex()
        {
            const long Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert an uint to a complex.
        /// </summary>
        [Test]
        public void CanConvertUIntToComplex()
        {
            const uint Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert an ulong to  complex.
        /// </summary>
        [Test]
        public void CanConvertULongToComplex()
        {
            const ulong Orginal = 123;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert a float to a complex.
        /// </summary>
        [Test]
        public void CanConvertFloatToComplex()
        {
            const float Orginal = 123.456789f;
            var complex = (Complex32)Orginal;
            Assert.AreEqual(123.456789f, complex.Real);
            Assert.AreEqual(0.0f, complex.Imaginary);
        }

        /// <summary>
        /// Can convert a complex to a complex32.
        /// </summary>
        [Test]
        public void CanConvertComplexToComplex32()
        {
            var complex32 = new Complex(123.456, -78.9);
            var complex = (Complex32)complex32;
            Assert.AreEqual(123.456f, complex.Real);
            Assert.AreEqual(-78.9f, complex.Imaginary);
        }

        /// <summary>
        /// Can conjugate.
        /// </summary>
        [Test]
        public void CanGetConjugate()
        {
            var complex = new Complex32(123.456f, -78.9f);
            var conjugate = complex.Conjugate();
            Assert.AreEqual(complex.Real, conjugate.Real);
            Assert.AreEqual(-complex.Imaginary, conjugate.Imaginary);
        }
    }
}
