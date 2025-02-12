#include "Auxil.h"                           
#include <iostream>
#include <ctime>
#include <locale>

int fib(int x) {
	if ((x == 1) || (x == 0)) {
		return(x);
	}
	else {
		return(fib(x - 1) + fib(x - 2));
	}
}

#define  CYCLE  10                      

int main()
{

	double  av1 = 0, av2 = 0;
	clock_t  t1 = 0, t2 = 0,t3 = 0;

	setlocale(LC_ALL, "rus");

	auxil::start();                         
	t1 = clock();                            
	for (int i = 0; i < CYCLE; i++)
	{
		av1 += (double)auxil::iget(-100, 100);
		av2 += auxil::dget(-100, 100);        
	}
	t2 = clock();                            
	int result = fib(30);
	t3 = clock();


	std::cout << std::endl << "количество циклов:         " << CYCLE;
	std::cout << std::endl << "среднее значение (int):    " << av1 / CYCLE;
	std::cout << std::endl << "среднее значение (double): " << av2 / CYCLE;
	std::cout << std::endl << "продолжительность (у.е):   " << (t3 - t2);
	std::cout << std::endl << "                  (сек):   "
		<< ((double)(t3 - t2)) / ((double)CLOCKS_PER_SEC);
	std::cout << std::endl;
	system("pause");

	return 0;

}
