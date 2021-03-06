// ConsoleApplication1.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include <cstdlib>

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


int** allocate_grid(int real_steps, int imag_steps)
{
	return static_cast<int**>(malloc(sizeof(int) * real_steps * imag_steps));
}

void dispose_grid(int** grid)
{
	free(grid);
}

int** mandel_grid(
	double lower_real, double upper_real, int real_steps, 
	double lower_imag, double upper_imag, int imag_steps,
	int max_count)
{
	int** grid = allocate_grid(real_steps, imag_steps);
	double dx = (upper_real - lower_real) / real_steps;
	double dy = (upper_imag - lower_imag) / imag_steps;
	double cx, cy;
	int count = 0;
	for (int i = 0; i < real_steps; i++)
	{
		cx = lower_real + dx * i;
		for (int j =0; j < imag_steps; j++)
		{
			cy = lower_imag + dy * j;
			count = mandelbrot_count(cx, cy, max_count);
			grid[i][j] = count;
		}
	}
	return grid;
}

int main()
{
	printf("Hello World\n");
	double cx = -0.34, cy = 0.27;
	int count = mandelbrot_count(cx, cy, 1000);
	printf("Count (%lf, %lf) = %d\n", cx, cy, count);
	printf("Hit a character to quit.");
	char ch = getchar();
    return 0;
}
