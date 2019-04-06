#pragma once
class CalculationSpec
{
public:
	CalculationSpec();
	~CalculationSpec();

	double real_lower;
	double real_upper;
	int real_steps;

	double imag_lower;
	double imag_upper;
	int imag_steps;

	int max_count;
};


