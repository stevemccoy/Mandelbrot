// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"

// Check that the modulus of the complex number is not more than 2.0
// (which indicates the calculation has diverged).
int divergent(double real, double imag)
{
	double m = real * real;
	if (m > 4.0)
	{
		return 1;
	}
	m += imag * imag;
	if (m > 4.0)
	{
		return 1;
	}
	return 0;
}

/*
Compute Mandelbrot set count for the given complex number c defined by the given real and imaginary components.
*/
int mandelbrot_count(double real, double imag, int max_count)
{
	// Initialise z <- c
	// Compute z <- z^2 + c
	// Increment count
	// If divergent, return count.
	// else go again.

	double z_real = real;
	double z_imag = imag;
	double temp_real = 0.0;
	double temp_imag = 0.0;
	int count = 0;

	while (count < max_count)
	{
		temp_real = z_real * z_real - z_imag * z_imag + real;
		temp_imag = 2 * z_real * z_imag + imag;
		count++;
		z_real = temp_real;
		z_imag = temp_imag;
		if (divergent(z_real, z_imag))
		{
			break;
		}
	}
	return count;
}


int main()
{
	printf("Hello World\n");
	double cx = -1.4, cy = 0.7;
	int count = mandelbrot_count(cx, cy, 1000);
	printf("Count (%lf, %lf) = %d\n", cx, cy, count);
	printf("Hit a character to quit.");
	char ch = getchar();
    return 0;
}

